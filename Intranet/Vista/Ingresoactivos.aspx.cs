using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class Ingresoactivos : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenamodelos();
                llenafabricante();
                llenaCategoria();
                llenaproveedor();
                alerta.Visible = false;
                modal.Visible = false;
               
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
                    
                    txtaviso.Visible = true;
                    txtaviso.InnerText = "Registro Guardado Correctamente";

                }
                else
                {
                    alerta.Visible = true;
                }


                //aqui limpia la pantalla
                Select1.Value = "";
                Select2.Value = "";
                Select3.Value = "";
                Select4.Value = "";
                txtserial.Value = "";
                txtnombre.Value = "";
                txtcoment.Value = "";
                txtfechacompra.Value = "";
                txtvalor.Value = "";
                txtgarantia.Value = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        protected void CreaMOdelo_Click(object sender, EventArgs e)
        {
          
            try
            {
                var registros = Controlasql.CcreaModelo(Textmodelo.Value.ToUpper(),  Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                   
                    Nuevomodelo.Visible = false;
                    llenamodelos();
                    Select1.Focus();
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alerta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void CreaFabrica_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CcreaFabricante(Textmodelo.Value.ToUpper(), 
                    Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    Nuevomodelo.Visible = false;
                    llenamodelos();
                    Select1.Focus();
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alerta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void CreaCategoria_Click(object sender, EventArgs e)
        {

            try
            {
                var registros = Controlasql.CcreaModelo(Textmodelo.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {

                    Nuevomodelo.Visible = false;
                    llenamodelos();
                    Select1.Focus();
                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alerta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void CreaActivo_Click(object sender, EventArgs e)
        {
            String Vmodelo = Select1.Value;
            String Vfabricante = Select2.Value;
            llenavariableid();
            String Varserial = txtserial.Value.ToUpper();
            try
            {
                var registros = Controlasql.Ccreaactivo(txtaviso.InnerText, txtserial.Value.ToUpper(), txtnombre.Value.ToUpper(),
                Select1.Value, Select2.Value, Select3.Value, txtcoment.Value.ToUpper(),
                Select4.Value.ToString(), txtgarantia.Value, txtfechacompra.Value, txtvalor.Value,
                Session["USUARIO"].ToString(), Session["BD"].ToString());
                if (registros > 0)
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    modal.Visible = true;

                }
                else
                {
                    serialcantidad.Value = txtserial.Value.ToUpper();
                    alerta.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+bd+"';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select nombMod FROM modelo", cn);
                dr = cm.ExecuteReader();
                Select1.Items.Clear();
                while (dr.Read())
                {
                    Select1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            

        }

     
        public void llenafabricante()
        {
            try
            {
                
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select nombFabric FROM fabricante", cn);
                dr = cm.ExecuteReader();
                Select2.Items.Clear();
                while (dr.Read())
                {
                    Select2.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
       
        public void llenaCategoria()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("   select nombCat FROM categoria", cn);
                dr = cm.ExecuteReader();
                Select3.Items.Clear();
                while (dr.Read())
                {
                    Select3.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();

            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
           
        }
        public void llenaproveedor()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select nomb FROM persona where esproveedor = true", cn);
                dr = cm.ExecuteReader();
                Select4.Items.Clear();
                while (dr.Read())
                {
                    Select4.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
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
            catch (Exception)
            {

                Response.Redirect("Exceptionnet.aspx");
            }
            
        }
        public void mostrarmenuModelo(object sender, EventArgs e)
        {
            Nuevomodelo.Visible =true;
        }
        public void ocultarmenuModelo(object sender, EventArgs e)
        {
            Nuevomodelo.Visible = false;
        }
        public void mostrarmenuFabricante(object sender, EventArgs e)
        {
            NuevoFabricante.Visible = true;
        }
        public void ocultarmenufabrica(object sender, EventArgs e)
        {
            NuevoFabricante.Visible = false;
        }
        public void mostrarmenucategoria(object sender, EventArgs e)
        {
            NuevoCategoria.Visible = true;
        }
        public void ocultarmenucategoria(object sender, EventArgs e)
        {
            NuevoCategoria.Visible = false;
        }
        public void llenavariablecant_articulo()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
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
            catch (Exception)
            {
                Response.Redirect("Exceptionnet.aspx");
            }
            

        }


    }
}