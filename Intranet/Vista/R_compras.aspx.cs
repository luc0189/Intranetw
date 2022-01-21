using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class R_compras : System.Web.UI.Page
    {
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //listado_ordencompra();

            }
        }
        protected void btnotro(object sender, EventArgs e)
        {

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                var registrosm = ControlaSql.Clista_orden_compra(Ltipo.Value,Lnumero.Value);
                if (registrosm.Tables[0].Rows.Count > 0)
                {

                    GridviewCompra.DataSource = registrosm;
                    GridviewCompra.DataBind();
                }
                else
                {
                    GridviewCompra.DataSource = null;
                    GridviewCompra.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna:" + ex.Message);

            }

        }
     
        protected void listado_ordencompra()
        {
            
        }

        protected void GridviewCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = GridviewCompra.SelectedRow;
            Session["tipoOC"] = Page.Server.HtmlDecode(gr.Cells[1].Text);
            Session["numeroOC"] = Page.Server.HtmlDecode(gr.Cells[2].Text);
            Session["numeroitems"] = Page.Server.HtmlEncode(gr.Cells[9].Text);
          
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.CValidaFactura(Session["numeroOC"].ToString(), Ltipo.Value, bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    var validador = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        validador = Convert.ToInt32(row[0]);

                    }
                    if (validador != 0)
                    {
                        Response.Redirect("recibomercancia/Rmercancia.aspx");
                    }
                    else
                    {
                        try
                        {
                            var Registroitems = Controlasql.Ccreanofactura(Session["tipoOC"].ToString(), Session["numeroOC"].ToString(), Session["USUARIO"].ToString(), bd);
                            var regist = Controlasql.CValidaFactura(Session["numeroOC"].ToString(), Ltipo.Value, bd);
                            if (regist.Tables[0].Rows.Count > 0)
                            {
                                dt = regist.Tables[0];
                                var validador2 = 0;
                                foreach (DataRow row in dt.Rows)
                                {
                                    validador2 = Convert.ToInt32(row[0]);

                                }                         
                                
                                   
                                var registrosm = ControlaSql.Clista_Items_orden_compra(Ltipo.Value, Lnumero.Value);
                                if (registrosm.Tables[0].Rows.Count > 0)
                                {
                                    dt = registrosm.Tables[0];
                                        
                                    foreach (DataRow row in dt.Rows)
                                    {
                                            var plu = Convert.ToString(row[0]);
                                            var cantidad = Convert.ToString(row[1]);
                                            var detalle = Convert.ToString(row[2]);
                                        string replace = Convert.ToString(row[3]);
                                        string piva = Convert.ToString(row[4]);
                                        string pivacodigo = Convert.ToString(row[5]);
                                        string prefproveedor = Convert.ToString(row[6]);
                                        var costo = replace.Replace(',', '.');
                                      
                                            try
                                        {
                                            var Regis = Controlasql.CcreaitemsOC(validador2.ToString(), plu,"0","","NLL-",cantidad,costo,"V","F",piva,pivacodigo,"0","", costo, prefproveedor, bd);
                                        }
                                        catch (Exception exp)
                                        {

                                            throw exp;
                                        }

                                    }
                                }
                                else
                                {
                                    txtestado.Text = "Dicha factura no tiene items";
                                }
                            }

                            Response.Redirect("recibomercancia/Rmercancia.aspx");
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    
                       
                    }
                }


            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion controlada:" + ex.Message);
            }

        }
        
    }
}