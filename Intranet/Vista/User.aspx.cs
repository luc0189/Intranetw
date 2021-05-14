using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class User : System.Web.UI.Page
    {
        Login l = new Login();
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                notificacion.Visible = false;
                excepcion.Visible = false;
                llenaempleados();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)//guardar
        {
            String bd = Session["BD"].ToString();
            try
            {
                string[] palabra = select_cc.Value.Split('/');
                string cc = palabra[0];
                string pas = l.getsha(txtpass.Value);
                var valida = sb.CcrearUsuario(cc, txtusuario.Value.ToUpper(), pas, Session["USUARIO"].ToString(),bd);
                if (valida.Rows.Count > 0)
                {

                    
                    txtusuario.Value = "";
                    txtpass.Value = "";
                    txtaviso.InnerText = "";
                    notificacion.Visible = true;
                    excepcion.Visible=false;
                    txtnotifica.InnerText = "Registro Exitoso";
                    llenaempleados();
                }
                else
                {
                    txtaviso.InnerText = "Error al Guardar";
                }
            }
            catch (Exception exp)
            {
                
                notificacion.Visible = false;
                excepcion.Visible = true;
                string dato = exp.Message;
                error.InnerText = dato;
                
            }
            llenaempleados();

        }

        
        public void nuevo(object sender, EventArgs e)
        {
            llenaempleados();
            txtusuario.Value = "";
            txtpass.Value = "";
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
                excepcion.Visible = true;
                error.InnerText = dato;

            }

        }
    }
}