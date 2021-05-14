using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Domicilios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }
        protected void consulta(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistsSalesDomicilios(txtfechadesde.Value, txtfechahasta.Value);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = registros;
                    GridView1.DataBind();

                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }

        }
       
    }
}