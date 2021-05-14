using Intranet.Controlador;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class JobDelivery : System.Web.UI.Page
       
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                LocalReport localReport = ReportViewer1.LocalReport;
                localReport.ReportPath = "actas.rdlc";

                //mostrarreporte();
                Imprime.Visible = false;
                llenapersonas();
               // notificacion.Visible = false;
                //llenaubicacion();
                // llenaarea();
                //llenaarticulo();
                //Nuevotercero.Visible = false;
                // panelarea.Visible = false;
                //panelubicacion.Visible = false;
                table = new System.Data.DataTable();
                table.Columns.Add("Serial_Nombre", typeof(System.String));

                table.Columns.Add("Observacion", typeof(System.String));
                Session.Add("Tabla", table);
            }

        }
        private void ListActivosDelivery()
        {
           
            string test = SelectEmployeeDelivery.Value;
            string[] palabras = test.Split('/');
            string cc = Page.Server.HtmlDecode(palabras[0]);
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistDeployeeDelivery(cc,bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridDelivery.DataSource = registros;
                    GridDelivery.DataBind();
                }
                else
                {
                    GridDelivery.DataSource = null;
                    GridDelivery.DataBind();
                }
            }
            catch (Exception e)
            {
                notificacion.Visible = false;
                txtnotifica.InnerText = "" + e.Message;
            }
        }
        private void llenapersonas()
        {
            


            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.cEmployee( bd);

               
                if (registros.Tables[0].Rows.Count > 0)
                {

                    SelectEmployeeDelivery.Items.Clear();
                    SelectEmployeeReceives.Items.Clear();
                    foreach (DataRow row in registros.Tables[0].Rows)
                    {
                        SelectEmployeeDelivery.Items.Add(Convert.ToString(row["Employee"]));
                        SelectEmployeeDelivery.DataBind();
                        SelectEmployeeReceives.Items.Add(Convert.ToString(row["Employee"]));
                        SelectEmployeeReceives.DataBind();
                    }





                }
                else
                {
                    SelectEmployeeDelivery.DataSource = null;
                    SelectEmployeeReceives.DataSource = null;

                    SelectEmployeeDelivery.DataBind();
                    SelectEmployeeReceives.DataBind();
                 
                }

            }
            catch (Exception e)
            {
                notificacion.Visible=true;
                txtnotifica.InnerText = "" + e.Message;
            }
        }

        private DataTable GetData(string acta)
        {
            DataTable dt = new DataTable();
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraeactaentrega(acta, bd);
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

            //datasou
            DataTable dt = GetData(SelectEmployeeDelivery.Value);

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);

            //path
            ReportViewer1.LocalReport.ReportPath = "actas.rdlc";

            //param
            // ReportParameter[] rptparamet = new ReportParameter[]
            //{
            //   new ReportParameter("parm",txtidacta.Value)
            //};
            //refresh
            ReportViewer1.LocalReport.Refresh();
        }

        protected void agregarow(object sender, EventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            row = table.NewRow();
            row["Serial_Nombre"] = SelectEmployeeDelivery.Value;

            row["Observacion"] = SelectEmployeeReceives.Value.ToUpper();
            table.Rows.Add(row);
            GridViewdetalle.DataSource = table;
            GridViewdetalle.DataBind();
            Session.Add("Tabla", table);
            GridViewdetalle.EditIndex = -1;


            //This code allows the user to edit the information in the DataGrid.

            
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

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            ListActivosDelivery();
        }

        protected void GridDelivery_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridDelivery.SelectedRow;

            string serial = Page.Server.HtmlDecode(gr.Cells[2].Text);
            string observa = Page.Server.HtmlDecode(gr.Cells[3].Text);
           

          
            table = (System.Data.DataTable)(Session["Tabla"]);
            row = table.NewRow();
            row["Serial_Nombre"] = serial;
            row["Observacion"] = observa;
            table.Rows.Add(row);
            GridViewdetalle.DataSource = table;
            GridViewdetalle.DataBind();
            Session.Add("Tabla", table);
            GridViewdetalle.EditIndex = -1;
        }
    }
}