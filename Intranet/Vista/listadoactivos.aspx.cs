using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class listadoactivos : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Listaractivos();

            }
        }
        protected void Listaractivos()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.listaactivo(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewGactivos.DataSource = registros;
                    GridViewGactivos.DataBind();
                }
                else
                {
                    GridViewGactivos.DataSource = null;
                    GridViewGactivos.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
        protected void Nuevo(object sender, EventArgs e)
        {
            Response.Redirect("Ingresoactivos.aspx");
        }
    }
}