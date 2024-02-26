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
    public partial class Ventasgrupo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
              
            }
        }

      
        protected void Consultar_Click(object sender, EventArgs e)
        {
            
            Ejecuta();
        }

       
        public void Ejecuta()
        {
            try
            {
              
                var registros = Controlador.Controlasql.CVentasgrupo(date1.Value, date2.Value,"FV,FP");
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
        protected void Consultaadmon_Click(object sender, EventArgs e)
        {
            var c = Selectsala.Value;
            string[] palabras = c.Split('/');
            string codigoc = Page.Server.HtmlDecode(palabras[0]);
            string nombre = palabras[1];
            Ejecuta();
        }
    }
}