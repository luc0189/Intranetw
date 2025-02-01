using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class RecordVentasN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
               
            }
        }

      
        protected void Consultar_Click(object sender, EventArgs e)
        {
            var ccosto = Session["salaventas"].ToString();

            try
            {

                var registros = Controlador.Controlasql.CRecordVentas(date1.Value, date2.Value,prov.Value);
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