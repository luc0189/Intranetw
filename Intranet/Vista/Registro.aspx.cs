using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using Intranet.Vista;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data;

namespace Intranet.Vista.config
{
    public partial class Registro : System.Web.UI.Page
    {
        Controla sb = new Controla();
        Main t = new Main();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenaritems();
                btnguardanuevo.Visible = false;
                btncancelanuevo.Visible = false;
                btnguardaeditar.Visible = false;
                btncancelareditar.Visible = false;
            }
           
        }
       
        protected void validarUsuario_Click(object sender, EventArgs e)
        {
            
           
           

        }
        OracleConnection cn;
      OracleCommand cm;
       OracleDataReader dr;
        public void llenaritems()
        {
            try
            {
                cn = new OracleConnection();
                cn.ConnectionString = "Data Source=localhost:1521/XE; Persist Security Info=True;User ID=LCSYSTEM; Password=Team0103;Unicode=true ";
                cn.Open();
                cm = new OracleCommand("select TIPP_NOMBRE FROM LCSYSTEM.TIPOPERSONA", cn);
                dr = cm.ExecuteReader();
                Select4.Items.Clear();
                while (dr.Read())
                {
                    Select4.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
           
        }
        protected void GridViewdetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridViewdetalle.SelectedRow;
            txtcc.Value = gr.Cells[1].Text;
            txtname1.Value = gr.Cells[2].Text;
            txtname2.Value = gr.Cells[3].Text;
            txtapellido1.Value = gr.Cells[4].Text;
            txtapellido2.Value = gr.Cells[5].Text;
            txttel.Value = gr.Cells[6].Text;
            txtdir.Value = gr.Cells[7].Text;
            Select.Value = gr.Cells[8].Text;
            Select4.Value = gr.Cells[9].Text;

        }

        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            btnguardanuevo.Visible = true;
            btncancelanuevo.Visible = true;
            btnnuevo.Visible = false;
        }

        protected void btncancelanuevo_Click(object sender, EventArgs e)
        {
            btnguardanuevo.Visible = false;
            btnnuevo.Visible = true;
            btncancelanuevo.Visible = false;
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            btneditar.Visible = false;
            btnguardaeditar.Visible = true;
            btncancelareditar.Visible = true;
        }

        protected void btncancelareditar_Click(object sender, EventArgs e)
        {
            btneditar.Visible = true;
            btncancelareditar.Visible = false;
            btnguardaeditar.Visible = false;
        }

        protected void btnguardanuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var valida = sb.Ccrearpersona(txtcc.Value, txtname1.Value.ToUpper(), txtname2.Value.ToUpper(), txtapellido1.Value.ToUpper(), txtapellido2.Value.ToUpper(),
               txttel.Value, txtdir.Value.ToUpper(), Select.Value, Select4.Value, Session["USUARIO"].ToString());
                if (valida.Rows.Count > 0)
                {
                    btncancelanuevo.Visible = false;
                    btnnuevo.Visible = true;
                    btnguardanuevo.Visible = false;
                    txtcc.Value = "";
                    txtname1.Value = "";
                    txtname2.Value = "";
                    txtapellido1.Value = "";
                    txtapellido2.Value = "";
                    txtdir.Value = "";
                    txttel.Value = "";
                    Select.Value = "";

                   
                    string script = @"<script type='text/javascript'>
                            alert('Registro Guardado exitosamente');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                }
                else
                {
                    txtname1.Value = "Error al Guardar";
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }

        protected void listausuarios_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable res = sb.Clistausuarios();
                if (res.Rows.Count > 0)
                {
                    this.GridViewdetalle.DataSource = res;
                    this.GridViewdetalle.DataBind();
                }
                else
                {
                    
                this.GridViewdetalle.DataBind();
                    

                    }
                 }
            catch (Exception E)
            {
             
            }
        }
    }
}