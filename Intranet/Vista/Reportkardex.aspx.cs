using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;
using System.Data;

namespace Intranet.Vista
{
    public partial class Reportkardex : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblalerta.Visible = false;
            if (!Page.IsPostBack)
            {
                notificacion.Visible = false;
                excepcion.Visible = false;
                llenaarticulos();
                llenaubicacion();
                lblalerta.Visible = false;

            }
        }
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader dr;
        public void llenaarticulos()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select CONCAT(a.serialArt, ' / ', a.nombreArt) As Nombre  FROM articulo a inner join categoria c on a.categArt=c.idcat where c.idcat=5", cn);
                dr = cm.ExecuteReader();
                Select1.Items.Clear();
                while (dr.Read())
                {
                    Select1.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText ="No se cargaron los Articulo. Error: "+ ex.Message;
            }


        }

        public void llenaubicacion()
        {
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='" + Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select nombUbica FROM ubicacion", cn);
                dr = cm.ExecuteReader();
                selectbodega.Items.Clear();
                while (dr.Read())
                {
                    selectbodega.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se cargo Ubicaciones. Error: " + ex.Message;
            }
           

        }
        protected void GridViewnovedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gr = Gridkardex.SelectedRow;
            string idtabla=gr.Cells[1].Text;//coment
            String bd = Session["BD"].ToString();
            try
            {
                var registros16 = Controlasql.Cdelete_kardex(idtabla, bd);

                if (registros16 > 0)
                {
                    lblalerta.Visible = true;
                    alertant.InnerText = registros16 + " Eliminado";
                    Listarsaldos();
                }
                else
                {
                    lblalerta.Visible = true;
                    alertant.InnerText = "Sin Eliminar";
                    Listarsaldos();
                }
            }
            catch (Exception ex)
            {
                lblalerta.Visible = true;
                alertant.InnerText = "Con excepcion interna :"+ex.Message;
                
            }
        }
        public void llenasaldokardex(object sender, EventArgs e)
        {
            string[] palabras = Select1.Value.Split('/');
            string serial = palabras[0];
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select sum(kard_entrada)-SUM(kard_salida) as saldo from kardex where kard_fecha<='" + txtfechaini.Value + "' and kard_idarticulo= (select idArt from articulo where serialArt='" + serial + "') and kard_bodegaid=(select idUbica from ubicacion where nombUbica='" + selectbodega.Value + "')", cn);
                dr = cm.ExecuteReader();
                sald.InnerText="";
                while (dr.Read())
                {


                    sald.InnerText=(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
                Listarsaldos();
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText="No se cargaron los Saldos. Error: "+ ex.Message;
            }

        }
        public void Listarsaldos()
        {
            string[] palabras = Select1.Value.Split('/');
            string serial = palabras[0];
            try
            {//aqui
                String bd = Session["BD"].ToString();
               // var registros16 = Controlasql.saldokardex(txtfechaini.Value,txtfechafin.Value, serial,selectbodega.Value.ToString(),bd);
                var registros16 = Controlasql.listakardexreport(serial,txtfechaini.Value,txtfechafin.Value,selectbodega.Value.ToString(),bd);
                
                if (registros16.Tables[0].Rows.Count > 0)
                {
                    Gridkardex.DataSource = registros16;
                    Gridkardex.DataBind();
                }
                else
                {
                    Gridkardex.DataSource = null;
                    Gridkardex.DataBind();
                }
                Listarsaldostotal();
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Cargo los saldos. Error: " + ex.Message;
            }

        }
        public void Listarsaldostotal()
        {
            string[] palabras = Select1.Value.Split('/');
            string serial = palabras[0];
            try
            {
                cn = new MySqlConnection();
                cn.ConnectionString = "server=192.168.1.133;port=3306;database='"+ Session["BD"].ToString() + "';Uid=root;pwd=dibal;SslMode=none ";
                cn.Open();
                cm = new MySqlCommand("select (sum(kard_entrada) - sum(kard_salida)) as Saldos   from kardex k  inner join ubicacion u on k.kard_bodegaid=u.idUbica where kard_idarticulo=(select idArt from articulo where serialArt='"+serial+"') AND u.idUbica=(SELECT AU.idUbica FROM ubicacion AU WHERE AU.nombUbica='" + selectbodega.Value+ "') group by kard_bodegaid", cn);
                dr = cm.ExecuteReader();
                saldoactual.InnerText = "";
                while (dr.Read())
                {


                    saldoactual.InnerText = (dr[0].ToString());
                }
                dr.Close();
                cn.Close();
               
            }
            catch (Exception ex)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se cargo los Saldos. Error:" + ex.Message;
            }


        }
    }
}