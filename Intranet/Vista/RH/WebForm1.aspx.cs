using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.RH
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/dist/RhS/") + filename);
                    StatusLabel.Text = "Estado: Archivo Subido!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Estado: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}