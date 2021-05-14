using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
namespace Intranet.Vista
{
    public partial class listageneral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Listaractivos();
        }
        protected void Listaractivos()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.listaactivos(bd);
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
            catch (Exception e)
            {
                alerta.MessageBox(this, $"{e}");
              
            }
           
        }
        protected void Nuevo(object sender, EventArgs e)
        {
            Response.Redirect("Acta_entrega.aspx");
        }
    }
}