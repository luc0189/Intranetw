using Intranet.Controlador;
using System;
using System.Data;
using System.Web.UI;

namespace Intranet.Vista.Sistema
{
    public partial class Consultor16 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InicializarPagina();
            }
        }
        private void InicializarPagina()
        {
            modal.Visible = true;
            dvalor1.Visible = false;
            ddescuento.Visible = false;
            dvalor2.Visible = false;
            txtbarra.Value = "";

        }


        protected void ir_Click(object sender, EventArgs e)
        {
            EjecutarSonido("/plugins/store4.mp3");
            try
            {
                ResetControles();

                var newArticulo = Controlasql.CNewlistaprecio(txtbarra.Value, "011");
                if (newArticulo.Tables[0].Rows.Count > 0)
                {
                    var row = newArticulo.Tables[0].Rows[0];
                    int vrbeneficio = SafeGetInt(row, "vrveneficio");

                    if (vrbeneficio == 0)
                    {
                        MostrarSinDescuento(row);
                    }
                    else
                    {
                        MostrarConDescuento(row);
                    }
                }
                else
                {
                    MostrarArticuloNoEncontrado();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                txtbarra.Value = "";
            }
        }

        private void ResetControles()
        {
            lbarticulo.Text = lbdescuento.Text = lbpxunidad.Text = lbsaldo.Text = lbvalor.Text = lbvalor1.Text = lbvalordes.Text = LblPlu.Text = "";
            boxvalor.Visible = true;
            dvalor1.Visible = false;
            ddescuento.Visible = false;
            dvalor2.Visible = false;
        }

        private void MostrarSinDescuento(DataRow row)
        {
            var detalle = $"{row["detalle"]}-{row["nombrepres"]}";
            int vrbeneficio = SafeGetInt(row, "vrveneficio");
            var valor = SafeGetInt(row, "valormiva");

            var peso = SafeGetInt(row, "peso");
            if (peso == 0) peso = 1;

            lbarticulo.Text = detalle;
            LblPlu.Text = Convert.ToString(row["CodigoArticulo"]);
            lbvalor.Text = valor.ToString();
            lbsaldo.Text = Convert.ToString(row["saldocant"]);
            lbpxunidad.Text = (valor / peso).ToString();
        }

        private void MostrarConDescuento(DataRow row)
        {
            var detalle = $"{row["detalle"]}-{row["nombrepres"]}";
            var valor = SafeGetInt(row, "PrecioOriginal");
            var peso = SafeGetInt(row, "peso");
            var descuento = SafeGetInt(row, "vrveneficio");
            var precioFinal = SafeGetInt(row, "PrecioFinal");
            var esDesvalor = Convert.ToString(row["dtocomovalor"]);

            if (peso == 0) peso = 1;
            var descuentoTexto = (esDesvalor == "False" || string.IsNullOrEmpty(esDesvalor)) ? $"{descuento}%" : $"${descuento}";

            lbarticulo.Text = detalle;
            LblPlu.Text = Convert.ToString(row["CodigoArticulo"]);
            lbvalor1.Text = valor.ToString();
            lbvalordes.Text = precioFinal.ToString();
            lbsaldo.Text = Convert.ToString(row["saldocant"]);
            lbdescuento.Text = descuentoTexto;
            lbpxunidad.Text = (precioFinal / peso).ToString();

            boxvalor.Visible = false;
            dvalor1.Visible = true;
            ddescuento.Visible = true;
            dvalor2.Visible = true;
        }

        private void MostrarArticuloNoEncontrado()
        {
            modal.Visible = true;
            ResetControles();
        }
        private int SafeGetInt(DataRow row, string columnName)
        {
            if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
            {
                return Convert.ToInt32(row[columnName]);
            }
            return 0; // o el valor por defecto que prefieras
        }
        private void EjecutarSonido(string urlSonido)
        {
            string script = $@"
        var audio = new Audio('{urlSonido}');
        audio.play();
    ";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
}