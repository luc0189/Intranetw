using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Intranet.Controlador;

namespace Intranet.Vista
{
    public partial class Info_carnes : System.Web.UI.Page
    {
        Controlasql sb = new Controlasql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              
            }
        }
        public void Buscararticulo(object sender, EventArgs e)
        {
            //AQUI ESTA LO DE BNET 
            try
            {
                var registrosm = Controlasql.listaventascarnesBnet(selectgrupo.Value,txtfechaini.Value,txtfechafin.Value,selectSucursal.Value);
                if (registrosm.Tables[0].Rows.Count > 0)
                {


                    GridViewBnet.DataSource = registrosm;
                    GridViewBnet.DataBind();
                    
                }
                else
                {
                    GridViewBnet.DataSource = null;
                    GridViewBnet.DataBind();
                }

            }
            catch (Exception)
            {

                
            }
           

        }
        public void BuscaBasculas(object sender,EventArgs e)
        {
            
            //aqui la info de versalles
            try

            {
                var registrosBVERSA = Controlasql.ListaventascarnesBasculas(selectgrupo.Value, txtfechaini.Value, txtfechafin.Value,selectSucursal.Value);
                if (registrosBVERSA.Tables[0].Rows.Count > 0)
                {

                    GridViewBasculas.DataSource = registrosBVERSA;
                    GridViewBasculas.DataBind();

                }
                else
                {
                    GridViewBasculas.DataSource = null;
                    GridViewBasculas.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public void buscala13(object sender, EventArgs e)
        //{
      
        //    //aqui la info de la 13
        //    try
        //    {
        //        var registrosB13 = Controlasql.listaventascarnesBASVERSA(selectgrupo.Value, txtfechaini.Value, txtfechafin.Value,"SUPERMIO LA 13");
        //        if (registrosB13.Tables[0].Rows.Count > 0)
        //        {

        //            GridViewLA13.DataSource = registrosB13;
        //            GridViewLA13.DataBind();

        //        }
        //        else
        //        {
        //            GridViewLA13.DataSource = null;
        //            GridViewLA13.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        //public void buscala16(object sender,EventArgs e)
        //{
        //    try
        //    {
        //        var registrosB16 = Controlasql.listaventascarnesBASVERSA(selectgrupo.Value, txtfechaini.Value, txtfechafin.Value, "SUPERMIO LA 16");
        //        if (registrosB16.Tables[0].Rows.Count > 0)
        //        {

        //            GridView1.DataSource = registrosB16;
        //            GridView1.DataBind();

        //        }
        //        else
        //        {
        //            GridView1.DataSource = null;
        //            GridView1.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}