using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.Sistema
{
    public partial class ConsultorV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                modal.Visible = true;
                dvalor1.Visible = false;
                ddescuento.Visible = false;
                dvalor2.Visible = false;
            }
        }



        protected void ir_Click(object sender, EventArgs e)
        {
            try
            {
                var varArticulo = "";
                var des = 0;
                var detalle = "";
                var valor = 0;
                var peso = 1;
                lbarticulo.Text = "";
                lbdescuento.Text = "";
                lbpxunidad.Text = "";
                lbsaldo.Text = "";
                lbvalor.Text = "";
                lbvalor1.Text = "";
                lbvalordes.Text = "";
                LblPlu.Text = "";
                var descuentossss = (valor - ((valor * des) / 100));
                var articulo = Controlasql.Clistaprecio(txtbarra.Value,"002");
                if (articulo.Tables[0].Rows.Count > 0)
                {
                    DataTable Tablearticulo = articulo.Tables[0];

                    foreach (DataRow row in Tablearticulo.Rows)
                    {
                        varArticulo = (Convert.ToString(row["codigo"]));
                        detalle = (Convert.ToString(row["detalle"]));
                        valor = (Convert.ToInt32(row["valormiva"]));
                         peso = (Convert.ToInt32(row["peso"]));
                        if (peso == 0)
                        {
                            peso = 1;
                        }
                    }
                    var descuento = Controlasql.Clistadesc(varArticulo);
                    if (descuento.Tables[0].Rows.Count > 0)
                    {
                        DataTable Tdescuento = descuento.Tables[0];

                        foreach (DataRow row in Tdescuento.Rows)
                        {
                           
                            des = (Convert.ToInt32(row["vrveneficio"]));
                        }
                        lbarticulo.Text = detalle;
                        boxvalor.Visible = false;
                        dvalor1.Visible = true;
                        ddescuento.Visible = true;
                        dvalor2.Visible = true;
                        LblPlu.Text = varArticulo;
                        lbvalor1.Text = valor.ToString();
                        lbdescuento.Text = des.ToString();
                        descuentossss = (valor - ((valor * des) / 100));
                        lbvalordes.Text = descuentossss.ToString();
                        lbpxunidad.Text = (descuentossss / peso).ToString();

                    }
                    else
                    {
                        boxvalor.Visible = true;
                        dvalor1.Visible = false;
                        ddescuento.Visible = false;
                        dvalor2.Visible = false;
                        LblPlu.Text = varArticulo;
                        lbvalor.Text = valor.ToString();
                        lbarticulo.Text = detalle;
                        lbpxunidad.Text = (valor / peso).ToString();
                    }
                    var saldo = Controlasql.Clistasaldo(varArticulo,"014");
                    if (saldo.Tables[0].Rows.Count > 0)
                    {
                        DataTable Tsaldo = saldo.Tables[0];

                        foreach (DataRow row in Tsaldo.Rows)
                        {
                            lbsaldo.Text = (Convert.ToString(row["saldocant"]));
                        }

                    }

                }
                else
                {
                    lbarticulo.Text = "Articulo No existe";
                    txtbarra.Value = "";
                    lbdescuento.Text = "";
                    lbpxunidad.Text = "";
                    lbsaldo.Text = "";
                    lbvalor.Text = "";
                    lbvalor1.Text = "";
                    lbvalordes.Text = "";
                    LblPlu.Text = "";
                    modal.Visible = true;
                    dvalor1.Visible = false;
                    ddescuento.Visible = false;
                    dvalor2.Visible = false;
                }
                txtbarra.Value = "";
            }
            catch (Exception EX)
            {

                alerta.MessageBox(this, $" {EX}");
            }
        }
    }
}