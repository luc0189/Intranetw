using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista
{
    public partial class _1 : System.Web.UI.Page
    {
        DataTable dt = null;
        String profi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                    A1.Visible = false;
                    notificacion.Visible = false;
                    A4.Visible = false;
                   
                    AE1.Visible = false;
                    
                  
                    AM1.Visible = false;
               
                    AM3.Visible = false;
                    AM4.Visible = false;
                    AM5.Visible = false;
                   
                    RH1.Visible = false;
                    RH3.Visible = false;
                    RH4.Visible = false;
                   
                    LCS1.Visible = false;
                    LCS2.Visible = false;
                LCS3.Visible = false;
                LCS.Visible = false;
                    V1.Visible = false;
                    V2.Visible = false;
                    V3.Visible = false;
                   
                
                    K1.Visible = false;
                   
                    LA141.Visible = false;
                    LA142.Visible = false;
                  

                    notificacion.Visible = false;
                    excepcion.Visible = false;
                
                 
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
                                   
                                    case "A1":
                                        A1.Visible = true;
                                        break;
                                   
                                    case "A3":
                                        A1.Visible = true;
                                        break;
                                    case "A4":
                                        A4.Visible = true;
                                        break;
                                    
                                    case "AE1":
                                        AE1.Visible = true;
                                        break;
                                   
                                    case "AM1":
                                        AM1.Visible = true;
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
                                   
                                    case "LCS1":
                                        LCS1.Visible = true;
                                        break;
                                    case "LCS2":
                                        LCS2.Visible = true;
                                        break;
                                case "LCS3":
                                    LCS3.Visible = true;
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
                                    case "K1":
                                        K1.Visible = true;
                                        break;
                                    case "LA141":
                                        LA141.Visible = true;
                                        break;
                                    case "LA142":
                                        LA142.Visible = true;
                                        break;
                                case "LCS":
                                    LCS.Visible = true;
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
                

                if (Session["USUARIO"] != null)
                {
                    profi = Session["perfil"].ToString();
                    notificacion.Visible = false;
                   
                }
               
               
              
               
            }
        }

  
    }
}