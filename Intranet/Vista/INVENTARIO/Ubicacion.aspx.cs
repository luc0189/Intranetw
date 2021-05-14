using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.INVENTARIO
{
  public partial class Ubicacion : System.Web.UI.Page
  {
    Cinventario cn = new Cinventario();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {

      }
    }

    protected void GridviewUser_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btncrea1_ServerClick(object sender, EventArgs e)
    {
     
        try
        {
          var registros2 = cn.CcreaInventario("1");
          if (registros2.Tables[0].Rows.Count > 0)
          {
            txtestado.InnerText = "Registro Ok";
          GridviewUbicaciones.DataSource = registros2;
          GridviewUbicaciones.DataBind();

          }
          else
          {
            txtestado.InnerText = "Error al Guardar los datos, Valide la informacion y vuelva a intentarlo";
          }

        }
        catch (Exception EC)
        {

          txtestado.InnerText = "Excepcion no Controlada: " + EC.Message;
        }

    }
  }
}
