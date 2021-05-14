using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.Sistema
{
    
    public partial class User : System.Web.UI.Page
    {
        Login l = new Login();
        Controlasql sb = new Controlasql();
        Ccodemas sbora = new Ccodemas();
        protected void Page_Load(object sender, EventArgs e)
        {
            notificacion.Visible = false;
            if (!Page.IsPostBack)
            {
                btnactualizar.Visible = false;
                notificacion.Visible = false;
                llenaempleados();
            }
        }
        public void llenaempleados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroPROVEE = Controlasql.ctraeEmpleado_Sin_contra(bd);

                if (registroPROVEE.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroPROVEE.Tables[0];
                    select_cc.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        select_cc.Items.Add(Convert.ToString(row["NOMB"]));
                        select_cc.DataBind();
                    }



                }
                else
                {
                    select_cc.DataSource = null;
                    select_cc.DataBind();
                }
            }
            catch (Exception EXCP)
            {
                String dato = EXCP.Message;
                notificacion.Visible = true;
                alertant.InnerText = dato;

            }

        }
        public void limpiaempleados()
        {

        }
        protected void Buttonguardar(object sender, EventArgs e)//guardar
        {
            String bd = Session["BD"].ToString();
            try
            {
                string[] palabra = select_cc.Value.Split('/');
                string cc = palabra[0];
                string pas = l.getsha(txtpass.Value);
                var valida = sb.CcrearUsuario(cc, txtusuario.Value.ToUpper(), pas, Session["USUARIO"].ToString(), bd);
                if (valida.Rows.Count > 0)
                {


                    txtusuario.Value = "";
                    txtpass.Value = "";
                 
                    notificacion.Visible = true;
                    alertant.InnerText = "Guardado exitosamente";
                    llenaempleados();
                }
                else
                {
                    notificacion.Visible = true;
                    alertant.InnerText = "Error al Guardar";
                }
            }
            catch (Exception exp)
            {
                llenaempleados();
                notificacion.Visible = true;
              
               
                alertant.InnerText = exp.Message;
               
            }
           

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.clistausercc(txtcc.Value,bd);
                if (registros.Rows.Count > 0)
                {
                    GridViewsearh.DataSource = registros;
                    GridViewsearh.DataBind();
                }
                else
                {
                    GridViewsearh.DataSource = null;
                    GridViewsearh.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = true;
                alertant.InnerText = ex.Message;
            }
        }
        protected void GridViewdetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                select_cc.Items.Clear();
                GridViewRow gr = GridViewsearh.SelectedRow;
                txtusuario.Value = Page.Server.HtmlDecode(gr.Cells[2].Text);
                btnactualizar.Visible = true;
                btnguardanuevo.Visible = false;
                    select_cc.Items.Add(Page.Server.HtmlDecode(gr.Cells[1].Text));
                    select_cc.DataBind();

            }
            catch (Exception ex)
            {
                notificacion.Visible = true;
                alertant.InnerText=ex.Message;
            }
           
           
           

        }
        protected void btnuser_Click(object sender, EventArgs e)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.clistauseruser(txtuser.Value.ToUpper(), bd);
                if (registros.Rows.Count > 0)
                {
                    GridViewsearh.DataSource = registros;
                    GridViewsearh.DataBind();
                }
                else
                {
                    GridViewsearh.DataSource = null;
                    GridViewsearh.DataBind();
                }
            }
            catch (Exception ex)
            {
                notificacion.Visible = true;
                alertant.InnerText = ex.Message;
            }
        }

       

        protected void btncancelanuevo_Click(object sender, EventArgs e)
        {
            llenaempleados();
            btnguardanuevo.Visible = true;
            btnactualizar.Visible = false;
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
           
                string[] palabra = select_cc.Value.Split('/');
                string cc = palabra[0];
                string pas = l.getsha(txtpass.Value);

                try
                {
                    string bd = Session["BD"].ToString();
                    var listado = sbora.CupdateUser(cc, txtusuario.Value.ToUpper(), pas, Session["USUARIO"].ToString(), bd);
                    if (listado.Rows.Count > 0)
                    {
                        txtusuario.Value = "";
                        txtpass.Value = "";

                        notificacion.Visible = true;
                        alertant.InnerText = "Guardado exitosamente";
                        llenaempleados();
                    }
                    else
                    {
                        notificacion.Visible = true;
                        alertant.InnerText = "Error al Guardar";
                    }
                }
                catch (Exception ex)
                {
                    llenaempleados();
                    notificacion.Visible = true;


                    alertant.InnerText = ex.Message;

                    alerta.MessageBox(this, "Excepcion interna:" + ex.Message);
                  }
           

        }
    }
}