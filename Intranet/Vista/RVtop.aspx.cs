using Intranet.Controlador;
using System;

namespace Intranet.Vista
{
    public partial class RVtop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void listaventas(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.listaTopVentas(txtfechaini.Value.ToUpper(), txtfechafin.Value,selectTop.Value.ToString());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewTopventas.DataSource = registros;

                    GridViewTopventas.DataBind();
                }
                else
                {
                    GridViewTopventas.DataSource = null;
                    GridViewTopventas.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
        //public void listaventastop()
        //{
        //    try
        //    {
        //        var registros = Controlasql.listaventasXarticulotop(txtfechaini.Value.ToUpper(), txtfechafin.Value, txtarticuloid.Value.ToUpper(), Select1.Value);
        //        if (registros.Tables[0].Rows.Count > 0)
        //        {
        //            GridViewventascajeraXarticulo.DataSource = registros;

        //            GridViewventascajeraXarticulo.DataBind();
        //        }
        //        else
        //        {
        //            GridViewventascajeraXarticulo.DataSource = null;
        //            GridViewventascajeraXarticulo.DataBind();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        Response.Redirect("Exceptionnet.aspx");
        //    }

        //}
    }
}