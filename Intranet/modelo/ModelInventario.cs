using Intranet.conexiona;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Intranet.modelo
{
   
    public class ModelInventario
    {
        Bdconexion con = new Bdconexion();
        Bdconexion dataload = new Bdconexion();
        String sql = String.Empty;
        String sql1 = String.Empty;
        string db = "LCSYSTEM";
        internal DataTable Mcreabodega(String bodega)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.ReturnValue));
                RunLista.Add(new parametro("PNOMBRE", bodega, "VARCHAR2", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_INVENBODEGA", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable MListabodega(String bodega)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.ReturnValue));
                RunLista.Add(new parametro("PNOMBRE", bodega, "VARCHAR2", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_INVENBODEGA", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable s(String pnombre)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
             
                crearp.Add(new parametro("PNOMBRE", pnombre, "VARCHAR", ParameterDirection.Input));

                return con.ProcedureSelectDB("PRCREAR_INVENBODEGA", crearp, db);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable McreaUser(String pnombre,String psena)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PNOMBRE", pnombre, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PSENA", psena, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_INVENUSUARIO", crearp, db);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable McreaZonas(String pnombre)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PNOMBRE", pnombre, "VARCHAR", ParameterDirection.Input));

                return con.ProcedureSelectDB("PRCREAR_INVENZONAS", crearp, db);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable Masig_ubicacion_a_grupo(String pconteo)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
               crearp.Add(new parametro("PCONTEO", pconteo, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_INVEN_ASGGRUPO", crearp, db);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable Mcreaconteos(String pnombre)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PNOMBRE", pnombre, "VARCHAR", ParameterDirection.Input));

                return con.ProcedureSelectDB("PRCREAR_INVENCONTEOS", crearp, db);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataSet listadoMcreaInventarioacta(String bodega)
        {
            sql = "call P_2('"+bodega+"')";
            return dataload.oraconsulta(sql, "LCSYSTEM");
        }
       
        internal DataSet McreaInventario()
        {
            sql = " SELECT U.UBIC_ID AS ID,C.CONT_NOMBRE,Z.ZON_NOMBRE,B.BOD_NOMBRE" +
                "        FROM INVEN_UBICACION U" +
                "                INNER JOIN LCSYSTEM.INVEN_CONTEOS C ON U.UBIC_CONTEO_ID = C.CONT_ID" +
                "                INNER JOIN LCSYSTEM.INVEN_ZONAS Z ON U.UBIC_ZONA_ID = Z.ZON_ID" +
                "                INNER JOIN LCSYSTEM.INVEN_BODEGA B ON U.UBIC_BODEGA_ID = B.BOD_ID" +
                "                ORDER BY UBIC_ID";
            return dataload.oraconsulta(sql, "LCSYSTEM");
           
        }

    }
}