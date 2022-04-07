using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.Sistema
{
    public partial class permisosLcs : System.Web.UI.Page
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        Controlasql sb = new Controlasql();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    llenamenus();
                    // Listarsaldos();
                    llenaRol();
                    if (Session["USUARIO"].ToString() == "")
                    {
                        Response.Redirect("../Login.aspx");
                    }
                    notificacion.Visible = false;
                    excepcion.Visible = false;
                    table = new System.Data.DataTable();
                    table.Columns.Add("id_nombre", typeof(System.String));
                    Session.Add("Tabla", table);
                }
                catch (Exception)
                {
                    Response.Redirect("..//..//Login.aspx");
                }
               
            }
        }
        protected void agregarow(object sender, EventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            row = table.NewRow();
            row["id_nombre"] = Selectmenuid.Value;
           
            table.Rows.Add(row);
            Gridviewpermisos.DataSource = table;
            Gridviewpermisos.DataBind();
            Session.Add("Tabla", table);
            Gridviewpermisos.EditIndex = -1;


            //This code allows the user to edit the information in the DataGrid.

            
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["Tabla"] as DataTable;
            dt1.Rows[index].Delete();
            Session["Tabla"] = dt1;

            Gridviewpermisos.DataSource = dt1;
            Gridviewpermisos.DataBind();

        }

        public void llenaRol()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosseriales = Controlasql.ClistaRoll(bd);

                if (registrosseriales.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrosseriales.Tables[0];
                    Selectrol.Items.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        Selectrol.Items.Add(Convert.ToString(row["NOMBRE"]));
                        Selectrol.DataBind();
                    }
                }
                else
                {
                    Selectrol.DataSource = null;
                    Selectrol.DataBind();

                }
            }
            catch (Exception ex)
            {
                excepcion.Visible = true;
                string dato = ex.Message;
                error.InnerText = dato;

            }



        }
        public void llenamenus()
        {
           try
                {
                    String bd = Session["BD"].ToString();
                    var registrosseriales = Controlasql.Clistadomenus(bd);

                    if (registrosseriales.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = registrosseriales.Tables[0];
                        Selectmenuid.Items.Clear();
                        
                        foreach (DataRow row in dt.Rows)
                        {
                            Selectmenuid.Items.Add(Convert.ToString(row["Menu"]));
                            Selectmenuid.DataBind();
                            
                        }



                    }
                    else
                    {
                        Selectmenuid.DataSource = null;
                    
                        Selectmenuid.DataBind();
                       
                    }
                }
                catch (Exception ex)
                {
                    excepcion.Visible = true;
                    string dato = ex.Message;
                    error.InnerText = dato;

                }


            
        }
        public void Listarpermisos()
        {

            try
            {
                String bd = Session["BD"].ToString();
                var registros16 = Controlasql.Clistadomenus(bd);

                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridviewpermisos.DataSource = registros16;
                    Gridviewpermisos.DataBind();
                }
                else
                {
                    Gridviewpermisos.DataSource = null;
                    Gridviewpermisos.DataBind();
                }
            }
            catch (Exception ex)
            {
                excepcion.Visible = true;
                string dato = ex.Message;
                error.InnerText = dato;
            }

        }

        public void btnconsulta_Click(object sender, EventArgs e)//Guardar
        {


            DataTable dt = Session["Tabla"] as DataTable;
            if (dt.Rows.Count == 0)
            {
                ahora = "nada en tabla";
            }
            else
            {
                foreach (GridViewRow row in Gridviewpermisos.Rows)
                {
                    string serialtemp = row.Cells[1].Text;
                    string dat = ahora;
                    string test = serialtemp;
                    string[] palabras = test.Split('/');
                    string idpermiso = palabras[0];
                    string nombrepermiso = palabras[1];

                    string[] Datorol = Selectrol.Value.Split('/');
                    string idrol = Datorol[0];
                    string nombrerol = Datorol[1];
                    //aqui ingresamos el famoso asigarticulo
                    String bd = Session["BD"].ToString();
                    try
                    {
                        
                        var valida = sb.Ccreapermiso(idpermiso,idrol,Session["USUARIO"].ToString(),bd);
                        if (valida.Rows.Count > 0)
                        {


                            
                            excepcion.Visible = false;
                            notificacion.Visible = true;
                            txtnotifica.InnerText = "Registro Exitoso";
                            
                        }
                        else
                        {
                            notificacion.Visible = false;
                            excepcion.Visible = true;
                            error.InnerText = "Error al Guardar";
                        }
                    }
                    catch (Exception exp)
                    {

                        notificacion.Visible = false;
                        excepcion.Visible = true;
                        string dato = exp.Message;
                        error.InnerText = dato;

                    }





                }


                string script = @"<script type='text/javascript'>
                            alert('Guadado con exito');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
               
            }

        }

        protected void Click(object sender, EventArgs e)
        {
            try
            {
              
                var refdatos = Controlasql.Clistadonombremenu(Session["BD"].ToString(), Session["perfilid"].ToString());
               
                   
                   
                    if (refdatos.Tables[0].Rows.Count > 0)
                    {

                    Gridviewmenus.DataSource = refdatos;
                    Gridviewmenus.DataBind();
                    }
                    else
                    {
                    Gridviewmenus.DataSource = null;
                    Gridviewmenus.DataBind();
                    }

              


            }
            catch (Exception ex)
            {

                excepcion.Visible = true;
                error.Visible = false;
                txtnotifica.InnerText = ex.Message;
            }
        }
    }
}