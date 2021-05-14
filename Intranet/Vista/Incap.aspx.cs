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

    public partial class Incap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                llenaempleados();
                Nuevotercero.Visible = false;
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

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ccrea_incapacidades(selectempleado.Value,txtobserva.Value.ToUpper().ToString(),
                    txtfechaini.Value ,txtfechafin.Value, Session["USUARIO"].ToString(),bd);
                if (registros > 0)
                {
                    string script = @"<script type='text/javascript'>
                            alert('Guardado con Exito');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            selectempleado.Value = "";
            txtobserva.Value = "";
            txtfechaini.Value = "";
            txtfechafin.Value = "";
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