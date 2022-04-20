using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class RotacionDias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      
        protected void Consultar_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlador.Controlasql.CRotaciondias(date1.Value,date2.Value,Session["salaventas"].ToString());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridviewRotacion.DataSource = registros;
                    GridviewRotacion.DataBind();
                }
                else
                {
                    GridviewRotacion.DataSource = null;
                    GridviewRotacion.DataBind();
                }
            }
            catch (Exception exe)
            {
               
               
            }
        }
    }
}