using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Aprova_Manteni : System.Web.UI.Page
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                consultaasignados();
                llenaselectproveedor();
                llenaselectactivos();
                Selectarticulodiv.Visible = false;
                table = new System.Data.DataTable();
                table.Columns.Add("Serial_Nombre", typeof(System.String));
                table.Columns.Add("Tipo_Mant", typeof(System.String));
                table.Columns.Add("Detalle", typeof(System.String));
                table.Columns.Add("Repuesto", typeof(System.String));
                table.Columns.Add("Garantia", typeof(System.String));
                
                Session.Add("Tabla", table);
                Selectarticulo.Value = "- /";
                idactual();
                view_detalles.Visible = false;
            }
        }
        public void idactual()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registro_maxid = Controlasql.Cmaxid_mantenimientos(bd);

                if (registro_maxid.Tables[0].Rows.Count > 0)
                {
                    DataTable dtordenes = registro_maxid.Tables[0];
                    
                    foreach (DataRow row in dtordenes.Rows)
                    {
                        txtnumeromanteni.Value=(Convert.ToString(row["id"]));
                       
                    }



                }
                else
                {

                    string script = @"<script type='text/javascript'>
                            alert('Error en obtener el Id del Documento');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            catch (Exception)
            {


            }
        }
        public void consultaasignados()
        {
            if (Session["perfilnombre"].ToString().Equals("ADMINISTRADOR") || Session["perfilnombre"].ToString().Equals("LIDER PUNTO DE VENTA"))
            {
                try
                {
                    String bd = Session["BD"].ToString();
                    var registro_ordenes = Controlasql.Cllenaselectasig_admon(bd);

                    if (registro_ordenes.Tables[0].Rows.Count > 0)
                    {
                        DataTable dtordenes = registro_ordenes.Tables[0];
                        GridView_Ord_Work.DataSource = registro_ordenes;
                        GridView_Ord_Work.DataBind();
                    }
                    else
                    {
                        GridView_Ord_Work.DataSource = null;
                        GridView_Ord_Work.DataBind();
                    }
                }
                catch (Exception)
                {


                }
            }
           
           
        }
        public void llenaselectproveedor()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registro_proveedores = Controlasql.ClistaPROVEEDORES(bd);

                if (registro_proveedores.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_noadmin = registro_proveedores.Tables[0];
                    Selectproveedor.Items.Clear();
                    foreach (DataRow row in dt_noadmin.Rows)
                    {
                        Selectproveedor.Items.Add(Convert.ToString(row["nomb"]));
                        Selectproveedor.DataBind();
                    }



                }
                else
                {
                    Selectproveedor.DataSource = null;
                    Selectproveedor.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }

        public void llenaselectactivos()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registro_activos = Controlasql.listaserial(bd);

                if (registro_activos.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_noadmin = registro_activos.Tables[0];
                    Selectarticulo.Items.Clear();
                    foreach (DataRow row in dt_noadmin.Rows)
                    {
                        Selectarticulo.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectarticulo.DataBind();
                    }



                }
                else
                {
                    Selectarticulo.DataSource = null;
                    Selectarticulo.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }
        protected void btnselectelectrico_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "ELECTRICO";
            Selectarticulodiv.Visible = false;

        }
         protected void btnobracivil_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "OBRA CIVIL";
            Selectarticulodiv.Visible = false;
        }

        protected void btnornamentacion_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "ORNAMENTACION";
            Selectarticulodiv.Visible = false;
        }

        protected void btnPintura_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "PINTURA";
            Selectarticulodiv.Visible = false;
        }

        protected void btnactivosfijos_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "ACTIVOS FIJOS";
            Selectarticulodiv.Visible = true;
        }

      
    

        protected void btnguardar_Click(object sender, EventArgs e)//CREA APROBACION DE ASIGNACION
        {
            DataTable dt = Session["Tabla"] as DataTable;
            if (Txtfechamantenimiento.Value == "")
            {
                string script = @"<script type='text/javascript'>
                            alert('Ingrese la Fecha de Mantenimiento');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }
            else
            {
                
                if (clasetrabajo.Value != "ACTIVOS FIJOS")//este es para cuando no tiene que ver con activos fijos
                {
                    string ORDEN = OBSERVACIONG.Value;// TENER EN CUENTA PARA QUITARLO DE AQUI CON EL ID DE LA TABLA DE ORDENES DE  TRABAJO
                   
                    string idasigna = txtnumeroAsg.Value;
                    string IDORDEN = txtnumeroOrden.Value;
                    try
                    {
                        var registrosapruebaasig = Controlasql.ccreaaprueba_asignac(txtnumeromanteni.Value,
                            Selectproveedor.Value, OBSERVACIONG.Value, Txtfechamantenimiento.Value,
                            Session["USUARIO"].ToString(),idasigna,IDORDEN, Session["BD"].ToString());
                        if (registrosapruebaasig > 0)
                        {
                           
                                string claseMant = clasetrabajo.Value;
                                string tipoMant = SelecttipoMant.Value;
                                string detalleobserva = OBSERVACIONG.Value;//Page.Server.HtmlDecode

                            string repuesto = txtRepuestos.Value.ToUpper();
                                string garantia = Textgarantia.Value;

                                try
                                {
                                    var registrodetallesmante = Controlasql.ccreadetallesaprobacion(txtnumeromanteni.Value,
                                    repuesto, detalleobserva, tipoMant, claseMant, garantia, Session["BD"].ToString());

                                }
                                catch (Exception expc)
                                {

                                    throw expc;
                                }
                                
                       

                        }
                        string script = @"<script type='text/javascript'>
                            alert('Guardado con exito');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                    catch (Exception ex)
                    {

                        alerta.MessageBox(this,ex.Message);
                    }

                }
                if (clasetrabajo.Value == "ACTIVOS FIJOS")
                {
                    string ORDEN = OBSERVACIONG.Value;// TENER EN CUENTA PARA QUITARLO DE AQUI CON EL ID DE LA TABLA DE ORDENES DE  TRABAJO

                    string idasigna = txtnumeroAsg.Value;
                    string IDORDEN = txtnumeroOrden.Value;
                    try
                    {
                        var registrosapruebaasig = Controlasql.ccreaaprueba_asignac(txtnumeromanteni.Value,
                            Selectproveedor.Value, OBSERVACIONG.Value, Txtfechamantenimiento.Value, 
                            Session["USUARIO"].ToString(), idasigna, IDORDEN, Session["BD"].ToString());
                        if (registrosapruebaasig > 0)
                        {
                          
                                string serialtemp = Selectarticulo.Value;
                                string tipoMant = SelecttipoMant.Value;
                                string detalleobserva = OBSERVACIONG.Value;
                                string respuesto = txtRepuestos.Value;
                                string garantia = Textgarantia.Value;
                                string[] palabras = serialtemp.Split('/');
                                string serial = palabras[0];
                                string nombrearticulo = palabras[1];
                                try
                                {
                                    var egistrodetallesmante = Controlasql.ccreadetallesaprobacionactivos(txtnumeromanteni.Value,
                                        serial, txtRepuestos.Value.ToUpper(), txtobserva.Value, SelecttipoMant.Value,
                                        clasetrabajo.Value, Textgarantia.Value, Session["BD"].ToString());
                                    
                                }
                                finally
                                {

                                }
                                
                           
                            string script = @"<script type='text/javascript'>
                            alert('Guardado con Exito');
                            
                        </script>";

                            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                            //imprimir();
                            Response.Redirect("../Vista/Aprova_Manteni.aspx");
                        }


                    }
                    catch (Exception ex)
                    {

                        throw ex;
                        
                    }

                }
                view_detalles.Visible = false;
                consultaasignados();
            }

          
        }

        protected void GridView_Ord_Work_SelectedIndexChanged(object sender, EventArgs e)
        {
            view_detalles.Visible = true;
            GridViewRow gwr = GridView_Ord_Work.SelectedRow;
            String idOrden = gwr.Cells[1].Text;
            String idAsig = gwr.Cells[2].Text;
            String trabajo = Page.Server.HtmlDecode(gwr.Cells[3].Text);
            OBSERVACIONG.Value = trabajo;
            txtnumeroOrden.Value = idOrden;
            txtnumeroAsg.Value = idAsig;

        }
    }
}