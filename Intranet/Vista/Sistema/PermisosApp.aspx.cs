using Intranet.Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intranet.Vista.Sistema
{
    public partial class PermisosApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!Page.IsPostBack)
            {
                consultausuariosincro();
            }
        }
        public void consultausuariosincro()
        {
            try
            {

                var registros = ControlaSql.Cverificausuariosincro();
                if (registros.Tables[0].Rows.Count > 0)
                {
                    btnOn.Enabled = false;
                    btnOff.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                btnOn.Enabled = true;
                btnOff.Enabled = false;
            }
        }

        protected void btnOn_Click(object sender, EventArgs e)
        {
            try
            {

                var registros = ControlaSql.Cactivasincro();
                if (registros >= -1)
                {
                    btnOn.Enabled = false;
                    btnOff.Enabled = true;
                }
                else
                {
                    btnOn.Enabled = true;
                    btnOff.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnOff_Click(object sender, EventArgs e)
        {
            try
            {

                var registros = ControlaSql.Cinactivasincro();
                if (registros >= -1)
                {
                    btnOn.Enabled = true;
                    btnOff.Enabled = false;
                }
                else
                {
                    btnOn.Enabled = false;
                    btnOff.Enabled = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}