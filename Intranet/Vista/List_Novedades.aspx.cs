using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class List_Novedades : System.Web.UI.Page
    {
        string ahora = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Imprime.Visible = false;
            }

        }

        public void txtdesact()
        {
            
            txtfechaini.Disabled = true;
            txtfechafin.Disabled = true;
          
        }
        protected void ListaNovedades()
        {
            try
            {
                var userdb = Session["USUARIO"].ToString();
                if (userdb != null)
                {
                    String bd = Session["BD"].ToString();
                    var registros = Controlasql.listaNovedadesAdmon(txtfechaini.Value,txtfechafin.Value, bd);
                    if (registros.Tables[0].Rows.Count > 0)
                    {
                        GridView.DataSource = registros;
                        GridView.DataBind();
                    }
                    else
                    {
                        GridView.DataSource = null;
                        GridView.DataBind();
                    }
                }
               
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }

        protected void btnguardar_Click_Click(object sender, EventArgs e)
        {
            ListaNovedades();
        }

        public void Mostrarpop()
        {

            GridViewRow gwr = GridView.SelectedRow;

            String id = Page.Server.HtmlDecode(gwr.Cells[1].Text);
            var userdb = Session["USUARIO"].ToString();
            if (userdb != null)
            {
                try
                {
                    String bd = Session["BD"].ToString();
                    var registrosdetails = Controlasql.listNovedadesAdmonDetails(txtfechaini.Value, txtfechafin.Value, id, bd);
                    if (registrosdetails.Tables[0].Rows.Count > 0)
                    {
                        GridViewdetalle.DataSource = registrosdetails;
                        GridViewdetalle.DataBind();
                    }
                    else
                    {
                        GridViewdetalle.DataSource = null;
                        GridViewdetalle.DataBind();
                    }
                    Imprime.Visible=true;
                }
                catch (Exception ex)
                {
                    alerta.MessageBox(this, $"{ex}");
                    //  Response.Redirect("Exceptionnet.aspx");
                }

            }
           

        }

        protected void GridViewdetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mostrarpop();
        }

        protected void btncerrarimprime_Click(object sender, EventArgs e)
        {
            Imprime.Visible=false;
        }
    }
}