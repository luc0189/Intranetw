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
    public partial class Consultor : System.Web.UI.Page
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
                var articulo = Controlasql.Clistaprecio(txtbarra.Value,"005");
                if (articulo.Tables[0].Rows.Count > 0)
                {
                    DataTable Tablearticulo = articulo.Tables[0];

                    foreach (DataRow row in Tablearticulo.Rows)
                    {
                        varArticulo = (Convert.ToString(row["codigo"]));
                        detalle = (Convert.ToString(row["detalle"])) + "-" + (Convert.ToString(row["nombrepres"]));
                        valor = (Convert.ToInt32(row["valormiva"]));
                        peso = (Convert.ToInt32(row["peso"]));

                        if (peso == 0)
                        {
                            peso = 1;
                        }
                    }
                
                    var saldo = Controlasql.Clistasaldo(varArticulo,"015");
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