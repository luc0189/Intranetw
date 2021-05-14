using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Vista;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace Intranet.Vista
{
    public partial class GestionOrdenesM : System.Web.UI.Page
    {
        string ahora = DateTime.Now.ToString("yyyy-MM-dd");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lista_mant_preaprobados();
              
                llenaubicacion();
                llenaarea();
                  llenatipomantenimiento();
                 panelEditardetalles.Visible = false;
                panelAsignaciones.Visible = false;

                view_detalles.Visible = false;
             
                this.txtfecha.Attributes.Add("min", ahora);
            }
        }
        protected void buttoncancel(object sender, EventArgs e)
        {
            view_detalles.Visible = false;
        }
        public async Task SendSms(string tel, string sms,string dia)
        {
            try
            {
                var send = $"http://api.hablame.co/sms/envio/?api=bjwx2FEYM1AKC1NWYMlWmdbx2EXX8D&cliente=10011043&numero= {tel}&sms=Trabajo Asignado en Supermio:{sms} Programado para el {dia}.";
                var client = new HttpClient();
                var res = await client.GetAsync(send);
                var json = await res.Content.ReadAsStringAsync();
               
                //var rest = JsonConvert.DeserializeObject<List<smsobjet>>(json);
              

            }
            catch (Exception e)
            {

                alerta.MessageBox(this, $" {e}");
            }

            //  r.sms = $"Hola {nombre}, En nuestro calendario siempre esta marcada la fecha de tu cumpleaños porque eres una persona muy especial para SUPERMIO. ¡Que pases un bonito dia ! ¡Muchas felicidades!. para cancelar suscripcion: https://bit.ly/2Bgdf8X";


            //var messagePost = Newtonsoft.Json.JsonConvert.SerializeObject(r);
            //Debug.WriteLine(messagePost);
        }
       
       
      
        public void llenaubicacion()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroubica = Controlasql.Clistaubicacion(bd);

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    //Selectubicacion.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        //Selectubicacion.Items.Add(Convert.ToString(row["Nombre"]));
                        //Selectubicacion.DataBind();
                    }



                }
                else
                {
                    //Selectubicacion.DataSource = null;
                    //Selectubicacion.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);

            }

        }
        public void llenaProveedores()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroubica = Controlasql.ClistaPROVEEDORES2(bd);

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    SelectProveedores.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        SelectProveedores.Items.Add(Convert.ToString(row["nomb"]));
                        SelectProveedores.DataBind();
                    }
                }
                else
                {
                    SelectProveedores.DataSource = null;
                    SelectProveedores.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
            }

        }
        public void llenaarea()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registroubica = Controlasql.Clistaarea(bd);

                if (registroubica.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registroubica.Tables[0];
                    //Selectarea.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        //Selectarea.Items.Add(Convert.ToString(row["Nombre"]));
                        //Selectarea.DataBind();
                    }
                }
                else
                {
                    //Selectarea.DataSource = null;
                    //Selectarea.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
            }

        }
        public void llenatipomantenimiento()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrotipom = Controlasql.Clistaclasemantenimiento(bd);

                if (registrotipom.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = registrotipom.Tables[0];
                    //Selecttipo.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        //Selecttipo.Items.Add(Convert.ToString(row["Nombre"]));
                        //Selecttipo.DataBind();
                    }
                }
                else
                {
                    //Selecttipo.DataSource = null;
                    //Selecttipo.DataBind();
                }
            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
            }

        }
        protected void btnbuscarpendientes_Click(object sender, EventArgs e)
        {
            consultaradicados();
        }
        protected void GridViewpendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelAsignaciones.Visible = true;
            GridViewRow gr = GridViewpendientes.SelectedRow;
            textidorden.Value = Page.Server.HtmlDecode(gr.Cells[1].Text);
            lbltarea.InnerText= Page.Server.HtmlDecode(gr.Cells[3].Text);
            llenaProveedores();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            panelAsignaciones.Visible = false;
        }
        public void consultaradicados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridradicados(Session["USUARIO"].ToString(), Session["perfilnombre"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewpendientes.DataSource = registrosr;
                    GridViewpendientes.DataBind();
                    //ul1.Style.Add("display", "block");

                }
                else
                {
                    GridViewpendientes.DataSource = null;
                    GridViewpendientes.DataBind();

                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
            }
        }
        public void lista_mant_preaprobados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros_M_preaprobados = Controlasql.Clista_mant_preaprobadas(bd);
                if (registros_M_preaprobados.Tables[0].Rows.Count > 0)
                {

                    GridViewlista.DataSource = registros_M_preaprobados;
                    GridViewlista.DataBind();
                    //lista_Mant_preaprobadas.Style.Add("display", "block");

                }
                else
                {
                    GridViewlista.DataSource = null;
                    GridViewlista.DataBind();

                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
            }
        }
        public void consultaasignados()//este
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridasignados(Session["USUARIO"].ToString(), Session["perfilnombre"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewasignados.DataSource = registrosr;
                    GridViewasignados.DataBind();
                    //ul2.Style.Add("display", "block");

                }
                else
                {
                    GridViewasignados.DataSource = null;
                    GridViewasignados.DataBind();

                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
               
            }
        }
        public void consultadetalles()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registrosr = Controlasql.Clistagridasignados(Session["USUARIO"].ToString(), Session["ROL"].ToString(),bd);
                if (registrosr.Tables[0].Rows.Count > 0)
                {

                    GridViewasignados.DataSource = registrosr;
                    GridViewasignados.DataBind();
                    //ul2.Style.Add("display", "block");

                }
                else
                {
                    GridViewasignados.DataSource = null;
                    GridViewasignados.DataBind();

                }

            }
            catch (Exception ex)
            {
                alerta.MessageBox(this, ex.Message);
            }
        }
        protected async void Button5_Click(object sender, EventArgs e)
        {
            string test = SelectProveedores.Value;
            string[] palabras = test.Split('/');
            string nombre = palabras[0];
            string telefono = palabras[1];
            if (txtfecha.Value.Equals("") || SelectProveedores.Value.Equals("") || textidorden.Value.Equals(""))
            {
                string script = @"<script type='text/javascript'>
                            alert('Ingrese la Informacion Requerida');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
            else
            {
                try
                {
                    var registros3 = Controlasql.Ccreaasigtrabajo(textidorden.Value, nombre,
                        txtfecha.Value, Session["USUARIO"].ToString(), Session["BD"].ToString());
                    if (registros3 > 0)
                    {
                        panelAsignaciones.Visible = false;


                        string script = @"<script type='text/javascript'>
                            alert('Registro exitoso');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        await SendSms(telefono,lbltarea.InnerText, txtfecha.Value);
                        consultaradicados();

                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>
                            alert('No fue Posible guardar el Registro');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        consultaradicados();

                    }

                }
                catch (Exception ex)
                {
                    alerta.MessageBox(this, ex.Message);
                }
            }
        }
        protected void btnbuscarasignados_Click(object sender, EventArgs e)
        {
            consultaasignados();
        }
        protected void GridViewlista_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ul3.Style.Add("display", "block");
            //lista_Mant_preaprobadas.Style.Add("display", "none");
            //ul1.Style.Add("display", "none");
            GridViewRow gr = GridViewlista.SelectedRow;
            Textidacta.Value = Page.Server.HtmlDecode(gr.Cells[1].Text);
         
            Selectordenes.Value = Page.Server.HtmlDecode(gr.Cells[5].Text);
            Selectproveedor.Value = Page.Server.HtmlDecode(gr.Cells[2].Text);
            OBSERVACIONG.Value = Page.Server.HtmlDecode(gr.Cells[4].Text);
            fechaacta.Value = Page.Server.HtmlDecode(gr.Cells[3].Text);
            try
            {
                String bd = Session["BD"].ToString();
                var registro_detalle_preap = Controlasql.Clista_detamant_preaprobadas(Textidacta.Value, bd);
                if (registro_detalle_preap.Tables[0].Rows.Count > 0)
                {

                    GridViewdetalles_preaprob.DataSource = registro_detalle_preap;
                    GridViewdetalles_preaprob.DataBind();
                    //ul8.Style.Add("display", "block");

                }
                else
                {
                    GridViewdetalles_preaprob.DataSource = null;
                    GridViewdetalles_preaprob.DataBind();

                }
            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, ex.Message);
            }
            view_detalles.Visible = true;
           
            
        }
        public void detallespreaprobados()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registro_detalle_preap = Controlasql.Clista_detamant_preaprobadas(Textidacta.Value, bd);
                if (registro_detalle_preap.Tables[0].Rows.Count > 0)
                {

                    GridViewdetalles_preaprob.DataSource = registro_detalle_preap;
                    GridViewdetalles_preaprob.DataBind();
                    //ul8.Style.Add("display", "block");

                }
                else
                {
                    GridViewdetalles_preaprob.DataSource = null;
                    GridViewdetalles_preaprob.DataBind();

                }
            }
            catch (Exception ex)
            {

                alerta.MessageBox(this, ex.Message);
            }
        }
        //public void llenaselectactivos()
        //{
        //    try
        //    {
        //        String bd = Session["BD"].ToString();
        //        var registro_activos = Controlasql.listaserial(bd);

        //        if (registro_activos.Tables[0].Rows.Count > 0)
        //        {
        //            DataTable dt_noadmin = registro_activos.Tables[0];
        //            Selectarticulo.Items.Clear();
        //            foreach (DataRow row in dt_noadmin.Rows)
        //            {
        //                Selectarticulo.Items.Add(Convert.ToString(row["Nombre"]));
        //                Selectarticulo.DataBind();
        //            }
        //        }
        //        else
        //        {
        //            Selectarticulo.DataSource = null;
        //            Selectarticulo.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        alerta.MessageBox(this, ex.Message);
        //    }
        //}
        protected void GridViewdetalles_preaprob_SelectedIndexChanged(object sender, EventArgs e)
        {

            panelEditardetalles.Visible = true;
            //llenaselectactivos();
            GridViewRow gr = GridViewdetalles_preaprob.SelectedRow;
            txtid.Value = Page.Server.HtmlDecode(gr.Cells[1].Text);
            Selectarticulo.Value = Page.Server.HtmlDecode(gr.Cells[2].Text);
            txtRepuestos.Value = Page.Server.HtmlDecode(gr.Cells[3].Text);
            Textmano_obra.Value = Page.Server.HtmlDecode(gr.Cells[4].Text);
            Valor_Repuestos.Value = Page.Server.HtmlDecode(gr.Cells[5].Text);
            txtobserva.Value = Page.Server.HtmlDecode(gr.Cells[6].Text);
            Textgarantia.Value = Page.Server.HtmlDecode(gr.Cells[7].Text);
            SelecttipoMant.Value = Page.Server.HtmlDecode(gr.Cells[8].Text);
            clasetrabajo.Value = Page.Server.HtmlDecode(gr.Cells[9].Text);


        }
        protected void btncancela_detalles_Click(object sender, EventArgs e)
        {
            panelEditardetalles.Visible = false;
        }
        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            if (Valor_Repuestos.Value == "")
            {
                string script = @"<script type='text/javascript'>
                            alert('Registre un valor Mayor o Igual a O');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                Valor_Repuestos.Focus();
            }
            if (Textmano_obra.Value == "")
            {
                string script = @"<script type='text/javascript'>
                            alert('Registre un valor Mayor o Igual a O');
                            
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                Textmano_obra.Focus();
            }
            else { 
                try
                {
                    var registros3 = Controlasql.Cupdate_mant_valores(txtid.Value, Textmano_obra.Value, Valor_Repuestos.Value, txtnumeroexterno_act.Value, Session["BD"].ToString());
                    if (registros3 > 0)
                    {
                        panelAsignaciones.Visible = false;
                        view_detalles.Visible=false;
                        lista_mant_preaprobados();
                        string script = @"<script type='text/javascript'>
                            alert('Registro exitoso');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                       
                       
                    }
                    else
                    {
                        string script = @"<script type='text/javascript'>
                            alert('No fue Posible guardar el Registro');
                            
                        </script>";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                        lista_mant_preaprobados();

                    }

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        }

        protected void consultar_Click(object sender, EventArgs e)
        {
            detallespreaprobados();
        }
    }
}