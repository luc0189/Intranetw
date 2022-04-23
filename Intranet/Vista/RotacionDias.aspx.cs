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
    public partial class RotacionDias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Llenasalas();

                if (Session["salaventas"].ToString().Equals("ADMINISTRACION"))
                {
                    LinkButton3.Visible = false;
                    consultaadmon.Visible = true;
                }
                else
                {
                    LinkButton3.Visible = true;
                    consultaadmon.Visible = false;
                }
            }
        }

      
        protected void Consultar_Click(object sender, EventArgs e)
        {
            var ccosto = Session["salaventas"].ToString();
            Ejecuta(ccosto);
        }

        public void Llenasalas()
        {
            try
            {
                string bd = Session["BD"].ToString();
                var registros = Controlasql.CSalaventas(bd);
                Selectsala.Items.Clear();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectsala.Items.Add(Convert.ToString(row["NOMBRE"]));
                        Selectsala.DataBind();
                    }
                }
                else
                {
                    Selectsala.DataSource = null;
                    Selectsala.DataBind();
                }

            }
            catch (Exception ex)
            {
                //notificacion.Visible = false;
                //excepcion.Visible = true;
                //error.InnerText = "No Registros. Error: " + ex.Message;
            }


        }
        public void Ejecuta(string sala)
        {
            try
            {
              
                var registros = Controlador.Controlasql.CRotaciondias(date1.Value, date2.Value, sala);
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
            Ejecuta(nombre);
        }
    }
}