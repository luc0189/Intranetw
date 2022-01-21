using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class V_linea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
             



            }

        }
        public void Consulta(object sender, EventArgs e)
        {
            Consultala16();
            Consultala13();
            Consultalaversalles();
            Consultalaciudadela();
            Consultageneral();
        }
        public void Consultala16()
        {
            string idcosto = "000001";

            try
            {
                var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value,  idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    gridla16.DataSource = registros13;
                    gridla16.DataBind();


                }
                else
                {
                    gridla16.DataSource = null;
                    gridla16.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
        public void Consultala13()
        {
            string idcosto = "000002";

            try
            {
                var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    Gridla13.DataSource = registros13;
                    Gridla13.DataBind();


                }
                else
                {
                    Gridla13.DataSource = null;
                    Gridla13.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
        public void Consultalaversalles()
        {
            string idcosto = "000004";

            try
            {
                var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    GridVersalles.DataSource = registros13;
                    GridVersalles.DataBind();


                }
                else
                {
                    GridVersalles.DataSource = null;
                    GridVersalles.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
        public void Consultalaciudadela()
        {

            string idcosto = "000005";
            try
            {
                var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    GridCiudadela.DataSource = registros13;
                    GridCiudadela.DataBind();


                }
                else
                {
                    GridCiudadela.DataSource = null;
                    GridCiudadela.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
        public void Consultageneral()
        {

            try
            {
                var registros13 = Controlasql.Cventas_linea_general(txtdesde.Value, txthasta.Value);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    GridGeneral.DataSource = registros13;
                    GridGeneral.DataBind();


                }
                else
                {
                    GridGeneral.DataSource = null;
                    GridGeneral.DataBind();

                }

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }

        }
    }
}