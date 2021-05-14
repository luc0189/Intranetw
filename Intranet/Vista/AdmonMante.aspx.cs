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
    public partial class AdmonMante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                normalestado();
                llenaubicacion();
                llenaarea();
                llenatipomantenimiento();

            }
        }
        public void normalestado()
        {
            btnguardar.Visible = true;

            btnNuevo.Visible = true;

        }

        public void nuevoestado()
        {

            btnguardar.Visible = true;
            btnNuevo.Visible = true;

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
                    var registros3 = Controlasql.Ccreaorden(Selectubicacion.Value, Selectarea.Value, 
                        Selecttipo.Value, txtDescripcion.Value.ToUpper(), var_stado, 
                        Session["USUARIO"].ToString(), Session["BD"].ToString());
                    if (registros3 > 0)
                    {
                        string script = @"<script type='text/javascript'>
                            alert('Registro exitoso');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                       
                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>
                            alert('No fue Posible guardar el Registro');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                      
                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
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
                var registrotipom = Controlasql.Clistaclasemantenimiento(bd);

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
       
        public void consultaasignados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridasignados(Session["USUARIO"].ToString(), Session["perfil"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewasignados.DataSource = registrosr;
                    GridViewasignados.DataBind();

                }
                else
                {
                    GridViewasignados.DataSource = null;
                    GridViewasignados.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }
        public void consultaradicados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridradicados(Session["USUARIO"].ToString(), Session["perfil"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewpendientes.DataSource = registrosr;
                    GridViewpendientes.DataBind();

                }
                else
                {
                    GridViewpendientes.DataSource = null;
                    GridViewpendientes.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
        }

        protected void btnbuscarpendientes_Click(object sender, EventArgs e)
        {
            consultaradicados();
        }
    }
}