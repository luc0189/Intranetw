using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class Main : System.Web.UI.MasterPage
    {
      
        DataTable dt = null;
        String profi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                titlecosto.Text = Session["salaventas"].ToString();
                try
                {
                    A.Visible = false;
                    A1.Visible = false;
                    A2.Visible = false;
                    A4.Visible = false;
                    A5.Visible = false;
                    A6.Visible = false;
                    A7.Visible = false;
                    AE.Visible = false;
                    AE1.Visible = false;
                    AE2.Visible = false;
                    AE3.Visible = false;
                    AM.Visible = false;
                    AM1.Visible = false;
                    AM2.Visible = false;
                    AM3.Visible = false;
                    AM4.Visible = false;
                    AM5.Visible = false;
                    RH.Visible = false;
                    RH1.Visible = false;
                    RH3.Visible = false;
                    RH4.Visible = false;
                    LCS.Visible = false;
                    LCS1.Visible = false;
                    LCS2.Visible = false;
                    V.Visible = false;

                    V1.Visible = false;
                    V2.Visible = false;
                    V3.Visible = false;
                    V4.Visible = false;
                    V5.Visible = false;
                    V6.Visible = false;
                    V7.Visible = false;
                    V8.Visible = false;
                    K.Visible = false;
                    K1.Visible = false;
                    K2.Visible = false;
                    K3.Visible = false;
                    LA14.Visible = false;
                    LA141.Visible = false;
                    LA142.Visible = false;
                    G.Visible = false;
                    G1.Visible = false;

                    notificacion.Visible = false;
                    excepcion.Visible = false;
                    ListarCumpleñeros();
                    if (Session["USUARIO"] != null)
                    {
                        profi = Session["perfil"].ToString();
                        Label2.Text = Session["USUARIO"].ToString();
                       
                        perfiles.InnerText = Session["perfilnombre"].ToString();
                        labelcc.InnerText = Session["CC"].ToString();
                        traedatos(Session["CC"].ToString());

                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }
                          
                    if (Label2.Text == "")
                    {
                        // Response.Redirect("../Login.aspx");
                    }
                    try
                    {
                        var refdatos = Controlasql.Clistamenuid(Session["BD"].ToString(), Session["perfilid"].ToString());
                        if (refdatos.Tables[0].Rows.Count > 0)
                        {
                            dt = refdatos.Tables[0];
                            foreach (DataRow row in dt.Rows)
                            {

                                var valor1 = Convert.ToString(row[0]);
                                switch (valor1)
                                {
                                    case "A":
                                        A.Visible = true;
                                        break;
                                    case "A1":
                                        A1.Visible = true;
                                        break;
                                    case "A2":
                                        A2.Visible = true;
                                        break;
                                    case "A3":
                                        A1.Visible = true;
                                        break;
                                    case "A4":
                                        A4.Visible = true;
                                        break;
                                    case "A5":
                                        A5.Visible = true;
                                        break;
                                    case "A6":
                                        A6.Visible = true;
                                        break;
                                    case "A7":
                                        A7.Visible = true;
                                        break;
                                    case "AE":
                                        AE.Visible = true;
                                        break;
                                    case "AE1":
                                        AE1.Visible = true;
                                        break;
                                    case "AE2":
                                        AE2.Visible = true;
                                        break;
                                    case "AE3":
                                        AE3.Visible = true;
                                        break;
                                    case "AM":
                                        AM.Visible = true;
                                        break;
                                    case "AM1":
                                        AM1.Visible = true;
                                        break;
                                    case "AM2":
                                        AM2.Visible = true;
                                        break;
                                    case "AM3":
                                        AM3.Visible = true;
                                        break;
                                    case "AM4":
                                        AM4.Visible = true;
                                        break;
                                    case "AM5":
                                        AM5.Visible = true;
                                        break;
                                    case "RH":
                                        RH.Visible = true;
                                        break;
                                    case "RH1":
                                        RH1.Visible = true;
                                        break;
                                    case "RH2":
                                        A1.Visible = true;
                                        break;
                                    case "RH3":
                                        RH3.Visible = true;
                                        break;
                                    case "RH4":
                                        RH4.Visible = true;
                                        break;
                                    case "LCS":
                                        LCS.Visible = true;
                                        break;
                                    case "LCS1":
                                        LCS1.Visible = true;
                                        break;
                                    case "LCS2":
                                        LCS2.Visible = true;
                                        break;
                                    case "LCS3":
                                        LCS3.Visible = true;
                                        break;
                                    case "V":
                                        V.Visible = true;
                                        break;
                                    case "V1":
                                        V1.Visible = true;
                                        break;
                                    case "V2":
                                        V2.Visible = true;
                                        break;
                                    case "V3":
                                        V3.Visible = true;
                                        break;
                                    case "V4":
                                        V4.Visible = true;
                                        break;
                                    case "V5":
                                        V5.Visible = true;
                                        break;
                                    case "V6":
                                        V6.Visible = true;
                                        break;
                                    case "V7":
                                        V7.Visible = true;
                                        break;
                                    case "V8":
                                        V8.Visible = true;
                                        break;
                                    case "K":
                                        K.Visible = true;
                                        break;
                                    case "K1":
                                        K1.Visible = true;
                                        break;
                                    case "K2":
                                        K2.Visible = true;
                                        break;
                                    case "K3":
                                        K3.Visible = true;
                                        break;
                                    case "LA14":
                                        LA14.Visible = true;
                                        break;
                                    case "LA141":
                                        LA141.Visible = true;
                                        break;
                                    case "LA142":
                                        LA142.Visible = true;
                                        break;
                                    case "G":
                                        G.Visible = true;
                                        break;
                                    case "G1":
                                        G1.Visible = true;
                                        break;

                                    default:
                                        notificacion.Visible = false;

                                        break;

                                }
                            }


                        }


                    }
                    catch (Exception ex)
                    {

                        excepcion.Visible = true;
                        error.Visible = false;
                        txtnotifica.InnerText = ex.Message;
                    }
                }
                catch (Exception)
                {

                    // Response.Redirect("..//Login.aspx");
                }

            }
            
}
        public void salir(object sender, EventArgs e)
        {
            Session.Remove("USUARIO");
            Session.Remove("BD");
            Session.Remove("perfilid");
            Session.Remove("perfil");
            Session.Remove("perfiLnombre");
            Session.Remove("idcompra");
            Response.Redirect("../Login.aspx");
        }
        protected void ListarCumpleñeros()
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.Clistacumpleañeros();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {

                        hay_cumpleañeros.InnerText = Convert.ToString(row[2]) + " y Otros mas cumplen Años hoy";
                    }
                }
                else
                {
                    hay_cumpleañeros.InnerText = "No hay Cumpleañeros por Hoy";
                }
            }
            catch (Exception e)
            {
                notificacion.Visible = false;
                excepcion.Visible = true;
                error.InnerText = "No se Muestra Inf. Error: " + e.Message;
            }

        }
        public void traedatos(string cc)
        {
            try
            {
                String bd = Session["BD"].ToString();
                var registros = Controlasql.perfil(cc, Session["BD"].ToString());
                if (registros.Tables[0].Rows.Count > 0)
                {
                    dt = registros.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {

                        byte[] misdatos = new byte[0];
                        misdatos = (byte[])row[5];

                        string cadena = Encoding.UTF8.GetString(misdatos);
                        // var fotook = Convert.ToBase64String((byte[])row[5]);
                        fotoperfil.Src = cadena;

                       

                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                alerta.Equals(this, "excepcion: " + e.Message);
            }
        }
    }
}