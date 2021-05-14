using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.INVENTARIO
{
  public partial class Diferencias : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        consultardife();
       
      }
    }
    public void consultardife()
    {
      try
      {
      
        var registros = ControlaSql.Clista_dif_conteos();
        if (registros.Tables.Count > 0)
        {
          GridViewDiferencias.DataSource = registros;
          GridViewDiferencias.DataBind();

        }
        else
        {
          GridViewDiferencias.DataSource = null;
          GridViewDiferencias.DataBind();
        }
      }
      catch (Exception ex)
      {
        alerta.MessageBox(this, $"{ex}");
        //  Response.Redirect("Exceptionnet.aspx");
      }
    }

    protected void click_VerArticulos(object sender, EventArgs e)
    {
      

      GridViewRow gwr = GridViewDiferencias.SelectedRow;
  
      String pzona = Page.Server.HtmlDecode(gwr.Cells[2].Text);
      txtzona.Value = pzona;
      try
      {

        var registros = ControlaSql.Clista_Dif_Items_conteos(pzona);
        if (registros.Tables.Count > 0)
        {
          Gridarticulos.DataSource = registros;
          Gridarticulos.DataBind();
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "vistaArticulos", "$('#vistaArticulos').modal();", true);

        }
        else
        {
          Gridarticulos.DataSource = null;
          Gridarticulos.DataBind();
        }
      }
      catch (Exception ex)
      {
        alerta.MessageBox(this, $"{ex}");
        //  Response.Redirect("Exceptionnet.aspx");
      }

    }

        protected void GridViewDiferencias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
      string Data = e.Values[0].ToString();

            try
            {
        var registros = ControlaSql.Cconteo_revisado(Data);
        if (registros > 0)
        {
          alerta.MessageBox(this, $"Conteo {Data} Revisado");
          consultardife();

        }
        else
        {
          alerta.MessageBox(this, $"No se aplico ningun cambio");
          consultardife();
        }
      }
            catch (Exception ex)
            {

        alerta.MessageBox(this, $"{ex}");
      }
        }
    }
}
