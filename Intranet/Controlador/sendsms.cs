using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Intranet.Controlador
{
    public class sendsms
    {
        public async Task SendSms(string tel, string nombre)
        {
            try
            {
                var send = $"http://api.hablame.co/sms/envio/?api=bjwx2FEYM1AKC1NWYMlWmdbx2EXX8D&cliente=10011043&numero= {tel}&sms=Hola{nombre}, En nuestro calendario siempre esta marcada la fecha de tu cumpleaños porque eres una persona muy especial para SUPERMIO. ¡Que pases un bonito dia ! ¡Muchas felicidades!. para cancelar suscripcion: https://bit.ly/2Bgdf8X";
                var client = new HttpClient();
                var res = await client.GetAsync(send);
                var json = await res.Content.ReadAsStringAsync();

                //var rest = JsonConvert.DeserializeObject<List<smsobjet>>(json);


                Debug.WriteLine(await res.Content.ReadAsStringAsync());//Stifen

            }
            catch (Exception e)
            {

                throw e;
            }

            //  r.sms = $"Hola {nombre}, En nuestro calendario siempre esta marcada la fecha de tu cumpleaños porque eres una persona muy especial para SUPERMIO. ¡Que pases un bonito dia ! ¡Muchas felicidades!. para cancelar suscripcion: https://bit.ly/2Bgdf8X";
           

            //var messagePost = Newtonsoft.Json.JsonConvert.SerializeObject(r);
            //Debug.WriteLine(messagePost);
        }
    }
}