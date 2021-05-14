using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WebForms;

namespace Intranet.Vista
{
    public partial class H_VidaEquipos : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
           
                excepcion.Visible = false;
                notificacion.Visible = false;



            }

        }
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        private DataTable GetData(string acta)
        {
            DataTable dt = new DataTable();
            string connex = System.Configuration.ConfigurationManager.ConnectionStrings["lcsystemConnectionString"].ConnectionString;
            using (MySqlConnection cn = new MySqlConnection(connex))
            {
                MySqlCommand cmd = new MySqlCommand("hoja_vida", cn);
                // cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@parm", MySqlDbType.String).Value = acta;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }


 
        public void Button3_Click(object sender, EventArgs e)//trae la info de los mantenimientos
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.traemanteni(Select1.Value,bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {

                    GridViewmantenimientos.DataSource = registrosm;
                    GridViewmantenimientos.DataBind();
                }
                else
                {
                    GridViewmantenimientos.DataSource = null;
                    GridViewmantenimientos.DataBind();
                }
            }
            catch (Exception)
            {

                
            }
        }

        public void buscararticulo(object sender, EventArgs e)
        {
           
           
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.traemanteni(Select2.Value, bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {

                    GridViewmantenimientos.DataSource = registrosm;
                    GridViewmantenimientos.DataBind();
                    traedatosgenerales();
                }
                else
                {
                    GridViewmantenimientos.DataSource = null;
                    GridViewmantenimientos.DataBind();
                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion no controlada"+ex.Message);
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.traerepuestos(Select2.Value,bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewrepuestos.DataSource = registrosr;
                    GridViewrepuestos.DataBind();
                    traedatosgenerales();
                }
                else
                {
                    GridViewrepuestos.DataSource = null;
                    GridViewrepuestos.DataBind();
                    traedatosgenerales();
                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.listaHistoriaActivos(Select2.Value, bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewhistoria.DataSource = registrosr;
                    GridViewhistoria.DataBind();
                 
                }
                else
                {
                    GridViewhistoria.DataSource = null;
                    GridViewhistoria.DataBind();
                    
                }

            }
            catch (Exception ex)
            {
                excepcion.Visible = true;
                string dato = ex.Message;
                error.InnerText = dato;

            }
        }
        public void traedatosgenerales()
        {
            string[] palabra = Select2.Value.Split('/');
            string seria = palabra[0].Trim();
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.ctraeinfoactivo(seria,bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrosm.Tables[0];
                 
                    foreach (DataRow row in dt.Rows)
                    {
                        Select1.Value=(Convert.ToString(row[0]));
                        txtnombre.Value = Convert.ToString(row[1]);
                        TextArea1.Value = Convert.ToString(row[8]);
                        txtmodelo.Value = Convert.ToString(row[2]);
                        txtfabricante.Value = Convert.ToString(row[3]);
                        txtcategoria.Value = Convert.ToString(row[4]);
                        txtproveedor.Value = Convert.ToString(row[5]);
                        txtfechacompra.Value = Convert.ToString(row[6]);
                        txtvalor.Value = Convert.ToString(row[7]);
                        txtgarantia.Value = Convert.ToString(row[9]) + " Meses de Garantia";
                    }
                   
                }
                else
                {
                    
                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
           

        }
        public void traerespuestos()
        {
            String bd = Session["BD"].ToString();
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+bd+"';Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select serialArt AS Serial  FROM articulo", cn);
            dr = cm.ExecuteReader();
            Select1.Value = "";
            while (dr.Read())
            {
                Select1.Value=(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }

      
    }
}