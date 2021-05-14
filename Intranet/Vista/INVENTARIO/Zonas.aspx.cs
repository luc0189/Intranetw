using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.INVENTARIO
{
  
  public partial class Zonas : System.Web.UI.Page
  {
    Cinventario cn = new Cinventario();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {

      }
    }
    public void NewZonas(object sender, EventArgs e)
    {
      try
      {
        var registros2 = cn.CcreaZonas(txtzona.Value.ToUpper());
        if (registros2.Rows.Count > 0)
        {
          txtestado.InnerText = "Registro Ok";
          Gridviewzonas.DataSource = registros2;
            Gridviewzonas.DataBind();

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
    protected void Gridviewzonas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void subir(object sender, EventArgs e)
    {
      string folder = "/Vista/INVENTARIO/Datasource/";
      string file = Path.GetFileName(FileUpload1.FileName);

      SaveFile(folder, file);
    }
    public void SaveFile(string folder, string name)
    {
      if (FileUpload1.HasFile)
      {
        try
        {

          string path = HttpContext.Current.Server.MapPath(folder); //Path
          var pic = $"{folder}{name}";
     


          if (!System.IO.Directory.Exists(path))
          {
            System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
          }
         
          //var valida = cn.Ccrearformato(name, pathComplet, Session["USUARIO"].ToString(), Selectmodelo.Value, txtlabel.Value, Session["BD"].ToString());
          //if (valida.Rows.Count > 0)
          //{
          //  alerta.MessageBox(this, "Archivo guardado");


          //}
          //else
          //{
          //  alerta.MessageBox(this, "Error al Guardar");
          //}
          FileUpload1.SaveAs(Server.MapPath(folder) + name);
         
          string conexion = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =E:/info luis/Intranet/Intranet " + pic + "; Extended Properties = 'Excel 8.0;HDR=NO;IMEX=1'";
          OleDbConnection conector = default(OleDbConnection);
          conector = new OleDbConnection(conexion);
          conector.Open();
          OleDbCommand consulta = default(OleDbCommand);
          consulta = new OleDbCommand("select * from [Hoja1$]", conector);
          OleDbDataAdapter adaptador = new OleDbDataAdapter();
          adaptador.SelectCommand = consulta;
          DataSet ds = new DataSet();
          adaptador.Fill(ds);
          Gridviewzonas.DataSource = ds.Tables[0];
          txtestado.InnerText = "Estado: Archivo Subido!";
         

        }
        catch (Exception ex)
        {
          txtestado.InnerText = "Estado: A ocurrido una Excepcion no Controlada: " + ex.Message;
        }
      }
      else
      {
        txtestado.InnerText = "Estado: Seleccione un archivo";
      }
    }
  }
}
