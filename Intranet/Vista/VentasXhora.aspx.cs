using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista.Documentos
{
    public partial class VentasXhora : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ListaraDATOS(object sender, EventArgs e)
        {
            try
            {
                var registrosv13 = Controlasql.listaventaXhora13(txtfechaini.Value);
                if (registrosv13.Tables[0].Rows.Count > 0)
                {
                    Gridsuper13.DataSource = registrosv13;
                    Gridsuper13.DataBind();
                }
                else
                {
                    Gridsuper13.DataSource = null;
                    Gridsuper13.DataBind();
                }
                var regtotal16 = Controlasql.listaventa16total(txtfechaini.Value);
                if (regtotal16.Tables[0].Rows.Count > 0)
                {
                    GridViewtotal.DataSource = regtotal16;
                    GridViewtotal.DataBind();
                }
                var regtotal13 = Controlasql.listaventa13total(txtfechaini.Value);
                if (regtotal13.Tables[0].Rows.Count > 0)
                {
                    GridViewtotal13.DataSource = regtotal13;
                    GridViewtotal13.DataBind();
                }
                var regtotalversa = Controlasql.listaventaversatotal(txtfechaini.Value);
                if (regtotalversa.Tables[0].Rows.Count > 0)
                {
                    GridViewtotalversa.DataSource = regtotalversa;
                    GridViewtotalversa.DataBind();
                }
                var registrosv16 = Controlasql.listaventaXhora(txtfechaini.Value,Session["CCOSTO"].ToString());
                if (registrosv16.Tables[0].Rows.Count > 0)
                {
                    Gridsuper16.DataSource = registrosv16;
                    Gridsuper16.DataBind();
                }
                else
                {
                    Gridsuper16.DataSource = null;
                    Gridsuper16.DataBind();
                }
                var registrosvVERSA = Controlasql.listaventaXhoraVERSA(txtfechaini.Value);
                if (registrosvVERSA.Tables[0].Rows.Count > 0)
                {
                    GridsuperVERSA.DataSource = registrosvVERSA;
                    GridsuperVERSA.DataBind();
                }
                else
                {
                    GridsuperVERSA.DataSource = null;
                    GridsuperVERSA.DataBind();
                }
                var registrosCiudadela = Controlasql.listaventaXhoraCiudadela(txtfechaini.Value);
                if (registrosCiudadela.Tables[0].Rows.Count > 0)
                {
                    GridViewCiuaudadela.DataSource = registrosCiudadela;
                    GridViewCiuaudadela.DataBind();
                }
                else
                {
                    GridViewCiuaudadela.DataSource = null;
                    GridViewCiuaudadela.DataBind();
                }
                var registrosCiudadelatotal = Controlasql.listadoventaCiudadelatotal(txtfechaini.Value);
                if (registrosCiudadelatotal.Tables[0].Rows.Count > 0)
                {
                    GridView2ciudaela.DataSource = registrosCiudadelatotal;
                    GridView2ciudaela.DataBind();
                }
                else
                {
                    GridView2ciudaela.DataSource = null;
                    GridView2ciudaela.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
        public void btImprimir_Click(object sender, EventArgs e)
        {
              Response.Write("<script language=javascript>window.Print();</script>");
        }
    }
}