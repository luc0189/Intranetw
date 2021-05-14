using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.reportes
{
    public partial class PLANTILLA1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                tablero.Visible = false;
            }
        }

        protected void btn_crearbarrido_Click(object sender, EventArgs e)
        {
            tablero.Visible = true;
            Nombre_barrido.InnerText = codigo.Value;
        }

       protected void btnAgregar_Click(object sender, EventArgs e)
        {

            
                String g = "hola";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", g, false);
            }

        /** private DataTable GetData(string acta)
         {
             DataTable dt = new DataTable();
             string connex = System.Configuration.ConfigurationManager.ConnectionStrings["lcsystemConnectionString"].ConnectionString;
             using (SqlConnection cn = new SqlConnection(connex))
             {
                 SqlCommand cmd = new SqlCommand("PLISTAR_MANTENIMIENTO", cn);
                 // cmd.CommandType = CommandType.Text;
                 cmd.CommandType = CommandType.TableDirect;
                 cmd.Parameters.Add("@ID", SqlDbType.String).Value = acta;
                 SqlDataAdapter adp = new SqlDataAdapter(cmd);
                 adp.Fill(dt);

             }
             return dt;
         }
         private void mostrarreporte()
         {
             //reset
             ReportViewer1.Reset();

             //datasou
             DataTable dt = GetData(txtidacta.Value);
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
         }**/
    }
}