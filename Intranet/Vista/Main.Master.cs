using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Main : System.Web.UI.MasterPage
    {
      
        DataTable dt = null;
        String profi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Verifica si la sesión ha expirado antes de acceder a cualquier variable de sesión
                if (Session["USUARIO"] == null || Session["BD"] == null)
                {
                    string mensaje = "Se ha terminado su sesión";
                    string script = $@"<script type='text/javascript'>
                    alert('Error: {mensaje}');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    Response.Redirect("~/Login.aspx");
                    return;
                }

                try
                {
                    titlecosto.Text = Session["salaventas"].ToString();
                    ListarCumpleñeros();

                    profi = Session["perfil"].ToString();
                    Label2.Text = Session["USUARIO"].ToString();
                    perfiles.InnerText = Session["perfilnombre"].ToString();
                    labelcc.InnerText = Session["CC"].ToString();
                    traedatos(Session["CC"].ToString());

                    if (Label2.Text == "")
                    {
                        // Puedes redirigir aquí si lo deseas
                        // Response.Redirect("../Login.aspx");
                    }

                    try
                    {
                        var refdatos = Controlasql.Clistamenuid(Session["BD"].ToString(), Session["perfilid"].ToString());

                        if (refdatos.Tables[0].Rows.Count > 0)
                        {
                            notificacion.Visible = false;

                            foreach (DataRow row in refdatos.Tables[0].Rows)
                            {
                                string idControl = row[0].ToString();

                                Control control = FindControlRecursivo(this, idControl);
                                if (control != null)
                                {
                                    control.Visible = true;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string mensaje = System.Web.HttpUtility.JavaScriptStringEncode(ex.Message);
                        string script = $@"<script type='text/javascript'>
                    alert('Error: {mensaje}');
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                        txtnotifica.InnerText = ex.Message;
                    }
                }
                catch (Exception)
                {
                    // Si ocurre cualquier excepción, redirige al login
                    Response.Redirect("~/Login.aspx");
                }
            }
            
}
        public Control FindControlRecursivo(Control root, string id)
        {
            if (root.ID == id)
                return root;

            foreach (Control child in root.Controls)
            {
                Control result = FindControlRecursivo(child, id);
                if (result != null)
                    return result;
            }

            return null;
        }
        public void salir(object sender, EventArgs e)
        {
            Session.Remove("USUARIO");
            Session.Remove("BD");
            Session.Remove("perfilid");
            Session.Remove("perfil");
            Session.Remove("perfiLnombre");
            Session.Remove("idcompra");
            Response.Redirect("../Login.aspx");
        }
        protected void ListarCumpleñeros()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clistacumpleañeros();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {

                        hay_cumpleañeros.Text = Convert.ToString(row[2]) + " y Otros mas cumplen Años hoy";
                    }
                }
                else
                {
                    hay_cumpleañeros.Text = "No hay Cumpleañeros por Hoy";
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                string mensaje = System.Web.HttpUtility.JavaScriptStringEncode(ex.Message);
                string script = $@"<script type='text/javascript'>
                    alert('Error: {mensaje}');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            }

        }
        public void traedatos(string cc)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.perfil(cc, Session["BD"].ToString());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {

                        byte[] misdatos = new byte[0];
                        misdatos = (byte[])row[5];

                        string cadena = Encoding.UTF8.GetString(misdatos);
                        // var fotook = Convert.ToBase64String((byte[])row[5]);
                        fotoperfil.Src = cadena;

                       

                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                alerta.Equals(this, "excepcion: " + e.Message);
            }
        }
    }
}