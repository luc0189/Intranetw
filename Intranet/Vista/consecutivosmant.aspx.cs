using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using MySql.Data.MySqlClient;

namespace Intranet.Vista
{
    public partial class consecutivosmant : System.Web.UI.Page
    {
      
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                consecutivos();
              

                llenaproveedores();
                

            }
        }
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        public void llenaproveedores()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database=lcsystem;Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select p.nomb personas FROM persona p ", cn);
            dr = cm.ExecuteReader();
            Select1.Items.Clear();
            while (dr.Read())
            {
                
                Select1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }
        public void consecutivos()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.lista_idmanteni(bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = Session["Tabla"] as DataTable;
                    Session["Tabla"] = registrosm;
                    GridViewactas.DataSource = registrosm;
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
                throw e; 

            }

        }
        protected void GridViewdetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gr = GridViewactas.SelectedRow;
          
            txtNacta.Value = gr.Cells[1].Text;
            Select1.Value = gr.Cells[2].Text;
            txtfecha.Value = gr.Cells[3].Text;
            txtobserva.Disabled = false;
            txtobserva.Value= Page.Server.HtmlDecode(gr.Cells[4].Text);
            Session["acta"] = txtNacta.Value;

        }
        protected void updateacta(object sender,EventArgs e)
        {
           
                string idproveedortemp = Select1.Value;
               
                string dat = DateTime.Now.ToString();
         
                
            //aqui ingresamos el famoso asigarticulo

            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.cupdate_actasm(idproveedortemp, txtfecha.Value,txtobserva.Value.ToUpper(),txtNacta.Value,bd);
                if (registrosm > 0)
                {
                    consecutivos();                   
                }
                else
                {
                   
                }
            }
            catch (Exception)
            {


            }
        }
          
       



    }
}