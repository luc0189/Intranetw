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
    public partial class _1 : System.Web.UI.Page
    {
        DataTable dt = null;
        String profi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                   
                    notificacion.Visible = false;
                 
           
                  

                    notificacion.Visible = false;
                    excepcion.Visible = false;
                
                 
                

                if (Session["USUARIO"] != null)
                {
                    profi = Session["perfil"].ToString();
                    notificacion.Visible = false;
                   
                }
               
               
              
               
            }
        }

  
    }
}