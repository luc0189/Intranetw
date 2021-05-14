
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class Transform : System.Web.UI.Page
    {
        Ccodemas sb = new Ccodemas();
        ControlaSql sbql = new ControlaSql();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnenvia.ServerClick += btnenviar_Click;

            if (!Page.IsPostBack)
            {
                traearticulossuper();
                listatranspendientes();
                listasalas();
                listaItemsTramsform();
            }
        }
        protected void listaItemsTramsform()
        {
            try
            {
                String bd = Session["BD"].ToString();
                DataSet res2 = sb.CListaItemstransformaciones();
                if (res2.Tables[0].Rows.Count > 0)
                {

                    Select_transf.Items.Clear();
                    foreach (DataRow row in res2.Tables[0].Rows)
                    {
                        Select_transf.Items.Add(Convert.ToString(row["NOMBRE"]));
                        Select_transf.DataBind();
                    }



                }
                else
                {
                    Select_transf.DataSource = null;
                    Select_transf.DataBind();
                }
            }
            catch (Exception E)
            {
                txtestado.Value = E.Message;
            }

        }
        protected void traearticulossuper()
        {
            SelectarticuloF.Items.Clear();
            try
            {
                var registros = ControlaSql.listaarticulosfruver();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    SelectarticuloF.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectarticuloF.Items.Add(Convert.ToString(row["articulo"]));
                        SelectarticuloF.DataBind();
                    }

                }
                else
                {
                    SelectarticuloF.DataSource = null;
                    SelectarticuloF.DataBind();
                }
            }
            catch (Exception ex)
            {

                txtestado.Value= ex.Message;
            }
        }
        protected void OnRowDeleting(object sender, EventArgs e)
        {
            GridViewRow gr = GridViewNovedades.SelectedRow;
            String ids = gr.Cells[1].Text;
            String bd = Session["BD"].ToString();
            try
            {
                DataTable res2 = sb.CdeleteTransformacion(ids, bd);
                if (res2.Rows.Count > 0)
                {
                    listatranspendientes();
                }
                else
                {
                    listatranspendientes();
                    alerta.MessageBox(this, "No se realizo ningun cambio");
                }
            }
            catch (Exception ex)
            {

                alerta.MessageBox(this,"Excepcion no Controlada :"+ex.Message) ;
            }
            

      
           

        }
        public void insertTransform(string id2,string detalle2,double vcosto)
        {
            try
            {
                var registros2 = sb.CcreaTransformacion(id2, detalle2, txtcant_tranform.Value,
          txtfecha.Value, txtccosto.Value, Session["USUARIO"].ToString(), Convert.ToString(vcosto), Session["BD"].ToString());
                if (registros2.Rows.Count > 0)
                {
                    txtcant_articulo.Value = "";
                    txtcant_tranform.Value = "";
                    listatranspendientes();
                    SelectarticuloF.Focus();
                    txtestado.Value = "Registros Exitoso";
                 

                }
                else
                {
                    txtestado.Value = "Error al Guardar los datos, Valide la informacion y vuelva a intentarlo";
                }

            }
            catch (Exception EC)
            {

                txtestado.Value = EC.Message;
            }
        }
        public void insertArticulo(string id1,string detalle1) {
            try//Aqui enviamos la fila correspondiente al articulo a transformar
            {
                var registros = sb.CcreaTransformacion(id1, detalle1, "-" + txtcant_articulo.Value,
                    txtfecha.Value, txtccosto.Value, Session["USUARIO"].ToString(), vcosto.Value, Session["BD"].ToString());
                if (registros.Rows.Count > 0)
                {
                    

                    listatranspendientes();
                    

                }
                else
                {
                    txtestado.Value = "Error al Guardar los datos, Valide la informacion y vuelva a intentarlo";
                }
            }
            catch (Exception ex)
            {
                txtestado.Value = ex.Message;
            }
        }
        protected void btnenviar_Click(object sender, EventArgs e)
        {
            string articulo1 = Page.Server.HtmlDecode(SelectarticuloF.Value);
            string articulo2 = Page.Server.HtmlDecode(Select_transf.Value);
            string[] data1 = articulo1.Split('/');
            string[] data2 = articulo2.Split('/');

            string plu1 = Page.Server.HtmlDecode(data1[0]);
            string detalle1 = Page.Server.HtmlDecode(data1[1]);
            string plu2 = Page.Server.HtmlDecode(data2[0]);
            string detalle2 = Page.Server.HtmlDecode(data2[1]);
            double costotransformacion;
            try
            {
                var costo = sb.CListaCostoArticulo(plu1,txtfecha.Value);
                if (costo.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in costo.Tables[0].Rows)
                    {
                         vcosto.Value=(Convert.ToString(row["vrcostounitneto"]));
                         double vrtemp=(Convert.ToDouble(row["vrcostounitneto"]));
                        double operacion = vrtemp * (Convert.ToDouble(txtcant_articulo.Value));
                         costotransformacion = operacion / (Convert.ToDouble(txtcant_tranform.Value));
                        insertArticulo(plu1, detalle1);
                        insertTransform(plu2, detalle2, costotransformacion);

                    }
                   
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }

         

        }
        protected void listatranspendientes()
        {
            try
            {
                String bd = Session["BD"].ToString();
                DataTable res2 = sb.CListatransformaciones(bd);
                if (res2.Rows.Count > 0)
                {
                    GridViewNovedades.DataSource = res2;
                    GridViewNovedades.DataBind();
                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }

            }
            catch (Exception E)
            {
                txtestado.Value = E.Message;
            }

        }
        protected void listasalas()
        {
            try
            {
                String bd = Session["BD"].ToString();
                DataTable res2 = sb.CListasalas(bd);
               if (res2.Rows.Count > 0)
                {
                    
                    txtccosto.Items.Clear();
                    foreach (DataRow row in res2.Rows)
                    {
                        txtccosto.Items.Add(Convert.ToString(row["NOMBRE"]));
                        txtccosto.DataBind();
                    }



                }
                else
                {
                    txtccosto.DataSource = null;
                    txtccosto.DataBind();
                }
            }
            catch (Exception E)
            {
                txtestado.Value = E.Message;
            }

        }
    }
}