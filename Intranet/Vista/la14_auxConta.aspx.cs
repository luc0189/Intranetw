using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class la14_auxConta : System.Web.UI.Page
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
                var registros14 = Controlasql.Clista_la14aux(txtfechaini.Value.ToUpper(), txtfechafin.Value, txtcuenta.Value);
                if (registros14.Tables[0].Rows.Count > 0)
                {
                    GridViewLa14auxcontable.DataSource = registros14;
                    GridViewLa14auxcontable.DataBind();
                }
                else
                {
                    GridViewLa14auxcontable.DataSource = null;
                    GridViewLa14auxcontable.DataBind();
                }

            }
            catch (Exception)
            {

               
                throw;
            }
            

        }
        }
}