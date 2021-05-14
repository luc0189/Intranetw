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
    public partial class Baja_Activos : System.Web.UI.Page
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenaubicacion();
                llenaarea();
                llenaarticulo();
                table = new System.Data.DataTable();
                table.Columns.Add("Serial_Nombre", typeof(System.String));
                table.Columns.Add("Detalle", typeof(System.String));
                table.Columns.Add("Destino", typeof(System.String));
                Session.Add("Tabla", table);

            }
            
        }
    
        private DataTable GetData(string acta)
        {
            DataTable dt = new DataTable();
            string connex = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
            using (MySqlConnection cn = new MySqlConnection(connex))
            {
                MySqlCommand cmd = new MySqlCommand("PLISTAR_MANTENIMIENTO", cn);
                // cmd.CommandType = CommandType.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", MySqlDbType.String).Value = acta;
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            return dt;
        }
        private void mostrarreporte()
        {
            //reset
            ReportViewer1.Reset();

            //datasou
            DataTable dt = GetData(txtN_acta.Value);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);

            //path
            ReportViewer1.LocalReport.ReportPath = "actasmantenimiento.rdlc";

            //param
            // ReportParameter[] rptparamet = new ReportParameter[]
            //{
            //   new ReportParameter("parm",txtidacta.Value)
            //};
            //refresh
            ReportViewer1.LocalReport.Refresh();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["Tabla"] as DataTable;
            dt1.Rows[index].Delete();
            Session["Tabla"] = dt1;

            GridViewdetalle.DataSource = dt1;
            GridViewdetalle.DataBind();

        }
        protected void agregarow(object sender, EventArgs e)
        {
           
                table = (System.Data.DataTable)(Session["Tabla"]);
                row = table.NewRow();
                row["Serial_Nombre"] = Selectarticulo.Value;
                row["Detalle"] = txtobserva.Value.ToUpper().Trim();
                row["Destino"] = txtdestino.Value.ToUpper().Trim();
                table.Rows.Add(row);
                GridViewdetalle.DataSource = table;
                GridViewdetalle.DataBind();
                Session.Add("Tabla", table);
                nuevo();
                txtobserva.Value = "";
               

        }
        public void nuevo()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroNUEVO = Controlasql.ClistaNUEVONUMERObaja(bd);

                if (registroNUEVO.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroNUEVO.Tables[0];
                    txtN_acta.Value = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        txtN_acta.Value = (Convert.ToString(row["id"]));

                    }
                }

            }
            catch (Exception)
            {


            }

        }
        public void llenaubicacion()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroUbica = Controlasql.Clistaubicacion(bd);

                if (registroUbica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroUbica.Tables[0];
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
            catch (Exception e)
            {
                throw e;

            }
        }
        public void llenaarticulo()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosseriales = Controlasql.listaserial(bd);

                if (registrosseriales.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrosseriales.Tables[0];
                    Selectarticulo.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectarticulo.Items.Add(Convert.ToString(row["Nombre"]));
                        Selectarticulo.DataBind();
                    }

                }
                else
                {
                    Selectarticulo.DataSource = null;
                    Selectarticulo.DataBind();
                }
            }
            catch (Exception e)
            {
                throw e;

            }


        }
        public void llenaarea()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroarea = Controlasql.Clistaarea(bd);

                if (registroarea.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroarea.Tables[0];
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
            catch (Exception e)
            {
                throw e;

            }
        }
        public void Guardar(object sender, EventArgs e)//Guardar
        {
            DataTable dt = Session["Tabla"] as DataTable;
            if (dt.Rows.Count == 0)
            {
                string script = @"<script type='text/javascript'>
                            alert('La tabla no continiene ningun items');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

             
            }
            else
            {
                try 
                {
                    var registrosactas_baja = Controlasql.CcreaActabaja(txtN_acta.Value,
                        txtfecha.Value,Selectubicacion.Value,Selectarea.Value, Session["USUARIO"].ToString(),
                        Session["BD"].ToString());
                    if (registrosactas_baja > 0)
                    {
                        foreach (GridViewRow row in GridViewdetalle.Rows)
                        {
                             string serialtemp = row.Cells[1].Text;
                               string detallemant = row.Cells[2].Text.Trim();
                                string destino = row.Cells[3].Text;
                                 string test = serialtemp;
                                string[] palabras = test.Split('/');
                                string serial = palabras[0];
                                string nombrearticulo = palabras[1];
                                try
                                {
                                    var registros3 = Controlasql.CcreabajaArticulo(txtfecha.Value, serial, detallemant, destino, Session["USUARIO"].ToString(),txtN_acta.Value, Session["BD"].ToString());
                                    string script = @"<script type='text/javascript'>
                            alert('Acta OK');
                            
                        </script>";

                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


                                }
                                catch (Exception Ex)
                                {
                                    throw Ex;
                                }
                            }
                        
                            //aqui creamos el acta de mantenimiento

                        }


                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }
        }
        public void imprimir()
        {
            Imprime.Visible = true;
            mostrarreporte();

            // Response.Write("<script language=javascript>window.Print();</script>");

        }
    }
}