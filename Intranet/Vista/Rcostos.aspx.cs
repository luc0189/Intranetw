
using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SpreadsheetLight;
using System.IO;
using System.Web.Mvc;

namespace Intranet.Vista
{
    public partial class Rcostos : System.Web.UI.Page
    {
        System.Data.DataTable table;
        System.Data.DataRow row;
        protected void Page_Load(object sender, EventArgs e)
        {
            table = new System.Data.DataTable();
            table.Columns.Add("areadato", typeof(System.String));
            table.Columns.Add("plu", typeof(System.String));
            table.Columns.Add("detalle", typeof(System.String));
            table.Columns.Add("presentacion", typeof(System.String));
            table.Columns.Add("cantidadpres", typeof(System.String));
            table.Columns.Add("vrunit", typeof(System.String));
            table.Columns.Add("vrcosto", typeof(System.String));
            table.Columns.Add("vrprecio", typeof(System.String));
            table.Columns.Add("vrtotal", typeof(System.String));
            table.Columns.Add("vrcostototal", typeof(System.String));
            table.Columns.Add("vr_unit_extranjero", typeof(System.String));
            table.Columns.Add("total_extranjero", typeof(System.String));
            table.Columns.Add("vriva", typeof(System.String));
            table.Columns.Add("piva", typeof(System.String));
            table.Columns.Add("vrico", typeof(System.String));
            table.Columns.Add("vricouni", typeof(System.String));
            table.Columns.Add("vrdto", typeof(System.String));
            table.Columns.Add("Bodega_ID", typeof(System.String));
            table.Columns.Add("Tercero_ID", typeof(System.String));
            table.Columns.Add("CCostoID", typeof(System.String));
            table.Columns.Add("factorpres", typeof(System.String));
            table.Columns.Add("peso", typeof(System.String));
            table.Columns.Add("Dto_comercial", typeof(System.String));
            table.Columns.Add("Dto_Especial", typeof(System.String));
            table.Columns.Add("ref1", typeof(System.String));
            table.Columns.Add("ref2", typeof(System.String));
            table.Columns.Add("ref3", typeof(System.String));
            table.Columns.Add("otroscostos", typeof(System.Boolean));
            table.Columns.Add("Lista_precios_ID", typeof(System.String));
            table.Columns.Add("Cantidad_sugerida", typeof(System.String));
            table.Columns.Add("Cuenta_Salida_ID", typeof(System.String));
            table.Columns.Add("Cant_Cruza", typeof(System.String));
            table.Columns.Add("Cruzado_Item", typeof(System.String));
            table.Columns.Add("Especial", typeof(System.String));
            table.Columns.Add("Promos_aplicadas", typeof(System.String));
            table.Columns.Add("No_aplicar_promociones", typeof(System.String));
            table.Columns.Add("Producto_ID", typeof(System.String));
            table.Columns.Add("Cajas", typeof(System.String));
            table.Columns.Add("Unid_Sueltas", typeof(System.String));
            table.Columns.Add("TarifadeID", typeof(System.String));
            Session.Add("Tabla", table);
            if (!Page.IsPostBack)
            {
                Llenatabla();
                table = new System.Data.DataTable();
                table.Columns.Add("areadato", typeof(System.String));
                table.Columns.Add("plu", typeof(System.String));
                table.Columns.Add("detalle", typeof(System.String));
                table.Columns.Add("presentacion", typeof(System.String));
                table.Columns.Add("cantidadpres", typeof(System.String));
                table.Columns.Add("vrunit", typeof(System.String));
                table.Columns.Add("vrcosto", typeof(System.String));
                table.Columns.Add("vrprecio", typeof(System.String));
                table.Columns.Add("vrtotal", typeof(System.String));
                table.Columns.Add("vrcostototal", typeof(System.String));
                table.Columns.Add("vr_unit_extranjero", typeof(System.String));
                table.Columns.Add("total_extranjero", typeof(System.String));
                table.Columns.Add("vriva", typeof(System.String));
                table.Columns.Add("piva", typeof(System.String));
                table.Columns.Add("vrico", typeof(System.String));
                table.Columns.Add("vricouni", typeof(System.String));
                table.Columns.Add("vrdto", typeof(System.String));
                table.Columns.Add("Bodega_ID", typeof(System.String));
                table.Columns.Add("Tercero_ID", typeof(System.String));
                table.Columns.Add("CCostoID", typeof(System.String));
                table.Columns.Add("factorpres", typeof(System.String));
                table.Columns.Add("peso", typeof(System.String));
                table.Columns.Add("Dto_comercial", typeof(System.String));
                table.Columns.Add("Dto_Especial", typeof(System.String));
                table.Columns.Add("ref1", typeof(System.String));
                table.Columns.Add("ref2", typeof(System.String));
                table.Columns.Add("ref3", typeof(System.String));
                table.Columns.Add("otroscostos", typeof(System.Boolean));
                table.Columns.Add("Lista_precios_ID", typeof(System.String));
                table.Columns.Add("Cantidad_sugerida", typeof(System.String));
                table.Columns.Add("Cuenta_Salida_ID", typeof(System.String));
                table.Columns.Add("Cant_Cruza", typeof(System.String));
                table.Columns.Add("Cruzado_Item", typeof(System.String));
                table.Columns.Add("Especial", typeof(System.String));
                table.Columns.Add("Promos_aplicadas", typeof(System.String));
                table.Columns.Add("No_aplicar_promociones", typeof(System.String));
                table.Columns.Add("Producto_ID", typeof(System.String));
                table.Columns.Add("Cajas", typeof(System.String));
                table.Columns.Add("Unid_Sueltas", typeof(System.String));
                table.Columns.Add("TarifadeID", typeof(System.String));
                Session.Add("Tabla", table);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                var registrosm = Controlasql.ClistaitemsRecibo_compra(Ltipo.Value, Lnumero.Value,Session["BD"].ToString());
                if (registrosm.Tables[0].Rows.Count > 0)
                {
                    GridviewItemsCompra.DataSource = registrosm;
                    this.Page.Session["ds"] = registrosm;
                    var dt = registrosm.Tables[0];
                    string validador = "";
                    foreach (DataRow row in dt.Rows)
                    {
                        validador = Convert.ToString(row[9]);
                        
                    }
                  
                  
                    GridviewItemsCompra.DataBind();
                  
                }
                else
                {
                    GridviewItemsCompra.DataSource = null;
                    GridviewItemsCompra.DataBind();
                }
            }
            catch (Exception ex)
                {
                alerta.MessageBox(this, "Excepcion Interna:" + ex.Message);

            }
        }

    

        protected void GridviewItemsCompra_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridviewItemsCompra.EditIndex = -1;
            GridviewItemsCompra.DataSource = this.Page.Session["ds"];
            GridviewItemsCompra.DataBind();
        }

        protected void GridviewItemsCompra_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void GridviewItemsCompra_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridviewItemsCompra.EditIndex = e.NewEditIndex;
            GridviewItemsCompra.DataSource = this.Page.Session["ds"];
            GridviewItemsCompra.DataBind();

        }

        //protected void GridviewItemsCompra_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        //{
        //    try
        //    {
        //        var id = e.NewValues[1].ToString();
        //        var oc = e.NewValues[2].ToString();
        //        var pplu = e.NewValues[3].ToString();
        //        var pcant = e.NewValues[4].ToString();
        //        var pdetalle = e.NewValues[5].ToString();
        //        var pcostoanterior = e.NewValues[6].ToString();
        //        var pcostonuevo = e.NewValues[7].ToString();
        //        var pestado = e.NewValues[8].ToString();
        //        var pobserva = e.NewValues[9].ToString();
        //        var regis = Controlasql.CcreaitemsOC(oc, pplu, pcant, pdetalle, pestado,pestado, Session["BD"].ToString());
        //        //if (regis.Tables[0].Rows.Count > 0)
        //        //{

        //        //    GridviewItemsCompra.DataSource = regis;
        //        //    this.Page.Session["ds"] = regis;
        //        //    GridviewItemsCompra.DataBind();
        //        //}
        //        //else
        //        //{
        //        //    GridviewItemsCompra.DataSource = null;
        //        //    GridviewItemsCompra.DataBind();
        //        //}
        //        Llenatabla();
        //    }
        //    catch (Exception ex)
        //    {

        //        lbestado.Text=ex.Message;
        //    }

        //}
        public void Llenatabla()
        {
            try
            {

                var registrosm = Controlasql.ClistaitemsRecibo_compra(Ltipo.Value, Lnumero.Value, Session["BD"].ToString());
                if (registrosm.Tables[0].Rows.Count > 0)
                {

                    GridviewItemsCompra.DataSource = registrosm;
                    this.Page.Session["ds"] = registrosm;
                 
                    GridviewItemsCompra.DataBind();
                }
                else
                {
                    GridviewItemsCompra.DataSource = null;
                    GridviewItemsCompra.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna:" + ex.Message);

            }
        }

        protected void GridviewItemsCompra_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = e.NewValues[0].ToString();
                var pcant = e.NewValues[2].ToString();
                  
                var pcostonuevo = e.NewValues[4].ToString().Replace(',','.');
                //string pestado =Select  ;
                var pobserva = e.NewValues[5].ToString();
                var estate = e.NewValues[6].ToString();
                if (estate.Equals("BON"))
                {
                    estate = "BON";
                }
                else
                {
                    estate = "R";
                }
               
                var regis = Controlasql.CupdateitemsOC(id, pcant, pcostonuevo,estate,pobserva, Session["BD"].ToString());
                //if (regis.Tables[0].Rows.Count > 0)
                //{

                //    GridviewItemsCompra.DataSource = regis;
                //    this.Page.Session["ds"] = regis;
                //    GridviewItemsCompra.DataBind();
                //}
                //else
                //{
                //    GridviewItemsCompra.DataSource = null;
                //    GridviewItemsCompra.DataBind();
                //}

                GridviewItemsCompra.EditIndex = -1;
                Llenatabla();
                lbestado.Text = id+" - Registro actualizado";
            }
            catch (Exception ex)
            {

                lbestado.Text = ex.Message;
            }
        }

        protected void GridviewItemsCompra_DataBound(object sender, EventArgs e)
        {
           
            double f = 0;
            double np = 0;
            double mav = 0;
            double mev = 0;
            double nll = 0;
            double sll = 0;
            double dev = 0;
            for (int i = 0; i < GridviewItemsCompra.Rows.Count; i++)
            {
                string stado = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[10].Text);
                string stadodev = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[11].Text);

                
               

                f += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[15].Text.Replace('.',','));
                    np += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[16].Text.Replace('.', ','));
                    mav += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[17].Text.Replace('.', ','));
                    mev += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[18].Text.Replace('.', ','));
                    nll += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[19].Text.Replace('.', ','));
                    dev += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[20].Text.Replace('.', ','));
                var dato = GridviewItemsCompra.Rows[i].Cells[21].Text.Replace('.', ',');
                if (dato=="")
                {
                    dato = "0";
                }
                   sll += Convert.ToDouble(dato);
              
            
                txtF.Value = f.ToString();
                txtNP.Value = np.ToString();
                txtMaV.Value = mav.ToString();
                txtMeV.Value = mev.ToString();
                txtNLL.Value = nll.ToString();
                txtDev.Value = dev.ToString();
                txtSll.Value = sll.ToString();

                if (stado.Equals("R"))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.DarkGray;


                }
                if (stadodev.Equals("DEV"))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.DarkRed;
                    GridviewItemsCompra.Rows[i].ForeColor = Color.White;

                }
                if (stado.Equals("BON"))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.YellowGreen;
                    GridviewItemsCompra.Rows[i].ForeColor = Color.White;

                }

            }
           
        }
        public void renderisado()
        {
            double f = 0;
            double np = 0;
            double mav = 0;
            double mev = 0;
            double nll = 0;
            double sll = 0;
            double dev = 0;
            for (int i = 0; i < GridviewItemsCompra.Rows.Count; i++)
            {
                string stado = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[10].Text);
                string stadodev = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[11].Text);




                f += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[15].Text.Replace('.', ','));
                np += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[16].Text.Replace('.', ','));
                mav += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[17].Text.Replace('.', ','));
                mev += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[18].Text.Replace('.', ','));
                nll += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[19].Text.Replace('.', ','));
                dev += Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[20].Text.Replace('.', ','));
                var dato = GridviewItemsCompra.Rows[i].Cells[21].Text.Replace('.', ',');
                if (dato == "")
                {
                    dato = "0";
                }
                sll += Convert.ToDouble(dato);


                txtF.Value = f.ToString();
                txtNP.Value = np.ToString();
                txtMaV.Value = mav.ToString();
                txtMeV.Value = mev.ToString();
                txtNLL.Value = nll.ToString();
                txtDev.Value = dev.ToString();
                txtSll.Value = sll.ToString();

                if (stado.Equals("R"))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.DarkGray;


                }
                if (stadodev.Equals("DEV"))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.DarkRed;
                    GridviewItemsCompra.Rows[i].ForeColor = Color.White;

                }
                if (stado.Equals("BON"))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.YellowGreen;
                    GridviewItemsCompra.Rows[i].ForeColor = Color.White;

                }

            }
        }
        public void ExportListFromGridView()
        {
            var guid = Guid.NewGuid().ToString();



            var name = "AppLcsDevoluciones";

            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "text";
            SLDocument osLDocument = new SLDocument();
            osLDocument.AddWorksheet("inventario");
            for (int i = 0; i < GridviewItemsCompra.Rows.Count; i++)
            {
                string rowtest = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[11].Text);
                if ( rowtest != "DEV")
                {
                    if (rowtest != "NLL-")
                    {
                        string areadato = "0";
                        string plu = Page.Server.HtmlDecode(GridviewItemsCompra.Rows[i].Cells[3].Text);
                        string detalle = "";
                        string presentacion = Page.Server.HtmlDecode(GridviewItemsCompra.Rows[i].Cells[26].Text);
                        string cantidadpres = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[5].Text.Replace('.', ','));
                        string vrunit = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[8].Text);
                        string vrcosto = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[8].Text);
                        string vrprecio = "";
                        string vrtotal = "0";
                        string vrcostototal = Convert.ToString(

                                                (Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[5].Text)) *
                                                (Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[8].Text))

                                                );
                        string vr_unit_extranjero = "";
                        string total_extranjero = "";
                        string vriva = Convert.ToString(
                                                 (
                                                (Convert.ToDouble(vrcostototal)) *
                                                (Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[23].Text.Replace(',', '.')))
                                                / 100)
                                                );

                        string piva = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[23].Text.Replace(',', '.'));
                        string vrico = "";
                        string vricouni = "";
                        string vrdto = "";
                        string Bodega_ID = "30";
                        string Tercero_ID = "";
                        string CCostoID = "";
                        string factorpres = Page.Server.HtmlDecode(GridviewItemsCompra.Rows[i].Cells[25].Text) ;
                        string peso = "0";
                        string Dto_comercial = "0";
                        string Dto_Especial = "";
                        string ref1 = "";
                        string ref2 = "";
                        string ref3 = "";
                        Boolean otroscostos = false;
                        string Lista_precios_ID = "";
                        string Cantidad_sugerida = "";
                        string Cuenta_Salida_ID = "";
                        string Cant_Cruza = "";
                        string Cruzado_Item = "";
                        string Especial = "";
                        string Promos_aplicadas = "";
                        string No_aplicar_promociones = "";
                        string Producto_ID = "";
                        string Cajas = "";
                        string Unid_Sueltas = "";
                        string TarifadeID = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[24].Text);
                        table = (System.Data.DataTable)(Session["Tabla"]);
                        row = table.NewRow();
                        row["areadato"] = areadato;
                        row["plu"] = plu;
                        row["detalle"] = detalle;
                        row["presentacion"] = presentacion;
                        row["cantidadpres"] = cantidadpres;
                        row["vrunit"] = vrunit;
                        row["vrcosto"] = vrcosto;
                        row["vrprecio"] = vrprecio;
                        row["vrtotal"] = vrtotal;
                        row["vrcostototal"] = vrcostototal;
                        row["vr_unit_extranjero"] = vr_unit_extranjero;
                        row["total_extranjero"] = total_extranjero;
                        row["vriva"] = vriva;
                        row["piva"] = piva;
                        row["vrico"] = vrico;
                        row["vricouni"] = vricouni;
                        row["vrdto"] = vrdto;
                        row["Bodega_ID"] = Bodega_ID;
                        row["Tercero_ID"] = Tercero_ID;
                        row["CCostoID"] = CCostoID;
                        row["factorpres"] = factorpres;
                        row["peso"] = peso;
                        row["Dto_comercial"] = Dto_comercial;
                        row["Dto_Especial"] = Dto_Especial;
                        row["ref1"] = ref1;
                        row["ref2"] = ref2;
                        row["ref3"] = ref3;
                        row["otroscostos"] = otroscostos;
                        row["Lista_precios_ID"] = Lista_precios_ID;
                        row["Cantidad_sugerida"] = Cantidad_sugerida;
                        row["Cuenta_Salida_ID"] = Cuenta_Salida_ID;
                        row["Cant_Cruza"] = Cant_Cruza;
                        row["Cruzado_Item"] = Cruzado_Item;
                        row["Especial"] = Especial;
                        row["Promos_aplicadas"] = Promos_aplicadas;
                        row["No_aplicar_promociones"] = No_aplicar_promociones;
                        row["Producto_ID"] = Producto_ID;
                        row["Cajas"] = Cajas;
                        row["Unid_Sueltas"] = Unid_Sueltas;
                        row["TarifadeID"] = TarifadeID;

                        table.Rows.Add(row);

                        Session.Add("Tabla", table);
                    }
                   
                }
                else
                {
                    lbestado.Text = "algunos items sin datos";
                }
                
            }
            osLDocument.ImportDataTable(1, 1, table, true);
     
            osLDocument.SaveAs(pathFile + $"\\{guid}-{name}.xlsx");
            Session.Remove("Tabla");
            var file = $"{guid}-{name}.xlsx";
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AppendHeader("Content-Disposition", "attachment;filename=LcsApp.xlsx");

            Response.TransmitFile(Server.MapPath("~/text/" + file + ""));
            Response.End();




        }

        public void ExportListDev()
        {
            var guid = Guid.NewGuid().ToString();

          

            var name = "AppLcsDevoluciones";
           
            string pathFile = AppDomain.CurrentDomain.BaseDirectory + "text";
          
            SLDocument osLDocument = new SLDocument();
            osLDocument.AddWorksheet("inventario");
            for (int i = 0; i < GridviewItemsCompra.Rows.Count; i++)
            {
                string rowtest = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[11].Text);
                if (rowtest == "DEV")
                {
                   
                        string areadato = "0";
                        string plu = Page.Server.HtmlDecode(GridviewItemsCompra.Rows[i].Cells[3].Text);
                        string detalle = "";
                        string presentacion = Page.Server.HtmlDecode(GridviewItemsCompra.Rows[i].Cells[26].Text);
                    string cantidadpres = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[5].Text.Replace('.', ','));
                        string vrunit = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[8].Text);
                        string vrcosto = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[8].Text);
                        string vrprecio = "";
                        string vrtotal = "0";
                        string vrcostototal = Convert.ToString(

                                                (Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[5].Text)) *
                                                (Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[8].Text))

                                                );
                        string vr_unit_extranjero = "";
                        string total_extranjero = "";
                        string vriva = Convert.ToString(
                                                 (
                                                (Convert.ToDouble(vrcostototal)) *
                                                (Convert.ToDouble(GridviewItemsCompra.Rows[i].Cells[23].Text.Replace(',', '.')))
                                                / 100)
                                                );

                        string piva = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[23].Text.Replace(',', '.'));
                        string vrico = "";
                        string vricouni = "";
                        string vrdto = "";
                        string Bodega_ID = "30";
                        string Tercero_ID = "";
                        string CCostoID = "";
                        string factorpres = Page.Server.HtmlDecode(GridviewItemsCompra.Rows[i].Cells[25].Text);
                    string peso = "0";
                        string Dto_comercial = "0";
                        string Dto_Especial = "";
                        string ref1 = "";
                        string ref2 = "";
                        string ref3 = "";
                        Boolean otroscostos = false;
                        string Lista_precios_ID = "";
                        string Cantidad_sugerida = "";
                        string Cuenta_Salida_ID = "";
                        string Cant_Cruza = "";
                        string Cruzado_Item = "";
                        string Especial = "";
                        string Promos_aplicadas = "";
                        string No_aplicar_promociones = "";
                        string Producto_ID = "";
                        string Cajas = "";
                        string Unid_Sueltas = "";
                        string TarifadeID = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[24].Text);
                        table = (System.Data.DataTable)(Session["Tabla"]);
                        row = table.NewRow();
                        row["areadato"] = areadato;
                        row["plu"] = plu;
                        row["detalle"] = detalle;
                        row["presentacion"] = presentacion;
                        row["cantidadpres"] = cantidadpres;
                        row["vrunit"] = vrunit;
                        row["vrcosto"] = vrcosto;
                        row["vrprecio"] = vrprecio;
                        row["vrtotal"] = vrtotal;
                        row["vrcostototal"] = vrcostototal;
                        row["vr_unit_extranjero"] = vr_unit_extranjero;
                        row["total_extranjero"] = total_extranjero;
                        row["vriva"] = vriva;
                        row["piva"] = piva;
                        row["vrico"] = vrico;
                        row["vricouni"] = vricouni;
                        row["vrdto"] = vrdto;
                        row["Bodega_ID"] = Bodega_ID;
                        row["Tercero_ID"] = Tercero_ID;
                        row["CCostoID"] = CCostoID;
                        row["factorpres"] = factorpres;
                        row["peso"] = peso;
                        row["Dto_comercial"] = Dto_comercial;
                        row["Dto_Especial"] = Dto_Especial;
                        row["ref1"] = ref1;
                        row["ref2"] = ref2;
                        row["ref3"] = ref3;
                        row["otroscostos"] = otroscostos;
                        row["Lista_precios_ID"] = Lista_precios_ID;
                        row["Cantidad_sugerida"] = Cantidad_sugerida;
                        row["Cuenta_Salida_ID"] = Cuenta_Salida_ID;
                        row["Cant_Cruza"] = Cant_Cruza;
                        row["Cruzado_Item"] = Cruzado_Item;
                        row["Especial"] = Especial;
                        row["Promos_aplicadas"] = Promos_aplicadas;
                        row["No_aplicar_promociones"] = No_aplicar_promociones;
                        row["Producto_ID"] = Producto_ID;
                        row["Cajas"] = Cajas;
                        row["Unid_Sueltas"] = Unid_Sueltas;
                        row["TarifadeID"] = TarifadeID;

                        table.Rows.Add(row);

                        Session.Add("Tabla", table);
                  
                }
                else
                {
                    lbestado.Text = "algunos items sin datos";
                }

            }
           
            osLDocument.ImportDataTable(1, 1, table, true);
           
            osLDocument.SaveAs(pathFile + $"\\{guid}-{name}.xlsx");
            Session.Remove("Tabla");
               var file = $"{guid}-{name}.xlsx";
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AppendHeader("Content-Disposition", "attachment;filename=LcsApp.xlsx");

            Response.TransmitFile(Server.MapPath("~/text/"+file+""));
            Response.End();



        }
       
        protected void GridviewItemsCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            GridViewRow gr = GridviewItemsCompra.SelectedRow;
            var idCompra = Page.Server.HtmlDecode(gr.Cells[2].Text);
            var plu = Page.Server.HtmlDecode(gr.Cells[3].Text);
            var detalle = Page.Server.HtmlDecode(gr.Cells[4].Text);
            try
            {
                var registro = Controlasql.CInsertitemsbonificado(idCompra, plu, detalle,Session["BD"].ToString());
                if (registro >0)
                {
                    lbestado.Text = "bonificado ok";
                    try
                    {

                        var registrosm = Controlasql.ClistaitemsRecibo_compra(Ltipo.Value, Lnumero.Value, Session["BD"].ToString());
                        if (registrosm.Tables[0].Rows.Count > 0)
                        {
                            GridviewItemsCompra.DataSource = registrosm;
                            this.Page.Session["ds"] = registrosm;
                            var dt = registrosm.Tables[0];
                            string validador = "";
                            foreach (DataRow row in dt.Rows)
                            {
                                validador = Convert.ToString(row[9]);

                            }


                            GridviewItemsCompra.DataBind();
                            
                        }
                        else
                        {
                            GridviewItemsCompra.DataSource = null;
                            GridviewItemsCompra.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        alerta.MessageBox(this, "Excepcion Interna:" + ex.Message);

                    }
                }
            }
            catch (Exception ex)
            {

                lbestado.Text =  "Excepcion no Controlada= "+ex.Message ;
            }
            
        }

       
        protected void BtnExportar_Click(object sender, EventArgs e)
        {
            ExportListFromGridView();
        }
        public void Exportardata()
        {
           
        }

        protected void BtnExportarDev_Click(object sender, EventArgs e)
        {
            ExportListDev();
        }

        protected void Btnbuscaitems_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridviewItemsCompra.Rows.Count; i++)
            {
                string stado = Convert.ToString(GridviewItemsCompra.Rows[i].Cells[3].Text);
                if (stado.Contains(txtbuscadorplu.Value))
                {
                    GridviewItemsCompra.Rows[i].BackColor = Color.Cyan;

                }
                else
                {
                    renderisado();
                }
            }


        }
       

    }
}