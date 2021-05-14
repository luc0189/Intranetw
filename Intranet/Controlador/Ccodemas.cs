using Intranet.conexiona;
using Intranet.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Intranet.Controlador
{
    public class Ccodemas
    {
        Modelos sb = new Modelos();

        //McreaArticulo McreaTranformacion
        internal DataTable CcreaTransformacion(string id, string detalle, string cantidad,
         string fecha, string costo, string usuar,string vcosto, string pbd)
        {
            try
            {
                return sb.McreaTranformacion(id, detalle, cantidad, fecha,costo,usuar,vcosto, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CcreaDetallesregistro(string cc, string area, string datoin,
       string datoout, string usuario, string pbd)
        {
            try
            {
                return sb.McreaDetallesRegistro(cc,area,datoin,datoout,usuario, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CdeleteTransformacion(string pid,  string pbd)
        {
            try
            {
                return sb.MdeleteTranformacion(pid, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CupdateTransformacion(string pid, string pverifica, string pbd)
        {
            try
            {
                return sb.MupdateTranformacion(pid, pverifica, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CupdateDetallesRegistro(string pid, string parea, string pout, string pusucrea, string pbd)
        {
            try
            {
                return sb.MupdateDetalleRegistro(pid,parea,pout,pusucrea, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable CupdateUser(string pid, string pUser,string pPass,string ppor, string pbd)
        {
            try
            {
                return sb.Mupdateuser(pid,pUser,pPass, ppor, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        internal DataTable CListatransformaciones(string db)
        {
            try
            {
                return sb.Mlistatransformaciones(db);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        internal DataTable clistaCC_IDCOBI(string pcc,string db)
        {
            try
            {
                return sb.MlistaCC_IDCOBI(pcc,db);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        internal DataTable clistaCC_dato1(string pcc, string db)
        {
            try
            {
                return sb.MlistaCC_dato1(pcc, db);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        internal DataTable CListasalas(string db)
        {
            try
            {
                return sb.Mlistasalasdeventa(db);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        internal DataSet CListaItemstransformaciones()
        {
            try
            {
                return sb.MlistaItemsTransformaciones();
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        internal DataSet CListaCostoArticulo(string Pplu,string pfecha)
        {
            try
            {
                return sb.Mlistacosto_Articulo(Pplu,pfecha);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        //aqui termina el menu de trasformaciones

    }
}