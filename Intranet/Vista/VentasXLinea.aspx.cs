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
    public partial class VentasXLinea : System.Web.UI.Page
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
        private void llenatotales()
        {

            string test2 = selectBodega.Value;

            string[] palabras2 = test2.Split('/');

            string idcosto = palabras2[0];
            labelFechainicio.InnerText = txtdesde.Value;
            labelfechafin.InnerText = txthasta.Value;
            try
            {
                var registros = Controlasql.Cventastotaleslinea(txtdesde.Value, txthasta.Value, idcosto);
                DataTable dt = registros.Tables[0];

                foreach (DataRow row in dt.Rows)
                {

                    lblventasr.InnerText = row[0].ToString();
                    lblvrproyectado.InnerText = row[1].ToString();
                    porcentaje.InnerText = row[2].ToString();
                    Int32 valor1 = Convert.ToInt32(row[2]);
                    lblpromventadiaria.InnerText = row[3].ToString();
                    lblproyectado.InnerText = row[4].ToString();
                    lblporcen_Proyectado.InnerText = row[5].ToString();
                    lblproyectado.InnerText = row[4].ToString();
                    Int32 valor2 = Convert.ToInt32(row[5]);
                    this.bar1.Attributes.Add("style", "width:" + valor1 + "%");
                    this.bar2.Attributes.Add("style", "width:" + valor2 + "%");
                    lblcompraclientes.InnerText = row[10].ToString();
                    lblventasmetroc.InnerText = row[11].ToString();



                }
            }
            catch (Exception ex)
            {

                notificacion.Visible=true;
                txtnotifica.InnerText = ex.Message;
            }

            try
            {
                var registros = Controlasql.Cventasmesanterior(txtdesde.Value, txthasta.Value, idcosto);
                DataTable dt = registros.Tables[0];
                foreach (DataRow row in dt.Rows)
                    {
                    txtporcentaMesAnterior.InnerText = row[0].ToString();
                }
                }
            catch (Exception exp)
            {

                throw exp;
            }


        }
        private void llenatablaresumido()
        {
     
            string test2 = selectBodega.Value;
       
            string[] palabras2 = test2.Split('/');
        
            string idcosto = palabras2[0];
            labelFechainicio.InnerText = txtdesde.Value;
            labelfechafin.InnerText = txthasta.Value;

            try
            {

                var res = Controlasql.Cventasresumidolinea(txtdesde.Value,txthasta.Value, idcosto);
                if (res.Tables[0].Rows.Count > 0)
                {
                    Gridviewresumido.DataSource = res;
                    Gridviewresumido.DataBind();
             

                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = true;
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
                notificacion.Visible = true;
                txtnotifica.InnerText = ex.Message;

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
                notificacion.Visible = true;
                txtnotifica.InnerText = ex.Message;

            }
        }
        public void consulta()
        {
            
            string test1 = selectLinea.Value;
            string test2 = selectBodega.Value;
            string[] palabras = test1.Split('/');
            string[] palabras2 = test2.Split('/');
            string idlinea = palabras[0];
            string idcosto = palabras2[0];
         
            try
            {
                var registros13 = Controlasql.cventasxlinea(txtdesde.Value, txthasta.Value, idlinea, idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    Gridviewventaslinea.DataSource = registros13;
                    Gridviewventaslinea.DataBind();
                    

                }
                else
                {
                    Gridviewventaslinea.DataSource = null;
                    Gridviewventaslinea.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }

        protected void Btnconsulta_Click(object sender, EventArgs e)
        {
            llenatablaresumido();
            llenatotales();
        }
    }
}