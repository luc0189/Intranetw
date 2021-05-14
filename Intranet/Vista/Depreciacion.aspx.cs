using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Depreciacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ListaDepreciacion();
            }
        }
        protected void ListaDepreciacion()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.clistadepreciacion(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewDepreciacion.DataSource = registros;
                    GridViewDepreciacion.DataBind();
                }
                else
                {
                    GridViewDepreciacion.DataSource = null;
                    GridViewDepreciacion.DataBind();
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
    }
}