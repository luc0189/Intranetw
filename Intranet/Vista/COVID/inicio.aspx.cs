using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.COVID
{
 
    public partial class inicio : System.Web.UI.Page
    {
        Ccodemas sb = new Ccodemas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listasalas();
            }
        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            Session["SALAVENTAS"] = selectAREA.Value;
            Response.Redirect("Lectura.aspx");
        }
        protected void listasalas()
        {
            try
            {
                String bd = Session["BD"].ToString();
                DataTable res2 = sb.CListasalas(bd);
                if (res2.Rows.Count > 0)
                {

                    selectAREA.Items.Clear();
                    foreach (DataRow row in res2.Rows)
                    {
                        selectAREA.Items.Add(Convert.ToString(row["NOMBRE"]));
                        selectAREA.DataBind();
                    }



                }
                else
                {
                    selectAREA.DataSource = null;
                    selectAREA.DataBind();
                }
            }
            catch (Exception E)
            {
                notificacion.Visible = true;
                error.InnerText = "Excepcion no Controlada: " + E;
            }

        }

    }
}