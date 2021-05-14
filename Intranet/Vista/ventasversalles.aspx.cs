using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class ventasversalles : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }
        protected void consulta(object sender, EventArgs e)
        {
            try
            {
                var registros14 = Controlasql.listaventalocalVERSA(txtcuenta.Value, txtfechaini.Value.ToUpper(), txtfechafin.Value);
                if (registros14.Tables[0].Rows.Count > 0)
                {
                    GridViewVentasVersa.DataSource = registros14;
                    GridViewVentasVersa.DataBind();
                    
                }
                else
                {
                    GridViewVentasVersa.DataSource = null;
                    GridViewVentasVersa.DataBind();
                }
                
            }
            catch (Exception)
            {


                throw;
            }
            consultadetalle();

        }
        public void consultadetalle()
        {
            try
            {
                var registrosdetallados = Controlasql.listadetalleventalocalVERSA(txtcuenta.Value, txtfechaini.Value.ToUpper(), txtfechafin.Value);
                if (registrosdetallados.Tables[0].Rows.Count > 0)
                {
                    GridViewVentadetallesVersa.DataSource = registrosdetallados;
                    GridViewVentadetallesVersa.DataBind();
                }
                else
                {
                    GridViewVentadetallesVersa.DataSource = null;
                    GridViewVentadetallesVersa.DataBind();
                }

            }
            catch (Exception)
            {


                throw;
            }
        }

    }
}