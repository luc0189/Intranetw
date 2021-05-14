using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class recogidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listadorecogida();
        }
        protected void listadorecogida()
        {
            try
            {

                var registrosm = Controlasql.listaRecogida(selectccosto.Value);
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
                alerta.MessageBox(this, "Excepcion Interna:" + ex.Message);

            }
        }

     

        protected void btnenvia_Click(object sender, EventArgs e)
        {
            if (txtnombres.Value.Equals(" "))
            {
                alerta.MessageBox(this, "No se encuentra ningun Cajero con Efectivo");
            }
            else
            {
                try
                {
                    var registros = Controlasql.Cagregarecogida(selectccosto.Value, txtnombres.Value, txtvalo.Value, Session["USUARIO"].ToString());
                    if (registros > 0)
                    {
                        listadorecogida();
                        txtnombres.Value = "";
                        alerta.MessageBox(this, "Registro Exitoso");
                    }

                }
                catch (Exception ex)
                {
                    alerta.MessageBox(this, "Excepcion Interna" + ex.Message);
                }
            }
        }

        protected void Actualiza_Click(object sender, EventArgs e)
        {
            listadorecogida();
        }

        protected void GridViewnovedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridViewnovedades.SelectedRow;
              
            txtnombres.Value = Page.Server.HtmlDecode(gr.Cells[1].Text);//coment
        }
    }
}