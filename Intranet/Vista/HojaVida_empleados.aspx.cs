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
    public partial class HojaVida_empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenaempleados();
        }

        public void llenaempleados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroPROVEE = Controlasql.ctraeEmpleado(bd);

                if (registroPROVEE.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroPROVEE.Tables[0];
                    Select1.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        Select1.Items.Add(Convert.ToString(row["Proveedor"]));
                        Select1.DataBind();
                    }



                }
                else
                {
                    Select1.DataSource = null;
                    Select1.DataBind();
                }
            }
            catch (Exception)
            {


            }

        }
        protected void botonbusca_Click(object sender, EventArgs e)
        {
            string nombre = Select1.Value;
            
                 try
            {
                String bd = Session["BD"].ToString();
                var Registroactivos_cargo = Controlasql.ctraelistaactivos_asg(nombre,bd);

                if (Registroactivos_cargo.Tables[0].Rows.Count > 0)
                {

                    GridViewactivos_cargo.DataSource = Registroactivos_cargo;
                    GridViewactivos_cargo.DataBind();

                }
                else
                {
                    GridViewactivos_cargo.DataSource = null;
                    GridViewactivos_cargo.DataBind();
                }
            }
            catch (Exception)
            {


            }
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnestados_Click(object sender, EventArgs e)
        {

        }

        protected void btninsertarnovedad_Click(object sender, EventArgs e)
        {

        }

        protected void btnborra_Click(object sender, EventArgs e)
        {

        }
    }
}