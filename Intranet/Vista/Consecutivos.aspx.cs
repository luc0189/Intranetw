using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class Consecutivos : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listaractas();
            }
           
        }
        protected void Listaractas()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.listaactas(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewactas.DataSource = registros;
                    GridViewactas.DataBind();
                }
                else
                {
                    GridViewactas.DataSource = null;
                    GridViewactas.DataBind();
                }
            }
            catch (Exception e)
            {
                alerta.MessageBox(this, $"{e}");
              
            }

        }
       
    }
}