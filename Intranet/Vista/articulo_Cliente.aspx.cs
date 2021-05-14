using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class articulo_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        protected void listaventas(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.listaventasXarticulocliente(txtfechaini.Value.ToUpper(), txtfechafin.Value, txtarticuloid.Value.ToUpper());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewventasclienteXarticulo.DataSource = registros;
                    GridViewventasclienteXarticulo.DataBind();
                }
                else
                {
                    GridViewventasclienteXarticulo.DataSource = null;
                    GridViewventasclienteXarticulo.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
    }
}