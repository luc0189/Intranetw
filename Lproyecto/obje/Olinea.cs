using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lproyecto.obje
{
    class Olinea
    {
        private int id;
        private string nombrelinea;
        private int idcategoria;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }
                id = value;
            }
        }
        public string Nombre
        {
            get
            {
                return nombrelinea;
            }
            set
            {
                nombrelinea = value;
            }
        }
        public int Idcat
        {
            get
            {
                return idcategoria;
            }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }
                idcategoria = value;
            }
        }
        public void setId(int pid)
        {
            if (pid <= 0)
            {
                pid = 1;
            }
            id = pid;
        }
        public void guardar(int nid, string nombre, int catg)
        {
            //try
            //{
            //    var registros = Controlasql.Ccreacategoria(Textcategoria.Value.ToUpper(),
            //        TxtVidaUtil.Value.ToUpper(), Session["USUARIO"].ToString(), Session["BD"].ToString());
            //    if (registros > 0)
            //    {


            //        llenaCategoria();
            //        Select3.Focus();
            //        excepcion.Visible = false;
            //        notificacion.Visible = true;
            //        txtnotifica.InnerText = "Registro Exitoso";
            //    }
            //    else
            //    {
            //        serialcantidad.Value = txtserial.Value.ToUpper();
            //        alerta.Visible = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    notificacion.Visible = false;
            //    excepcion.Visible = true;
            //    error.InnerText = "No se registro. Error: " + ex.Message;
            //}
        }
    }
}
