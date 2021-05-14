using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.RH
{
    public partial class Rh2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Session["USUARIO"].ToString() == "")
                    {
                        Response.Redirect("../Login.aspx");
                    }
                    notificacion.Visible = false;
                    excepcion.Visible = false;
                }
                catch (Exception)
                {

                    Response.Redirect("..//..//Login.aspx");
                }
               
            }
        }
        public void listadoasistencia()
        {
            
        }

        protected void btnconsulta_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clistadoasistencia(fechaini.Value, fechafin.Value);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    Gridviewasistencia.DataSource = registros;
                    Gridviewasistencia.DataBind();
                }
                else
                {
                    Gridviewasistencia.DataSource = null;
                    Gridviewasistencia.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Muestra Inf. Error: " + ex.Message;
            }
        }
    }
}