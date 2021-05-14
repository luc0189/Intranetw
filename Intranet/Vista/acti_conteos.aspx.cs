using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using System.Data.SqlClient;
using System.Data;

namespace Intranet.Vista
{
    public partial class acti_conteos : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                actualizaconteosabiertos();
                actualizaconteos2();
                listaabiertosc1();
                listaabiertosc2();

            }

        }

        public void listaabiertosc2()
        {
            try
            {
                var registros2 = ControlaSql.Clista_abiertos("32");
                if (registros2.Tables[0].Rows.Count > 0)
                {
                    GridViewconteos2.DataSource = registros2;
                    GridViewconteos2.DataBind();
                }
                else
                {
                    GridViewconteos2.DataSource = null;
                    GridViewconteos2.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna" + ex.Message);
            }
        }
        public void listaabiertosc1()
        {
            try
            {
                var registros = ControlaSql.Clista_abiertos("31");
                if (registros.Tables[0].Rows.Count > 0)
                {
                    GridViewabiertos1.DataSource = registros;
                    GridViewabiertos1.DataBind();
                }
                else
                {
                    GridViewabiertos1.DataSource = null;
                    GridViewabiertos1.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna" + ex.Message);
            }

        }
        protected void Adicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var registros13 = ControlaSql.Cabreconteo(txtidconteo.Value);
                if (registros13 > 0)
                {
                    alerta.MessageBox(this, "Conteo Abierto");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }


        }

        public void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.Ccierraconteo(txtidconteo.Value);
                if (registros > 0)
                {
                    alerta.MessageBox(this, "Conteo Cerrado");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }

        }

       

        protected void Button2_click(object sender, EventArgs e)
        {
          
            alerta.MessageBox(this, "No se Realizo Ningun Cambio");
            actualizaconteosabiertos();
            actualizaconteos2();
            listaabiertosc1();
            listaabiertosc2();
        }
        protected void Button3_click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.Cactivaconteo1();
                if (registros > 0)
                {
                   
                    alerta.MessageBox(this, "Se activaron Todos los Modulos Conteo 1");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }

        }
     
     
        protected void Button4_click(object sender, EventArgs e)
        {
            
           
            alerta.MessageBox(this, "No se Realizo Ningun cambio");
            actualizaconteosabiertos();
            actualizaconteos2();
            listaabiertosc1();
            listaabiertosc2();
        }
        protected void Btnactivaconteos2(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.Cactivaconteo2();
                if (registros > 0)
                {
                                 
                    alerta.MessageBox(this, "Se Activaron todos los Conteos 2");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                  
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }

        }

        //aqui termina
        protected void si_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.Climpiaconteo(txtidconteo.Value);
                if (registros > 0)
                {
                    alerta.MessageBox(this, "Se eliminaron todos los items del Conteo Seleccionado");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            txtidconteo.Focus();
            alerta.MessageBox(this, "No se realizo ningun Cambio");
            actualizaconteosabiertos();
            actualizaconteos2();
            listaabiertosc1();
            listaabiertosc2();
        }
        SqlConnection cn;
        SqlCommand cm;
        SqlDataReader dr;
        public void actualizaconteosabiertos()
        {
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = "Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False";
                cn.Open();
                cm = new SqlCommand("select count(*) from invenfis where grupoinvenfisID=31 and protejido=0", cn);
                dr = cm.ExecuteReader();
                txtcactivos.InnerText = "";
                while (dr.Read())
                {

                    txtcactivos.InnerText = (dr[0].ToString());
                }

                try
                {
                    var registros = ControlaSql.Ctotalconteo1();
                    DataTable dt = registros.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        int conteoa = Convert.ToInt32(txtcactivos.InnerText);
                        Int32 valor1 = Convert.ToInt32(row[0]);
                        float multiplica = (100 * conteoa) / valor1;
                        float total = 100 - multiplica;
                        this.bar1.Attributes.Add("style", "width:" + total + "%");
                        r.InnerText = "" + total + "%";

                    }
                }
                catch (Exception e)
                {

                    alerta.MessageBox(this, "Excepcion Interna: " + e.Message);
                }


                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }




        }
        public void actualizaconteos2()
        {
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = "Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False";
                cn.Open();
                cm = new SqlCommand("select count(*) from invenfis where grupoinvenfisID=32 and protejido=0", cn);
                dr = cm.ExecuteReader();
                txtactivosdos.InnerText = "";

                while (dr.Read())
                {
                    txtactivosdos.InnerText = (dr[0].ToString());

                }
                var registros = ControlaSql.Ctotalconteo2();
                DataTable dt = registros.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    int conteoa = Convert.ToInt32(txtactivosdos.InnerText);
                    Int32 valor1 = Convert.ToInt32(row[0]);
                    float multiplica = (100 * conteoa) / valor1;
                    float total = 100 - multiplica;
                    this.Bar2.Attributes.Add("style", "width:" + total + "%");
                    txtpor2.InnerText = "" + total + "%";

                }


                dr.Close();
                cn.Close();


            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }


        }

        protected void btncierra1_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.Ccierraconteo1();
                if (registros > 0)
                {
                    alerta.MessageBox(this, "Conteo Cerrado");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {
                    alerta.MessageBox(this, "No se realizo ningun Cambio");
                }

            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }

        }

        protected void Btncierra2_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.Ccierraconteo2();
                if (registros > 0)
                {
                   
                    alerta.MessageBox(this, "Todos los Modulos del CONTEO 2 fueron CERRADOS");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {
                    alerta.MessageBox(this, "Error Al Grabar");
                }

            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }
        }

   


        protected void btnabrirRango_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.CabreoCierraRangoConteos(txtIdInicio.Value, txtIdFin.Value, 0);
                if (registros > 0)
                {
                 
                    alerta.MessageBox(this, "Rango de Modulos Abiertos");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {
                    alerta.MessageBox(this, "Error Al Grabar");
                }

            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }
        }

        protected void btncerrarRango_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.CabreoCierraRangoConteos(txtIdInicio.Value, txtIdFin.Value, 1);
                if (registros > 0)
                {
              
                    alerta.MessageBox(this, "Rango de Modulos Cerrados");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {
                    alerta.MessageBox(this, "Error Al Grabar");
                }

            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }
        }

        protected void btnactualizafecha_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.CfechaRangoConteos(txtIdInicio.Value, txtIdFin.Value, txtfecha.Value);
                if (registros > 0)
                {
                    
                    alerta.MessageBox(this, "Se ha cambiado la Fecha del Rango de Modulos");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {
                    alerta.MessageBox(this, "Error Al Grabar");
                }

            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }
        }

        protected void btnactualizabodega_Click(object sender, EventArgs e)
        {
            try
            {
                var registros = ControlaSql.CbodegaRangoConteos(txtIdInicio.Value, txtIdFin.Value, selecbodegaid.Value);
                if (registros > 0)
                {
               
                    alerta.MessageBox(this, "Se ha cambiado la Bodega del Rango de Modulos");
                    actualizaconteosabiertos();
                    actualizaconteos2();
                    listaabiertosc1();
                    listaabiertosc2();
                }
                else
                {
                    alerta.MessageBox(this, "Error Al Grabar");
                }

            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, "Excepcion Interna: " + ex.Message);
            }
        }
    }
}