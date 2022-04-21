using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.reportes
{
    public partial class BajasFruver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void consulta(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.CBajasFruver(txtfechadesde.Value, txtfechahasta.Value,Session["CCOSTO"].ToString());
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