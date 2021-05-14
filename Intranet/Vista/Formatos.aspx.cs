
using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Formatos : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                resultRepeat();
              
            }
        }
       
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string folder = "";
            string file = Path.GetFileName(FileUploadControl.FileName);
            switch (Selectmodelo.Value)
            {
                case "S.S.T":
                    folder = "~/dist/SST/";
                    SaveFile(folder, file);
                    break;
                case "P.E.S.V":
                    folder = "~/dist/PESV/";
                    SaveFile(folder, file);
                    break;
                case "RRHH":
                    folder = "~/dist/RRHH/";
                    SaveFile(folder, file);
                    break;
                case "Correspondencia":
                    folder = "~/dist/Correspondencia/";
                    SaveFile(folder, file);
                    break;
                case "Plan_Contingencia":
                    folder = "~/dist/Plan_Contingencia/";
                    SaveFile(folder, file);
                    break;
                case "Covid_19":
                    folder = "~/dist/Covid_19/";
                    SaveFile(folder, file);
                    break;
                case "Examen_MA":
                    folder = "~/dist/Examen_MA/";
                    SaveFile(folder, file);
                    break;
                case "Plan_MA":
                    folder = "~/dist/Plan_MA";
                    SaveFile(folder, file);
                    break;
                case "CursosMA":
                    folder = "~/dist/CursosMA/";
                    SaveFile(folder, file);
                    break;
                case "Formatos_sanidad":
                    folder = "~/dist/Formatos_sanidad/";
                    SaveFile(folder, file);
                    break;
                default:
                    break;
            }
           

        }
        public void SaveFile(string folder, string name)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                  
                    string path = HttpContext.Current.Server.MapPath(folder); //Path
                  var  pic = $"{folder}{name}";
                    string[] palabras = pic.Split('~');
                    string pathComplet = palabras[1];

                   
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                    }
                    var valida = sb.Ccrearformato(name,pathComplet, Session["USUARIO"].ToString(),Selectmodelo.Value,txtlabel.Value, Session["BD"].ToString() );
                    if (valida.Rows.Count > 0)
                    {
                        alerta.MessageBox(this, "Archivo guardado");


                    }
                    else
                    {
                        alerta.MessageBox(this,"Error al Guardar");
                    }
                    FileUploadControl.SaveAs(Server.MapPath(folder) + name);
                    StatusLabel.Text = "Estado: Archivo Subido!";
                    resultRepeat();

                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Estado: A ocurrido una Excepcion no Controlada: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "Estado: Seleccione un archivo";
            }
        }

        public void resultRepeat()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("S.S.T",  bd);
                if (registros.Rows.Count > 0)
                {
                    GridView1.DataSource = registros;
                    GridView1.DataBind();
                    
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("P.E.S.V", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView2.DataSource = registros;
                    GridView2.DataBind();

                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("RRHH", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView3.DataSource = registros;
                    GridView3.DataBind();

                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("Correspondencia", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView4.DataSource = registros;
                    GridView4.DataBind();

                }
                else
                {
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try

            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("Plan_Contingencia", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView5.DataSource = registros;
                    GridView5.DataBind();

                }
                else
                {
                    GridView5.DataSource = null;
                    GridView5.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("Covid_19", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView6.DataSource = registros;
                    GridView6.DataBind();

                }
                else
                {
                    GridView6.DataSource = null;
                    GridView6.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("Examen_MA", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView7.DataSource = registros;
                    GridView7.DataBind();

                }
                else
                {
                    GridView7.DataSource = null;
                    GridView7.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("Plan_MA", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView8.DataSource = registros;
                    GridView8.DataBind();

                }
                else
                {
                    GridView8.DataSource = null;
                    GridView8.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("CursosMA", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView9.DataSource = registros;
                    GridView9.DataBind();

                }
                else
                {
                    GridView9.DataSource = null;
                    GridView9.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistFiles("Formatos_sanidad", bd);
                if (registros.Rows.Count > 0)
                {
                    GridView10.DataSource = registros;
                    GridView10.DataBind();

                }
                else
                {
                    GridView10.DataSource = null;
                    GridView10.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, $"{ex}");
                //  Response.Redirect("Exceptionnet.aspx");
            }
        }
    }

}