using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using MySql.Data.MySqlClient;




namespace Intranet.Vista
{
    public partial class Ingactivos : System.Web.UI.Page
    {
      
        Controlasql sb = new Controlasql();
        System.Data.DataTable table;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                textid.Enabled = false;
                llenamodelos();
                llenafabricante();
                llenaCategoria();
                llenaproveedor();
                notificacion.Visible = false;
                excepcion.Visible = false;
                alertaid.Visible = false;
                modal.Visible = false;
                llenaLinea();
                btnactualizar.Visible = false;
                btnguardar.Visible = false;
                disablecasillas();
                
            }
        }
        public void si_Click(object sender, EventArgs e)
        {
            serialcantidad.Value = txtserial.Value.ToUpper();
            llenavariablecant_articulo();
            try
            {
                var registros = Controlasql.Ccreacantidadactivo(txtaviso.InnerText, serialcantidad.Value,
                    canti.Value, Session["BD"].ToString());
                if (registros > 0)
                {
                    modal.Visible = false;
                    notificacion.Visible = true;
                    txtnotifica.InnerText = "Registro Exitoso";

                }
                else
                {
                    alertaid.Visible = true;
                }


                //aqui limpia la pantalla
               
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Registro la Cantidad. Error: " + ex.Message;
            }

        }
        protected void CreaMOdelo_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CcreaModelo(Textmodelo.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                    excepcion.Visible = false;
                    notificacion.Visible = true;
                    txtnotifica.InnerText = "Registro exitoso";
           
                    llenamodelos();
                    Selectmodelo.Focus();
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Registro el Modelo. Error: " + ex.Message;
            }


        }
       
        protected void GridViewdetalle_RowEditing(object sender, EventArgs e)
        {
           
            GridViewRow gr = GridViewNovedades.SelectedRow;
            textid.Text = gr.Cells[1].Text;
            txtserial.Value = gr.Cells[2].Text;
           
            txtnombre.Value = Page.Server.HtmlDecode(gr.Cells[3].Text) ;
            txtvalor.Value = gr.Cells[4].Text;
            txtgarantia.Value = gr.Cells[5].Text;
            SelectTercero.Value = gr.Cells[6].Text;
            txtfechacompra.Value = gr.Cells[7].Text;
            Selectmodelo.Value = gr.Cells[8].Text;//mode
            SelectFabricante.Value = gr.Cells[9].Text;//fabr
            SelectCategoria.Value = gr.Cells[10].Text;//cate
            txtcoment.Value = Page.Server.HtmlDecode(gr.Cells[11].Text);//coment

        }
       
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            table = (System.Data.DataTable)(Session["Tabla"]);
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt1 = Session["Tabla"] as DataTable;
            dt1.Rows[index].Delete();
            Session["Tabla"] = dt1;

            GridViewNovedades.DataSource = dt1;
            GridViewNovedades.DataBind();

        }
        protected void CreaFabrica_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CcreaFabricante(Textfabricante.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                                  llenafabricante();
                    SelectFabricante.Focus();
                    excepcion.Visible = false;
                    notificacion.Visible = true;
                    txtnotifica.InnerText = "Registro Exitoso";
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Registro. Error: " + ex.Message;
            }


        }
        protected void CreaCategoria_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.Ccreacategoria(Textcategoria.Value.ToUpper(),
                    TxtVidaUtil.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                
                    llenaCategoria();
                    SelectCategoria.Focus();
                    excepcion.Visible = false;
                    notificacion.Visible = true;
                    txtnotifica.InnerText = "Registro Exitoso";
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se registro. Error: " + ex.Message;
            }


        }
        protected void Creanuevalinea(object sender, EventArgs e)
        {
            try
            {
                var registros = Controlasql.CcreaFabricante(Textfabricante.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    llenafabricante();
                    SelectFabricante.Focus();
                    excepcion.Visible = false;
                    notificacion.Visible = true;
                    txtnotifica.InnerText = "Registro Exitoso";
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Registro. Error: " + ex.Message;
            }



        }
        protected void CreaTercero_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CcreaTercero(txtccoNit.Value.ToUpper(),txtNomb.Value.ToUpper(),
                    txtdir.Value.ToUpper(),txttel.Value,txtCiudad.Value.ToUpper(),
                    txtEmail.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                    llenaproveedor();
                    SelectTercero.Focus();
                    notificacion.Visible = true;
                    excepcion.Visible = false;
                    txtnotifica.InnerText = "Registro Exitoso";
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Registro. Error: " + ex.Message;
            }


        }
        protected void CreaActivo_Click(object sender, EventArgs e)
        {
            String Vmodelo = Selectmodelo.Value;
            String Vfabricante = SelectFabricante.Value;
            llenavariableid();
            String Varserial = txtserial.Value.ToUpper();
            try
            {
                var registros = Controlasql.Ccreaactivo(txtaviso.InnerText, txtserial.Value.ToUpper(), txtnombre.Value.ToUpper(),
                Selectmodelo.Value, SelectFabricante.Value, SelectCategoria.Value, txtcoment.Value.ToUpper(),
                SelectTercero.Value.ToString(), txtgarantia.Value, txtfechacompra.Value,
                txtvalor.Value, Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    modal.Visible = true;

                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registro. Error: " + ex.Message;
            }


        }

        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        public void llenamodelos()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraemodelo(bd);
                Selectmodelo.Items.Clear();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectmodelo.Items.Add(Convert.ToString(row["nombMod"]));
                        Selectmodelo.DataBind();
                    }
                }
                else
                {
                    Selectmodelo.DataSource = null;
                    Selectmodelo.DataBind();
                }

            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }


        }
        public void llenafabricante()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraefabricante(bd);
                SelectFabricante.Items.Clear();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectFabricante.Items.Add(Convert.ToString(row["nombFabric"]));
                        SelectFabricante.DataBind();
                    }
                }
                else
                {
                    SelectFabricante.DataSource = null;
                    SelectFabricante.DataBind();
                }

            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: "+ex.Message;
            }

        }

        public void llenaCategoria()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraecategoriaactivos(bd);
                SelectCategoria.Items.Clear();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectCategoria.Items.Add(Convert.ToString(row["nombCat"]));
                        SelectCategoria.DataBind();
                    }
                }
                else
                {
                    SelectCategoria.DataSource = null;
                    SelectCategoria.DataBind();
                }
            }
            catch (Exception e)
            {

                alerta.MessageBox(this,"excepcion Interna: "+e.Message);
            }
            

        }
        public void llenaproveedor()//ctraeproveedor
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraeproveedoractivos(bd);
                SelectTercero.Items.Clear();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectTercero.Items.Add(Convert.ToString(row["nomb"]));
                        SelectTercero.DataBind();
                    }
                }
                else
                {
                    SelectTercero.DataSource = null;
                    SelectTercero.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }


        }
        public void llenavariableid()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("SELECT max(idArt+1) as idArt from articulo", cn);
                dr = cm.ExecuteReader();
                txtaviso.InnerText = "";
                while (dr.Read())
                {
                    txtaviso.InnerText = (dr[0].ToString());
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }

        }
        public void llenaLinea()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ctraelinea(bd);
                Selectlinea.Items.Clear();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        Selectlinea.Items.Add(Convert.ToString(row["nombre"]));
                        Selectlinea.DataBind();
                    }
                }
                else
                {
                    Selectlinea.DataSource = null;
                    Selectlinea.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }

        }




        public void llenavariablecant_articulo()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("SELECT max(id+1) from cantproducto", cn);
                dr = cm.ExecuteReader();
                txtaviso.InnerText = "";
                while (dr.Read())
                {
                    txtaviso.InnerText = (dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se cargo el Id. Error: " + ex.Message;
            }


        }
        protected void listadoactivos(object sender,EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.listaactivo(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewNovedades.DataSource = registros;
                    GridViewNovedades.DataBind();
                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }
            }
            catch (Exception ex)
            {

                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }
        }
        protected void listadoactivosserial(object sender, EventArgs e)
        {
            var ser = searh_serial.Value;
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.listaactivoserial(ser,bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                 
                    GridViewNovedades.DataSource = registros;
                    GridViewNovedades.DataBind();
                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message; 
            }
        }
        protected void listadoactivonombre(object sender, EventArgs e)
        {
         
            try
            {
                string bd = Session["BD"].ToString();
                var registros = Controlasql.listaactivonombre(buscadortxtnombre.Value.ToString(),bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    
                    GridViewNovedades.DataSource = registros;
                    GridViewNovedades.DataBind();
             
                }
                else
                {
                    GridViewNovedades.DataSource = null;
                    GridViewNovedades.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }
        }
        public void disablecasillas()
        {
          

            txtnombre.Disabled = true;
            txtserial.Disabled = true;
            txtgarantia.Disabled = true;
            txtcoment.Disabled = true;
            txtfechacompra.Disabled = true;
            txtvalor.Disabled = true;
            TxtVidaUtil.Disabled = true;
            Selectmodelo.Disabled = true;
            SelectFabricante.Disabled = true;
            SelectCategoria.Disabled = true;
            SelectTercero.Disabled = true;


        }
        public void Enablecasillas()
        {
            txtccoNit.Disabled = false;

            txtnombre.Disabled = false;
            txtserial.Disabled = false;
            txtgarantia.Disabled = false;
            txtcoment.Disabled = false;
            txtfechacompra.Disabled = false;
            txtvalor.Disabled = false;
            TxtVidaUtil.Disabled = false;
            Selectmodelo.Disabled = false;
            SelectFabricante.Disabled = false;
            SelectCategoria.Disabled = false;
            SelectTercero.Disabled = false;


        }
        protected void clickbtneditar()
        {
            Enablecasillas();
            btnactualizar.Visible = true;
            btnNuevo.Visible = true;
            btnguardar.Visible = false;
          

        }
        protected void clickbtnnuevo()
        {
            btnactualizar.Visible = false;
            btneditar.Visible = false;
            btnguardar.Visible = true;
            Enablecasillas();
        }
        protected void clickbtactualiza()
        {
            btnactualizar.Visible = false;
            btneditar.Visible = true;
            btnguardar.Visible = false;
            
            disablecasillas();

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            clickbtnnuevo();


        }
      

        protected void btneditar_Click(object sender, EventArgs e)
        {
            clickbtneditar();
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            clickbtactualiza();
           
                String Vmodelo = Selectmodelo.Value;
            String Vfabricante = SelectFabricante.Value;
          
            String Varserial = txtserial.Value.ToUpper();
            try
            {
                var registros = Controlasql.cupdateactivo(textid.Text, txtserial.Value.ToUpper(), txtnombre.Value.ToUpper(), txtcoment.Value.ToUpper()
               , txtgarantia.Value, Selectmodelo.Value, SelectFabricante.Value, SelectCategoria.Value,
                SelectTercero.Value.ToString(),  txtfechacompra.Value, txtvalor.Value,
                Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                    notificacion.Visible = true;
                    excepcion.Visible = false;
                    txtnotifica.InnerText = "Registro Exitoso";

                }
                else
                {
                    notificacion.Visible = false;
                    excepcion.Visible = true;
                    error.InnerText = "No registrado";
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alertaid.Visible = true;
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No Registros. Error: " + ex.Message;
            }

        }
    }
}