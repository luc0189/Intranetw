using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class Rep_Kardexg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listarkardex();
            }
        }
        protected void Listarkardex()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.saldokardexgeneral(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewkardexg.DataSource = registros;
                    GridViewkardexg.DataBind();
                }
                else
                {
                    GridViewkardexg.DataSource = null;
                    GridViewkardexg.DataBind();
                }
            }
            catch (Exception e)
            {
                alerta.MessageBox(this, $"{e}");
                Response.Redirect("Exceptionnet.aspx");
            }

        }
    }
}