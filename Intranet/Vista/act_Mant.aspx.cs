using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WebForms;

namespace Intranet.Vista
{
    public partial class act_Mant : System.Web.UI.Page
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
                llenapersonas();
                llenaarticulo();
                Nuevotercero.Visible = false;
                Selectarticulodiv.Visible = false;
                Imprime.Visible = false;
                table = new System.Data.DataTable();
                table.Columns.Add("Serial_Nombre", typeof(System.String));
                table.Columns.Add("Tipo_Mant", typeof(System.String));
                table.Columns.Add("Detalle", typeof(System.String));
                table.Columns.Add("$_Mano_Obra", typeof(System.String));
                table.Columns.Add("Repuestos", typeof(System.String));
                table.Columns.Add("#_Externo", typeof(System.String));
                table.Columns.Add("$_Repuestos", typeof(System.String));
                table.Columns.Add("Garantia", typeof(System.String));
                table.Columns.Add("Clase_M", typeof(System.String));

                Session.Add("Tabla", table);
            }
        }
      
        private DataTable GetData(string acta)
        {
            DataTable dt = new DataTable();
            try
            {
                
                     String bd = Session["BD"].ToString();
                var registrosseriales = Controlasql.ctraeactamantenimiento(acta,bd);

                if (registrosseriales.Tables[0].Rows.Count > 0)
                {
                   dt = registrosseriales.Tables[0];
                    
                }
              
            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, $"Excepcion Interna: {ex.Message}");
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
        }

        public void llenapersonas()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroPROVEE = Controlasql.ClistaPROVEEDORES(bd);

                if (registroPROVEE.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroPROVEE.Tables[0];
                    SelectProveedor.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectProveedor.Items.Add(Convert.ToString(row["nomb"]));
                        SelectProveedor.DataBind();
                    }



                }
                else
                {
                    SelectProveedor.DataSource = null;
                    SelectProveedor.DataBind();
                }
            }
            catch (Exception)
            {


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

                alerta.MessageBox(this, $"{e}");
            }


        }
        public void nuevonumeroacta(object sender, EventArgs e)
        {
            nuevo();

            SelectProveedor.Value = "QUIEN REALIZA MANTENIMIENTO";
            OBSERVACIONG.Value = "";
            Selectarticulo.Value = "SELECCIONE ARTICULO";
            valorManObra.Value = "0";
            txtRepuestos.Value = "";
          
            V_repuestos.Value = "0";
            table = (System.Data.DataTable)(Session["Tabla"]);

            DataTable dt1 = Session["Tabla"] as DataTable;
            dt1.Rows.Clear();
            Session["Tabla"] = dt1;

            GridViewdetalle.DataSource = dt1;
            GridViewdetalle.DataBind();
        }
        public void nuevo()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroNUEVO = Controlasql.ClistaNUEVONUMEROACTA(bd);

                if (registroNUEVO.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroNUEVO.Tables[0];
                    txtidacta.Value = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        txtidacta.Value=(Convert.ToString(row["id"]));
                        
                    }
                    }
                
            }
            catch (Exception)
            {


            }

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
            if (Selectarticulo.Visible == false)
            {
                table = (System.Data.DataTable)(Session["Tabla"]);
            row = table.NewRow();
            row["Serial_Nombre"] = clasetrabajo.Value;
            row["Tipo_Mant"] = SelecttipoMant.Value;
            row["Detalle"] = txtobserva.Value.ToUpper().Trim();
            row["$_Mano_Obra"] = valorManObra.Value.Trim();
            row["Repuestos"] = txtRepuestos.Value.ToUpper().Trim();
            row["#_Externo"] = Textnumeroexterno.Value.ToUpper().Trim();
            row["Garantia"] = Textgarantia.Value.ToUpper().Trim();
            row["$_Repuestos"] = V_repuestos.Value.Trim();
            row["Clase_M"] = clasetrabajo.Value.Trim();
            table.Rows.Add(row);
            GridViewdetalle.DataSource = table;
            GridViewdetalle.DataBind();
            Session.Add("Tabla", table);
            nuevo();
            txtobserva.Value = "";
            valorManObra.Value = "0";
            txtRepuestos.Value = "";
            Textnumeroexterno.Value = "";
            V_repuestos.Value = "0";
                                
                }
            else
            {
                table = (System.Data.DataTable)(Session["Tabla"]);
                row = table.NewRow();
                row["Serial_Nombre"] = Selectarticulo.Value;
                row["Tipo_Mant"] = SelecttipoMant.Value;
                row["Detalle"] = txtobserva.Value.ToUpper();
                row["$_Mano_Obra"] = valorManObra.Value.Trim();
                row["Repuestos"] = txtRepuestos.Value.ToUpper();
                row["#_Externo"] = Textnumeroexterno.Value.ToUpper().Trim();
                row["Garantia"] = Textgarantia.Value.ToUpper().Trim();
                row["$_Repuestos"] = V_repuestos.Value.Trim();
                row["Clase_M"] = clasetrabajo.Value.Trim();
                table.Rows.Add(row);
                GridViewdetalle.DataSource = table;
                GridViewdetalle.DataBind();
                Session.Add("Tabla", table);
                GridViewdetalle.EditIndex = -1;
                  nuevo();
                        }
            }
        public void Guardar(object sender, EventArgs e)//Guardar
        {
         DataTable dt = Session["Tabla"] as DataTable;
            if (dt.Rows.Count == 0)
            {
                txtahora.InnerText = "La tabla no continiene ningun items";
            }
            else
            {
                try
                {
                    var registrosapruebaasig = Controlasql.ccreaaprueba_asignac(txtidacta.Value, SelectProveedor.Value, OBSERVACIONG.Value,
                   FECHAMANT.Value, Session["USUARIO"].ToString(), "", "", Session["BD"].ToString());
                    if (registrosapruebaasig > 0)
                    {
                        foreach (GridViewRow row in GridViewdetalle.Rows)
                        {
                            string clasemante = row.Cells[10].Text;
                            if (clasemante == "ACTIVOS FIJOS")
                            {
                                string serialtemp = row.Cells[2].Text;
                                string tipomant = row.Cells[3].Text;
                                string detallemant = row.Cells[4].Text.Trim();
                                int mano_obra = Convert.ToInt32(row.Cells[5].Text);
                                string r_utilizados = row.Cells[6].Text.Trim();
                                string nexterno = row.Cells[7].Text.Trim();
                                int v_repuestos = Convert.ToInt32(row.Cells[8].Text);
                                string garant = row.Cells[9].Text;

                                string dat = ahora;
                                string test = serialtemp;
                                string[] palabras = test.Split('/');
                                string serial = palabras[0];
                                string nombrearticulo = palabras[1];
                                try
                                {
                                    var registros3 = Controlasql.Ccrea_detalles_mant_conArticulo(txtidacta.Value, serial,
                                        r_utilizados, mano_obra, v_repuestos, detallemant, tipomant,
                                        clasemante, garant, nexterno, Session["BD"].ToString());
                                    string script = @"<script type='text/javascript'>
                            alert('Acta de Mantenimiento OK');
                            
                        </script>";

                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


                                }
                                catch (Exception Ex)
                                {
                                    throw Ex;
                                }
                            }
                            else
                            {
                                string serialtemp = row.Cells[2].Text;
                                string tipomant = row.Cells[3].Text;
                                string detallemant = row.Cells[4].Text.Trim();
                                int mano_obra = Convert.ToInt32(row.Cells[5].Text);
                                string r_utilizados = row.Cells[6].Text.Trim();
                                string nexterno = row.Cells[7].Text.Trim();
                                int v_repuestos = Convert.ToInt32(row.Cells[8].Text);
                                string garant = row.Cells[9].Text;

                                string dat = ahora;
                                string test = serialtemp;

                                try
                                {
                                    var registros3 = Controlasql.ccreadeta_Act_Mant_Na(txtidacta.Value, r_utilizados, mano_obra
                                        , v_repuestos, detallemant, tipomant, clasemante, garant, nexterno, Session["BD"].ToString());
                                    if (registros3 > 0)
                                    {
                                        string script = @"<script type='text/javascript'>
                            alert('Acta de Mantenimiento OK');
                            
                        </script>";

                                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                                    }
                                }
                                catch (Exception exp)
                                {
                                    throw exp;
                                }
                            }
                            //aqui creamos el acta de mantenimiento

                        }


                        imprimir();
                    }
                }
                catch (Exception ex)
                {

                    alerta.MessageBox(this,$"Excepcion Interna: {ex}");
                }
               
              
            }
        }
        public void imprimir()
        {
            Imprime.Visible = true;
            mostrarreporte();

            // Response.Write("<script language=javascript>window.Print();</script>");

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
                var registros = Controlasql.CcreaTercero(txtccoNit.Value.ToUpper(), txtNomb.Value.ToUpper(), txtdir.Value.ToUpper(),
                    txttel.Value, txtCiudad.Value.ToUpper(), txtEmail.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    Nuevotercero.Visible = false;
                    llenapersonas();

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
        protected void GridViewdetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            table = (System.Data.DataTable)(Session["Tabla"]);
            DataTable dt1 = Session["Tabla"] as DataTable;
            GridViewdetalle.EditIndex = e.NewEditIndex;
            Session["Tabla"] = dt1;
            GridViewdetalle.DataSource = dt1;
            GridViewdetalle.DataBind();
        }
        protected void GridViewdetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            DataTable dt1 = Session["Tabla"] as DataTable;
            GridViewdetalle.EditIndex = -1;
            Session["Tabla"] = dt1;
            GridViewdetalle.DataSource = dt1;
            GridViewdetalle.DataBind();
            //Bind data to the GridView control.

        }
        protected void GridViewdetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            DataTable dt1 = Session["Tabla"] as DataTable;
            //Update the values.
            GridViewRow row = GridViewdetalle.Rows[e.RowIndex];
            dt1.Rows[row.DataItemIndex]["Serial_Nombre"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
            dt1.Rows[row.DataItemIndex]["Tipo_Mant"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dt1.Rows[row.DataItemIndex]["Detalle"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
            dt1.Rows[row.DataItemIndex]["$_Mano_Obra"] = ((TextBox)(row.Cells[5].Controls[0])).Text;
            dt1.Rows[row.DataItemIndex]["Repuestos"] = ((TextBox)(row.Cells[6].Controls[0])).Text;
            dt1.Rows[row.DataItemIndex]["#_Externo"] = ((TextBox)(row.Cells[7].Controls[0])).Text;
            dt1.Rows[row.DataItemIndex]["$_Repuestos"] = ((TextBox)(row.Cells[8].Controls[0])).Text;
            //Reset the edit index.
            GridViewdetalle.DataSource = dt1;
            GridViewdetalle.EditIndex = -1;
            GridViewdetalle.DataBind();
           

        }
        protected void btninsertar_Click(object sender, EventArgs e)
        {
            if (Selectarticulo.Visible == false)
            {
                table = (System.Data.DataTable)(Session["Tabla"]);
                row = table.NewRow();
                row["Serial_Nombre"] = clasetrabajo.Value;
                row["Tipo_Mant"] = SelecttipoMant.Value;
                row["Detalle"] = txtobserva.Value.ToUpper();
                row["Repuesto"] = txtRepuestos.Value.ToUpper();
                row["Garantia"] = Textgarantia.Value;
                table.Rows.Add(row);
                GridViewdetalle.DataSource = table;
                GridViewdetalle.DataBind();
                Session.Add("Tabla", table);
                GridViewdetalle.EditIndex = -1;
               
            }
            else
            {
                table = (System.Data.DataTable)(Session["Tabla"]);
                row = table.NewRow();
                row["Serial_Nombre"] = Selectarticulo.Value;
                row["Tipo_Mant"] = SelecttipoMant.Value;
                row["Detalle"] = txtobserva.Value.ToUpper();
                row["Repuesto"] = txtRepuestos.Value.ToUpper();
                row["Garantia"] = Textgarantia.Value;
                table.Rows.Add(row);
                GridViewdetalle.DataSource = table;
                GridViewdetalle.DataBind();
                Session.Add("Tabla", table);
                GridViewdetalle.EditIndex = -1;
               
            }



            //This code allows the user to edit the information in the DataGrid.

        }

        public void mostrarselect(object sender, EventArgs e)
        {

            Selectarticulodiv.Visible = true;
            clasetrabajo.Value = "ACTIVOS FIJOS";
        }
        public void mostrarinputelectrico(object sender, EventArgs e)
        {
            Selectarticulodiv.Visible = false;
            clasetrabajo.Value = "ELECTRICO";
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            Selectarticulodiv.Visible = true;
        }
        protected void btnselectelectrico_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "ELECTRICO";
            Selectarticulodiv.Visible = false;

        }

        protected void btnobracivil_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "OBRA CIVIL";
            Selectarticulodiv.Visible = false;
        }

        protected void btnornamentacion_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "ORNAMENTACION";
            Selectarticulodiv.Visible = false;
        }

        protected void btnPintura_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "PINTURA";
            Selectarticulodiv.Visible = false;
        }

        protected void btnactivosfijos_Click(object sender, EventArgs e)
        {
            clasetrabajo.Value = "ACTIVOS FIJOS";
            Selectarticulodiv.Visible = true;
        }

        protected void btncerrarimprime_Click(object sender, EventArgs e)
        {
            Imprime.Visible = false;
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            imprimir();
        }
    }
}