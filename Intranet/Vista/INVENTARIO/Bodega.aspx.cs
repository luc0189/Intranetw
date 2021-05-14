
using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.INVENTARIO
{
  public partial class Bodega : System.Web.UI.Page
  {
    Cinventario cn = new Cinventario();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {

      }

    }
    public void NewBodega(object sender, EventArgs e)
    {
      try
      {
        var registros2 = cn.Ccreabodega(txtBodega.Value.ToUpper());
        if (registros2.Rows.Count > 0)
        {
          txtestado.InnerText = "Registro Ok";
          GridviewBodega.DataSource = registros2;
          GridviewBodega.DataBind();
        }
        else
        {
          txtestado.InnerText = "Error al Guardar los datos, Valide la informacion y vuelva a intentarlo";
        }

      }
      catch (Exception EC)
      {

        txtestado.InnerText ="Excepcion no Controlada: "+ EC.Message;
      }


    }

    protected void GridviewBodega_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
