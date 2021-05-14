using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista.Mod
{
    public partial class Edicion_Mant : System.Web.UI.Page
    {
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                txtidacta.Value = Session["acta"].ToString();
                cargarInfo();
                llenaarticulo();
                desctbtn();
                btnactualizar.Visible = false;
                btncancelar.Visible = false;
               

            }
        }
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        protected void Nuevo(object sender, EventArgs e)
        {
            clicnuevo();
        }
        protected void clicnuevo()
        {
            btnguardar.Enabled = true;
            btneditar.Visible = false;
            btnactualizar.Visible = false;
            btncancelar.Visible = false;
            btnborra.Visible = false;
            Selectarticulo.Value = "";
            SelecttipoMant.Value = "";
      
            txtidart.Value = "";

            txtobserva.Value = "";
            txtRepuestos.Value = "";
            valorManObra.Value = "0";
            V_repuestos.Value = "0";
            Textnumeroexterno.Value ="";
            actvbtn();

        }
        protected void clicguardar()
        {
            btnnuevo.Enabled = true;
            btneditar.Enabled = false;
            btnactualizar.Enabled = false;
            btncancelar.Enabled = false;
            btnborra.Enabled = false;
            desctbtn();
        }
        
        public void desctbtn()
        {
            Selectarticulo.Disabled = true;
            SelecttipoMant.Disabled = true;
            Aviso.Visible = false;
            txtidacta.Disabled = true;
            txtidart.Disabled = true;
            timegarantia.Disabled = true;
            txtobserva.Disabled = true;
            txtRepuestos.Disabled = true;
            valorManObra.Disabled = true;
            V_repuestos.Disabled = true;
            Textnumeroexterno.Disabled = true;
        }
        public void actvbtn()
        {
            Selectarticulo.Disabled = false;
            SelecttipoMant.Disabled = false;
            
            txtidacta.Disabled = false;
            txtidart.Disabled = false;
            timegarantia.Disabled = false;
            txtobserva.Disabled = false;
            txtRepuestos.Disabled = false;
            valorManObra.Disabled = false;
            V_repuestos.Disabled = false;
            Textnumeroexterno.Disabled = false;
        }
        public void llenaarticulo()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database=lcsystem;Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select CONCAT(serialArt, ' / ', nombreArt) As Nombre  FROM articulo", cn);
            dr = cm.ExecuteReader();
            Selectarticulo.Items.Clear();
            while (dr.Read())
            {
                Selectarticulo.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }
              
        public void ocultarmenu(object sender, EventArgs e)
        {
            Aviso.Visible = false;
        }
        protected void borra(object sender, EventArgs e)
        {
            Aviso.Visible = true;
        }
        protected void borraitems_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.Cdelete_detalleactas(txtidart.Value, Session["BD"].ToString());
                if (registros > 0)
                {

                    Aviso.Visible = false;
                    cargarInfo();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
         protected void GridViewdetalle_RowUpdating(object sender, EventArgs e)
        {

            try
            {
                string[] palabras = Selectarticulo.Value.Split('/');
                string serial = palabras[0];
                string nombrearticulo = palabras[1];

                var registros = Controlasql.Cupdateitemsacta(serial.Trim(),SelecttipoMant.Value,
                    txtobserva.Value, valorManObra.Value, txtRepuestos.Value, Textnumeroexterno.Value,
                    V_repuestos.Value, txtidacta.Value,txtidart.Value, timegarantia.Value, Session["BD"].ToString());
                if (registros > 0)
                {

                    cargarInfo();
                    btnnuevo.Visible = true;
                    btnnuevo.Enabled = true;
                     
                    btneditar.Enabled = true;
                    btneditar.Visible = true;
                    btnactualizar.Visible = false;
                    btncancelar.Visible = false;

                    desctbtn();

                }
                else
                {
                    txtidacta.Value = "Error";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                    
                GridViewdetalle.EditIndex = -1;
          


        }
        public void cargarInfo()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.ctraeactaeditar(txtidacta.Value,bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {
                    DataTable dt1 = Session["Tabla"] as DataTable;
                    Session["Tabla"] = registrosm;
                    GridViewdetalle.DataSource = registrosm;
                    GridViewdetalle.DataBind();
                }
                else
                {
                    GridViewdetalle.DataSource = null;
                    GridViewdetalle.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }
        protected void buscaracta(object sender, EventArgs e)
        {
            cargarInfo();
        }
        protected void salir(object sender, EventArgs e)
        {
            string script = @"<script type='text/javascript'>
                            
                             window.close();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
           
        }
        protected void GridViewdetalle_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow gr = GridViewdetalle.SelectedRow;
            txtidart.Value = gr.Cells[1].Text;
            Selectarticulo.Value = gr.Cells[2].Text;
            txtRepuestos.Value = gr.Cells[3].Text;
            valorManObra.Value = gr.Cells[4].Text;
            V_repuestos.Value = gr.Cells[5].Text;
            txtobserva.Value = gr.Cells[6].Text;
            SelecttipoMant.Value = gr.Cells[7].Text;
            Textnumeroexterno.Value = gr.Cells[8].Text;
            timegarantia.Value = gr.Cells[9].Text;



            btnnuevo.Visible = true;
            btnnuevo.Enabled = true;
            btneditar.Visible = true;
            btneditar.Enabled = true;
            btnactualizar.Visible = false;
            btnborra.Visible = true;
            desctbtn();



        }
        protected void editar(object sender, EventArgs e)
        {
            actvbtn();
            btneditar.Visible = false;
            btnactualizar.Enabled = true;
            btnactualizar.Visible = true;
            btncancelar.Visible = true;
        }
        protected void cancela_modifica(object sender, EventArgs e)
        {
            btncancelar.Visible = false;
            desctbtn();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string[] palabras = Selectarticulo.Value.Split('/');
            string serial = palabras[0];
            try
            {
                var registros3 = Controlasql.ccreadetalleactamante(txtidacta.Value, serial,
                    txtRepuestos.Value.ToUpper().Trim(),valorManObra.Value, V_repuestos.Value,
                    txtobserva.Value.ToUpper(),SelecttipoMant.Value, Textnumeroexterno.Value, Session["BD"].ToString());
                if (registros3>0)
                {
                    string script = @"<script type='text/javascript'>
                            alert('Fila insertada ');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    cargarInfo();
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
