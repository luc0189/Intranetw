using Intranet.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Intranet.Controlador
{
    public class Cinventario
    {
        ModelInventario md = new ModelInventario();
        internal DataTable Ccreabodega( string nombre)
        {
            try
            {
                return md.Mcreabodega(nombre);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CcreaUser(string nombre,string sena)
        {
            try
            {
                return md.McreaUser(nombre,sena);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CcreaZonas(string nombre)
        {
            try
            {
                return md.McreaZonas(nombre);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CcreaConteos(string nombre)
        {
            try
            {
                return md.Mcreaconteos(nombre);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CAsign_ubicacion_a_usuarios(string conteo)
        {
            try
            {
                return md.Masig_ubicacion_a_grupo(conteo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataSet CcreaInventario(string pbodega)
        {
            try
            {
                 md.listadoMcreaInventarioacta(pbodega);
                return md.McreaInventario();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}