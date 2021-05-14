using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.COVID
{
    public partial class Lectura : System.Web.UI.Page
    {
        DataTable dt = null;
        Ccodemas sb = new Ccodemas();
     
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
              
                
                txtcc.Focus();
                datoin.Visible = false;
                datoout.Visible = false;
                notificacion.Visible = false;
                area.InnerText = Session["SALAVENTAS"].ToString();
                btnGuardaRegistro2.Visible = false;
                txtid.Visible = false;

            }
        }
       
       

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try




            {
                var exist_lcs = sb.clistaCC_IDCOBI(txtcc.Value, Session["BD"].ToString());
                if (exist_lcs.Rows.Count>0)
                {
                    string NOMBRE = Convert.ToString(exist_lcs.Rows[0]["NOMBRE"]);
                    txtnombre.InnerText = Convert.ToString(exist_lcs.Rows[0]["NOMBRE"]);
                    string TIPO = Convert.ToString(exist_lcs.Rows[0]["TIPO"]);
                    switch (TIPO)
                    {
                        case "E":
                            datoin.Visible = true;
                            datoout.Visible = true;
                            buscaregistro();
                            break;
                        case "C":
                            datoin.Visible = true;
                            datoin.Disabled = false;
                            datoin.Value = "";
                            datoin.Focus();
                            datoout.Visible = false;
                            btnGuardaRegistro.Visible = true;

                            break;
                        case "P":
                            datoin.Visible = true;
                            datoin.Disabled = false;
                            datoin.Value = "";
                            datoin.Focus();
                            datoout.Visible = true;
                            buscaregistro();
                            btnGuardaRegistro.Visible = true;
                            break;
                        default:
                            break;
                    }

                }else 
                {
                    try
                    {
                        var terceros_bnet = Controlasql.Clista_tercerosbnet(txtcc.Value);
                        if (terceros_bnet.Tables[0].Rows.Count>0)
                        {
                            foreach (DataRow row in terceros_bnet.Tables[0].Rows)
                            {
                               Session["NOMBREC"]= (Convert.ToString(row["nombrecompleto"]));
                               Session["TELEFONO"] = (Convert.ToString(row["telefono"]));
                               Session["TXTCC"] = txtcc.Value;
                               

                            }
                            Response.Redirect("WebForm1.aspx");
                        }
                        else
                        {
                            Session["TXTCC"] = txtcc.Value;
                            Response.Redirect("WebForm1.aspx");
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                   
                }
                
            }
            catch (Exception E)
            {
               
                throw E;
            }
        }
        private void buscaregistro()
        {
            datoin.Value = "";
            datoout.Value = "";
            var registro = sb.clistaCC_dato1(txtcc.Value, Session["BD"].ToString());
            if (registro.Rows.Count > 0)
            {
                String DATO = Convert.ToString(registro.Rows[0]["DATO1"]);
                String DATO2 = Convert.ToString(registro.Rows[0]["DATO2"]);
                String ID = Convert.ToString(registro.Rows[0]["ID"]);
                String tipo = Convert.ToString(registro.Rows[0]["TIPO"]);
                switch (tipo)
                {
                    case "E":
                        datoin.Value = DATO;
                        if (DATO2.Equals("0"))
                        {
                           datoout.Disabled = false;
                            datoout.Focus();
                            btnGuardaRegistro.Visible = false;
                            btnGuardaRegistro2.Visible = true;
                        }
                        else
                        {
                            datoin.Disabled = true;
                            btnGuardaRegistro.Visible = false;
                            btnGuardaRegistro2.Visible = true;
                            txtid.InnerText = ID;
                            datoout.Disabled = true;
                            datoout.Value = DATO2;

                        }
                       
                        break;
                    case "P":
                        datoin.Value = DATO;
                        if (DATO2.Equals("0"))
                        {
                            datoout.Disabled = false;
                            datoout.Focus();
                            btnGuardaRegistro.Visible = false;
                            btnGuardaRegistro2.Visible = true;
                        }
                        else
                        {
                            datoin.Disabled = true;
                            btnGuardaRegistro.Visible = false;
                            btnGuardaRegistro2.Visible = true;
                            txtid.InnerText = ID;
                            datoout.Disabled = true;
                            datoout.Value = DATO2;

                        }

                        break;
                    default:
                        break;
                }
            }
            else
            {
                datoin.Disabled = false;
                datoout.Disabled = false;
                btnGuardaRegistro.Visible = true;
                btnGuardaRegistro2.Visible = false;
                datoin.Focus();
            }
        }

        protected void btnGuardaRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                if (datoout.Value=="")
                {
                    datoout.Value = "0";
                }
                var registros2 = sb.CcreaDetallesregistro(txtcc.Value,area.InnerText,datoin.Value
                    ,datoout.Value,Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros2.Rows.Count > 0)
                {
                    notificacion.Visible = true;
                    alertant.InnerText = "Registro Exitoso";
                    txtcc.Value = "";
                    txtcc.Focus();
                    datoin.Value = "";
                    datoout.Value = "";
                    Session.Remove("TXTCC");

                }
                else
                {

                    notificacion.Visible = true;
                    alertant.InnerText = "Error al Guardar los datos, Valide la informacion y vuelva a intentarlo";
                }

            }
            catch (Exception EC)
            {

                notificacion.Visible = true;
                alertant.InnerText = EC.Message;
            }

            
        }
      
        protected void btnGuardaRegistro2_Click(object sender, EventArgs e)
        {
            try
            {
               
                var registros2 = sb.CupdateDetallesRegistro(txtcc.Value, area.InnerText,
                    datoout.Value, Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros2.Rows.Count > 0)
                {
                    notificacion.Visible = true;
                    alertant.InnerText = "Registro Exitoso";
                    btnGuardaRegistro2.Visible = false;
                    txtcc.Value = "";
                    datoout.Value = "";
                    txtcc.Focus();
                    btnGuardaRegistro.Visible = true;
                    btnGuardaRegistro2.Visible = false;

                }
                else
                {
                    datoout.Value = "";
                    notificacion.Visible = true;
                    alertant.InnerText = "Error al Guardar los datos, Valide la informacion y vuelva a intentarlo";
                }

            }
            catch (Exception EC)
            {

                notificacion.Visible = true;
                alertant.InnerText = EC.Message;
            }
        }
    }
}