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
    public partial class ventaXhora_linea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            notificacion.Visible = false;
            if (!Page.IsPostBack)
            {
                notificacion.Visible = false;
                llenalineas();
                llenacostos();
            }
        }
        public void llenacostos()
        {
            try
            {

                var registroubica = Controlasql.Ccosto
();

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    selectBodega.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        selectBodega.Items.Add(Convert.ToString(row["Nombre"]));
                        selectBodega.DataBind();
                    }



                }
                else
                {
                    selectLinea.DataSource = null;
                    selectLinea.DataBind();
                }
            }
            catch (Exception ex)
            {
                txtnotifica.InnerText = ex.Message;

            }
        }
        public void llenalineas()
        {
            try
            {

                var registroubica = Controlasql.traelineassupermio();

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    selectLinea.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        selectLinea.Items.Add(Convert.ToString(row["Nombre"]));
                        selectLinea.DataBind();
                    }



                }
                else
                {
                    selectLinea.DataSource = null;
                    selectLinea.DataBind();
                }
            }
            catch (Exception ex)
            {

                txtnotifica.InnerText = ex.Message;
            }
        }
        public void consulta()
        {
            string test = selectLinea.Value;
            string test2 = selectBodega.Value;
            string[] palabras = test.Split('/');
            string[] palabras2 = test2.Split('/');
            string idlinea = palabras[0];
            string idbodega = palabras2[0];
          
            try
            {
                var registrosr = Controlasql.Cventashoralinea(txtfecha.Value,idlinea,idbodega);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewsupermio.DataSource = registrosr;
                    GridViewsupermio.DataBind();
                 

                }
                else
                {
                    GridViewsupermio.DataSource = null;
                    GridViewsupermio.DataBind();

                }

            }
            catch (Exception e)
            {

                txtnotifica.InnerText=e.Message;
            }
        }
   
   
        protected void btnconsulta(object sender, EventArgs e)
        {
            consulta();
            
        }
    }
}