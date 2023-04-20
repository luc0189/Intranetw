using Intranet.Controlador;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class OrdenTrabajo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                normalestado();
                llenaubicacion();
                llenaarea();
                llenatiposolicitud();
                llenatipomantenimiento();
                Imprime_R.Visible = false;
            }
        }

        private void llenatiposolicitud()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroubica = Controlasql.ClistaTiposolicitud(bd);

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    SelectTiposolicitud.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectTiposolicitud.Items.Add(Convert.ToString(row["Nombre"]));
                        SelectTiposolicitud.DataBind();
                    }



                }
                else
                {
                    SelectTiposolicitud.DataSource = null;
                    SelectTiposolicitud.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }

        private DataTable GetData(string acta)
        {
            
            //DataTable dt = new DataTable();
            //string connex = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none";
            //using (MySqlConnection cn = new MySqlConnection(connex))
            //{
            //    MySqlCommand cmd = new MySqlCommand("LISTAASIGNACIONORDENMANTENIMIENTO", cn);
            //    // cmd.CommandType = CommandType.Text;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@parm", MySqlDbType.String).Value = acta;
            //    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            //    adp.Fill(dt);

            //}
            //return dt;


            DataTable dt = new DataTable();
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraeactaasignado(acta, bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];

                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return dt;
        }
        private void mostrarreporte()
        {
            //reset
            ReportViewer1.Reset();
            GridViewRow gr = GridViewASIGNADO.SelectedRow;
            String id = gr.Cells[1].Text;
            //datasou
            DataTable dt = GetData(id);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);

            //path
            ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";

            //param
            // ReportParameter[] rptparamet = new ReportParameter[]
            //{
            //   new ReportParameter("parm",txtidacta.Value)
            //};
            //refresh
            ReportViewer1.LocalReport.Refresh();
        }
        public void normalestado()
        {
            btnguardar.Visible = true;
            
            //btnNuevo.Visible = true;
        
        }
        protected void GridViewpendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Imprime_R.Visible = true;
            mostrarreporte();
        }
        public void nuevoestado()
        {
                    
            btnguardar.Visible = true;
            //btnNuevo.Visible = true;

        }
        public void guardarestado()
        {
            normalestado();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoestado();
            Selectubicacion.Value = "";
            Selectarea.Value = "";
            Selecttipo.Value = "";
            txtDescripcion.Value = "";
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            guardarestado();
            string var_stado = "RADICADO";
           
            if (Selectubicacion.Value.Equals("") || txtDescripcion.Value.Equals("")) 
                {
                string script = @"<script type='text/javascript'>
                            alert('Ingrese la Informacion Requerida');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                try
                {
                    var registros3 = Controlasql.Ccreaorden( Selectubicacion.Value, Selectarea.Value, Selecttipo.Value,
                        txtDescripcion.Value.ToUpper(), var_stado, Session["USUARIO"].ToString(),SelectTiposolicitud.Value, Session["BD"].ToString());
                    if (registros3 > 0)
                    {
                        string script = @"<script type='text/javascript'>
                            alert('Registro exitoso');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        consultaradicados();
                        consultaasignados();
                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>
                            alert('No fue Posible guardar el Registro');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        consultaradicados();
                        consultaasignados();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
          
        }
        public void consultaasignados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridasignados(Session["USUARIO"].ToString(), Session["perfilnombre"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewASIGNADO.DataSource = registrosr;
                    GridViewASIGNADO.DataBind();
                    
                }
                else
                {
                    GridViewASIGNADO.DataSource = null;
                    GridViewASIGNADO.DataBind();
                    
                }

            }
            catch (Exception Exp)
            {

                alerta.MessageBox(this,Exp.Message);
            }
        }
        public void consultaradicados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridradicados(Session["USUARIO"].ToString(),Session["perfilnombre"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewPENDIENTES.DataSource = registrosr;
                    GridViewPENDIENTES.DataBind();
                  
                }
                else
                {
                    GridViewPENDIENTES.DataSource = null;
                    GridViewPENDIENTES.DataBind();
                   
                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            normalestado();
        }
        public void llenaubicacion()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroubica = Controlasql.Clistaubicacion(bd);

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    Selectubicacion.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectubicacion.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectubicacion.DataBind();
                    }



                }
                else
                {
                    Selectubicacion.DataSource = null;
                    Selectubicacion.DataBind();
                }
            }
            catch (Exception)
            {


            }

        }
        public void llenaarea()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroubica = Controlasql.Clistaarea(bd);

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    Selectarea.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectarea.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectarea.DataBind();
                    }



                }
                else
                {
                    Selectarea.DataSource = null;
                    Selectarea.DataBind();
                }
            }
            catch (Exception)
            {


            }

        }
        public void llenatipomantenimiento()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrotipom = Controlasql.Clistaclasemantenimiento (bd);

                if (registrotipom.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrotipom.Tables[0];
                    Selecttipo.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Selecttipo.Items.Add(Convert.ToString(row["Nombre"]));
                        Selecttipo.DataBind();
                    }



                }
                else
                {
                    Selecttipo.DataSource = null;
                    Selecttipo.DataBind();
                }
            }
            catch (Exception)
            {


            }

        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            consultaradicados();
        }

        protected void btnasignadas_Click(object sender, EventArgs e)
        {
            consultaasignados();
        }

        protected void btncerrarimprime_Click(object sender, EventArgs e)
        {
            Imprime_R.Visible = false;
        }
        public void imprimir()
        {
            Imprime_R.Visible = true;
            //mostrarreporte();
            // Response.Write("<script language=javascript>window.Print();</script>");

        }
    }
}