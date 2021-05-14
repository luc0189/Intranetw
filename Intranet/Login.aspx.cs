using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using Intranet.Controlador;
using System.Text;

namespace Intranet
{
    public partial class Login : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        string valor1 = "";
        string valor2 = "";
        string valor3 = "";
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["USUARIO"] = txtususario.Value;
                Session["perfil"] = valor1;
                notificacion.Visible = false;
            }
        }
        public string getsha(string text)

        {
            SHA1CryptoServiceProvider sp = new SHA1CryptoServiceProvider();
            sp.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] re = sp.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("X2"));
            }

                return sb.ToString();
        }
        protected void validarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string contra = getsha(txtcontraseña.Value);
                var valida = sb.Cconsusuario(txtususario.Value.ToUpper(), contra, selectbd.Value);
                if (valida.Tables[0].Rows.Count > 0)
                {
                    dt = valida.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {

                        valor1 = Convert.ToString(row[1]);
                        valor2 = Convert.ToString(row[2]);
                        valor3 = Convert.ToString(row[3]);

                        Session["USUARIO"] = txtususario.Value.ToUpper();
                        Session["perfilid"] = valor1;
                        Session["perfilnombre"] = valor2;
                        Session["CC"]= valor3;

                        Session["BD"] = selectbd.Value;
                        Response.Redirect("Vista/1.aspx");

                    }

                }
                else
                {
                    txtcontraseña.Value = "";
                    txtususario.Value = "";
                    string script = @"<script type='text/javascript'>
                            alert('Error en usuario o contraseña');
                            
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
            catch (Exception ex)
            {
                String f = ex.Message;
                if (f== "ORA-12514: TNS:el listener no conoce actualmente el servicio solicitado en el descriptor de conexión\n")
                {
                    notificacion.Visible = true;
                    error.InnerText = "Conexion fallida con BD  -Excepcion: "+f;
                }
                else
                {
                    notificacion.Visible = true;
                    error.InnerText = f;
                }
                   
            }
               



            


        }


        
    }
}