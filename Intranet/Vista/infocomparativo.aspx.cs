using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista.Documentos
{
    public partial class infocomparativo : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            notificacion.Visible = false;
        }
   

        protected void ListaraDATOS(object sender, EventArgs e)
        {
            try
            {
                var registros13 = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,"000002");
                if (registros13.Tables[0].Rows.Count > 0)
                {
                    Gridsuper13.DataSource = registros13;
                    Gridsuper13.DataBind();
                }
                else
                {
                    Gridsuper13.DataSource = null;
                    Gridsuper13.DataBind();
                }
                var registros16 = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,"000001");
                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridsuper16.DataSource = registros16;
                    Gridsuper16.DataBind();
                }
                else
                {
                    Gridsuper16.DataSource = null;
                    Gridsuper16.DataBind();
                }
                var registrosVERSA = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,"000004");
                if (registrosVERSA.Tables[0].Rows.Count > 0)
                {
                    GridsuperVERSA.DataSource = registrosVERSA;
                    GridsuperVERSA.DataBind();
                }
                else
                {
                    GridsuperVERSA.DataSource = null;
                    GridsuperVERSA.DataBind();
                }
                var registrosciudadela = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,"000005");
                if (registrosciudadela.Tables[0].Rows.Count > 0)
                {
                    GridViewCiudadela.DataSource = registrosciudadela;
                    GridViewCiudadela.DataBind();
                }
                else
                {
                    GridViewCiudadela.DataSource = null;
                    GridViewCiudadela.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
        public void Listarventas16(object sender, EventArgs e)
        {
            try
            {
                var registros16 = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,Session["CCOSTO"].ToString());
                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridsuper16.DataSource = registros16;
                    Gridsuper16.DataBind();
                }
                else
                {
                    Gridsuper16.DataSource = null;
                    Gridsuper16.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
        protected void Listarventas13(object sender, EventArgs e)
        {
            try
            {
                var registros13 = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,"000002");
                if (registros13.Tables[0].Rows.Count > 0)
                {
                    Gridsuper13.DataSource = registros13;
                    Gridsuper13.DataBind();
                }
                else
                {
                    Gridsuper13.DataSource = null;
                    Gridsuper13.DataBind();
                }
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
   
        protected void ListarventasVERSA(object sender, EventArgs e)
        {
            try
            {
                var registrosVERSA = Controlasql.listaventa(txtfechaini.Value.ToUpper(), txtfechafin.Value,"00005");
                if (registrosVERSA.Tables[0].Rows.Count > 0)
                {
                    GridsuperVERSA.DataSource = registrosVERSA;
                    GridsuperVERSA.DataBind();
                }
                else
                {
                    GridsuperVERSA.DataSource = null;
                    GridsuperVERSA.DataBind();
                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.apx");
            }
           
        }

    }
}