using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.COVID
{
    public partial class exitwebform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                salirx();
            }
        }
        public void salirx()
        {
            Session.Remove("TXTCC");
            Session.Remove("NOMBREC");
            Session.Remove("TELEFONO");
    
            Response.Redirect("Lectura.aspx");
        }
    }
}