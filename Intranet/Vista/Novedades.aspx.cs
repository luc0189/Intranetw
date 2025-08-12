using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{

    public partial class Novedades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                llenaempleados();
                Nuevotercero.Visible = false;
                ListaNovedades();
            }

        }
        public void llenaempleados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroPROVEE = Controlasql.ctraeEmpleado(bd);

                    if (registroPROVEE.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = registroPROVEE.Tables[0];
                    selectempleado.Items.Clear();
                        foreach (DataRow row in dt.Rows)
                        {
                            selectempleado.Items.Add(Convert.ToString(row["Proveedor"]));
                        selectempleado.DataBind();
                        }



                    }
                    else
                    {
                    selectempleado.DataSource = null;
                    selectempleado.DataBind();
                    }
                }
            catch (Exception)
            {


            }

        }
        protected void ListaNovedades()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.listaNovedades(Session["USUARIO"].ToString(),bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewNovedades.DataSource = registros;
                    GridViewNovedades.DataBind();
                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
        public void Limpia()
        {
            selectempleado.Value = "";
            txtobserva.Value = "";

        }
        protected void btnguardar_Click2(object sender, EventArgs e)
        {
           var horas=Convert.ToInt32(hours.Value);
            if (horas >2 || horas <0)
            {
                string script = @"<script type='text/javascript'>
                            alert('solo se permite maximo 2 horas');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                return;
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ccrea_Novedades(
                    selectempleado.Value,
                    txtfechaini.Value,
                    Convert.ToInt32(hours.Value),
                    id39.Checked,
                    id40.Checked,
                    txtobserva.Value.ToUpper().ToString(),
                     Session["USUARIO"].ToString(), bd);
                if (registros > 0)
                {
                    string script = @"<script type='text/javascript'>
                            alert('Guardado con Exito');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    Limpia();
                    ListaNovedades();
                }
            }
            catch (Exception ex)
            {
                string mensaje = System.Web.HttpUtility.JavaScriptStringEncode(ex.Message);
                string script = $@"<script type='text/javascript'>
                    alert('Error: {mensaje}');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            selectempleado.Value = "";
            //txtobserva.Value = "";
            //txtfechaini.Value = "";
            //txtfechafin.Value = "";
        }

        protected void Button11_Click(object sender, EventArgs e)
        {

        }

        protected void btnguardaempleado_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.CcreaTerceroempleado(txtccoNit.Value.ToUpper(), txtNomb.Value.ToUpper(), 
                    txtdir.Value.ToUpper(), txttel.Value, txtCiudad.Value.ToUpper(),
                    txtEmail.Value.ToUpper(), Session["USUARIO"].ToString(),bd);
                if (registros > 0)
                {

                    Nuevotercero.Visible = false;
                    llenaempleados();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {

        }

        protected void Btncancela_Click(object sender, EventArgs e)
        {
            Nuevotercero.Visible = false;
        }

        protected void btnnuevoempleado_Click(object sender, EventArgs e)
        {
            Nuevotercero.Visible = true;
        }
    }
}