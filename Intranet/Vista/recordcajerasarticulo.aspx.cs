using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class recordcajerasarticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void listaventas(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.listaventasXarticulo(txtfechaini.Value.ToUpper(), txtfechafin.Value, txtarticuloid.Value.ToUpper());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewtodos.DataSource = registros;
                   
                    GridViewtodos.DataBind();
                }
                else
                {
                    GridViewtodos.DataSource = null;
                    GridViewtodos.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            listaventastop();
        }
        public void listaventastop()
        {
            try
            {
                var registros = Controlasql.listaventasXarticulotop(txtfechaini.Value.ToUpper(), txtfechafin.Value, txtarticuloid.Value.ToUpper(),Select1.Value);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewventascajeraXarticulo.DataSource = registros;

                    GridViewventascajeraXarticulo.DataBind();
                }
                else
                {
                    GridViewventascajeraXarticulo.DataSource = null;
                    GridViewventascajeraXarticulo.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
    }
}