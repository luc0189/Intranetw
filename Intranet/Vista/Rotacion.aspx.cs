using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Rotacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void UploadButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        var registros = Controlasql.Crotacion(fechaini.Value, nits.Value);
        //        if (registros.Tables[0].Rows.Count > 0)
        //        {
        //            GridView1.DataSource = registros;
        //            GridView1.DataBind();

        //        }
        //        else
        //        {
        //            GridView1.DataSource = null;
        //            GridView1.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        txtestado.InnerText = $"excepcion no Controlada: {ex}";

        //    }
        //}
    }
}