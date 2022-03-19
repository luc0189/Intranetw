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

                alerta.Visible = false;


            }

        }
        public void Consulta(object sender, EventArgs e)
        {
          
            Consultageneral();
        }
        public void Consultala16(object sender, EventArgs e)
        {
            if (Session["salaventas"].ToString().Equals("2")|| Session["salaventas"].ToString().Equals("1"))
            {
                string idcosto = "000001";
                if (txtdesde.Value.Length == 0 || txthasta.Value.Length == 0)
                {
                    alerta.Visible = true;
                    alerta.Text = "Ingrese un rango de Fechas";
                }
                info2.Text = txtdesde.Value.ToString() + " - " + txthasta.Value.ToString();
                try
                {
                    var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                    if (registros13.Tables[0].Rows.Count > 0)
                    {

                        gridla16.DataSource = registros13;
                        gridla16.DataBind();
                        alerta.Visible = false;

                    }
                    else
                    {
                        gridla16.DataSource = null;
                        gridla16.DataBind();

                    }

                }
                catch (Exception es)
                {
                    alerta.Visible = true;
                    alerta.Text = (es.Message.ToString());
                }

            }

           
        }
       
        public void Consultala13(object sender,EventArgs e)
        {
            if (Session["salaventas"].ToString().Equals("3") || Session["salaventas"].ToString().Equals("1"))
            {
                string idcosto = "000002";
                if (txtdesde.Value.Length == 0 || txthasta.Value.Length == 0)
                {
                    alerta.Visible = true;
                    alerta.Text = "Ingrese un rango de Fechas";
                }
                info3.Text = txtdesde.Value.ToString() + " - " + txthasta.Value.ToString();
                try
                {
                    var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                    if (registros13.Tables[0].Rows.Count > 0)
                    {

                        Gridla13.DataSource = registros13;
                        Gridla13.DataBind();
                        alerta.Visible = false;

                    }
                    else
                    {
                        Gridla13.DataSource = null;
                        Gridla13.DataBind();

                    }

                }
                catch (Exception es)
                {
                    alerta.Visible = true;
                    alerta.Text = (es.Message.ToString());
                }

            }
          

        }
        public void Consultalaversalles(object sender, EventArgs e)
        {
            string idcosto = "000004";
            if (txtdesde.Value.Length == 0 || txthasta.Value.Length == 0)
            {
                alerta.Visible = true;
                alerta.Text = "Ingrese un rango de Fechas";
            }
            info4.Text = txtdesde.Value.ToString() + " - " + txthasta.Value.ToString();
            try
            {
                var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    GridVersalles.DataSource = registros13;
                    GridVersalles.DataBind();
                    alerta.Visible = false;

                }
                else
                {
                    GridVersalles.DataSource = null;
                    GridVersalles.DataBind();

                }

            }
            catch (Exception es)
            {
                alerta.Visible = true;
                alerta.Text = (es.Message.ToString());
            }

        }
        public void Consultalaciudadela(object sender, EventArgs e)
        {
            if (txtdesde.Value.Length == 0 || txthasta.Value.Length == 0)
            {
                alerta.Visible = true;
                alerta.Text = "Ingrese un rango de Fechas";
            }
            info5.Text = txtdesde.Value.ToString() + " - " + txthasta.Value.ToString();
            string idcosto = "000005";
            try
            {
                var registros13 = Controlasql.Cventas_linea(txtdesde.Value, txthasta.Value, idcosto);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    GridCiudadela.DataSource = registros13;
                    GridCiudadela.DataBind();
                    alerta.Visible = false;

                }
                else
                {
                    GridCiudadela.DataSource = null;
                    GridCiudadela.DataBind();

                }

            }
            catch (Exception es)
            {
                alerta.Visible = true;
                alerta.Text = (es.Message.ToString());
            }

        }
        public void Consultageneral()
        {
            if (txtdesde.Value.Length ==0 || txthasta.Value.Length==0)
            {
                alerta.Visible = true;
                alerta.Text = "Ingrese un rango de Fechas";
            }
            info1.Text = txtdesde.Value.ToString() + " - " + txthasta.Value.ToString();
            try
            {
                var registros13 = Controlasql.Cventas_linea_general(txtdesde.Value, txthasta.Value);
                if (registros13.Tables[0].Rows.Count > 0)
                {

                    GridGeneral.DataSource = registros13;
                    GridGeneral.DataBind();
                    alerta.Visible = false;

                }
                else
                {
                    GridGeneral.DataSource = null;
                    GridGeneral.DataBind();

                }

            }
            catch (Exception es)
            {
                alerta.Visible = true;
                alerta.Text = (es.Message.ToString());
            }

        }
    }
}