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
                var registros13 = Controlasql.listaventa13(txtfechaini.Value.ToUpper(), txtfechafin.Value);
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
                var registrosVERSA = Controlasql.listaventaVERSA(txtfechaini.Value.ToUpper(), txtfechafin.Value);
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
                var registrosciudadela = Controlasql.listaventaCiudadela(txtfechaini.Value.ToUpper(), txtfechafin.Value);
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
            Listarventastotal();
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
                var registros13 = Controlasql.listaventa13(txtfechaini.Value.ToUpper(), txtfechafin.Value);
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
        public void Listarventastotal()
        {
            try
            {
                var registros16 = Controlasql.CSale_supermarkets(txtfechaini.Value.ToUpper(), txtfechafin.Value,"000001");
                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridsuper16total.DataSource = registros16;
                    Gridsuper16total.DataBind();
                }
                else
                {
                    Gridsuper16total.DataSource = null;
                    Gridsuper16total.DataBind();
                }
            }
            catch (Exception e)
            {
                notificacion.Visible = true;
                txtnotifica.InnerText = "" + e.Message;
            }
            try
            {
                var registros13 = Controlasql.CSale_supermarkets(txtfechaini.Value.ToUpper(), txtfechafin.Value, "000002");
                if (registros13.Tables[0].Rows.Count > 0)
                {
                    GridViewtotal13.DataSource = registros13;
                    GridViewtotal13.DataBind();
                }
                else
                {
                    GridViewtotal13.DataSource = null;
                    GridViewtotal13.DataBind();
                }
            }
            catch (Exception e)
            {
                notificacion.Visible = true;
                txtnotifica.InnerText = "" + e.Message;
            }
            try
            {
                var registrosversa = Controlasql.CSale_supermarkets(txtfechaini.Value.ToUpper(), txtfechafin.Value, "000004");
                if (registrosversa.Tables[0].Rows.Count > 0)
                {
                    GridViewtotalversa.DataSource = registrosversa;
                    GridViewtotalversa.DataBind();
                }
                else
                {
                    GridViewtotalversa.DataSource = null;
                    GridViewtotalversa.DataBind();
                }
            }
            catch (Exception e)
            {
                notificacion.Visible = true;
                txtnotifica.InnerText = "" + e.Message;
            }
            try
            {
                var registrosciud = Controlasql.CSale_supermarkets(txtfechaini.Value.ToUpper(), txtfechafin.Value, "000005");
                if (registrosciud.Tables[0].Rows.Count > 0)
                {
                    GridViewtotalCiudadela.DataSource = registrosciud;
                    GridViewtotalCiudadela.DataBind();
                }
                else
                {
                    GridViewtotalCiudadela.DataSource = null;
                    GridViewtotalCiudadela.DataBind();
                }
            }
            catch (Exception e )
            {
                notificacion.Visible = true;
                txtnotifica.InnerText = "" + e.Message;
            }

        }
        protected void ListarventasVERSA(object sender, EventArgs e)
        {
            try
            {
                var registrosVERSA = Controlasql.listaventaVERSA(txtfechaini.Value.ToUpper(), txtfechafin.Value);
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