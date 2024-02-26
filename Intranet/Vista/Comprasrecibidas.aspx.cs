using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class Comprasrecibidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void listaventas(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.listacomprasrecibo(txtfechaini.Value.ToUpper(), txtfechafin.Value);
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
            
        }
     
    }
}