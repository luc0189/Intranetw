using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.COVID
{
    public partial class Signature : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static void UploadImage(string imageData)
        {
            using (FileStream fs = new FileStream(@"C:\\inetpub\\grado\\testpic.png", FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    bw.Write(Convert.FromBase64String(imageData));
                  bw.Close();
                }
            }
        }


    }
}