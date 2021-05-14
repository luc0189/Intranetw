using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using System.Data;

namespace Intranet.Vista
{
    public partial class Kardex : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                             
                llenaarticulos();
                llenaubicacion();
               
            }
        }
        
        public void llenaarticulos()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosseriales = Controlasql.listaserial(bd);

                if (registrosseriales.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrosseriales.Tables[0];
                    Selectarticulotranslado.Items.Clear();
                    Selectarticulo_consumo.Items.Clear();
                    Selectarticulo_entrada.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectarticulo_entrada.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectarticulo_consumo.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectarticulotranslado.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectarticulo_entrada.DataBind();
                        Selectarticulo_consumo.DataBind();
                        Selectarticulotranslado.DataBind();
                    }



                }
                else
                {
                    Selectarticulo_entrada.DataSource = null;
                    Selectarticulo_consumo.DataSource = null;
                    Selectarticulotranslado.DataSource = null;
                    Selectarticulo_entrada.DataBind();
                    Selectarticulo_consumo.DataBind();
                    Selectarticulotranslado.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }


        }
      
        public void llenaubicacion()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosubicacion = Controlasql.Clistaubicacion(bd);

                if (registrosubicacion.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrosubicacion.Tables[0];
                    selectbodega_entrada.Items.Clear();
                    selectbodega_entrada_trans.Items.Clear();
                    selectbodega_salida_trans.Items.Clear();
                    selectbodega_consumo.Items.Clear();
                    
                    foreach (DataRow row in dt.Rows)
                    {
                        selectbodega_entrada.Items.Add(Convert.ToString(row["Nombre"]));
                        selectbodega_entrada_trans.Items.Add(Convert.ToString(row["Nombre"]));
                        selectbodega_salida_trans.Items.Add(Convert.ToString(row["Nombre"]));
                        selectbodega_consumo.Items.Add(Convert.ToString(row["Nombre"]));
                        selectbodega_entrada.DataBind();
                        selectbodega_entrada_trans.DataBind();
                        selectbodega_salida_trans.DataBind();
                        selectbodega_consumo.DataBind();
                    }



                }
                else
                {
                    selectbodega_entrada.DataSource = null;
                    selectbodega_entrada_trans.DataSource = null;
                    selectbodega_salida_trans.DataSource = null;
                    selectbodega_consumo.DataSource = null;
                    selectbodega_entrada.DataBind();
                    selectbodega_entrada_trans.DataBind();
                    selectbodega_salida_trans.DataBind();
                    selectbodega_consumo.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);

            }

        }
       
        public void Listarsaldos(string serial)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros16 = Controlasql.listasaldos(serial,bd);

                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridsaldos.DataSource = registros16;
                    Gridsaldos.DataBind();
                }
                else
                {
                    Gridsaldos.DataSource = null;
                    Gridsaldos.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }

        }
       
       
        protected void CreaUbicacion_Click(object sender, EventArgs e)
        {

            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.CcreaUbicacion(TextUbicacion.Value.ToUpper(), Session["USUARIO"].ToString(),bd);
                if (registros > 0)
                {
                    llenaubicacion();
                    selectbodega_entrada.Focus();
                    alerta.MessageBox(this, "Registro Completado");
                }
                else
                {
                    alerta.MessageBox(this, "Verifique la informacion e intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }


        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                Double datoentrada = Convert.ToDouble(cantEntrada.Value);
                if (fecha_entrada.Value == "")
                {
                   
                    alerta.MessageBox(this, "Ingrese una Fecha valida");
                    fecha_entrada.Focus();
                }
                else if (selectbodega_entrada.Value == "")
                {
                    alerta.MessageBox(this, "Seleccione una Bodega de entrada");
                    selectbodega_entrada.Focus();
                }
                else if (cantEntrada.Value == "")
                {
                    alerta.MessageBox(this, "Ingrese una cantidad" );
                    cantEntrada.Focus();
                }
                else if (datoentrada >= 1 & cantEntrada.Value != "" & selectbodega_entrada.Value != "" & fecha_entrada.Value != "")//ingreso 
                {
                    string[] palabra = Selectarticulo_entrada.Value.Split('/');
                    string seria = palabra[0];
                    try
                    {
                        String bd = Session["BD"].ToString();
                        var registros3 = Controlasql.Ccreaentradakardex(seria, cantEntrada.Value, "0", txtObserva.Value.ToUpper(), Session["USUARIO"].ToString(), selectbodega_entrada.Value, fecha_entrada.Value,bd);
                        if (registros3 > 0)
                        {
                          
                            alerta.MessageBox(this, "Registro completado");
                            Listarsaldos(seria);
                            fecha_entrada.Value = "";
                            cantEntrada.Value = "";
                            txtObserva.Value = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        alerta.MessageBox(this, "Excepcion controlada:"+ex.Message);
                    }

                }

                else
                {
                    alerta.MessageBox(this, "Verifique los Datos e intente nuevamente");
                   
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);

            }
            
          
            }

        protected void btntranslado_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                Double dato = Convert.ToDouble(cant_translado.Value);
                if (selectbodega_salida_trans.Value == "")
                {
                    alerta.MessageBox(this, "Seleccione un Bodega de Salida");
                    selectbodega_salida_trans.Focus();
                }
                else if (selectbodega_entrada_trans.Value == "")
                {
                    alerta.MessageBox(this, "Seleccione una Bodega de Entrada");
                    selectbodega_entrada_trans.Focus();
                }
                else if (fecha_translados.Value == "")
                {
                    alerta.MessageBox(this, "Ingrese la Fecha");
                    fecha_translados.Focus();
                }
                else if (dato > 0 & selectbodega_salida_trans.Value!="" & selectbodega_entrada_trans.Value!="" & fecha_translados.Value!="")
                {
                    string[] palabra = Selectarticulotranslado.Value.Split('/');
                    string seria = palabra[0];
                    try
                    {
                        try
                        {
                            var registros3 = Controlasql.Ccreaentradakardex(seria, "0", cant_translado.Value,
                            detalle_translado.Value.ToUpper(), Session["USUARIO"].ToString(),
                            selectbodega_salida_trans.Value, fecha_translados.Value, bd);
                        }
                        catch (Exception exp)
                        {
                            alerta.MessageBox(this, "Excepcion controlada:" + exp.Message);

                        }
                        try
                        {
                            var registros2 = Controlasql.Ccreaentradakardex(seria, cant_translado.Value, "0",
                                                        detalle_translado.Value.ToUpper(), Session["USUARIO"].ToString(),
                                                        selectbodega_entrada_trans.Value, fecha_translados.Value, bd);
                            alerta.MessageBox(this, "Registro Completado");
                            Listarsaldos(seria);
                            fecha_translados.Value = "";
                            cant_translado.Value = "";
                            detalle_translado.Value = "";
                        }
                        catch (Exception exp)
                        {
                            alerta.MessageBox(this, "Excepcion controlada:" + exp.Message);
                        }


                    }
                    finally
                    {

                    }

                }
                else
                {
                    alerta.MessageBox(this, "Verifique los datos suministrados");
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }
           
            
        }
        protected void btnagregaconsumo_Click(object sender, EventArgs e)
        {
            try
            {
                Double dato = Convert.ToDouble(cant_consumo.Value);
                if (selectbodega_consumo.Value == "")
                {
                    alerta.MessageBox(this, "Seleccione una Bodega de Consumo");
                    selectbodega_consumo.Focus();
                }
                else if (fecha_consumo.Value == "")
                {
                    alerta.MessageBox(this, "Ingrese una Fecha valida" );
                    fecha_consumo.Focus();
                }
                else if (dato > 0 & selectbodega_consumo.Value!="" & fecha_consumo.Value!="")
                {
                    string[] palabra = Selectarticulo_consumo.Value.Split('/');
                    string seria = palabra[0];
                    try
                    {
                        var registros2 = Controlasql.Ccreaentradakardex(seria, "0", cant_consumo.Value,
                       detalle_consumo.Value.ToUpper(), Session["USUARIO"].ToString(),
                       selectbodega_consumo.Value, fecha_consumo.Value, Session["BD"].ToString());
                        Listarsaldos(seria);
                        fecha_consumo.Value = "";
                        cant_consumo.Value = "";
                        detalle_consumo.Value = "";
                    }
                    catch (Exception ex)
                    {
                        alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
                        Listarsaldos(seria);
                    }
                   
                              

                }
                else
                {
                    alerta.MessageBox(this, "Verifique la informacion e intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }
           
        }
    }
}