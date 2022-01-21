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
    System.Data.DataTable table;
    System.Data.DataRow row;
    protected void Page_Load(object sender, EventArgs e)
    {
      table = new System.Data.DataTable();
      table.Columns.Add("articuloID", typeof(System.String));
      table.Columns.Add("detalle", typeof(System.String));
      table.Columns.Add("CANT_CONTEO1", typeof(System.String));
      table.Columns.Add("CANT_CONTEO2", typeof(System.String));
      table.Columns.Add("DIF", typeof(System.String));
     
      Session.Add("Tabla", table);
      if (!Page.IsPostBack)
      {
        consultardife();
        table = new System.Data.DataTable();
        table.Columns.Add("articuloID", typeof(System.String));
        table.Columns.Add("detalle", typeof(System.String));
        table.Columns.Add("CANT_CONTEO1", typeof(System.String));
        table.Columns.Add("CANT_CONTEO2", typeof(System.String));
        table.Columns.Add("DIF", typeof(System.String));
        
        Session.Add("Tabla", table);
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
          this.Page.Session["ds"] = registros;
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

        protected void Gridarticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridarticulos.EditIndex = e.NewEditIndex;
            Gridarticulos.DataSource = this.Page.Session["ds"];
            Gridarticulos.DataBind();
    }
    }
}
