using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista.COVID
{
   
    public partial class WebForm1 : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                notificacion.Visible = false;
                if (Session["TXTCC"] != null && Session["NOMBREC"] != null)
                {
                    txtcc.Value = Session["TXTCC"].ToString();
                    txtname1.Value = Session["NOMBREC"].ToString();
                    txtcelular.Value = Session["TELEFONO"].ToString();
                    notificacion.Visible = false;
                }
                if (Session["TXTCC"] != null && Session["NOMBREC"] == null)
                {
                    txtcc.Value = Session["TXTCC"].ToString();
                    txtname1.Value = "";
                    txtcelular.Value = "";
                    notificacion.Visible = false;
                }
            }
          
        }
      
        protected void btnguardanuevo_Click(object sender, EventArgs e)
        {
            var pic = string.Empty;
            var folder = "~/dist/img/signature";
            string firma = ruta.Value;
            if (firma != null)
            {
                pic = FilesHelper.UploadPhoto(firma, folder, txtcc.Value);
                if (pic != "")
                    pic = $"{folder}/{pic}";
                string[] palabras = pic.Split('~');
                string urll = palabras[1];
                try
                {
                    String bd = Session["BD"].ToString();
                    var valida = sb.Ccrearfirma(txtcc.Value, txtname1.Value.ToUpper(), Select.Value.ToUpper(),txtcelular.Value,urll , bd);
                    if (valida.Rows.Count > 0)
                    {
                        notificacion.Visible = true;
                        alertant.InnerText = "Registro guardado";
                       Session["TXTCC"] = txtcc.Value ;
                        txtname1.Value = "";
                        txtcelular.Value = "";
                        Select.Value = "";
                    }
                    else
                    {
                        txtname1.Value = "Error al Guardar";
                    }
                }
                catch (Exception ex)
                {
                    notificacion.Visible = true;
                    alertant.InnerText = ex.Message;
                }

                // hhtps://nombreservidor.com/fdist/img/134.png
            }
        }

        protected void btncierra(object sender, EventArgs e)
        {
            Session.Remove("TXTCC");
            Session.Remove("NOMBREC");
            Session.Remove("TELEFONO");
            Response.Redirect("Lectura.aspx");
        }
    }
 
    public static class FilesHelper
    {
        public static string UploadPhoto(string file, string folder, string txtcc)
        {
            //string path = folder;
            //string pic = string.Empty;
            string imageName = "";
            if (file != null)
            {
              string path = HttpContext.Current.Server.MapPath(folder); //Path

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                imageName = txtcc + ".png";

                //set the image path
                string imgPath = Path.Combine(path, imageName);

                string convert = file.Replace("data:image/png;base64,", String.Empty);
                byte[] imageBytes = Convert.FromBase64String(convert);

                File.WriteAllBytes(imgPath, imageBytes);

                return imageName;
            }

            return "";
        }
      
    }
}