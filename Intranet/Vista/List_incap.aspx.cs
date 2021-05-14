using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class List_incap : System.Web.UI.Page
    {
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                btncancelar.Visible = false;
                btnguardar.Visible = false;
                btnestados.Visible = false;
                cargarinfo();
                llenaempleados();
                txtidempleado.Disabled = true;
            }

        }

        public void txtdesact()
        {
            Selectempleado.Disabled = true;
            txtidempleado.Disabled = true;
            txtfechaini.Disabled = true;
            txtfechafin.Disabled = true;
            txtobserva.Disabled = true;
        }
        // CraeIncapacidad
        public void llenaempleados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroPROVEE = Controlasql.ctraeEmpleado(bd);

                if (registroPROVEE.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroPROVEE.Tables[0];
                    Selectempleado.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectempleado.Items.Add(Convert.ToString(row["Proveedor"]));
                        Selectempleado.DataBind();
                    }



                }
                else
                {
                    Selectempleado.DataSource = null;
                    Selectempleado.DataBind();
                }
            }
            catch (Exception)
            {


            }

        }
        public void cargarinfo()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.CtraeIncapacidad(bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {
                  
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

                throw;
            }
        }
        protected void GridViewdetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridViewdetalle.SelectedRow;
            txtidempleado.Value = gr.Cells[1].Text;
            Selectempleado.Value = gr.Cells[2].Text;
            txtfechaini.Value = gr.Cells[4].Text;
            txtfechafin.Value = gr.Cells[5].Text;
            txtobserva.Value = gr.Cells[6].Text;
            txtdesact();
            btnestados.Visible = true;
            btnborra.Visible = true;
         

        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            txtidempleado.Disabled = true;
            Selectempleado.Disabled = false;
            txtfechaini.Disabled = false;
            txtfechafin.Disabled = false;
            txtobserva.Disabled = false;
            btnguardar.Visible = true;
            btncancelar.Visible = true;
            btnestados.Visible = false;
            btnborra.Visible = false;
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            txtdesact();
            btncancelar.Visible = false;
            btnguardar.Visible = false;
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.Cupdateincapacidad(Selectempleado.Value,
                    txtobserva.Value.ToUpper().ToString(), txtfechaini.Value,
                    txtfechafin.Value, Session["USUARIO"].ToString(),txtidempleado.Value, Session["BD"].ToString());
                if (registros > 0)
                {
                    btnguardar.Visible = false;
                    btncancelar.Visible = false;
                    string script = @"<script type='text/javascript'>
                            alert('Guardado con Exito');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    cargarinfo();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnborra_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.cborraincapacidad(txtidempleado.Value, Session["BD"].ToString());
                if (registros > 0)
                {
                    btnguardar.Visible = false;
                    btncancelar.Visible = false;
                    string script = @"<script type='text/javascript'>
                            alert('Registro Borrado');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    cargarinfo();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void traenovedadesincapacidades()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosn = Controlasql.Ctraenovedadesincapacidades(txtidempleado.Value,bd);
                if (registrosn.Tables[0].Rows.Count > 0)
                {

                    GridViewNovedades.DataSource = registrosn;
                    GridViewNovedades.DataBind();
                   

                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnestados_Click(object sender, EventArgs e)
        {
            traenovedadesincapacidades();
            //ulnovedad.Style.Add("display", "block");
            //footer.Style.Add("display", "none");
        }

        protected void btninsertarnovedad_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.ccrea_novedadincapacidades(txtidempleado.Value,selectestado.Value,
                    txtnovedadincapacidad.Value.ToUpper(),ahora, Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                    btnguardar.Visible = false;
                    btncancelar.Visible = false;
                    string script = @"<script type='text/javascript'>
                            alert('Registro Guardado');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    traenovedadesincapacidades();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}