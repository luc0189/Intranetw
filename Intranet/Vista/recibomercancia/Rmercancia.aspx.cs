using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.recibomercancia
{
    public partial class Rmercancia : System.Web.UI.Page
    {
        DataTable dt = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            cantrecibo();
            Listarecibido();
            if (!Page.IsPostBack)
            {
                cantrecibo();
                Listarecibido();
                if (Session["tipoOC"] != null && Session["numeroOC"] != null)
                {
                    txtnombreProveedor.Text = Session["numeroOC"].ToString();
                    DevOc.Text= Session["numeroOC"].ToString(); 
                }
                else
                {
                    Response.Redirect("../R_compras.aspx");
                    Session["numeroOC"] = "";
                }
              
            }
            
        }
        //public void limpia()

        //{
        //    txtcodbarra.Value = "";
        //    txtcodbarra.Focus();
        //    txtdetalle.InnerText = "";
        //    txtplu.Value = "";
        //}
      
       public void Guarda(string pcantoc,
           string pplu,
           string pcantidad,
           string pnombre,
           string pvalorcosto,
           string oc,
           string isDev,
           string piva,
           string pcodigoiva,
           string factor,
           string namepres)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var usert = Session["USUARIO"].ToString();
                String tipodoc = Session["tipoOC"].ToString();
                var Registroitems = 0;
                var registros = Controlasql.CValidaFactura(oc, tipodoc, bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    var validador = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        validador = Convert.ToInt32(row[0]);

                    }
                    if (validador != 0)
                    {
                        Insertaritems(pcantoc, pplu, pcantidad,pnombre, pvalorcosto, bd, validador.ToString(), "P",isDev,piva,pcodigoiva,factor,namepres);
                        Listarecibido();
                    }
                    else
                    {
                        try
                        {
                            Registroitems = Controlasql.Ccreanofactura(tipodoc, oc, usert, bd);
                            Insertaritems(pcantoc,pplu,pcantidad,pnombre,pvalorcosto,bd, validador.ToString(), "P", isDev, piva, pcodigoiva,factor,namepres);
                            cantrecibo();
                            Listarecibido();
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }


                    }
                    Dev_estado.Value = "Registro Guardado";
                    txtestado.Value = "Registro Guardado";
                    //limpia();
                    txtcodbarra.Focus();
                    cantrecibo();


                }
                else
                {
                    txtestado.Value = "Registro con error";
                    Dev_estado.Value = "Registro con error";
                    //limpia();
                    txtcodbarra.Focus();

                }
            }
            catch (Exception ex)
            {
                txtestado.Value = "Excepcion controlada: " + ex.Message;
                Dev_estado.Value = "Excepcion controlada: " + ex.Message;

                //limpia();

            }
        }
        protected void btnguarda_Click(object sender, EventArgs e)
        {
            Guarda(txtCantOc.Text,txtplu.Text,txtcant.Value, txtdetalle.InnerText,txtcosto.Text, txtnombreProveedor.Text,"F", Piva.Text, PcodigoIva.Text, pfactor.Text, PnamePres.Text);
           
        }
        protected void Insertaritems(string cantorden,string pPlu,string pcant,string pdetalle,string pcosto,string pbd,string valida,string stateid,string isDev,string piva,string pcodigoiva,string fact,string namep) 
        {
            int cantoc = Convert.ToInt32(cantorden);
            string pedido = ":)";
            if (cantoc>0)
            {
                 pedido = "V";
            }
            else
            {
                pedido = "F";
            }
            try
            {
                var Registroitems = Controlasql.CcreaitemsOC(valida, pPlu, pcant, pdetalle, stateid, cantoc.ToString(), pcosto.Replace(',','.'), pedido, isDev,piva,pcodigoiva,fact,namep,  pbd);
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }
        protected void Lista_esta_ono()
        {
            try
            {
                
                var registros2 = ControlaSql.Clista_esta_ono(Session["tipoOC"].ToString(),txtnombreProveedor.Text,txtcodbarra.Value);
                if (registros2.Tables[0].Rows.Count > 0)
                {
                    dt = registros2.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        txtestado.Value = Convert.ToString(row[1])+" Cant: "+ Convert.ToString(row[2]);
                        txtcant.Focus();
                        int ca = Convert.ToInt32(row[2]);
                        if (ca>0)
                        {
                            txtCantOc.Text = Convert.ToString(ca);
                            Dev_CantOc.Text= Convert.ToString(ca);
                        }
                        else
                        {
                            txtCantOc.Text = "0";
                            Dev_CantOc.Text = "0";
                           
                        }
                        txtCantOc.Text = Convert.ToString(row[2]);
                        Dev_CantOc.Text = Convert.ToString(row[2]);

                    }
                }
                else
                {
                    txtestado.Value = "El PLU:" +txtplu.Text + " No se encuentra en esta orden de Compra";
                    txtCantOc.Text = "0";
                    Dev_CantOc.Text  = "0";
                    txtcodbarra.Value = "";
                    txtcant.Value = "";
                    txtcant.Focus();
                }
            }
            catch (Exception e)
            {
                txtestado.InnerText = "Ecepcion no Controlada: " + e.Message;
            }

        }
        public void cantrecibo()
        {
            int cxr = Convert.ToInt32(Session["numeroitems"]);
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clista_count_recibo(Session["numeroOC"].ToString(), bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        var cantR = Convert.ToInt32(row[0]);
                        var total = cxr - cantR;
                    
                    }
                
                }
                else
                {
                   
                }
            }
            catch (Exception e)
            {

                alerta.MessageBox(this, "Excepcion controlada:" + e.Message);
            }
        }

        public void Listarecibido()
        {
           
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clista_rmercancia(Session["numeroOC"].ToString(), bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridviewListaItems.DataSource = registros;
                    GridviewListaItems.DataBind ();

                }
                else
                {
                    GridviewListaItems.DataSource = null;
                    GridviewListaItems.DataBind();
                }
            }
            catch (Exception e)
            {

                alerta.MessageBox(this, "Excepcion controlada:" + e.Message);
            }
        }


        //public void cantdevo()
        //{
        //    try
        //    {
        //        String bd = Session["BD"].ToString();
        //        var registros = Controlasql.Clista_count_devo(txtnombreProveedor.Text, bd);
        //        if (registros.Tables[0].Rows.Count > 0)
        //        {
        //            dt = registros.Tables[0];
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                txtdevoluciones.Value = Convert.ToString(row[0]);
        //            }

        //        }
        //        else
        //        {
        //            txtdevoluciones.Value = "";
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        alerta.MessageBox(this, "Excepcion controlada:" + e.Message);
        //    }
        //}
        protected void ListarAriculos(string barra)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosd = ControlaSql.Clista_articulos(barra);
                if (registrosd.Tables[0].Rows.Count > 0)
                {
                    dt = registrosd.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        txtcant.Disabled = false;
                        txtplu.Text = Convert.ToString(row[0]) ;
                        Dev_plu.Text= Convert.ToString(row[0]);
                        txtdetalle.InnerText = Convert.ToString(row[1]);
                        Devnamearticulo.InnerText = Convert.ToString(row[1]);
                        
                        Piva.Text = Convert.ToString(row[2]);
                        Dev_Piva.Text = Convert.ToString(row[2]);
                        PcodigoIva.Text = Convert.ToString(row[3]);
                        Dev_PcodigoIva.Text = Convert.ToString(row[3]); 
                        pfactor.Text = Convert.ToString(row[4]);
                        Dev_Pfactor.Text = Convert.ToString(row[4]);
                        PnamePres.Text = Convert.ToString(row[5]);
                        Dev_PnamePres.Text = Convert.ToString(row[5]);
                    }
                    var registrosde = ControlaSql.Clista_CostoArticulos(barra);
                    if (registrosde.Tables[0].Rows.Count > 0)
                    {
                        dt = registrosde.Tables[0];
                        foreach (DataRow row in dt.Rows)
                        {
                            txtcant.Disabled = false;
                            txtcosto.Text = Convert.ToString(row[0]);
                            Dev_Costo.Text = Convert.ToString(row[0]);
                            
                        }
                    }
                        Lista_esta_ono();
                }
                else
                {
                    txtplu.Text = "N/a";
                    Dev_plu.Text = "N/a";
                    txtdetalle.InnerText = "Articulo No existe";
                    Devnamearticulo.InnerText = "Articulo No existe";
                   
                    //txtcodbarra.Value = "";
                    txtcodbarra.Focus();
                    
                }
            }
            catch (Exception e)
            {

                alerta.MessageBox(this, "Excepcion controlada:" + e.Message);
            }
        }

        protected void Actualiza_Click(object sender, EventArgs e)
        {
            ListarAriculos(txtcodbarra.Value);
        }

      

        protected void Devolucion_Click(object sender, EventArgs e)
        {
            Guarda("0" ,Dev_plu.Text,Dev_cantidad.Value,Devnamearticulo.InnerText,Dev_Costo.Text, DevOc.Text, "V",Dev_Piva.Text,Dev_PcodigoIva.Text,Dev_Pfactor.Text,Dev_PnamePres.Text);
        }

        protected void BtnDevbuscar_Click(object sender, EventArgs e)
        {
            ListarAriculos(Dev_barra.Value);
        }
        protected void GridviewItemsCompra_DataBound(object sender, EventArgs e)
        {
            
            for (int i = 0; i < GridviewListaItems.Rows.Count; i++)
            {
                string stado = Convert.ToString(GridviewListaItems.Rows[i].Cells[3].Text);




                if (stado.Equals("V"))
                {
                    GridviewListaItems.Rows[i].BackColor = Color.DarkRed;
                    GridviewListaItems.Rows[i].ForeColor = Color.White;
                }
            }

        }

        //protected void btndevolucion_Click(object sender, EventArgs e)
        //{
        //    String bd = Session["BD"].ToString();
        //    var usert = Session["USUARIO"].ToString();
        //    String tipodoc = Session["tipoOC"].ToString();
        //    var Registroitems = 0;
        //    var registros = Controlasql.CValidaFactura(txtnombreProveedor.Text, tipodoc, bd);
        //    if (registros.Tables[0].Rows.Count > 0)
        //    {
        //        dt = registros.Tables[0];
        //        var validador = 0;
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            validador = Convert.ToInt32(row[0]);

        //        }
        //        if (validador != 0)
        //        {
        //            Insertaritems(bd, validador.ToString(), "D");

        //        }
        //        else
        //        {
        //            try
        //            {
        //                Registroitems = Controlasql.Ccreanofactura(tipodoc, txtnombreProveedor.Text, usert, bd);
        //                Insertaritems(bd, validador.ToString(), "D");

        //            }
        //            catch (Exception ex)
        //            {
        //                txtestado.Value = "Excepcion controlada: " + ex.Message;
        //                //cantdevo();
        //                //limpia();

        //            }
        //        }
        //        txtestado.Value = "Registro Guardado";
        //    }
        //}

        //protected void btnRnPedido_Click(object sender, EventArgs e)
        //{
        //    String bd = Session["BD"].ToString();
        //    var usert = Session["USUARIO"].ToString();
        //    String tipodoc = Session["tipoOC"].ToString();
        //    var Registroitems = 0;
        //    var registros = Controlasql.CValidaFactura(txtnombreProveedor.Text, tipodoc, bd);
        //    if (registros.Tables[0].Rows.Count > 0)
        //    {
        //        dt = registros.Tables[0];
        //        var validador = 0;
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            validador = Convert.ToInt32(row[0]);

        //        }
        //        if (validador != 0)
        //        {
        //            Insertaritems(bd, validador.ToString(), "RnP");

        //        }
        //        else
        //        {
        //            try
        //            {
        //                Registroitems = Controlasql.Ccreanofactura(tipodoc, txtnombreProveedor.Text, usert, bd);
        //                Insertaritems(bd, validador.ToString(), "RnP");

        //            }
        //            catch (Exception ex)
        //            {
        //                txtestado.Value = "Excepcion controlada: " + ex.Message;
        //                cantdevo();
        //                //limpia();

        //            }
        //        }
        //        txtestado.Value = "Registro Guardado";
        //    }
        //}
        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        EjecutarFuncion();
        //    }
        //}
    }
}