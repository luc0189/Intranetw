using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Reporte_recibo_mercancia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GridViewnovedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridViewnovedades.SelectedRow;
            //Session["idcompra"] = Page.Server.HtmlDecode(gr.Cells[1].Text);

           



        }

        protected void Btnir_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.Clista_rmercancia(txtidfactura.Value, bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {

                    GridViewnovedades.DataSource = registrosm;
                    GridViewnovedades.DataBind();
                }
                else
                {
                    GridViewnovedades.DataSource = null;
                    GridViewnovedades.DataBind();
                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }
            try
            {
                String bd = Session["BD"].ToString();
                var registrosm = Controlasql.Clista_devomercancia(txtidfactura.Value, bd);
                if (registrosm.Tables[0].Rows.Count > 0)
                {

                    GridViewnovedades2.DataSource = registrosm;
                    GridViewnovedades2.DataBind();
                }
                else
                {
                    GridViewnovedades2.DataSource = null;
                    GridViewnovedades2.DataBind();
                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }

        }
    }
}