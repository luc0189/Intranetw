using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class cumpleañeros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Ingreso.Visible = false;
                notificacion.Visible = true;
                excepcion.Visible = false;
                ListarCumpleñeros();
                Log_data();
            }
            

        }
        protected void ListarCumpleñeros()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clistacumpleañeros();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    Gridviewcumpleañeros.DataSource = registros;
                    Gridviewcumpleañeros.DataBind();
                }
                else
                {
                    Gridviewcumpleañeros.DataSource = null;
                    Gridviewcumpleañeros.DataBind();
                }
            }
            catch (Exception e)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Muestra Inf. Error: " + e.Message;
            }

        }
        protected void Log_data()
        {
            
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.ClistaLog_cumples(bd);
                if (registros.Tables[0].Rows.Count > 0)
                {
                    gridviewsms_send.DataSource = registros;
                    gridviewsms_send.DataBind();
                }
                else
                {
                    gridviewsms_send.DataSource = null;
                    gridviewsms_send.DataBind();
                }
            }
            catch (Exception e)
            {
                alerta.MessageBox(this, $"{e}");
            }

        }

        //protected async void LinkButton1_Click(object sender, EventArgs e)ButtonSend
        protected async void ButtonSend(object sender, EventArgs e)
        {

            await SendSms(txttel.InnerText, txtnombre.InnerText, txtsms.Value);
            
            Ingreso.Visible = false;
            Log_data();
        }
        protected void buttoncancel(object sender,EventArgs e)
        {
            Ingreso.Visible = false;
        }
        protected  void LinkButton1_Click(object sender, EventArgs e)
        {
            GridViewRow gr = Gridviewcumpleañeros.SelectedRow;

            string nombre = gr.Cells[3].Text;
            string telefono = gr.Cells[4].Text;
            txtnombre.InnerText = nombre;
            txttel.InnerText = telefono;
            Ingreso.Visible = true;
            //await SendSms(telefono, nombre, txtsms.Value);
        }
        public async Task SendSms(string tel, string nombre, string sms )
        {
            try
            {
                var send = $"https://api101.hablame.co/api/sms/v2.1/send/?apiKey=LyRMarMdWrdCIkxPCONFCg6Hbr6AcQ&account=10011043&token=f94dd6bde1f654cab0e08c90cd64981e&toNumber= {tel}&sms=Hola {nombre}, {sms}";
                var client = new HttpClient();
                var res = await client.GetAsync(send);
                var json = await res.Content.ReadAsStringAsync();
                try
                    {
                        String bd = Session["BD"].ToString();
                        var registros = Controlasql.CClog_cumples(nombre, tel,sms,Session["USUARIO"].ToString(),bd);
                   
                    }
                catch (Exception EX)
                    {

                        alerta.MessageBox(this,$" {EX}");
                    }
                //var rest = JsonConvert.DeserializeObject<List<smsobjet>>(json);
                alerta.MessageBox(this, "Mensaje Enviado Exitosamente");

                Debug.WriteLine(await res.Content.ReadAsStringAsync());//Stifen

            }
            catch (Exception e)
            {

                alerta.MessageBox(this, $" {e}");
            }

            //  r.sms = $"Hola {nombre}, En nuestro calendario siempre esta marcada la fecha de tu cumpleaños porque eres una persona muy especial para SUPERMIO. ¡Que pases un bonito dia ! ¡Muchas felicidades!. para cancelar suscripcion: https://bit.ly/2Bgdf8X";


            //var messagePost = Newtonsoft.Json.JsonConvert.SerializeObject(r);
            //Debug.WriteLine(messagePost);
        }
    }
}