using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Ventas_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

      

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                var registrosla14 = Controlasql.CListaVentas_la14VENTAS(txtfechaini.Value.ToUpper(), txtfechafin.Value);
                if (registrosla14.Tables[0].Rows.Count > 0)
                {
                    Gridla14.DataSource = registrosla14;
                    Gridla14.DataBind();
                }
                else
                {
                    Gridla14.DataSource = null;
                    Gridla14.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }
    }
}