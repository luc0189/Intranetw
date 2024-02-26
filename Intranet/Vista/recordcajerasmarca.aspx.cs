using Intranet.Controlador;
using System;

namespace Intranet.Vista
{
    public partial class recordcajerasmarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
      

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.listaventasXmarcatop(txtfechaini.Value.ToUpper(), txtfechafin.Value, txtmarca.Value.ToUpper(), Select1.Value);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewventascajeraXmarca.DataSource = registros;

                    GridViewventascajeraXmarca.DataBind();
                }
                else
                {
                    GridViewventascajeraXmarca.DataSource = null;
                    GridViewventascajeraXmarca.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }
    }
}