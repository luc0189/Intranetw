using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.COVID
{
    public partial class Plan_E_Covid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NameValueCollection collection;
             String firma1;
            firma1 = TextBox1.Text + ".jpg";
             collection = Request.Form;
            //byte bytes = Convert.FromBase64String(collection.Split('/'));
            //ImageField imageFile = New FileStream(Server.MapPath((Convert.ToString("~/Imagen/") & firma1) + ""), FileMode.Create);
            //imageFile.write
            //ImageField.Write(bytes, 0, bytes.Length);
            //ImageField.Flush();
        }
    }
}