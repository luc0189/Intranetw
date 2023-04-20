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
    public partial class Acta_ent : System.Web.UI.Page
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                LocalReport localReport = ReportViewer1.LocalReport;
                localReport.ReportPath = "actas.rdlc";

                mostrarreporte();
                Imprime.Visible = false;
                llenapersonas();
                llenaubicacion();
                llenaarea();
                llenaarticulo();
                Nuevotercero.Visible = false;
                panelarea.Visible = false;
                panelubicacion.Visible = false;
                table = new System.Data.DataTable();
                table.Columns.Add("Serial_Nombre", typeof(System.String));
                table.Columns.Add("Cantidad", typeof(System.String));
                table.Columns.Add("Observacion", typeof(System.String));
                Session.Add("Tabla", table);
            }
        }
        private DataTable GetData(string acta)
        {
            DataTable dt = new DataTable();

            try
            {

            }
            catch (Exception ex)
            {

               alerta.MessageBox(this,$"Excepcion Interna: {ex}");
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
            row["Serial_Nombre"] = Selectarticulo.Value;
            row["Cantidad"] = canti.Value;
            row["Observacion"] = observatxt.Value.ToUpper();
            table.Rows.Add(row);
            GridViewdetalle.DataSource = table;
            GridViewdetalle.DataBind();
            Session.Add("Tabla", table);
            GridViewdetalle.EditIndex = -1;


            //This code allows the user to edit the information in the DataGrid.

            nuevo();
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
        public void Button3_Click(object sender, EventArgs e)//Guardar
        {


            DataTable dt = Session["Tabla"] as DataTable;
            if (dt.Rows.Count == 0)
            {
                ahora = "nada en tabla";
            }
            else
            {
                foreach (GridViewRow row in GridViewdetalle.Rows)
                {
                    string serialtemp = row.Cells[1].Text;
                    string detallecantidad = row.Cells[2].Text;
                    string detalleobserva = row.Cells[3].Text;
                    string dat = ahora;
                    string test = serialtemp;
                    string[] palabras = test.Split('/');
                    string serial = palabras[0];
                    string nombrearticulo = palabras[1];
                    //aqui ingresamos el famoso asigarticulo
                    try
                    {
                        var asigarti = Controlasql.ccreaasigarticulo(ahora, Session["BD"].ToString());
                    }
                    finally
                    {

                    }

                    //aqui verificamos que el articulo ya este asignado a alguien
                    try
                    {
                        String bd = Session["BD"].ToString();
                        var registrosfiscal = Controlasql.selectfiscal(serial, bd);
                        if (registrosfiscal.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                // si esta asignado entonces aplica un update a la tabla fiscal
                                var registros = Controlasql.cupdatefiscal(Select1.Value, Selectubicacion.Value,
                                    Selectarea.Value, serial, txtidacta.Value, Session["BD"].ToString());
                            }
                            catch (Exception ext)
                            {

                                throw ext;
                            }
                            finally
                            {

                            }

                        }
                        else
                        {
                            try
                            {
                                var registros2 = Controlasql.ccreafiscal(serial, Select1.Value, Session["USUARIO"].ToString(),
                                    Selectubicacion.Value, Selectarea.Value, ahora, txtidacta.Value, Session["BD"].ToString());
                                //aqui se guarda en fiscal y continua con el insert de detalleacta
                            }
                            finally
                            {

                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }


                    var registros3 = Controlasql.ccreadetalleacta(txtidacta.Value, serial, Select1.Value, Selectubicacion.Value
                        , Selectarea.Value,  detalleobserva, ahora, ahora, Session["USUARIO"].ToString(), Session["BD"].ToString());

                }


                string script = @"<script type='text/javascript'>
                            alert('Acta de Entrega OK');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                imprimir();
            }

        }
        public void imprimir()
        {
            Imprime.Visible = true;
            mostrarreporte();
            // Response.Write("<script language=javascript>window.Print();</script>");

        }
        private void nuevo()
        {
            observatxt.Value = "";
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("SELECT max(idacta+1) as idArt from detalleactas", cn);
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                txtidacta.Value = dr[0].ToString();
            }
            dr.Close();
            cn.Close();
        }

        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        public void llenapersonas()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select nomb FROM persona where esempleado=true", cn);
            dr = cm.ExecuteReader();
            Select1.Items.Clear();
            while (dr.Read())
            {
                Select1.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }
        public void nuevonumeroacta(object sender, EventArgs e)
        {
            nuevo();
            observatxt.Value = "";
            table = (System.Data.DataTable)(Session["Tabla"]);

            DataTable dt1 = Session["Tabla"] as DataTable;
            dt1.Rows.Clear();
            Session["Tabla"] = dt1;

            GridViewdetalle.DataSource = dt1;
            GridViewdetalle.DataBind();

        }

        public void llenaubicacion()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select nombUbica FROM ubicacion", cn);
            dr = cm.ExecuteReader();
            selectubicacion_nuevaarea.Items.Clear();
            Selectubicacion.Items.Clear();
            while (dr.Read())
            {
                Selectubicacion.Items.Add(dr[0].ToString());
                selectubicacion_nuevaarea.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }

        public void llenaarea()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select nombrearea FROM area", cn);
            dr = cm.ExecuteReader();
            Selectarea.Items.Clear();
            while (dr.Read())
            {
                Selectarea.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }
        public void llenaarticulo()
        {
            cn = new MySqlConnection();
            cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
            cn.Open();
            cm = new MySqlCommand("select CONCAT(serialArt, ' / ', nombreArt) As Nombre  FROM articulo WHERE inactivo=1", cn);
            dr = cm.ExecuteReader();
            Selectarticulo.Items.Clear();
            while (dr.Read())
            {
                Selectarticulo.Items.Add(dr[0].ToString());
            }
            dr.Close();
            cn.Close();

        }
        public void mostrarmenutercero(object sender, EventArgs e)
        {
            Nuevotercero.Visible = true;
        }
        public void ocultarmenutercero(object sender, EventArgs e)
        {
            Nuevotercero.Visible = false;
        }
        protected void CreaTercero_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CcreaTerceroempleado(txtccoNit.Value.ToUpper(),
                    txtNomb.Value.ToUpper(), txtdir.Value.ToUpper(), txttel.Value,
                    txtCiudad.Value.ToUpper(), txtEmail.Value.ToUpper(),
                    Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    Nuevotercero.Visible = false;


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
        protected void btncancelaubicacion_Click(object sender, EventArgs e)
        {
            panelubicacion.Visible = false;
        }

        protected void btncreaubicacion_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.CcreaUbicacion(txtUbicacion.Value.ToUpper(),
                    Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    llenaubicacion();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            panelubicacion.Visible = false;
        }

        protected void btncreaArea_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CCrea_area(selectubicacion_nuevaarea.Value,
                    txtArea.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    panelarea.Visible = false;
                    llenaarea();

                }
                else
                {

                }
            }
            catch (Exception exp)
            {
                throw exp;
            }

        }

        protected void btnmenuarea_Click(object sender, EventArgs e)
        {
            panelarea.Visible = true;
        }

        protected void btncancelapanelarea_Click(object sender, EventArgs e)
        {
            panelarea.Visible = false;
        }

        protected void btnmenuubicacion_Click(object sender, EventArgs e)
        {
            panelubicacion.Visible = true;
        }

        protected void btnimprime_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        protected void btncerrarimprime_Click(object sender, EventArgs e)
        {
            Imprime.Visible = false;
        }
    }
}