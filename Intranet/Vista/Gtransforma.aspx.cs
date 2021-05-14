using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Gtransforma : System.Web.UI.Page
    {
        Ccodemas sbora = new Ccodemas();
        System.Data.DataTable table;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listatranspendientes();
                table = new System.Data.DataTable();
                table.Columns.Add("ID", typeof(System.String));
                table.Columns.Add("ARTICULO", typeof(System.String));
                table.Columns.Add("CANT1", typeof(System.String));
                table.Columns.Add("TRANSFORMACION", typeof(System.String));
                table.Columns.Add("CANT2", typeof(System.String));
                table.Columns.Add("DIF", typeof(System.String));
                table.Columns.Add("CCOSTO", typeof(System.String));
                Session.Add("Tabla", table);
            }

        }
        public void listatranspendientes()
        {
            try
            {
                String bd = Session["BD"].ToString();
                DataTable res2 = sbora.CListatransformaciones(bd);
                if (res2.Rows.Count > 0)
                {
                    GridViewNovedades.DataSource = res2;
                    GridViewNovedades.DataBind();
                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }

            }
            catch (Exception E)
            {
                alerta.MessageBox(this, "No se cargo el Listado de Activos. Excepcion: " + E.Message);
            }
            //

        }

        public void btnenviar_Click(object sender, EventArgs e)
        {
            GridViewRow gr = GridViewNovedades.SelectedRow;
            {
                string id = gr.Cells[1].Text;

                try
                {
                    string bd = Session["BD"].ToString();
                    var listado = sbora.CupdateTransformacion(id, "S", bd);
                    listatranspendientes();
                }
                catch (Exception ex)
                {
                    alerta.MessageBox(this, "Excepcion interna:" + ex.Message);
                }



            }




        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridViewNovedades.Rows)
            {
                string id = row.Cells[1].Text;
                string revisado = row.Cells[0].Text;

                try
                {
                    string bd = Session["BD"].ToString();
                    var listado = sbora.CupdateTransformacion(id, revisado, bd);

                }
                catch
                {

                }
                finally
                {
                    alerta.MessageBox(this, "se finalizo el procedimiento");
                }
            }




        }

        protected void Chk_CheckedChanged(object sender, EventArgs e)
        {
           

        }
        public void guardaitems(object sender, GridViewDeleteEventArgs e)
        {
          



            string bd = Session["BD"].ToString();
            foreach (GridViewRow row in GridViewNovedades.Rows)
            {
                string id = row.Cells[1].Text;
                string revisado = "S";
                CheckBox check = row.FindControl("Chk") as CheckBox;
                if (check.Checked)
                {
                    try
                    {
                        var listado = sbora.CupdateTransformacion(id, revisado, bd);

                        listatranspendientes();
                        alerta.MessageBox(this, "Guardado correctamente los items seleccionados");

                    }
                    catch (Exception ex)
                    {
                        alerta.MessageBox(this, "Excepcion interna:" + ex.Message);
                    }


                }
                else
                {
                    alerta.MessageBox(this, "no se realizo ningun cambio");
                }
               

            }
        }
        public void guardarcambios()
        {
            string bd = Session["BD"].ToString();
            foreach (GridViewRow row in GridViewNovedades.Rows)
            {
                string id = row.Cells[1].Text;
                string revisado = "S";
                CheckBox check = row.FindControl("Chk") as CheckBox;
                if (check.Checked)
                {
                    try
                    {
                        var listado = sbora.CupdateTransformacion(id, revisado, bd);

                        
                        alerta.MessageBox(this, "Guardado correctamente los items seleccionados");

                    }
                    catch (Exception ex)
                    {
                        alerta.MessageBox(this, "Excepcion interna:" + ex.Message);
                    }


                }

               

            }
            listatranspendientes();
            //string bd = Session["BD"].ToString();
            //foreach (GridViewRow row in GridViewNovedades.Rows)
            //{
            //    string id = row.Cells[1].Text;
            //    string revisado = "S";

            //    try
            //    {
            //        CheckBox check = row.FindControl("Chk") as CheckBox;

            //        if (check.Checked)
            //        {

            //            var listado = sbora.CupdateTransformacion(id, revisado, bd);

            //        } listatranspendientes();
            //        alerta.MessageBox(this, "Guardado correctamente los items seleccionados");


            //    }
            //    catch(Exception ex)
            //    {
            //        alerta.MessageBox(this, "Excepcion interna:" + ex.Message);
            //    }

            //}
        }

        protected void chkheader_CheckedChanged(object sender, EventArgs e)
        {
            //seleccionar todo
            bool a = ((CheckBox)GridViewNovedades.HeaderRow.FindControl("chkheader")).Checked;
            for (int i = 0; i<= GridViewNovedades.Rows.Count - 1; i++)
            {
                if (a == true)
                {
                    ((CheckBox)GridViewNovedades.Rows[i].FindControl("Chk")).Checked = true;
                }
                else if (a == false)
                {
                    ((CheckBox)GridViewNovedades.Rows[i].FindControl("Chk")).Checked = false;
                }
            }

        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            guardarcambios();
        }
    }
}