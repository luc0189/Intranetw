
using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.INVENTARIO
{
  public partial class Auditores : System.Web.UI.Page
  {
   
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        cant_conteos();
      }
    }

    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
      try
      {
        var registros = ControlaSql.Ccierraconteo(txtidconteo.Value);
        if (registros > 0)
        {
          alerta.MessageBox(this, "Conteo Cerrado");
          cant_conteos();
        }
        else
        {

        }

      }
      catch (Exception ex)
      {
        alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
      }
    }
    SqlConnection cn;
    SqlCommand cm;
    SqlDataReader dr;
    public void cant_conteos()
    {
      try
      {
        cn = new SqlConnection();
        cn.ConnectionString = "Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False";
        cn.Open();
        cm = new SqlCommand("select count(*) from invenfis where protejido=0", cn);
        dr = cm.ExecuteReader();
        lbl_abiertos.InnerText = "";
        while (dr.Read())
        {

          lbl_abiertos.InnerText = (dr[0].ToString());
        }

        


        dr.Close();
        cn.Close();
      }
      catch (Exception ex)
      {

        alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
      }
      try
      {
        cn = new SqlConnection();
        cn.ConnectionString = "Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False";
        cn.Open();
        cm = new SqlCommand("select count(*) from invenfis where protejido=1", cn);
        dr = cm.ExecuteReader();
        LabelConteosCerrados.InnerText = "";
        while (dr.Read())
        {

          LabelConteosCerrados.InnerText = (dr[0].ToString());
        }
        
        dr.Close();
        cn.Close();
      }
      catch (Exception ex)
      {

        alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
      }
      try
      {
        var registros = ControlaSql.Cconteosabiertos();

        DataTable dt = registros.Tables[0];
        if (registros.Tables[0].Rows.Count >= 1)
        {
          gridAbiertos.DataSource = registros;
          gridAbiertos.DataBind();
        }

      }
      catch (Exception e)
      {

        alerta.MessageBox(this, "Excepcion Interna: " + e.Message);
      }

      try
      {
        var registros = ControlaSql.Cconteoscerrados();

        DataTable dt = registros.Tables[0];
        if (registros.Tables[0].Rows.Count >= 1)
        {
          gridCerrados.DataSource = registros;
          gridCerrados.DataBind();
        }

      }
      catch (Exception e)
      {

        alerta.MessageBox(this, "Excepcion Interna: " + e.Message);
      }
    }
  }
}
