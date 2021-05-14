using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.RH
{
  
    public partial class RH : System.Web.UI.MasterPage
    {
        String profi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["USUARIO"] != null)
                {
                    profi = Session["perfil"].ToString();
                    Label2.Text = Session["USUARIO"].ToString();
                    Label1.Text = Session["USUARIO"].ToString();
                }
                if (Label2.Text == "")
                {
                    Response.Redirect("../../Login.aspx");
                }
                if (profi == "1")
                {
                    perfiles.InnerText = "ADMINISTRADOR";
                    //admin.Visible = false;
                    paneladmin.Visible = false;
                    Session["ROL"] = perfiles.InnerText;
                }
                if (profi == "2")
                {
                    perfiles.InnerText = "USUARIO";
                    admin.Visible = false;
                    inventario.Visible = false;
                    la14.Visible = false;
                    paneladmin.Visible = false;
                    recursos_humanos.Visible = false;
                    recuros_humanos2.Visible = true;
                    Session["ROL"] = perfiles.InnerText;
                    ADMON_ORDENM.Visible = false;
                }
                if (profi == "3")
                {
                    perfiles.InnerText = "LIDER PUNTO DE VENTA";
                    admin.Visible = false;
                    admincompventas.Visible = true;
                    inventario.Visible = false;
                    la14.Visible = false;
                    paneladmin.Visible = false;
                    recursos_humanos.Visible = false;
                    recuros_humanos2.Visible = true;
                    Session["ROL"] = perfiles.InnerText;
                    ADMON_ORDENM.Visible = false;
                }
                if (profi == "4")
                {
                    perfiles.InnerText = "COMPRAS";
                    inventario.Visible = false;
                    admin.Visible = false;
                    admincompventas.Visible = true;
                    la14.Visible = false;
                    paneladmin.Visible = false;
                    recursos_humanos.Visible = false;
                    recuros_humanos2.Visible = false;
                    Session["ROL"] = perfiles.InnerText;
                    ADMON_ORDENM.Visible = false;
                }
                if (profi == "5")
                {
                    perfiles.InnerText = "LA 14 DISTRIBUCIONES";
                    admin.Visible = false;
                    inventario.Visible = false;
                    admincompventas.Visible = false;
                    activos.Visible = false;
                    paneladmin.Visible = false;
                    Session["ROL"] = perfiles.InnerText;
                    ADMON_ORDENM.Visible = false;
                }
                if (profi == "6")
                {
                    perfiles.InnerText = "RECURSOS HUMANOS";
                    admin.Visible = false;
                    inventario.Visible = false;
                    admincompventas.Visible = false;
                    activos.Visible = true;
                    paneladmin.Visible = false;
                    recursos_humanos.Visible = true;
                    recuros_humanos2.Visible = true;
                    Session["ROL"] = perfiles.InnerText;
                    ADMON_ORDENM.Visible = false;
                }
            }
        }
        public void salir(object sender, EventArgs e)
        {
            Session.Remove("USUARIO");
            Response.Redirect("..//Login.aspx");
        }
    }
}