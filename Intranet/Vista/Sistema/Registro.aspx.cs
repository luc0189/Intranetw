using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.Sistema
{
    public partial class Registro : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        Main t = new Main();

        protected void Page_Load(object sender, EventArgs e)
        {
            notificacion.Visible = false;
            bloqueaitems();
            if (!Page.IsPostBack)
            {
                bloqueaitems();
                notificacion.Visible = false;
                llenaritems();
                btnguardanuevo.Visible = false;
                btncancelanuevo.Visible = false;
                btnguardaeditar.Visible = false;
                btncancelareditar.Visible = false;
            }

        }




        public void llenaritems()
        {

            SelectTipopersona.Items.Clear();
            try
            {
                var registros = Controlador.Controlasql.ClistaRoll(Session["BD"].ToString());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    SelectTipopersona.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectTipopersona.Items.Add(Convert.ToString(row["NOMBRE"]));
                        SelectTipopersona.DataBind();
                    }

                }
                else
                {
                    SelectTipopersona.DataSource = null;
                    SelectTipopersona.DataBind();
                }
            }
            catch (Exception ex)
            {
                String g = "" + ex.Message;

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", g, false);
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
            SelectTipopersona.Value = gr.Cells[9].Text;
            bloqueaitems();

        }
        public void limpiaitems()
        {
            txtcc.Value = "";
            txtname1.Value = "";
            txtname2.Value = "";
            txtapellido1.Value = "";
            txtapellido2.Value = "";
            txtdir.Value = "";
            txttel.Value = "";
            Select.Value = "";
            SelectTipopersona.Value = "";
        }
        public void bloqueaitems()
        {
            txtcc.Disabled = true;
            txtname1.Disabled = true;
            txtname2.Disabled = true;
            txtapellido1.Disabled = true;
            txtapellido2.Disabled = true;
            txtdir.Disabled = true;
            txttel.Disabled = true;
            Select.Disabled = true;
            SelectTipopersona.Disabled = true;
        }
        public void desbloqueaitems()
        {
            txtcc.Disabled = false;
            txtname1.Disabled = false;
            txtname2.Disabled = false;
            txtapellido1.Disabled = false;
            txtapellido2.Disabled = false;
            txtdir.Disabled = false;
            txttel.Disabled = false;
            Select.Disabled = false;
            SelectTipopersona.Disabled = false;
        }
        protected void btnnuevo_Click(object sender, EventArgs e)
        {
            btnguardanuevo.Visible = true;
            btncancelanuevo.Visible = true;
            btnnuevo.Visible = true;
            limpiaitems();
            desbloqueaitems();
        }

        protected void btncancelanuevo_Click(object sender, EventArgs e)
        {
            btnguardanuevo.Visible = false;
            bloqueaitems();
            btncancelanuevo.Visible = false;
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            btneditar.Visible = false;
            btnguardaeditar.Visible = true;
            btncancelareditar.Visible = true;
            desbloqueaitems();
        }

        protected void btncancelareditar_Click(object sender, EventArgs e)
        {
            btneditar.Visible = true;
            btncancelareditar.Visible = false;
            btnguardaeditar.Visible = false;
            bloqueaitems();
        }

        protected void btnguardanuevo_Click(object sender, EventArgs e)
        {
            String bd = Session["BD"].ToString();
            string[] palabras = SelectTipopersona.Value.Split('/');
            string id = palabras[0];
            try
            {
                var valida = sb.Ccrearpersona(txtcc.Value, txtname1.Value.ToUpper(), txtname2.Value.ToUpper(), txtapellido1.Value.ToUpper(), txtapellido2.Value.ToUpper(),
               txttel.Value, txtdir.Value.ToUpper(), Select.Value, id, Session["USUARIO"].ToString(), bd);
                if (valida.Rows.Count > 0)
                {
                    btncancelanuevo.Visible = false;
                  
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
                    bloqueaitems();
                }
                else
                {
                    txtname1.Value = "Error al Guardar";
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = true;
                alertant.InnerText = ex.Message;
            }
        }

        protected void listausuarios_Click(object sender, EventArgs e)
        {

            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clistausuarios(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewdetalle.DataSource = registros;
                    GridViewdetalle.DataBind();
                    bloqueaitems();
                }
                else
                {
                    GridViewdetalle.DataSource = null;
                    GridViewdetalle.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }

        }
    }
}