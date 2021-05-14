using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class perfil : System.Web.UI.Page
    {
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            traedatos(Session["CC"].ToString());

        }
      
        public void traedatos(string cc)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.perfil(cc,Session["BD"].ToString());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {

                        txtcc.Value = Convert.ToString(row[0]);
                        txtnombreall.Value = Convert.ToString(row[1]);
                        txtemail.Value = Convert.ToString(row[2]);
                        txtcel.Value = Convert.ToString(row[3]);
                        txtdir.Value = Convert.ToString(row[4]);
                        //foto.e(this, Convert.ToByte(row[5]));
                        byte[] misdatos = new byte[0];
                        misdatos=(byte[])row[5];
                       
                        string cadena = Encoding.UTF8.GetString(misdatos);
                        // var fotook = Convert.ToBase64String((byte[])row[5]);
                        foto.Src = cadena;

                        lblincap.InnerText = Convert.ToString(row[6]);
                        lblactivos.InnerText = Convert.ToString(row[7]);
                        lblhijos.InnerText = Convert.ToString(row[8]);
                        lblcreditos.InnerText = Convert.ToString(row[9]);

                    }
                }
                else
                {
                    
                }
            }
            catch (Exception e)
            {
                alerta.MessageBox(this, e.Message);
            }
        }
    }
  
}