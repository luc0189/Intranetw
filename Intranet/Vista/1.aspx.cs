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
    public partial class _1 : System.Web.UI.Page
    {
        DataTable dt = null;
        String profi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                Ventasmesanterior();




                //if (Session["USUARIO"] != null)
                //{
                  
                   
                //}
               
               
              
               
            }
        }

        public void Ventasmesanterior()
        {
            string desde;
            string hasta;
            string centrocosto = Session["CCOSTO"].ToString();

            if (txtdesde.Value.Equals("")||txthasta.Value.Equals(""))
            {
                 desde = "01-"+ DateTime.Now.Date.ToString("MM") + "-"+DateTime.Now.Year.ToString()+"";
                 hasta =DateTime.Now.Date.Date.AddDays(-1).ToString("dd-MM-yyyy");
                txtdesde.Value = desde;
                txthasta.Value = hasta;
            }
            try
            {
                var registros = Controlasql.Cventastotaleslinea(txtdesde.Value, txthasta.Value,centrocosto);
                DataTable dt = registros.Tables[0];

                foreach (DataRow row in dt.Rows)
                {

                    lblventasr.InnerText = row[0].ToString();
                    Label1.InnerText = row[0].ToString();
                    lblvrproyectado.InnerText = row[1].ToString();
                    porcentaje.InnerText = row[2].ToString();
                    Int32 valor1 = Convert.ToInt32(row[2]);
                   
                    lblproyectado.InnerText = row[4].ToString();
                    lblporcen_Proyectado.InnerText = row[5].ToString();
                    lblproyectado.InnerText = row[4].ToString();
                    Int32 valor2 = Convert.ToInt32(row[5]);
                    //this.bar1.Attributes.Add("style", "width:" + valor1 + "%");
                    //this.bar2.Attributes.Add("style", "width:" + valor2 + "%");
                    lblcompraclientes.InnerText = row[10].ToString();
                    lblventasmetroc.InnerText = row[11].ToString();



                }
            }
            catch (Exception ex)
            {

                //notificacion.Visible = true;
                //txtnotifica.InnerText = ex.Message;
            }

            try
            {
                var registros = Controlasql.Cventasmesanterior(txtdesde.Value, txthasta.Value, Session["CCOSTO"].ToString());
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

        protected void Btnconsulta_Click(object sender, EventArgs e)
        {
         Ventasmesanterior();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            var registrosv16 = Controlasql.listaventaXhora(txtdesde.Value,Session["CCOSTO"].ToString());
            if (registrosv16.Tables[0].Rows.Count > 0)
            {
                Gridsuper.DataSource = registrosv16;
                Gridsuper.DataBind();
            }
            var regtotal16 = Controlasql.listaventa(txtdesde.Value, Session["CCOSTO"].ToString());
            if (regtotal16.Tables[0].Rows.Count > 0)
            {
                grid.DataSource = regtotal16;
                grid.DataBind();
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var registros16 = Controlasql.listaventa(txtdesde.Value.ToUpper(), txthasta.Value, Session["CCOSTO"].ToString());
                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridsupermio.DataSource = registros16;
                    Gridsupermio.DataBind();
                }
                else
                {
                    Gridsupermio.DataSource = null;
                    Gridsupermio.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }
    }
}