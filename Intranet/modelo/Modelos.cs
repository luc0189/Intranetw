using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.Word;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml.Vml;
using Intranet.conexiona;
using Intranet.Vista;
using Intranet.Vista.Documentos;
using Intranet.Vista.INVENTARIO;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Web.WebPages;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using DataTable = System.Data.DataTable;

namespace Intranet.modelo
{
    public class Modelos
    {
        Bdconexion con = new Bdconexion();
        Bdconexion dataload = new Bdconexion();
        String sql = String.Empty;
        String Sqls = String.Empty;
        String sql1 = String.Empty;
        internal DataSet mlistaabiertos(string codigo)
        {
            sql = "select id,nombre from invenfis where protejido=0 and invenfis.grupoinvenfisID='" + codigo + "'";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoacta(String ip, String bd)
        {
            sql = "@call acta('" + ip + "');";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataTable Mlistatransformaciones(string db)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                return con.ProcedureSelectDB(db + ".FN_LISTATRANSFORMACIONES", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable MlistaCC_IDCOBI(string cc, string db)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                RunLista.Add(new parametro("CC", cc, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB(db + ".FN_LISTACC", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable MlistaCC_dato1(string cc, string db)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                RunLista.Add(new parametro("CC", cc, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB(db + ".FN_LISTADATO1", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataSet MlistagruposBnet(string db)
        {
            sql = "SELECT CODIGOGRUPO ||'/'|| NOMBRE_GRUPO AS NOMBRE FROM GRUPOSBNET";
            return dataload.oraconsulta(sql, db);
        }
        internal DataSet listadotrans_pendientes(string PBD)
        {
            sql = "SELECT  TRAN_ID AS ID,TRAN_IDARTICULOSALIDA AS ARTICULO, " +
                " TRAN_CANTSALIDA AS CANT1, " +
                "  TRAN_IDARTICULOENTRADA AS TRASNFORMACION,   " +
                " TRAN_CANTIDADENTRADA AS CANT2,  " +
                "    TRAN_DIFERENCIA AS DIF, TRAN_FECHATRANSFORMACION AS FECHA , " +
                "     TRAN_CCOSTO AS CCOSTO,TRAN_VERIFICADO AS VERIFI     " +
                "  FROM TRANSFORMACION WHERE TRAN_VERIFICADO='N'";
            return dataload.oraconsulta(sql, PBD);
        }
        internal DataTable McreaTranformacion(String pid, String pdetalle, String pcantidad,
         String pfecha, String pcosto, String usuario, String pvalorcosto, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PID", pid, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PDETALLE", pdetalle, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PCANTIDAD", pcantidad, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PFECHA", pfecha, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PCOSTO", pcosto, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PUSUARIO", usuario, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PVCOSTO", pvalorcosto, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREA_TRANSFORMACION", crearp, pbd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable McreaDetallesRegistro(String pcc, String parea, String pdatoIn,
       String pdatoOut, String pusucrea, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PCC", pcc, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PIDAREA", parea, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PDATOIN", pdatoIn, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PDATOOUT", pdatoOut, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PUSUCREA", pusucrea, "VARCHAR", ParameterDirection.Input));

                return con.ProcedureSelectDB("PRCREA_DETALLEREGISTROS", crearp, pbd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable MupdateTranformacion(String pid, String pverifica, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PRID", pid, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PVERIFICADO", pverifica, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRUPDATE_TRANSFORMACION", crearp, pbd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable MupdateDetalleRegistro(String pid, String parea, String pout, String pusucrea, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PID", pid, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PIDAREA", parea, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PDATOOUT", pout, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PUSUCREA", pusucrea, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRUPD_DETALLEREGISTROS", crearp, pbd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable Mupdateuser(String pid, String pUser, String pPass, String pPor, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PID", pid, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PUSUARIO", pUser, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPAS", pPass, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPOR", pPor, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRUPDATE_USER", crearp, pbd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataTable Mlistausercc(string cc, string db)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                crearp.Add(new parametro("CC", cc, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB(db + ".FN_LISTAUSERNCC", crearp, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable Mlistauseruser(string user, string db)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                crearp.Add(new parametro("USERR", user, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB(db + ".FN_LISTAUSER", crearp, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable Mlistasalasdeventa(string db)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                return con.ProcedureSelectDB(db + ".FN_LISTASALASVENTAS", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataSet MlistaItemsTransformaciones()
        {
            sql = "SELECT CONCAT(CODIGO,'/',DETALLE) AS NOMBRE FROM ARTICULO  " +
                "        WHERE ARTICULO.inactivo = 0" +
                "                AND ARTICULO.grupoID IN('00000373','381','340')";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mlistacosto_Articulo(string plu, string fecha)// TODO: AQUI LLEVO EL COSTO DEL ARTICULO ACTUAL
        {
            sql = "SELECT top(1) arthistocompra.vrcostounitneto " +
                "        FROM dbo.arthistocompra" +
                "                WHERE arthistocompra.articuloID = '" + plu + "'" +
                "                        and arthistocompra.fechahasta < '" + fecha + "'" +
                "                         order by arthistocompra.fechahasta desc";
            return dataload.sqlconsulta(sql);
        }
        internal DataTable MlistaItemsTransformacionesEE(string db)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                return con.ProcedureSelectDB(db + ".FN_LISTAITEMSTRANSFORM", RunLista, db);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable MdeleteTranformacion(String pid, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PRID", pid, "VARCHAR", ParameterDirection.Input));

                return con.ProcedureSelectDB("PRDELETE_TRANSFORMACION", crearp, pbd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal DataSet listadoPerfil(String cc, String bd)
        {
            sql = "select * from listado_perfiles where id='" + cc + "'";
            return dataload.MySqlQuery(sql, bd);
        }//trae los datos para el formulario perfil- pantalla inicial
        internal DataSet listadorecogida(string Ccosto, string tipoefectivo)//recogidas la 16
        {
            sql = "select  logusucreo,  " +
        " format(Sum(do.v" +
        "rtotal)+350000,'$ #,###.##') AS total, " +
        " format( " +

        " Sum(do.vrtotal)+350000 - case when(select sum(valor)+350000 from luisao_lcs where usuario = logusucreo and fecha = convert(date, getdate())) is null " +
         "       then 0 " +

         "else		 " +
         " (select sum(valor) from luisao_lcs where usuario = logusucreo and fecha = CONVERT(date, GETDATE()))  " +
          "      end " +


         " ,'$ #,###.##')  AS EnCaja " +
         " , (select format(sum(valor),'$ #,###.##') from luisao_lcs where usuario = logusucreo and fecha = convert(date, getdate()))as recogida " +

         " ,(select count(valor) from Luisao_lcs where usuario = logusucreo and fecha = CONVERT(date, getdate()))as cant " +

           "         FROM itfpago inner JOIN  documento AS do ON itfpago.documentID = do.id " +

            "            inner join fpago as fp  on fp.codigo = itfpago.fpagoID " +
             "       inner JOIN tipodoc AS td ON do.tipo = td.codigo " +
              "     WHERE fp.detalle = '" + tipoefectivo + "' " +
               "     AND do.fecha = CONVERT(date, GETDATE()) " +
                "     AND anulado = 0 " +
                 "  AND td.clasedoc in ('FV', 'FP') " +
                  "    AND do.ccostoID = '" + Ccosto + "'" +
                   " GROUP BY fp.detalle,do.logusucreo " +
                   "order by EnCaja";
            return dataload.sqlconsulta(sql);
        }
        internal int IngresaRecogida(string Ccosto, string empleado, string valor, string usuario)
        {
            sql = "INSERT INTO  dbo.Luisao_lcs (CCOSTO, USUARIO, VALOR,USUCREA) " +
                    " VALUES('" + Ccosto + "','" + empleado + "'," + valor + ",'" + usuario + "' )";
            return dataload.sqlProcedimiento(sql);
        }
        internal DataSet listadoactivo(String bd)
        {
            sql = "select * from listadoactivo";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listadoActas(string bd)
        {
            sql = "select * from listadoactas";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet Mactas_entrega(String bd)
        {
            sql = "select * from" +
                " actas_entrega";
            return dataload.MySqlQuery(sql, bd);
        }

        internal DataSet Mprecios()
        {
            sql = "SELECT a.codigo,  a.detalle, cd.codbarra,cast(valormiva as int)as" +
                " valormiva,cast(a.peso as int) as peso, cast(condiprom.vrveneficio as int) as descuento from articulo a" +
                " left join dbo.artspromo aprom ON a.codigo = aprom.articuloID " +
                "left join dbo.condicionpromo condiprom ON aprom.promocionID = condiprom.promocionID " +
                "left JOIN dbo.promocion promo ON condiprom.promocionID = promo.id" +
                "left join codbar cd on cd.articuloID = a.codigo" +
                "left join precio pc on pc.articuloID = a.codigo and(pc.presentacionID = cd.presentacionID or(pc.presentacionID is null and cd.presentacionID is null))" +
                "  where inactivo = 0";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mlistasaldos(string idart, String bd)
        {
            sql = "select nombUbica as Ubicacicion,(sum(kard_entrada) - sum(kard_salida)) as Saldos   from kardex k  inner join ubicacion u on k.kard_bodegaid=u.idUbica where kard_idarticulo=(select idArt from articulo where serialArt='" + idart + "') group by kard_bodegaid";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet msaldoactual(string idart, string bodega, String bd)
        {
            sql = "select nombUbica as Ubicacicion,(sum(kard_entrada) - sum(kard_salida)) as Saldos   from kardex k  inner join ubicacion u on k.kard_bodegaid=u.idUbica where kard_idarticulo=(select idArt from articulo where serialArt='" + idart + "') AND u.idUbica=(SELECT AU.idUbica FROM ubicacion AU WHERE AU.nombUbica='" + bodega + "') group by kard_bodegaid";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listado(String bd)
        {
            sql = "select * from listado";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listadoserial(string ser, String bd)
        {
            sql = "CALL P_LISTA_ACTIVOS_SERIAL  ('" + ser + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet MlistDeployeeDelivery(string cc, String bd)
        {
            sql = "CALL P_LISTA_ASIGNADOS  ('" + cc + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listadokardex(String id, String pf_ini, String pf_fin, String pubicacion, String bd)
        {
            sql = "CALL REPOR_KARDEX('" + id + "', '" + pf_ini + "', '" + pf_fin + " 23:59:00', '" + pubicacion + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listadonombre(string nom, String bd)
        {
            sql = "select * from listadotodos2 where Nombre_Avtivo like '%" + nom + "%'";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet msaldokardexgeneral(String bd)
        {
            sql = " SELECT a.nombreArt, SUM(k.kard_entrada)-sum(k.kard_salida) as saldos, u.nombUbica from kardex k inner join articulo a  on k.kard_idarticulo= a.idArt inner join ubicacion u        on k.kard_bodegaid= u.idUbica group by kard_idarticulo, kard_bodegaid order by a.nombreArt asc";
            return dataload.MySqlQuery(sql, bd);
        }

        internal DataSet msaldokardex(string fechaini, string fechafin, string serial, string pbodega, String bd)
        {
            sql = "select kard_fecha as Fecha_creacion,kard_fechamovimiento as Fecha,kard_registradopor as Usuario,kard_entrada AS ENTRADA,kard_salida AS SALIDA, kard_comentario AS DETALLE from kardex where kard_idarticulo= (select idArt from articulo where serialArt='" + serial + "') AND kard_fecha between '" + fechaini + "' and '" + fechafin + " 23:59:00'  and kard_bodegaid=(select idUbica from ubicacion where nombUbica='" + pbodega + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        //con esta parte del codigo puedo llenar los select2 sin necesidad del sql local
        //-----------------------------------------------------------------------------
        internal DataSet listaseriales(String bd)
        {
            sql = "select CONCAT(serialArt, ' / ', nombreArt) As Nombre  FROM articulo where inactivo=1";
            return dataload.MySqlQuery(sql, bd);
        }
        internal int Mcreaordentrabajo(string Pubicacion, string parea, string Pclasemante, string Pdescripcion, string pstado, string puser, string tiposolicitud, String bd)
        {
            sql = "call creaordentrabajo('" + Pubicacion + "', '" + parea + "', '" + Pclasemante + "', '" + Pdescripcion + "','" + pstado + "','" + puser + "','" + tiposolicitud + "'); ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreaasigtrabajo(string idorden, string pproveedor, string fecha, string puser, String bd)
        {
            sql = "call creaasigtrabajo(" + idorden + ", '" + pproveedor + "', '" + fecha + "', '" + puser + "'); ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreaaprobacion(string idorden, string pproveedor, string fecha, string puser, String bd)
        {
            sql = "call creaasigtrabajo(" + idorden + ", '" + pproveedor + "', '" + fecha + "', '" + puser + "'); ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet listaubicacion(String bd)
        {
            sql = "select nombUbica As Nombre  FROM ubicacion";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mlistatiposolicitud(String bd)
        {
            sql = "select Name As Nombre  FROM tiposolicitudordentrabajo";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet maxidmantenimientos(String bd)
        {
            sql = "SELECT max(mant_id)+1 as id from mantenimientos";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listaordenesradicadas(string puser, string roll, String bd)
        {
            sql = "call ORDENRADICADA('" + puser + "','" + roll + "');";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet Mlista_mant_preaprobados(String bd)
        {
            sql = "call Lista_Mant_Preaprovado();";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listaordenesasignadas(string puser, string roll, String bd)
        {
            sql = "call ORDENASIGNADOS('" + puser + "','" + roll + "');";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listadetallesmant_preaprobados(string pid, String bd)
        {
            sql = "call Listadetalles_Mante('" + pid + "');";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mllenaselectordenesasignadas(String bd)
        {
            sql = "select ordt_id IdOrden" +
                " ,asigt_id IdAsignacion," +
                " ordt_descripcion as Trabajo" +
                "      from orden_trabajo " +
                "       INNER JOIN asignacion_trabajo on asigt_idorden = ordt_id " +
                "       inner join persona on asigt_idproveedor = idResp" +
                "                       where ordt_estado = 'ASIGNADO'  " +
                "                           AND asigt_estado='PENDIENTE'";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mllenaselectordenes_Noadmin(string puser, String bd)
        {
            sql = "select CONCAT(CONVERT(asigt_id,CHAR),'/',CONVERT(ordt_id,CHAR),'/', ordt_descripcion) as Nombre " +
                " from orden_trabajo INNER JOIN asignacion_trabajo on asigt_idorden = ordt_id    " +
                "  inner join persona on asigt_idproveedor = idResp    " +
                "   where ordt_estado = 'ASIGNADO' AND ordt_user = '" + puser + "' AND asigt_estado='PENDIENTE'";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listaarea(String bd)
        {
            sql = "select nombrearea As Nombre  FROM area";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listatipomantenimiento(String bd)
        {
            sql = "select tipM_nombre As Nombre  FROM clase_mantenimiento";
            return dataload.MySqlQuery(sql, bd);
        }
        //-----------------------------------------------------------------
        //con esta parte del codigo lleno la informacion principal de un activo fijo
        //-----------------------------------------------------------------------------
        internal DataSet activodatosgenerales(String pserial, String bd)
        {
            sql = "select a.serialArt," +
                " nombreArt," +
                "m.nombMod," +
                "f.nombFabric," +
                "c.nombCat," +
                "p.nomb," +
                "a.fcompArt," +
                "a.valoruntArt," +
                "comentArt," +
                "a.timeGarant " +

                "from articulo a " +
                " inner join modelo m on m.idMod=a.modArt " +
                " inner join fabricante f on f.idFabric=a.fabriArt " +
                " inner join categoria c on c.idcat=a.categArt " +
                " inner join persona p on p.idResp=a.proveedor " +
              "  where a.serialArt='" + pserial + "'";
            return dataload.MySqlQuery(sql, bd);
        }
        //-----------------------------------------------------------------
        //----------------------------------------------------------------
        // aqui consulta carnes todos los puntos  BNET
        //----------------------------------------------------------------
        internal DataSet ListadocarnesBnet2(String pgrupo, String fechaini, String fechafin, String ccosto)
        {
            sql = "select articulo.detalle," +
                "cast (sum(itart.cantidad)as float) cantidad " +
                "       from itart, documento, articulo, tipodoc " +
                "           where articulo.codigo=itart.articuloID " +
                "               and itart.documentID= documento.id " +
                "               and documento.tipo= tipodoc.codigo " +
                "               and fecha between  '" + fechaini + "' and '" + fechafin + "' " +
                "               and tipodoc.clasedoc in ('FV', 'FP') and grupoID='" + pgrupo + "' " +
                "               and documento.ccostoId='" + ccosto + "' " +
                "               group by articulo.detalle,documento.ccostoId";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet ListadocarnesBnet(String pgrupo, String fechaini, String fechafin, String ccosto, string param)
        {
            sql = "   select i.articuloID, i.presentacion ," +
                "                                cast(sum(i.cantidad) as float) cantidad,cast(sum(i.vrtotal) as float)precio" +
                "                              from itart i inner join documento d on i.documentID = d.id" +
                "                                       inner join articulo a on a.codigo = i.articuloID" +
                "                                       inner join tipodoc td on td.codigo = d.tipo" +
                "                                          where" +
                "                                               fecha between  '" + fechaini + "' and '" + fechafin + "'" +
                "                                               and td.clasedoc in (" + param + ")" +
                "                                                and grupoID = '" + pgrupo + "'" +
                "                                               and d.ccostoId = '" + ccosto + "'" +
                "                                               AND d.anulado = 0" +
                "                                               group by presentacion,d.ccostoId,i.articuloID";
            return dataload.sqlconsulta(sql);
        }

        internal DataSet ListadodVBnet(String pgrupo, String fechaini, String fechafin, String ccosto)
        {
            sql = "   select itart.articuloID, itart.presentacion ," +
                "                cast(sum(itart.cantidad) as float) cantidad,cast(sum(itart.vrtotal) as float)precio" +
                "                       from itart, documento, articulo, tipodoc" +
                "                           where articulo.codigo = itart.articuloID" +
                "                               and itart.documentID = documento.id" +
                "                               and documento.tipo = tipodoc.codigo" +
                "                               and fecha between  '" + fechaini + "' and '" + fechafin + "'" +
                "                                and tipodoc.clasedoc in ('DV', 'DP')" +
                "                                and grupoID = '" + ccosto + "'" +
                "                               and documento.ccostoId = '" + pgrupo + "'" +
                "                               AND documento.anulado = 0" +
                "                               group by presentacion,documento.ccostoId,itart.articuloID";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet datosempresa_nomina()
        {
            sql = "SELECT 0 as ano, " +

        "0 as mes, " +
        "e.nombrec, " +
        "e.nombre, " +
        "e.nit, " +
        "e.digver, " +
        "e.regimen, " +
        "e.direccion, " +
        "e.telefono1, " +
        "c.nombre AS ciudad," +
        "dpto.nombre AS dpto, " +
        "e.telmovil," +
        "(SELECT TOP 1 le.logo FROM dbo.logoempresa le) logo," +
        "e.replegal," +
        "e.ccreplegal," +
        "e.contador," +
        "e.cccontador," +
        "e.tipopuc," +
        "e.telefono2," +
        "e.autorefreshinf," +
        "e.ccrevfiscal," +
        "e.revfiscal," +
        "e.tprevfiscal," +
        "e.tpcontador," +
        "e.ciudadID," +
        "email," +
        "url," +
        "e.id," +
        "e.autorete " +
        "FROM dbo.empresa e " +
        "LEFT OUTER JOIN ciudad c ON c.codigo = e.ciudadID LEFT OUTER JOIN " +
        "dpto ON c.dptoID = dpto.codigo";

            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mdatosnomina(String excluirparapres, String terceroID, String fechaini, String fechafin) //--Desprendible Nomina
        {
            sql = "declare @contratoID as nvarchar(20)" +
                " set @contratoID = (select contrato.id from th.contrato  where terceroID = '" + terceroID + "'    " +
                "and fechaini<= '" + fechaini + "'    and(fechafin is null or fechafin >= '" + fechafin + "')) " +
                "EXECUTE[dbo].[spDesprendiblesNomina]     " +
                "     '" + excluirparapres + "'    " +
                "      ,@contratoID   " +
                "       ,NULL     " +
                "     ,NULL    " +
                "      ,'0'      " +
                "    ,'" + fechaini + "'   " +
                "       ,'" + fechafin + "'";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadocarnes13(String pgrupo, String fechaini, String fechafin)
        {
            sql = "select itart.presentacion ,cast (sum(itart.cantidad)as float) cantidad from itart, documento, articulo, tipodoc where articulo.codigo=itart.articuloID and itart.documentID= documento.id and documento.tipo= tipodoc.codigo and fecha between  '" + fechaini + "' and '" + fechafin + "' and tipodoc.clasedoc in ('FV', 'FP') and grupoID='" + pgrupo + "' and documento.ccostoId='000002' group by presentacion,documento.ccostoId";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadocarnesversa(String pgrupo, String fechaini, String fechafin)
        {
            sql = "select itart.presentacion ,cast (sum(itart.cantidad)as float) cantidad from itart, documento, articulo, tipodoc where articulo.codigo=itart.articuloID and itart.documentID= documento.id and documento.tipo= tipodoc.codigo and fecha between  '" + fechaini + "' and '" + fechafin + "' and tipodoc.clasedoc in ('FV', 'FP') and grupoID='" + pgrupo + "' and documento.ccostoId='000004' group by presentacion,documento.ccostoId";
            return dataload.sqlconsulta(sql);
        }
        //----------------------------------------------------------------
        //-----------------------------------------------------------------
        //----------------------------------------------------------------
        // aqui consulta carnes todos los puntos  BASCULAS
        //----------------------------------------------------------------
        internal DataSet listadocarnesBS16(String pgrupo, String fechaini, String fechafin)
        {

            sql = "SELECT dat_ticket_linea.descripcion, SUM(dat_ticket_linea.peso)as Peso FROM dat_ticket_cabecera, dat_ticket_linea where dat_ticket_cabecera.idticket = dat_ticket_linea.idticket  and dat_ticket_cabecera.idbalanzamaestra = dat_ticket_linea.idbalanzamaestra and dat_ticket_cabecera.fecha between '" + fechaini + " 00:23:23' and '" + fechafin + " 23:01:01'and nombreseccion = '" + pgrupo + "' GROUP BY descripcion";
            return dataload.MySqlQuerycarnes(sql);
        }
        internal DataSet listadocarnesBS13(String pgrupo, String fechaini, String fechafin)
        {

            sql = "SELECT dat_ticket_linea.descripcion," +
                " SUM(dat_ticket_linea.peso)as Peso " +
                "FROM dat_ticket_cabecera, dat_ticket_linea where" +
                " dat_ticket_cabecera.idticket = dat_ticket_linea.idticket" +
                "  and dat_ticket_cabecera.idbalanzamaestra =" +
                " dat_ticket_linea.idbalanzamaestra and dat_ticket_cabecera.fecha between '" + fechaini + " 00:23:23' and '" + fechafin + " 23:01:01'and nombreseccion = '" + pgrupo + "' GROUP BY descripcion";
            return dataload.MySqlQuerycarnesLA13(sql);
        }
        internal DataSet ListadocarnesBasculas(String pgrupo, String fechaini, String fechafin, string tienda)
        {
            string idBascula = "";
            string idgrupo = "";
            switch (tienda)
            {
                case "SUPERMIO LA 13": idBascula = "11,12"; break;
                case "SUPERMIO LA 16": idBascula = "5,6,7"; break;
                case "SUPERMIO VERSALLES": idBascula = "1,2,3,4"; break;
                case "SUPERMIO CIUDADELA": idBascula = "8,9,10"; break;
                default:
                    break;
            }
            switch (pgrupo)
            {
                case "POLLO": idgrupo = "0"; break;
                case "RES": idgrupo = "1"; break;
                case "PEZ Y MAR": idgrupo = "2"; break;
                case "VISCERAS": idgrupo = "3"; break;
                case "CERDO": idgrupo = "4"; break;
                default:
                    break;
            }


            sql = "   select " +
                "         l.Descripcion," +
                "          count(c.IdTicket) as Operaciones," +
                "           sum(l.Peso) as Peso," +
                "            sum(l.ImporteConDtoTotal) as Importe" +
                "                 from dat_ticket_cabecera c" +
                "                 left" +
                "                 join dat_ticket_linea l on (c.IdEmpresa = l.IdEmpresa and c.IdTienda = l.IdTienda and c.IdBalanzaMaestra = l.IdBalanzaMaestra and c.IdBalanzaEsclava = l.IdBalanzaEsclava and c.TipoVenta = l.TipoVenta and c.IdTicket = l.IdTicket)" +
                "                  left join dat_tienda t on(c.`IdTienda`= t.`IdTienda` and c.`IdEmpresa`= t.`IdEmpresa`)" +
                "                   where" +
                "                    c.IdEmpresa = 1" +
                "                    AND c.IdTienda = 1" +
                "                     and l.EstadoLinea = 0" +
                "                      and(c.Fecha >= '"+fechaini+" 00:00:00' and c.Fecha <= '"+fechafin+" 23:59:59')" +
                "                       and c.IdBalanzaMaestra IN("+idBascula+")" +
                "                        and(l.IdSeccion = "+ idgrupo + ")" +
                "                         group by c.IdTienda, l.IdArticulo, t.DecimalesPrecio order by l.IdArticulo";
            return dataload.MySqlQuerycarnesVERSA(sql);
        }
        //----------------------------------------------------------------
        internal DataSet listadogeneral(String bd)
        {
            sql = "CALL P_LISTA_ACTAS_ENTREGA()";
            return dataload.MySqlQuery(sql, bd);
        }
        //trae el historico de un activo quien lo a tenido a cargo y sus ubicaciones
        internal DataSet listadoHistoriaActivos(String pserial, String bd)
        {
            sql = "CALL PHISTORIA_ACTIVO('" + pserial + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet validacionUsuario(string usuario, string contraseña, string PBD)
        {
            sql = "  select USUA_NOMBRE,PERS_TIPP_ID,TIPP_NOMBRE,PERS_CC,S.NOMBRE,S.CCOSTO,PERS_TEL FROM USUARIO " +
                "               INNER JOIN PERSONA ON USUA_IDPERS = PERS_ID" +
                "               INNER JOIN TIPOPERSONA ON PERS_TIPP_ID = TIPP_ID" +
                "               INNER JOIN SALAS_VENTA S ON USUA_SALAVENTAS = S.ID" +
                "                  WHERE USUA_NOMBRE= '" + usuario + "' and USUA_PASS='" + contraseña + "'";
            return dataload.oraconsulta(sql, PBD);
        }
        internal DataSet Salasventas(string PBD)
        {
            sql = "SELECT CCOSTO ||'/'||NOMBRE AS NOMBRE FROM SALAS_VENTA";
            return dataload.oraconsulta(sql, PBD);
        }
        internal DataSet llenatabla(string PBD)
        {
            sql = "select PERS_ID AS ID,PERS_NOMBRE1 AS PRIMER_NOMBRE,PERS_APELLIDO1 AS PRIMER_APELLIDO FROM PERSONA";
            return dataload.oraconsulta(sql, PBD);
        }

        internal DataSet Mlista_acom_ventasla16(string fei, string fef)//aquiventas la 16
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(DD, do.logfecreo) AS DIAS, format(Sum(do.vrsubtotal), '$ #,###.##') AS VALOR,COUNT(vrsubtotal) AS Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE(do.fecha BETWEEN '" + fei + "' AND '" + fef + "')  AND(td.clasedoc in ('FV', 'FP'))  AND do.ccostoID = '000001'  and do.anulado=0 GROUP BY DATEPART(DD, do.logfecreo) order by DIAS";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mlista_tercerosBnet(string cc)//lista terceros bnet para guardar listados de covid
        {
            sql = "select id,tercero.nombrecompleto,tercero.telefono from  tercero where id='" + cc + "'";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MVentasProveedor(string fei, string fef, string proveedor)//aqui ventas resumido tabla ventas por proveedor
        {
            sql = " SET NOCOUNT ON;  " +
                "declare @fecha1 as date = '" + fei + "'" +
                "       ,@fecha2 as date = '" + fef + "'" +
                " SELECT s.articuloID," +
                "                   a.detalle Articulo," +
                "       round(case when coalesce(Movimiento.PromVentaDia, 0) > 0 then s.saldocant / Movimiento.PromVentaDia else 0 end,2) DiasInvent, " +
                "   coalesce(Movimiento.CantidadInicial, 0) CantidadInicial," +
                "	   Movimiento.Traslados," +
                "	   Movimiento.compras," +
                "	   Movimiento.DevolCompras," +
                "	   coalesce(Movimiento.CantidadVenta, 0) CantidadVenta," +
                "	   s.saldocant," +
                "	   coalesce(Movimiento.PromVentaDia, 0) PromVentaDia," +
                "	   b.nombre[Nombre Bodega]," +
                "	   UltimoTraslado.FechaUltimoTraslado,	   " +
                "	   UltCompra.fechadesde FechaUltimaCompra," +
                "       Movimiento.CostoInicial," +
                "	   round(s.saldocant * s.costoPromedio, 2) CostoFinal," +
                "	   s.bodegaID," +
                "	   Movimiento.CostoVenta," +
                "	   s.saldocosto SaldoCosto," +
                "       costoPromedio CostoPromedio," +
                "	   UltCompra.proveedorID," +
                "	   m.nombre Marca," +
                "       l.nombre Linea," +
                "       g.nombre Grupo" +
                " FROM dbo.fnInventInventariosBase(@fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) s" +
                " inner join dbo.articulo a on a.codigo = s.articuloID " +
                " inner join dbo.bodega b on b.codigo = s.bodegaID " +
                " left join dbo.marca m on m.codigo = a.marcaID " +
                " left join dbo.linea l on l.codigo = a.lineaID " +
                " left join dbo.grupo g on g.codigo = a.grupoID " +
                " LEFT JOIN(SELECT t.articuloID," +
                "                     t.proveedorID," +
                "                     t.fechadesde" +
                "              FROM (" +
                "                    SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
                "    					articuloID, " +
                "    					proveedorID," +
                "    					fechadesde" +
                "                    FROM arthistocompra lc" +
                "                    WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta" +
                "					) T" +
                "             where T.rnum = 1" +
                ") UltCompra ON UltCompra.articuloID = s.articuloID" +
                " outer apply" +
                " ( " +
                "    SELECT sum(CostoVenta)      as CostoVenta" +
                "		,SUM(CantidadVenta) as CantidadVenta" +
                "		,sum(CantidadInicial) as CantidadInicial" +
                "		,(sum(CantidadVenta) / DATEDIFF(dd, @fecha1, @fecha2) + 1) * -1 as PromVentaDia" +
                "		,sum(CostoInicial) as CostoInicial" +
                "		,sum(Traslados) as Traslados" +
                "		,sum(Compras) as Compras" +
                "		,sum(DevolCompras) as DevolCompras" +
                "    FROM(" +
                "        SELECT" +
                "                (0.0) as CostoVenta" +
                "               , (0.0) as CantidadVenta" +
                "               , sx.saldocosto as CostoInicial" +
                "               , sx.saldocant as CantidadInicial" +
                "               , cast(0 as numeric(15, 2)) as Traslados" +
                "               , cast(0 as numeric(15, 2)) as Compras" +
                "               , cast(0 as numeric(15, 2)) as DevolCompras" +
                "               , articuloID" +
                "               , bodegaID" +
                "        FROM   dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "        where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "        and sx.articuloID = s.articuloID" +
                "        and sx.bodegaID = s.bodegaID" +
                "        UNION ALL    " +
                "        SELECT " +
                "				case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.vrcostototal else 0 end as CostoVenta" +
                "			   ,case when sx.clasedoc not in('NT', 'FC', 'DC') then sx.cantidad else 0 end as CantidadVenta" +
                "			   ,Cast(0 as numeric(15, 2)) as CostoInicial" +
                "			   ,Cast(0 as numeric(15, 2)) as CantidadInicial" +
                "			   ,case when sx.clasedoc = 'NT' then sx.cantidad else 0 end as Traslados" +
                "			   ,case when sx.clasedoc = 'FC' then sx.cantidad else 0 end as Compras" +
                "			   ,case when sx.clasedoc = 'DC' then sx.cantidad else 0 end as DevolCompras" +
                "			   ,articuloID" +
                "			   ,bodegaID" +
                "        FROM   dbo.itinvent sx" +
                "        where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "        AND sx.clasedoc IN('FV', 'FP', 'DV', 'DP','NT','FC','DC')" +
                "		and sx.articuloID = s.articuloID" +
                "        and sx.bodegaID = s.bodegaID" +
                "	)r group by r.articuloID,r.bodegaID " +
                ")Movimiento " +
                " OUTER APPLY( " +
                " SELECT TOP 1 r.fecha as FechaUltimoTraslado " +
                " FROM" +
                " (" +
                "    SELECT" +
                "            sx.fecha" +
                "    FROM   dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "    where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "    and s.articuloID = sx.articuloID" +
                "    and s.bodegaID = sx.bodegaID" +
                "    AND sx.clasedoc IN('NT')" +
                "    UNION ALL" +
                "    SELECT" +
                "        sx.fecha" +
                "    FROM   dbo.itinvent sx" +
                "    where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "    and s.articuloID = sx.articuloID" +
                "    and s.bodegaID = sx.bodegaID" +
                "    AND sx.clasedoc IN('NT')" +
                " )r order by r.fecha desc" +
                " )UltimoTraslado where UltCompra.proveedorID = '" + proveedor + "' ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MventasResmidoporlinea(string fei, string fef, string ccosto)//aqui ventas resumido tabla ventas por linea
        {
            sql = " declare @pro as int=(   select Sum(it.vrtotal) AS V_ANTES_IVA " +
                "                                         from documento d " +
                "                                                  inner " +
                "                                         join itart it on d.id = it.documentid " +
                "                                   inner" +
                "                                         join articulo art ON it.articuloID = art.codigo" +
                "                 inner join linea ln on art.lineaID = ln.codigo" +
                "                                   INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +

                "                                                         where d.anulado = 0" +
                "                                                          and d.fecha between '" + fei + "' and '" + fef + "' " +
                "                                                          and td.clasedoc IN('FV' , 'FP')" +
                "                                                          AND d.ccostoID = '" + ccosto + "')" +
                "      select final.LINEA," +
                "             final.VENTASS," +
                "             CONCAT(porcent, ' %') AS PORCENT" +
                "             FROM" +
                " (select    ventas.nombre AS LINEA," +
                "           format((ventas.V_ANTES_IVAs), '$ ###,###.##') as VENTASS, " +
                "          CONVERT(DECIMAL(10, 2), sum((ventas.V_ANTES_IVAs * 100) / @pro)) as porcent" +
                "   from(select ln.nombre," +
                "                Sum(it.vrtotal) AS V_ANTES_IVAs" +
                "                         from documento d" +
                "                             inner join itart it on d.id = it.documentid" +
                "              inner  join articulo art ON it.articuloID = art.codigo" +
                "                 inner  join linea ln on art.lineaID = ln.codigo" +
                "                   INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +
                "                                           where d.anulado = 0" +
                "                                                    and d.fecha between '" + fei + "' and '" + fef + "'" +
                "                                               and  td.clasedoc IN('FV', 'FP')" +
                "                               AND d.ccostoID = '" + ccosto + "'" +
                "                                group by ln.nombre)ventas" +
                "                                group by ventas.nombre, ventas.V_ANTES_IVAs)final";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MRoracioninventarioProveedor(string fei, string fef, string proveedor)//aqui ventas resumido tabla ventas por linea
        {
            sql = " SET NOCOUNT ON;  " +
                "declare @fecha1 as date = '" + fei + "'" +
                "       ,@fecha2 as date = '" + fef + "'" +
                " SELECT s.articuloID," +
                "                   a.detalle Articulo," +
                "       round(case when coalesce(Movimiento.PromVentaDia, 0) > 0 then s.saldocant / Movimiento.PromVentaDia else 0 end,2) DiasInvent, " +
                "   coalesce(Movimiento.CantidadInicial, 0) CantidadInicial," +
                "	   Movimiento.Traslados," +
                "	   Movimiento.compras," +
                "	   Movimiento.DevolCompras," +
                "	   coalesce(Movimiento.CantidadVenta, 0) CantidadVenta," +
                "	   s.saldocant," +
                "	   coalesce(Movimiento.PromVentaDia, 0) PromVentaDia," +
                "	   b.nombre[Nombre Bodega]," +
                "	   UltimoTraslado.FechaUltimoTraslado,	   " +
                "	   UltCompra.fechadesde FechaUltimaCompra," +
                "       Movimiento.CostoInicial," +
                "	   round(s.saldocant * s.costoPromedio, 2) CostoFinal," +
                "	   s.bodegaID," +
                "	   Movimiento.CostoVenta," +
                "	   s.saldocosto SaldoCosto," +
                "       costoPromedio CostoPromedio," +
                "	   UltCompra.proveedorID," +
                "	   m.nombre Marca," +
                "       l.nombre Linea," +
                "       g.nombre Grupo" +
                " FROM dbo.fnInventInventariosBase(@fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) s" +
                " inner join dbo.articulo a on a.codigo = s.articuloID " +
                " inner join dbo.bodega b on b.codigo = s.bodegaID " +
                " left join dbo.marca m on m.codigo = a.marcaID " +
                " left join dbo.linea l on l.codigo = a.lineaID " +
                " left join dbo.grupo g on g.codigo = a.grupoID " +
                " LEFT JOIN(SELECT t.articuloID," +
                "                     t.proveedorID," +
                "                     t.fechadesde" +
                "              FROM (" +
                "                    SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
                "    					articuloID, " +
                "    					proveedorID," +
                "    					fechadesde" +
                "                    FROM arthistocompra lc" +
                "                    WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta" +
                "					) T" +
                "             where T.rnum = 1" +
                ") UltCompra ON UltCompra.articuloID = s.articuloID" +
                " outer apply" +
                " ( " +
                "    SELECT sum(CostoVenta)      as CostoVenta" +
                "		,SUM(CantidadVenta) as CantidadVenta" +
                "		,sum(CantidadInicial) as CantidadInicial" +
                "		,(sum(CantidadVenta) / DATEDIFF(dd, @fecha1, @fecha2) + 1) * -1 as PromVentaDia" +
                "		,sum(CostoInicial) as CostoInicial" +
                "		,sum(Traslados) as Traslados" +
                "		,sum(Compras) as Compras" +
                "		,sum(DevolCompras) as DevolCompras" +
                "    FROM(" +
                "        SELECT" +
                "                (0.0) as CostoVenta" +
                "               , (0.0) as CantidadVenta" +
                "               , sx.saldocosto as CostoInicial" +
                "               , sx.saldocant as CantidadInicial" +
                "               , cast(0 as numeric(15, 2)) as Traslados" +
                "               , cast(0 as numeric(15, 2)) as Compras" +
                "               , cast(0 as numeric(15, 2)) as DevolCompras" +
                "               , articuloID" +
                "               , bodegaID" +
                "        FROM   dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "        where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "        and sx.articuloID = s.articuloID" +
                "        and sx.bodegaID = s.bodegaID" +
                "        UNION ALL    " +
                "        SELECT " +
                "				case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.vrcostototal else 0 end as CostoVenta" +
                "			   ,case when sx.clasedoc not in('NT', 'FC', 'DC') then sx.cantidad else 0 end as CantidadVenta" +
                "			   ,Cast(0 as numeric(15, 2)) as CostoInicial" +
                "			   ,Cast(0 as numeric(15, 2)) as CantidadInicial" +
                "			   ,case when sx.clasedoc = 'NT' then sx.cantidad else 0 end as Traslados" +
                "			   ,case when sx.clasedoc = 'FC' then sx.cantidad else 0 end as Compras" +
                "			   ,case when sx.clasedoc = 'DC' then sx.cantidad else 0 end as DevolCompras" +
                "			   ,articuloID" +
                "			   ,bodegaID" +
                "        FROM   dbo.itinvent sx" +
                "        where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "        AND sx.clasedoc IN('FV', 'FP', 'DV', 'DP','NT','FC','DC')" +
                "		and sx.articuloID = s.articuloID" +
                "        and sx.bodegaID = s.bodegaID" +
                "	)r group by r.articuloID,r.bodegaID " +
                ")Movimiento " +
                " OUTER APPLY( " +
                " SELECT TOP 1 r.fecha as FechaUltimoTraslado " +
                " FROM" +
                " (" +
                "    SELECT" +
                "            sx.fecha" +
                "    FROM   dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "    where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "    and s.articuloID = sx.articuloID" +
                "    and s.bodegaID = sx.bodegaID" +
                "    AND sx.clasedoc IN('NT')" +
                "    UNION ALL" +
                "    SELECT" +
                "        sx.fecha" +
                "    FROM   dbo.itinvent sx" +
                "    where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "    and s.articuloID = sx.articuloID" +
                "    and s.bodegaID = sx.bodegaID" +
                "    AND sx.clasedoc IN('NT')" +
                " )r order by r.fecha desc" +
                " )UltimoTraslado where UltCompra.proveedorID = '" + proveedor + "' ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mrotacion(string fechadesde, string nit)//AQUI ROTACION DE INVENTARIOS
        {
            sql = " SET NOCOUNT ON;" +
                "  declare @fecha1 as date = '" + fechadesde + "'" +
                "       ,@fecha2 as date = getdate() " +
                " SELECT s.articuloID, " +
                "	   a.detalle Articulo," +
                "       round(case when coalesce(Movimiento.PromVentaDia, 0) > 0 then s.saldocant / Movimiento.PromVentaDia else 0 end, 2) DiasInvent, " +
                "	   coalesce(s.SaldoCantidadInicial, 0) CantidadInicial," +
                "	   Movimiento.Traslados," +
                "	   Movimiento.compras," +
                "	   Movimiento.DevolCompras," +
                "	   coalesce(Movimiento.cantventa, 0) cantventa," +
                "	   s.saldocant," +
                "	   coalesce(Movimiento.PromVentaDia, 0) PromVentaDia," +
                "	   b.nombre[Nombre Bodega]," +
                "	   UltimoTraslado.FechaUltimoTraslado,	   " +
                "	   lc.fechadesde FechaUltimaCompra," +
                "       Movimiento.CostoInicialVenta," +
                "	   round(s.saldocant * s.costoPromedio, 2) CostoFinal," +
                "	   s.bodegaID," +
                "	   Movimiento.ValorVenta," +
                "	   s.saldocosto SaldoCosto," +
                "       costoPromedio CostoPromedio," +
                "	   lc.proveedorID," +
                "	   m.nombre Marca," +
                "       l.nombre Linea," +
                "       g.nombre Grupo" +
                " FROM dbo.fnInventInventariosBase(@fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) s" +
                " inner join dbo.articulo a on a.codigo = s.articuloID" +
                " inner join dbo.bodega b on b.codigo = s.bodegaID" +
                " left join dbo.marca m on m.codigo = a.marcaID" +
                " left join dbo.linea l on l.codigo = a.lineaID" +
                " left join dbo.grupo g on g.codigo = a.grupoID " +
                " LEFT JOIN(SELECT t.articuloID," +
                "                     t.proveedorID," +
                "                     t.fechadesde" +
                "              FROM (" +
                "                    SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
                "    					articuloID, " +
                "    					proveedorID," +
                "    					fechadesde" +
                "                    FROM arthistocompra lc" +
                "                    WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta" +
                "					) T             where T.rnum = 1" +
                " ) lc ON lc.articuloID = s.articuloID " +
                " outer apply" +
                " (" +
                "    SELECT sum(ValorVenta) ValorVenta" +
                "        , SUM(cantventa) cantventa" +
                "        , (sum(cantventa) / DATEDIFF(dd, @fecha1, @fecha2) + 1)*-1 as PromVentaDia" +
                "		,sum(CostoInicialVenta) CostoInicialVenta" +
                "		,sum(Traslados)     Traslados" +
                "		,sum(Compras)       Compras" +
                "		,sum(DevolCompras)  DevolCompras" +
                "    FROM(    " +
                "        SELECT" +
                "                (case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.saldocosto else 0 end)            ValorVenta" +
                "               , (0.0)                   cantventa" +
                "               , (case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.saldocosto else 0 end)            CostoInicialVenta" +
                "			   ,cast(0 as numeric(15, 2)) as Traslados" +
                "			   ,cast(0 as numeric(15, 2)) as Compras" +
                "			   ,cast(0 as numeric(15, 2)) as DevolCompras" +
                "        FROM dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "        where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "        and s.articuloID = sx.articuloID" +
                "        and s.bodegaID = sx.bodegaID" +
                "        AND sx.clasedoc IN('FV', 'FP', 'DV', 'DP','NT','FC','DC')" +
                "		UNION ALL   " +
                "        SELECT" +
                "                 sx.vrcostototal vrtotal" +
                "               ,(case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.cantidad else 0 end) CantVenta" +
                "			   ,Cast(0 as numeric(15, 2)) CostoInicial" +
                "			   ,case when sx.clasedoc = 'NT' then sx.cantidad else 0 end Traslados" +
                "               ,case when sx.clasedoc = 'FC' then sx.cantidad else 0 end Compras" +
                "               ,case when sx.clasedoc = 'DC' then sx.cantidad else 0 end DevolCompras" +
                "        FROM dbo.itinvent sx" +
                "        where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "        and s.articuloID = sx.articuloID" +
                "        and s.bodegaID = sx.bodegaID" +
                "        AND sx.clasedoc IN('FV', 'FP', 'DV', 'DP','NT','FC','DC')" +
                "	)r " +
                " )Movimiento" +
                " OUTER APPLY( " +
                " SELECT TOP 1 r.fecha as FechaUltimoTraslado" +
                " FROM" +
                "  (    SELECT" +
                "            sx.fecha " +
                "   FROM   dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "    where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "    and s.articuloID = sx.articuloID" +
                "    and s.bodegaID = sx.bodegaID" +
                "    AND sx.clasedoc IN('NT')" +
                "    UNION ALL" +
                "    SELECT" +
                "        sx.fecha" +
                "    FROM   dbo.itinvent sx" +
                "    where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "    and s.articuloID = sx.articuloID" +
                "    and s.bodegaID = sx.bodegaID" +
                "    AND sx.clasedoc IN('NT') " +
                ")r order by r.fecha desc " +
                ")UltimoTraslado " +
                "where lc.proveedorID = '" + nit + "'";
            return dataload.sqlconsulta(sql);
        }
        
        internal DataSet Mrotacionsaladeventas(string fechadesde, string nit,string salaventas)//AQUI ROTACION DE INVENTARIOS para salas de ventas JUlio
        {
            sql = " SET NOCOUNT ON; " +
                "                  declare @fecha1 as date = '"+fechadesde+"'" +
                "                       ,@fecha2 as date = getdate()" +
                "                 SELECT s.articuloID, " +
                "                	   a.detalle Articulo," +
                "                           cast(round(case when coalesce(Movimiento.PromVentaDia, 0) > 0 then s.saldocant / Movimiento.PromVentaDia else 0 end, 2)as decimal (7,1)) DiasInvent, " +
                "                                    cast(coalesce(s.SaldoCantidadInicial, 0) as decimal(7, 1)) CantidadInicial, " +
                "                                      cast(Movimiento.Traslados as decimal(7, 1))Traslados, " +
                "                                      cast(Movimiento.compras as decimal(7, 1))Compras, " +
                "                                         cast(Movimiento.DevolCompras as decimal(7, 1))DevolCompras, " +
                "                                         cast(coalesce(Movimiento.cantventa, 0) as decimal) cantventa, " +
                "                                           CAST(s.saldocant AS decimal(7, 1))Saldo, " +
                "                                            cast(abs(coalesce(Movimiento.PromVentaDia, 0)) as DECIMAL (7, 1)) PromVentaDia," +
                "                                             CAST((coalesce(Movimiento.PromVentaDia, 0) * 10) - s.saldocant AS int) Sugerido," +
                "                                             b.nombre[Nombre Bodega]," +
                "                              	   UltimoTraslado.FechaUltimoTraslado,	  " +
                "                	   lc.fechadesde FechaUltimaCompra," +
                "                       Movimiento.CostoInicialVenta," +
                "                	   round(s.saldocant * s.costoPromedio, 2) CostoFinal," +
                "                	   s.bodegaID," +
                "                	   Movimiento.ValorVenta," +
                "                	   s.saldocosto SaldoCosto," +
                "                       costoPromedio CostoPromedio," +
                "                	   lc.proveedorID," +
                "                	   m.nombre Marca," +
                "                       l.nombre Linea," +
                "                       g.nombre Grupo" +
                "                 FROM dbo.fnInventInventariosBaseRotacion(@fecha1, @fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) s" +
                "                 inner join dbo.articulo a on a.codigo = s.articuloID" +
                "                 inner join dbo.bodega b on b.codigo = s.bodegaID" +
                "                 left join dbo.marca m on m.codigo = a.marcaID" +
                "                 left join dbo.linea l on l.codigo = a.lineaID" +
                "                 left join dbo.grupo g on g.codigo = a.grupoID" +
                "                 LEFT JOIN(SELECT t.articuloID," +
                "                                     t.proveedorID," +
                "                                     t.fechadesde" +
                "                              FROM (" +
                "                                    SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
                "                    					articuloID, " +
                "                    					proveedorID," +
                "                    					fechadesde" +
                "                                    FROM arthistocompra lc" +
                "                                    WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta" +
                "                					) T where T.rnum = 1" +
                "                 ) lc ON lc.articuloID = s.articuloID" +
                "                 outer apply" +
                "                 (" +
                "                    SELECT sum(ValorVenta) ValorVenta" +
                "                        , SUM(cantventa) cantventa" +
                "                        , (sum(cantventa) / DATEDIFF(dd, @fecha1, @fecha2) + 1)*-1 as PromVentaDia" +
                "                		,sum(CostoInicialVenta) CostoInicialVenta" +
                "                		,sum(Traslados)     Traslados" +
                "                		,sum(Compras)       Compras" +
                "                		,sum(DevolCompras)  DevolCompras" +
                "                    FROM(" +
                "                        SELECT" +
                "                                (case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.saldocosto else 0 end)            ValorVenta" +
                "                               , (0.0)                   cantventa" +
                "                               , (case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.saldocosto else 0 end)            CostoInicialVenta" +
                "                			   ,cast(0 as numeric(15, 2)) as Traslados" +
                "                			   ,cast(0 as numeric(15, 2)) as Compras" +
                "                			   ,cast(0 as numeric(15, 2)) as DevolCompras" +
                "                        FROM dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "                        where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "                        and s.articuloID = sx.articuloID" +
                "                        and s.bodegaID = sx.bodegaID" +
                "                        AND sx.clasedoc IN('FV', 'FP', 'DV', 'DP','NT','FC','DC')" +
                "                		UNION ALL" +
                "                        SELECT" +
                "                                 sx.vrcostototal vrtotal" +
                "                               ,(case when sx.clasedoc not in ('NT', 'FC', 'DC') then sx.cantidad else 0 end) CantVenta" +
                "                			   ,Cast(0 as numeric(15, 2)) CostoInicial" +
                "                			   ,case when sx.clasedoc = 'NT' then sx.cantidad else 0 end Traslados" +
                "                               ,case when sx.clasedoc = 'FC' then sx.cantidad else 0 end Compras" +
                "                               ,case when sx.clasedoc = 'DC' then sx.cantidad else 0 end DevolCompras" +
                "                        FROM dbo.itinvent sx" +
                "                        where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "                        and s.articuloID = sx.articuloID" +
                "                        and s.bodegaID = sx.bodegaID" +
                "                        AND sx.clasedoc IN('FV', 'FP', 'DV', 'DP','NT','FC','DC')" +
                "                	)r" +
                "                 )Movimiento" +
                "                 OUTER APPLY(" +
                "                 SELECT TOP 1 r.fecha as FechaUltimoTraslado" +
                "                 FROM" +
                "                  (SELECT" +
                "                            sx.fecha" +
                "                   FROM   dbo.vwInventSaldosInventario sx WITH(NOEXPAND)" +
                "                    where sx.fecha <= eomonth(dateadd(Month, -1, @fecha1))" +
                "                    and s.articuloID = sx.articuloID" +
                "                    and s.bodegaID = sx.bodegaID" +
                "                    AND sx.clasedoc IN('NT')" +
                "                    UNION ALL" +
                "                    SELECT" +
                "                        sx.fecha" +
                "                    FROM   dbo.itinvent sx" +
                "                    where sx.fecha between dateadd(day, 1, eomonth(dateadd(month, -1, @Fecha1))) and @Fecha2" +
                "                    and s.articuloID = sx.articuloID" +
                "                    and s.bodegaID = sx.bodegaID" +
                "                    AND sx.clasedoc IN('NT')" +
                "                )r order by r.fecha desc" +
                "                )UltimoTraslado" +
                "                where lc.proveedorID = '"+nit+"' and b.nombre = '"+salaventas+"'";
            return dataload.sqlconsulta(sql);
        }


        internal DataSet MBajasFruver(string fechadesde, string hasta, string ccosto)//AQUI ROTACION DE INVENTARIOS
        {
            sql = $" declare @fecha1 as date='{fechadesde}'" +
             $"  declare @fecha2 as date = '{hasta}'" +
             $"  select a.codigo,a.detalle, cast(SUM(i.cantidadpres)as varchar )Cantidad from itart i" +
             $"        INNER" +
             $"                                                 join documento d on d.id = i.documentID" +
             $"                                          inner" +
             $"                                                 join tipodoc td on d.tipo = td.codigo" +
             $"                                         inner" +
             $"                                                join articulo a on a.codigo = i.articuloID" +
             $"        where" +
             $"        d.fecha between @fecha1 and @fecha2" +
             $"                           AND td.codigo in('4025','4027','4029')" +
             $"                                        AND d.ccostoID = '{ccosto}'" +
             $"                                              and d.anulado = 0" +
             $"                                              group by a.codigo,a.detalle";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mventastotalesporlinea(string fei, string fef, string ccosto, string metrosc)//aquiventas totales para formulario ventas por linea
        {
            sql = " declare @fecha1 as date='" + fei + "'" +
                "               declare @fecha2 as date = '" + fef + "'" +
                "                declare @pro as int = (select r.vrproyectado from dbo.Luisao_Proyectado r where r.ccostoID = '" + ccosto + "') " +
                "                 declare @dias as int = (SELECT DATEDIFF(day, @fecha1, @fecha2) + 1) " +
                "                 Declare @diasmes as int = (SELECT datepart(DD, dateadd(ms, -3, DATEADD(mm, DATEDIFF(m, 0, @fecha2) + 1, 0)))) " +
                "                 declare @diasmas as int = (select @diasmes - @dias) " +
                "                 select final2.VENTAS" +
                "                        ,final2.VR_META" +
                "                        ,final2.PORCENT" +
                "                        ,final2.PROM_VENTAS_DIARIAS" +
                "                        ,FORMAT((final2.PROYECTADO), '$ ###,###.##') as PROYECTADO" +
                "                        ,cast(SUM((final2.PROYECTADO * 100) / @pro)AS INT) PORC_PROYEC" +
                "                        ,@dias as Dias_a_Hoy" +
                "                        , @diasmes as Dias_Mes" +
                "                        , @diasmas AS Dias_Faltan" +
                "                        ,final2.cantidad" +
                "                        ,FORMAT((final2.PROM_COMPRA), '$ ###,###.##')PROMEDIO_COMPRA" +
                "                        ,VENTAS_METROCUADRADO" +
                "                        FROM(" +
                "                 select   format((final.Ventas_antes_iva), '$ ###,###.##') as VENTAS" +
                "                        , final.V_Proyectado as VR_META" +
                "                        , final.PORCENT" +
                "                        , final.cantidad" +
                "                        , final.PROM_COMPRA" +
                "                        , FORMAT((final.P_VENTA_DIARA), '$ ###,###.##')AS PROM_VENTAS_DIARIAS" +
                "                        , sum((P_VENTA_DIARA * @diasmas) + final.Ventas_antes_iva) AS PROYECTADO" +
                "                        , FORMAT((Ventas_antes_iva / '" + metrosc + "'), '$ ###,###.##') as VENTAS_METROCUADRADO" +
                "                      from" +
                "                        (" +
                "                SELECT(ventas.V_ANTES_IVA) as Ventas_antes_iva, ventas.cantidad," +
                "                        format((ventas.vrProyectado), '$ ###,###.##') as V_Proyectado," +
                "                        cast(SUM((V_ANTES_IVA * 100) / @pro)AS INT) PORCENT," +
                "                        sum((V_ANTES_IVA) / @dias) as P_VENTA_DIARA," +
                "                        sum(ventas.V_ANTES_IVA / ventas.cantidad) as PROM_COMPRA" +
                "                         from(" +
                "                 SELECT   lp.vrProyectado" +
                "                        , Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                "                         , COUNT(vrsubtotal) as cantidad" +
                "                                FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                "                               inner join dbo.Luisao_Proyectado lp on lp.ccostoId =do.ccostoID" +
                "                                WHERE fecha between @fecha1 and @fecha2" +
                "                                AND td.clasedoc in('FP', 'FV')" +
                "                                 AND do.ccostoID = '" + ccosto + "'" +
                "                                  and do.anulado = 0" +
                "                                  GROUP BY lp.vrProyectado" +
                "                                 )ventas GROUP BY ventas.V_ANTES_IVA,ventas.cantidad,ventas.vrProyectado)final                                       " +
                "                                    group by final.Ventas_antes_iva,final.cantidad,final.PROM_COMPRA,final.V_Proyectado,final.PORCENT,final.P_VENTA_DIARA)final2" +
                "                                          group by final2.VENTAS,final2.VENTAS_METROCUADRADO,final2.cantidad,final2.PROM_COMPRA,final2.VR_META,final2.PROM_VENTAS_DIARIAS,final2.PROYECTADO,final2.PORCENT";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MventasLINEA(string fei, string fef, string ccosto)//aquiventas totales para formulario ventas por linea
        {
            sql = "   select " +
                " r.Linea," +
                " r.N_fact," +
                " format(r.V_ANTES_IVA, '$ ###,###.##')V_ANTES_IVA," +
                " FORMAT(cast(r.V_ANTES_IVA as int) / cast(r.N_fact as int), '$ ###,###.##')Pr_Venta" +
                "  from(" +
                "    select  ln.nombre AS Linea" +
                "                        , count(distinct it.documentID)N_fact" +
                "                        , Sum(it.vrtotal) AS V_ANTES_IVA" +
                "                 from documento d inner join itart it on d.id = it.documentID and d.fecha between '" + fei + "' and '" + fef + "'" +
                "                 inner join articulo art ON it.articuloID = art.codigo" +
                "                 inner join linea ln on art.lineaID = ln.codigo" +
                "                 INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +
                "                 where" +
                "                    AND td.clasedoc in('FP','FV','FE')" +
                "                    AND d.ccostoID = '" + ccosto + "'" +
                "                    and d.anulado = 0" +
                "                 group by ln.nombre)r";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mventascontramesanterior(string fei, string fef, string ccosto)//aqui trae las ventas contra el mes anterior
        {
            sql = "     declare @fecha1 as date='" + fei + "'" +
                " declare @fecha2 as date = '" + fef + "'" +
                "    Declare @mesctual as float = (SELECT      Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                "                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                "                           WHERE fecha between @fecha1 and @fecha2" +
                "                               AND td.clasedoc in('FP', 'FV')" +
                "                                 AND do.ccostoID = '" + ccosto + "'" +
                "                                  and do.anulado = 0)" +
                "                                  declare @fanterior1 as date = (SELECT DATEADD(MM, -1, @fecha1))" +
                "                                   declare @fanterior2 as date = (SELECT DATEADD(MM, -1, @fecha2))                                  " +
                "        Declare @mesanterior as float = (SELECT      Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                "                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                "                           WHERE fecha between @fanterior1 and @fanterior2" +
                "                                AND td.clasedoc in('FP', 'FV')" +
                "                                 AND do.ccostoID = '" + ccosto + "'" +
                "                                  and do.anulado = 0)" +
                "                                 select FORMAT(((@mesctual -@mesanterior)/ @mesanterior)*100, '###,###.#')  as dato  ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MventascontraAñoanterior(string fei, string fef, string ccosto)//aqui trae las ventas contra el mes anterior
        {
            sql = "     declare @fecha1 as date='" + fei + "'" +
                " declare @fecha2 as date = '" + fef + "'" +
                "    Declare @mesctual as float = (SELECT      Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                "                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                "                           WHERE fecha between @fecha1 and @fecha2" +
                "                               AND td.clasedoc in('FP', 'FV')" +
                "                                 AND do.ccostoID = '" + ccosto + "'" +
                "                                  and do.anulado = 0)" +
                "                                  declare @fanterior1 as date = (SELECT DATEADD(yy, -1, @fecha1))" +
                "                                   declare @fanterior2 as date = (SELECT DATEADD(yy, -1, @fecha2))                                  " +
                "        Declare @añoanterior as float = (SELECT      Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                "                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                "                           WHERE fecha between @fanterior1 and @fanterior2" +
                "                                AND td.clasedoc in('FP', 'FV')" +
                "                                 AND do.ccostoID = '" + ccosto + "'" +
                "                                  and do.anulado = 0)" +
                "                                 select FORMAT(((@mesctual -@añoanterior)/ @añoanterior)*100, '###,###.#')  as dato,format(@añoanterior,'###,###.#') as dato2  ";
            return dataload.sqlconsulta(sql);
        }

        internal DataSet Rotaciondias(string fecha, string fechaf, string sala)
        {
            sql = $"SET NOCOUNT ON; " +
                $"declare @fecha1 as date = '{fecha}'" +
                $" ,@fecha2 as date = '{fechaf}'" +
                $" select" +
                $"            fin.articuloID," +
                $"			fin.Articulo," +
                $"			 CAST(CantidadInicial AS INT)as [cantidad Inicial]," +
                $"			CAST(fin.cantventa AS INT) as[Ventas]," +
                $"			CAST(fin.saldocant AS INT)as [cantidad Final]," +

                $"			cast(fin.dias_sin_venta as Float) as [Dias sin Venta]," +
                $"					cast(cast((fin.saldocant / fin.PromedioCantidadVentaDia)as DECIMAL(20,2))as varchar) DiasInventario" +
                $"					,FechaUltimoTraslado" +
                $"					,FechaUltimaVENTA," +

                $"			fin.Marca," +
                $"			fin.Grupo," +
                $"			fin.Linea," +
                $"			fin.nombre as Proveedor " +
                $"from" +
                $"(" +
                $"    SELECT  t.articuloID," +
                $"            a.detalle[Articulo]," +
                $"            t.cantventa," +
                $"            t.cantventa / DATEDIFF(dd, @fecha1, @fecha2) as PromedioCantidadVentaDia," +
                $"            t.saldocant," +
                $"            t.saldocosto," +
                $"            b.nombre[Nombre Bodega]," +
                $"            ma.nombre[Marca]," +
                $"            gr.nombre[Grupo]," +
                $"            ln.nombre[Linea]," +
                $"                        lc.proveedorID," +
                $"			ter.nombre," +
                $"			lc.fechadesde," +
                $"			CantidadInicial," +
                $"			UltimoTraslado.FechaUltimoTraslado," +
                $"			UltimaCompra.FechaUltimaVENTA," +
                $"			costoPromedio," +
                $"			DATEDIFF(dd, UltimaCompra.FechaUltimaVENTA, getdate()) as dias_sin_venta" +
                $"    FROM(" +
                $"        SELECT COALESCE(venta.articuloID, s.articuloID) articuloID," +
                $"            COALESCE(venta.bodegaID, s.bodegaID) bodegaID," +
                $"            venta.cantventa," +
                $"            s.saldocant," +
                $"            venta.vrtotal," +
                $"            s.saldocosto," +
                $"            costoPromedio" +
                $"        FROM(" +
                $"                SELECT itventa.articuloID," +
                $"                        itventa.bodegaID," +
                $"                        SUM(itventa.vrtotal) vrtotal," +
                $"                        SUM(itventa.cantidad) cantventa" +
                $"                FROM dbo.itart itventa INNER JOIN dbo.documento venta ON itventa.documentID = venta.id" +
                $"                        INNER JOIN dbo.tipodoc td ON venta.tipo = td.codigo" +
                $"                WHERE venta.fecha BETWEEN @fecha1 AND @fecha2" +
                $"                        AND venta.anulado = 0" +
                $"                        AND td.clasedoc IN('FV', 'FP', 'DV', 'DP')" +
                $"                GROUP BY itventa.articuloID" +
                $"                        , itventa.bodegaID" +
                $"            ) venta FULL JOIN" +
                $"                (SELECT articuloID" +
                $"                        , bodegaID" +
                $"                        , saldocant" +
                $"                        , saldocosto" +
                $"                        , fn.costoPromedio" +
                $"                FROM dbo.fnInventInventariosBaseRotacion(@fecha1, @fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) fn" +
                $"               ) s ON venta.articuloID = s.articuloID AND venta.bodegaID = s.bodegaID" +
                $"        ) t" +
                $"            OUTER APPLY(" +
                $"            select top 1 d.fecha as FechaUltimoTraslado" +
                $"            from dbo.documento d inner" +
                $"            join itart it on it.documentID = d.id inner" +
                $"            join tipodoc td on td.codigo = d.tipo" +
                $"            where td.clasedoc = 'NT'" +
                $"                    and it.articuloID = t.articuloID" +
                $"                    and it.bodegaID = t.bodegaID" +
                $"                    and d.fecha <= @fecha2" +
                $"                    order by d.fecha desc" +
                $"                )UltimoTraslado" +
                $"            OUTER APPLY(" +
                $"            select top 1 d.fecha as FechaUltimaVENTA" +
                $"            from dbo.documento d inner" +
                $"            join itart it on it.documentID = d.id inner" +
                $"            join tipodoc td on td.codigo = d.tipo" +
                $"            where td.clasedoc in ('FV', 'FP')" +
                $"                    and it.articuloID = t.articuloID" +
                $"                    and it.bodegaID = t.bodegaID" +
                $"                    and d.fecha <= @fecha2" +
                $"                    order by d.fecha desc" +
                $"                )UltimaCompra" +
                $"            inner join dbo.bodega b on b.codigo = t.bodegaID" +
                $"            inner join articulo a on t.articuloID = a.codigo" +
                $"            inner join dbo.grupo as gr on a.grupoID = gr.codigo" +
                $"            inner join dbo.linea as ln on a.lineaID = ln.codigo" +
                $"            inner join dbo.marca as ma on a.marcaID = ma.codigo" +
                $"            left join(select SUM(it.cantidad) as CantidadInicial" +
                $"							  ,it.articuloID" +
                $"							  ,it.bodegaID" +
                $"                       FROM dbo.itinvent it" +
                $"                                INNER JOIN dbo.documento venta ON it.documentID = venta.id" +
                $"                                INNER JOIN dbo.tipodoc td ON venta.tipo = td.codigo" +
                $"                            WHERE venta.fecha < @fecha1" +
                $"                                AND venta.anulado = 0" +
                $"                                GROUP BY" +
                $"                                it.articuloID,it.bodegaID" +
                $"						)salini on salini.articuloID = t.articuloID and t.bodegaID = salini.bodegaID" +
                $"            LEFT JOIN(SELECT t.articuloID, t.proveedorID, t.fechadesde" +
                $"                        FROM (" +
                $"                            SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
                $"						articuloID, " +
                $"							proveedorID," +
                $"							fechadesde" +
                $"                            from arthistocompra lc" +
                $"                            WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta) T" +
                $"                          where T.rnum = 1 ) lc ON lc.articuloID = t.articuloID" +
                $"            left join dbo.tercero as ter on ter.id = lc.proveedorID" +
                $"            where a.inactivo = 0" +
                $"			)fin where fin.[Nombre Bodega] = '{sala}' order by [Dias sin Venta] desc";
            return dataload.sqlconsulta(sql);
        }

        internal DataSet Mventasgrupo(string fechai, string fechaf, string parametro)
        {
            sql = "select grupoID,g.nombre, d.ccostoId,c.nombre, " +
                "                                cast(sum(i.cantidad) as float) cantidad,cast(sum(i.vrcostototal) as float)Costo" +
                "                                       from itart i inner join documento d on i.documentID=d.id" +
                "   inner join articulo a on a.codigo=i.articuloID" +
                "   inner join tipodoc td on td.codigo=d.tipo" +
                "   inner join grupo g on g.codigo=a.grupoID" +
                "   inner join ccosto c on c.codigo=d.ccostoID" +
                "                                           where " +
                "                                               fecha between  '" + fechai + "' and '" + fechaf + "'" +
                "                                                and td.clasedoc in (" + parametro + ")" +
                "                                               -- and grupoID = '00000357'" +
                "                                              --and d.ccostoId = '000002'" +
                "                                               AND d.anulado = 0" +
                "                                               group by grupoID,g.nombre,d.ccostoId ,c.nombre " +
                "                                               order by g.nombre ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventa13total(string fecha)
        {
            sql = "SELECT   format(Sum(do.vrsubtotal)," +
                " '$ #,###.##') AS Total_Ventas," +
                " COUNT(vrsubtotal) AS Total_Facturas" +
                " FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo " +
                " WHERE fecha='" + fecha + "' " +
                " AND td.clasedoc in('FP','FV')" +
                "  AND do.ccostoID = '000002'" +
                "  and do.anulado=0 ";

            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventa16total(string fecha)
        {
            sql = "SELECT   format(Sum(do.vrsubtotal)," +
                " '$ #,###.##') AS Total_Ventas," +
                " COUNT(vrsubtotal) AS Total_Facturas" +
                " FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo " +
                " WHERE fecha='" + fecha + "' " +
                " AND td.clasedoc in('FP','FV')" +
                "  AND do.ccostoID = '000001'" +
                "  and do.anulado=0 ";

            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaversatotal(string fecha)
        {
            sql = "SELECT format(Sum(do.vrsubtotal), '$ #,###.##') AS Total_Ventas," +
                "COUNT(vrsubtotal) AS Total_Facturas FROM  dbo.documento AS do " +
                "INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo " +
                "WHERE fecha='" + fecha + "'" +
                "  AND td.clasedoc in('FP','FV')" +
                "  AND do.ccostoID = '000004' " +
                " and do.anulado=0 ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaciudadelatotal(string fecha)
        {
            sql = "SELECT format(Sum(do.vrsubtotal), '$ #,###.##') AS Total_Ventas, " +
                "COUNT(vrsubtotal) AS Total_Facturas " +
                " FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE fecha='" + fecha + "' " +
                " AND td.clasedoc in('FP','FV')  AND do.ccostoID = '000005'  and do.anulado=0 ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventa(string fei, string fef, string ccosto)
        {
            sql = $"    declare @fecha1 as date='{fei}' " +
                $"      declare @fecha2 as date = '{fef}'" +
                $"   Declare @devoluciones as float = (SELECT      Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                $"                                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                $"                                        WHERE fecha between @fecha1 and @fecha2" +
                $"                                               AND td.clasedoc in('DP', 'DV')" +
                $"                                                 AND do.ccostoID = '{ccosto}' " +
                $"                                                  and do.anulado = 0)" +
                $" select ahorasi.DIA" +
                $",format(SUM(ahorasi.VALOR - ahorasi.DEV), '$ ###,###.##')Valor" +
                $" ,sum(ahorasi.Facturas + ahorasi.CantDev)Documentos" +
                $"       FROM(SELEct final.VALOR" +
                $"                , (SELECT      Sum(do.vrsubtotal) AS V_ANTES_IVA" +
                $"                                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                $"                                           WHERE fecha between @fecha1 and @fecha2" +
                $"                                                AND td.clasedoc in('DP', 'DV')" +
                $"                                                 AND do.ccostoID = '{ccosto}'" +
                $"                                                  and do.anulado = 0)DEV" +
                $"               ,(SELECT      count(do.vrsubtotal) AS cantidad" +
                $"                                       FROM dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                $"                                           WHERE fecha between @fecha1 and @fecha2" +
                $"                                                AND td.clasedoc in('DP', 'DV')" +
                $"                                                 AND do.ccostoID = '{ccosto}'" +
                $"                                                 and do.anulado = 0)CantDev" +
                $"                ,final.Facturas" +
                $"                ,final.DIA" +
                $"                        FROM" +
                $"                                 (SELECT  TOP(100) PERCENT DATEPART(DD, do.logfecreo) AS DIA" +
                $"                                        , Sum(do.vrsubtotal) AS VALOR" +
                $"                                        , COUNT(vrsubtotal) AS Facturas" +
                $"                                                FROM dbo.documento AS do" +
                $"                                               INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo" +
                $"                                               WHERE(do.fecha BETWEEN @fecha1 AND @fecha2)" +
                $"                                                  AND td.clasedoc in('FP', 'FV')" +
                $"                                                  AND do.ccostoID = '{ccosto}'" +
                $"                                                  and do.anulado = 0 GROUP BY DATEPART(DD, do.logfecreo) order by DIA)final)ahorasi" +
                $"                                                     group by ahorasi.Facturas,ahorasi.DIA,ahorasi.CantDev order by ahorasi.DIA";
            return dataload.sqlconsulta(sql);
        }

        //espacio para la 14 distribuciones
        internal DataSet MClista_la14aux(string fei, string fef, string fcuenta)
        {
            string H = ".,";
            sql = "SELECT * FROM (SELECT COD_CUENTA as" +
                " CUENTA,I.FCH_DOCUMENTO,TIPO_DOCUMENTO(ID_TIPO_DOCUMENTO)" +
                " TIPO, NUM_DOCUMENTO as NO_DOCU,'$'||TO_CHAR(VALOR,'999G999G999G999G999','NLS_NUMERIC_CHARACTERS = " + H + "') " +
                " VALOR, NIT_TERCERO(I.ID_TERCERO) TERCERO,I.OBSER AS OBSERVACIONES_DOCU FROM CO_CUENTAS C,CO_DOCUMENTOS D," +
                " CO_DOCUMENTO_ITEMS I WHERE D.ID_DOCUMENTO = I.ID_DOCUMENTO  AND C.ID_CUENTA" +
                "    = I.ID_CUENTA  AND COD_CUENTA LIKE('" + fcuenta + "'||'%')" +
                "  AND I.FCH_DOCUMENTO BETWEEN TO_DATE('" + fei + "','YYYY-MM-DD')" +
                " AND TO_DATE('" + fef + "','YYYY-MM-DD')" +
                " AND C.ID_SISTEMA = '1'ORDER BY COD_CUENTA,I.FCH_DOCUMENTO)";
            return dataload.orala14consulta(sql);
        }
        internal DataSet MClista_la14VENTAS(string fei, string fef)
        {
            // string H = ".,";
            sql = "SELECT  '$'||TO_CHAR(Sum(VENT_TOT_SIN_IVA),'999G999G999G999G999','NLS_NUMERIC_CHARACTERS =.,')  VALOR ,VENDEDOR FROM V_VENTAS  WHERE FECHA BETWEEN TO_DATE('" + fei + "','YYYY-MM-DD') AND TO_DATE('" + fef + "','YYYY-MM-DD') GROUP BY VENDEDOR  ORDER BY VALOR DESC";
            return dataload.orala14consulta(sql);
        }
        internal DataSet MVentas_la14VENTAS(string fei, string fef)
        {
            // string H = ".,";
            sql = "SELECT " +
                " '$' || TO_CHAR(Sum(VENT_TOT_SIN_IVA), '999G999G999G999G999', 'NLS_NUMERIC_CHARACTERS =.,')  VALOR ,GRUPO,V_VENTAS.PRODUCTO, " +
                " VENDEDOR,CANTIDAD,VENT_TOT_SIN_IVA," +
                "        VENT_TOT_CON_IVA,CLIENTE FROM V_VENTAS  WHERE FECHA BETWEEN TO_DATE('" + fei + "','YYYY-MM-DD') AND TO_DATE('" + fef + "','YYYY-MM-DD') GROUP BY VENDEDOR,GRUPO,CANTIDAD,V_VENTAS.PRODUCTO,VENT_TOT_SIN_IVA," +
                "        VENT_TOT_CON_IVA,CLIENTE ORDER BY VALOR DESC";
            return dataload.orala14consulta(sql);
        }

        //espacio para inventarios
        internal int mabreconteo(string codigo)
        {
            sql = "update invenfis set protejido=0 where id='" + codigo + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mupdate_mant_valores(string pid, string pvalormano, string pvalorRepuesto, string pnumeroexterno, string pbd)
        {
            sql = "CALL P_UPDATE_MANT_FISCAL('" + pid + "','" + pvalormano + "','" + pvalorRepuesto + "','" + pnumeroexterno + "')";
            return dataload.MysqlProcedimiento(sql, pbd);
        }
        internal int mlimpiaconteo(string codigo)
        {
            sql = "delete invenfisdet where invenfisID='" + codigo + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mconteo_revisado(string zona_name)
        {
            sql = "update invenfis set estado='ConteoRevisado' where nombre='" + zona_name + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal DataSet mlista_Dif_Items_conteos(String zona)
        {
            sql = " select" +
                "                  final.articuloID,final.detalle,FORMAT(Cant_Conteo1,'##,###.##')AS CANT_CONTEO1, " +
                "                       FORMAT(Cant_Conteo2,'##,###.##')AS CANT_CONTEO2,FORMAT(dif,'##,###.##')AS DIF " +
                "                             from" +
                "                                      (SELECT t.articuloID, t.detalle, sum(t.cantidad1) as Cant_Conteo1, sum(t.cantidad2) as Cant_Conteo2, ABS(SUM(t.cantidad1 - t.cantidad2)) AS dif" +
                "                                                 FROM(" +
                "                                                        SELECT  invenfisdet.articuloID, articulo.detalle, invenfisdet.cantidad AS cantidad1, CAST(0 as numeric(12, 4)) as cantidad2" +
                "                                                        FROM invenfisdet" +
                "                                                                inner join invenfis on invenfisdet.invenfisID = invenfis.id" +
                "                                                                inner join articulo on articulo.codigo = invenfisdet.articuloID" +
                "                                                        WHERE invenfis.nombre = '" + zona + "' and invenfis.grupoinvenfisID = 31" +
                "                                                                  UNION ALL" +
                "                                                        SELECT invenfisdet.articuloID, articulo.detalle, CAST(0 as numeric(12, 4)) AS cantidad1, invenfisdet.cantidad as cantidad2" +
                "                                                        FROM invenfisdet" +
                "                                                                inner join invenfis on invenfisdet.invenfisID = invenfis.id" +
                "                                                                 inner join articulo on articulo.codigo = invenfisdet.articuloID" +
                "                                                        WHERE invenfis.nombre = '" + zona + "' and invenfis.grupoinvenfisID = 32) t" +
                "                                        group by t.articuloID, t.detalle" +
                "                                        )final where dif != 0" +
                "                        group by final.articuloID,Cant_Conteo1,Cant_Conteo2,dif,detalle";
            return dataload.sqlconsulta(sql);
        }

        internal int mcierraconteo(string codigo2)
        {
            sql = "update invenfis set protejido=1 where id='" + codigo2 + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal DataSet mlista_dif_Conteos()
        {
            sql = "declare @p_id varchar(10)" +
                  "                  declare @p_nombre varchar(50)" +
                  "               IF OBJECT_ID('tempdb..#tmpX') IS NOT NULL" +
                  "                 DROP TABLE #tmpX " +
                  "                 create table #tmpX(id1 nvarchar(100), dif numeric(15,4)) " +
                  "                 declare nombreinvenfis cursor" +
                  "                 for     select invenfis.id, invenfis.nombre from invenfis where grupoinvenfisID = 31" +
                  "                 open nombreinvenfis" +
                  "                 fetch next from nombreinvenfis into @p_id, @p_nombre while (@@FETCH_STATUS = 0) " +
                  "                 begin" +
                  "                        insert into #tmpX		" +
                  "                           SELECT  t2.id1,  ABS(SUM(t2.dif)) AS dif " +

                  "                            FROM(" +
                  "                        SELECT t.id1,  ABS(SUM(t.cantidad1 - t.cantidad2)) AS dif" +
                  "                                                 FROM(" +
                  "                                                        SELECT invenfis.nombre as id1, invenfisdet.articuloID, invenfisdet.cantidad AS cantidad1, CAST(0 as numeric(12, 4)) as cantidad2" +
                  "                                                        FROM invenfisdet inner join invenfis on invenfisdet.invenfisID = invenfis.id" +
                  "                                                        WHERE invenfis.nombre = @p_nombre and grupoinvenfisID = 31  AND invenfis.protejido = 1 and invenfis.estado = 'Conteo Cerrado'" +
                  "                                                                  UNION ALL" +
                  "                                                        SELECT invenfis.nombre as id1, invenfisdet.articuloID, CAST(0 as numeric(12, 4)) AS cantidad1, invenfisdet.cantidad as cantidad2" +
                  "                                                        FROM invenfisdet inner join invenfis on invenfisdet.invenfisID = invenfis.id" +
                  "                                                        WHERE invenfis.nombre = @p_nombre AND grupoinvenfisID = 32  AND invenfis.protejido = 1 and invenfis.estado = 'Conteo Cerrado') t" +
                  "                                                group by t.id1,t.articuloID) t2" +
                  "                                                  GROUP BY t2.id1 " +
                  "                                               fetch next from nombreinvenfis into @p_id,@p_nombre" +
                  "                         end" +
                  "                 select id1 as [Nombre Conteo],FORMAT(dif, '##,###.##') as Diferencias  from #tmpX " +
                  "                 close nombreinvenfis DEALLOCATE nombreinvenfis";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mtotalconteo1()
        {
            sql = "select count(*) from invenfis where grupoinvenfisID=31";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mconteosabiertos()
        {
            sql = "select id as ID,   " +
                "  nombre as [Nombre Conteo],CASE invenfis.grupoinvenfisID WHEN '31'  " +
                "     THEN 'CONTEO 1'  " +
                "     WHEN '32'  " +
                "    THEN 'CONTEO 2'    " +
                "    ELSE 'NO TENER EN CUENTA'  " +
                "   END AS CONTEO from invenfis where protejido=0   ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mconteoscerrados()
        {
            sql = "select id as ID,   " +
                "  nombre as [Nombre Conteo],CASE invenfis.grupoinvenfisID WHEN '31'  " +
                "     THEN 'CONTEO 1'  " +
                "     WHEN '32'  " +
                "    THEN 'CONTEO 2'    " +
                "    ELSE 'NO TENER EN CUENTA'  " +
                "   END AS CONTEO from invenfis where protejido=1 ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mtotalconteo2()
        {
            sql = "select count(*) from invenfis where grupoinvenfisID=32";
            return dataload.sqlconsulta(sql);
        }
        //espacio para cumpleñeros
        internal int MClog_cumple(string pnombre, string ptel, string psms, string pusuario, string db)
        {
            sql = "CALL PCREA_LOG_CUMPLE('" + pnombre + "','" + ptel + "','" + psms + "','" + pusuario + "')";
            return dataload.MysqlProcedimiento(sql, db);
        }

        internal DataSet MListalog_cumple(string db)
        {
            sql = "CALL P_LISTA_ENVIOS()";
            return dataload.MySqlQuery(sql, db);
        }
        internal DataSet MListaprecio(string barra, string lista)
        {
            sql = " SELECT " +
                "    r.codigo, " +
                "    r.detalle," +
                "	r.codbarra," +
                "    r.valormiva," +
                "    r.peso," +
                "    r.descuento," +
                "    coalesce(pres.nombrepres, ' ') nombrepres," +
                "    r.nombrelinea," +
                "    r.nombregrupo," +
                "    r.nombremarca," +
                "    r.dtocomovalor," +
                "	r.nombre," +
                "	(SELECT CONVERT(datetime, GETDATE()))ahora," +
                "	r.fdesde," +
                "	r.fhasta" +
                "        from(" +
                "            SELECT a.codigo," +
                "                 a.detalle," +
                "                 cd.codbarra," +
                "                 cast(valormiva as int) as valormiva," +
                "                 cast(a.peso as int) as peso," +
                "                 coalesce(cast(condiprom.vrveneficio as int), 0.0) as descuento," +
                "                 cd.presentacionID," +
                "                 l.nombre as nombrelinea," +
                "                 g.nombre as nombregrupo," +
                "                 m.nombre as nombremarca," +
                "                 condiprom.dtocomovalor," +
                "                 promo.nombre," +
                "                 promo.fdesde," +
                "                 promo.fhasta" +
                "                        from articulo a with(nolock)" +
                "                          left join dbo.artspromo aprom with(nolock)  ON a.codigo = aprom.articuloID" +
                "                          left join dbo.condicionpromo condiprom with(nolock) ON aprom.promocionID = condiprom.promocionID" +
                "                          left JOIN dbo.promocion promo with(nolock) ON condiprom.promocionID = promo.id" +
                "                          left join codbar cd with(nolock) on cd.articuloID = a.codigo" +
                "                          LEFT JOIN marca m with(nolock) on m.codigo = a.marcaID" +
                "                          LEFT JOIN linea l with(nolock) on l.codigo = a.lineaID" +
                "                          LEFT JOIN grupo g with(nolock) on g.codigo = a.grupoID" +
                "                          left join precio pc with(nolock) on pc.articuloID = a.codigo and(pc.presentacionID = cd.presentacionID or(pc.presentacionID is null and cd.presentacionID is null))" +
                "                          where cd.CODBARRA = '" + barra + "'" +
                "                            and pc.listprecioID = '" + lista + "'" +
                "                         and inactivo = 0 " +
               
                "                         )r left join dbo.presentacion pres with(nolock) on pres.id = r.presentacionID";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MNewListaprecio(string barra, string lista)
        {
            sql = "SET NOCOUNT ON;" +
                "DECLARE @CodigoBarra VARCHAR(50) = '"+barra+"';" +
                " DECLARE @CodigoArticulo VARCHAR(50), @LineaID VARCHAR(10), @MarcaID VARCHAR(10), @GrupoID VARCHAR(10);" +
                "            DECLARE @SaldoCantidad INT;" +

                " SELECT DISTINCT" +
                "    r.CodigoArticulo, " +
                "    r.detalle," +
                "    r.valormiva," +
                "    r.peso," +
                "    r.marcaID," +
                "    r.lineaID," +
                "    r.grupoID," +
                "    COALESCE(pres.nombrepres, ' ') AS nombrepres" +
                " INTO #ArticuloTemplcd " +
                "FROM(" +
                "    SELECT a.codigo AS CodigoArticulo," +
                "           a.detalle," +
                "           a.marcaID," +
                "           a.lineaID," +
                "           a.grupoID," +
                "           CAST(pc.valormiva AS INT) AS valormiva," +
                "           CAST(a.peso AS INT) AS peso," +
                "            cd.presentacionID" +
                "    FROM articulo a WITH(NOLOCK)" +
                "    LEFT JOIN codbar cd WITH(NOLOCK) ON cd.articuloID = a.codigo" +
                "    LEFT JOIN precio pc WITH(NOLOCK) ON pc.articuloID = a.codigo" +
                "          AND(pc.presentacionID = cd.presentacionID" +
                "          OR(pc.presentacionID IS NULL AND cd.presentacionID IS NULL))" +
                "    WHERE cd.CODBARRA = @CodigoBarra" +
                "          AND a.inactivo = 0" +
                " ) r " +
                "LEFT JOIN dbo.presentacion pres WITH(NOLOCK) ON pres.id = r.presentacionID;" +

                "IF NOT EXISTS(SELECT 1 FROM #ArticuloTemplcd) " +
                "BEGIN" +
                "    PRINT 'No se encontró un artículo con ese código de barras';" +
                "            RETURN;" +
                "            END" +
          
                "            SELECT" +
                "    @CodigoArticulo = CodigoArticulo," +
                "    @LineaID = LineaID," +
                "    @MarcaID = MarcaID," +
                "    @GrupoID = GrupoID " +
                "FROM #ArticuloTemplcd; " +
            
                "SELECT @SaldoCantidad = CAST(saldocant AS INT) " +
                "FROM dbo.fnInventInventariosBaseInventariosConBodegas(GETDATE(), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) fn " +
                "WHERE articuloID = @CodigoArticulo AND bodegaID = '"+lista+"';" +
              
                "            IF EXISTS(" +
                "            SELECT 1" +
                "                FROM Promocion p" +
                "                INNER JOIN condicionpromo cp ON p.id = cp.promocionID" +
                "                LEFT JOIN artspromo ap ON p.Id = ap.promocionID" +
                "                WHERE" +
                "                    (SELECT CONVERT(date, GETDATE())) BETWEEN p.fdesde AND p.fhasta" +
                "                    AND(SELECT CONVERT(time, GETDATE())) <= p.hhasta " +
                "                   and(select CONVERT(time, GETDATE())) >= p.hdesde" +
                "                    AND p.activa = 1" +
                "                   AND cp.excluir != 1" +
                "                    AND(" +
                "                        ap.articuloID = @CodigoArticulo" +
                "                        OR(ap.LineaID = @LineaID AND ap.MarcaID IS NULL AND ap.GrupoID IS NULL)" +
                "                        OR(ap.MarcaID = @MarcaID AND ap.LineaID IS NULL AND ap.GrupoID IS NULL)" +
                "                        OR(ap.GrupoID = @GrupoID AND ap.LineaID IS NULL AND ap.MarcaID IS NULL)" +
                "                        OR(ap.MarcaID = @MarcaID AND ap.GrupoID = @GrupoID AND ap.LineaID IS NULL)" +
                "                       OR(ap.LineaID = @LineaID AND ap.MarcaID = @MarcaID AND ap.GrupoID IS NULL)" +
                "                       OR(ap.LineaID = @LineaID AND ap.GrupoID = @GrupoID AND ap.MarcaID IS NULL)" +
                "                        OR(ap.LineaID = @LineaID AND ap.MarcaID = @MarcaID AND ap.GrupoID = @GrupoID)" +
                "                 )      )" +
                " BEGIN" +
        
                "    SELECT DISTINCT" +
                "        at.CodigoArticulo," +
                "        at.detalle," +
                "        at.valormiva AS PrecioOriginal," +
          
                "        CASE" +
                "            WHEN cp.dtocomovalor = 1 THEN cast(at.valormiva -cp.vrveneficio as int) " +
                "            WHEN cp.dtocomovalor = 0 THEN cast(at.valormiva -(at.valormiva * (cp.vrveneficio / 100)) as int) " +
                "            ELSE at.valormiva " +
                "        END AS PrecioFinal," +
                "        at.peso," +
                "        at.marcaID," +
                "        at.lineaID," +
                "        at.grupoID," +
                "        at.nombrepres," +
                "        @SaldoCantidad AS saldocant, " +
                "        p.Nombre AS NombrePromocion," +
                "        ap.grupoID AS GrupoPromocion," +
                "        ap.marcaID AS MarcaPromocion," +
                "        p.tipobeneficio," +
                "        cp.dtocomovalor," +
                "        cp.montovalor," +
                "        cp.vrveneficio," +
                "        p.fdesde," +
                "        p.fhasta" +
                "    FROM #ArticuloTemplcd at" +
                "    INNER JOIN Promocion p ON 1 = 1" +
                "    INNER JOIN condicionpromo cp ON p.id = cp.promocionID" +
                "    LEFT JOIN artspromo ap ON p.Id = ap.promocionID" +
                "    WHERE" +
                "        (SELECT CONVERT(date, GETDATE())) BETWEEN p.fdesde AND p.fhasta" +
                "        AND(SELECT CONVERT(time, GETDATE())) <= p.hhasta " +
                "       and(select CONVERT(time, GETDATE())) >= p.hdesde " +
                "        AND p.activa = 1" +
                "        AND cp.excluir != 1" +
                "        AND(" +
                "            ap.articuloID = @CodigoArticulo" +
                "            OR(ap.LineaID = @LineaID AND ap.MarcaID IS NULL AND ap.GrupoID IS NULL)" +
                "            OR(ap.MarcaID = @MarcaID AND ap.LineaID IS NULL AND ap.GrupoID IS NULL)" +
                "            OR(ap.GrupoID = @GrupoID AND ap.LineaID IS NULL AND ap.MarcaID IS NULL)" +
                "            OR(ap.MarcaID = @MarcaID AND ap.GrupoID = @GrupoID AND ap.LineaID IS NULL)" +
                "            OR(ap.LineaID = @LineaID AND ap.MarcaID = @MarcaID AND ap.GrupoID IS NULL)" +
                "            OR(ap.LineaID = @LineaID AND ap.GrupoID = @GrupoID AND ap.MarcaID IS NULL)" +
                "            OR(ap.LineaID = @LineaID AND ap.MarcaID = @MarcaID AND ap.GrupoID = @GrupoID)" +
                "        );" +
                "            END" +
                "            ELSE " +
                "BEGIN" +
             
                "    SELECT *, @SaldoCantidad AS saldocant FROM #ArticuloTemplcd; " +
                " END " +
              
                "DROP TABLE #ArticuloTemplcd;";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MListaprecioOferta(string barra, string lista)
        {
            sql = " SELECT " +
                "    r.codigo, " +
                "    r.detalle," +
                "	r.codbarra," +
                "    r.valormiva," +
                "    r.peso," +
                "    r.descuento," +
                "    coalesce(pres.nombrepres, ' ') nombrepres," +
                "    r.nombrelinea," +
                "    r.nombregrupo," +
                "    r.nombremarca," +
                "    r.dtocomovalor," +
                "	r.nombre," +
                "	(SELECT CONVERT(datetime, GETDATE()))ahora," +
                "	r.fdesde," +
                "	r.fhasta" +
                "        from(" +
                "            SELECT a.codigo," +
                "                 a.detalle," +
                "                 cd.codbarra," +
                "                 cast(valormiva as int) as valormiva," +
                "                 cast(a.peso as int) as peso," +
                "                 coalesce(cast(condiprom.vrveneficio as int), 0.0) as descuento," +
                "                 cd.presentacionID," +
                "                 l.nombre as nombrelinea," +
                "                 g.nombre as nombregrupo," +
                "                 m.nombre as nombremarca," +
                "                 condiprom.dtocomovalor," +
                "                 promo.nombre," +
                "                 promo.fdesde," +
                "                 promo.fhasta" +
                "                        from articulo a with(nolock)" +
                "                          left join dbo.artspromo aprom with(nolock)  ON a.codigo = aprom.articuloID" +
                "                          left join dbo.condicionpromo condiprom with(nolock) ON aprom.promocionID = condiprom.promocionID" +
                "                          left JOIN dbo.promocion promo with(nolock) ON condiprom.promocionID = promo.id" +
                "                          left join codbar cd with(nolock) on cd.articuloID = a.codigo" +
                "                          LEFT JOIN marca m with(nolock) on m.codigo = a.marcaID" +
                "                          LEFT JOIN linea l with(nolock) on l.codigo = a.lineaID" +
                "                          LEFT JOIN grupo g with(nolock) on g.codigo = a.grupoID" +
                "                          left join precio pc with(nolock) on pc.articuloID = a.codigo and(pc.presentacionID = cd.presentacionID or(pc.presentacionID is null and cd.presentacionID is null))" +
                "                          where cd.CODBARRA = '" + barra + "'" +
                "                            and pc.listprecioID = '" + lista + "'" +
                "                         and inactivo = 0 " +
                "                         and condiprom.excluir!=1  " +
                "                         )r left join dbo.presentacion pres with(nolock) on pres.id = r.presentacionID" +
                "                       WHERE (SELECT CONVERT(datetime, GETDATE()))  between r.fdesde and r.fhasta";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MListasaldo(string articulo, string bodega)
        {
            sql = "SELECT articuloID ," +
            "                                        cast(saldocant as int) as saldocant" +
                "                                FROM dbo.fnInventInventariosBaseInventariosConBodegas(getdate(), NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) fn where articuloID = '" + articulo + "' and bodegaID = '" + bodega + "'; ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MListadescuentoarticuloid(string plu)
        {
            sql = "SELECT ap.articuloID,cast(condip.vrveneficio as int)as vrveneficio , condip.dtocomovalor" +
                "                     from artspromo ap inner" +
                "                     join promocion p on ap.promocionID = p.id" +
                " inner" +
                "                    join dbo.condicionpromo condip on ap.promocionID = condip.promocionID" +
                "                     where (" +
                "                         SELECT CONVERT(date, GETDATE())) <= p.fhasta" +
                "                         AND(SELECT CONVERT(date, GETDATE())) >= p.fdesde  and activa = 1" +
                "                         and(select CONVERT(time, GETDATE())) <= p.hhasta" +
                "                         and(select CONVERT(time, GETDATE())) >= p.hdesde" +
                "                         and ap.articuloID = '" + plu + "'" +
                "                         and condip.excluir!=1";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MListadescuentolinea(string linea)
        {
            sql = "SELECT ap.articuloID,cast(condip.vrveneficio as int)as vrveneficio " +
                " from artspromo ap inner " +
                " join promocion p on ap.promocionID = p.id inner" +
                " join dbo.condicionpromo condip on ap.promocionID = condip.promocionID" +
                " INNER JOIN linea l on l.codigo = ap.lineaID " +
                " where(" +
                "       SELECT CONVERT(date, GETDATE())) <= p.fhasta" +
                "                         AND(SELECT CONVERT(date, GETDATE())) >= p.fdesde  and activa = 1" +
                "                         and(select CONVERT(time, GETDATE())) <= p.hhasta" +
                "                         and(select CONVERT(time, GETDATE())) >= p.hdesde" +
                "        and l.nombre = '" + linea + "'" +
                "        and condip.excluir != 1" +
                "        ORDER BY  ap.articuloID asc";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MListadescuentogrupo(string grupo)
        {
            sql = "SELECT ap.articuloID,cast(condip.vrveneficio as int)as vrveneficio " +
                " from artspromo ap inner " +
                " join promocion p on ap.promocionID = p.id inner" +
                " join dbo.condicionpromo condip on ap.promocionID = condip.promocionID" +
                " INNER JOIN grupo g on g.codigo = ap.grupoID " +
                " where(" +
               "          SELECT CONVERT(date, GETDATE())) <= p.fhasta" +
                "                         AND(SELECT CONVERT(date, GETDATE())) >= p.fdesde  and activa = 1" +
                "                         and(select CONVERT(time, GETDATE())) <= p.hhasta" +
                "                         and(select CONVERT(time, GETDATE())) >= p.hdesde" +
                "        and g.nombre = '" + grupo + "'" +
                "        and condip.excluir != 1 " +
                "        ORDER BY  ap.articuloID asc";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MListadescuentomarca(string marca)
        {
            sql = "SELECT ap.articuloID,cast(condip.vrveneficio as int)as vrveneficio " +
                " from artspromo ap inner " +
                " join promocion p on ap.promocionID = p.id inner" +
                " join dbo.condicionpromo condip on ap.promocionID = condip.promocionID" +
                " INNER JOIN marca m on m.codigo = ap.marcaID " +
                " where(" +
                "       SELECT CONVERT(date, GETDATE())) <= p.fhasta" +
                "                         AND(SELECT CONVERT(date, GETDATE())) >= p.fdesde  and activa = 1" +
                "                         and(select CONVERT(time, GETDATE())) <= p.hhasta" +
                "                         and(select CONVERT(time, GETDATE())) >= p.hdesde" +
                "        and m.nombre = '" + marca + "'" +
                "        and condip.excluir != 1" +
                "        ORDER BY  ap.articuloID asc";
            return dataload.sqlconsulta(sql);
        }
        internal int Mdeleteitems_kardex(string id, string db)
        {
            sql = "call PDELETE_ITEM_KARDEX('" + id + "')";
            return dataload.MysqlProcedimiento(sql, db);
        }
        internal DataSet mlistacumpleañeros()
        {
            sql = "SELECT T.claseter as TipoTer,T.id,T.nombre as Nombre,T.telefono FROM dbo.tercero T where MONTH(T.nacio)= Month(getdate()) and day(T.nacio)= day(getdate())";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mlistadatoasistencia(String dateini, String datefin)
        {
            sql = "SELECT Checkinout.Userid as Id," +
                " Format([CheckTime], 'yyyy-mm-dd') as Dia_Hora,  format([Checkinout.CheckTime],'hh:nn:ss')as Hora, " +
                    "Userinfo.Name as Empleado," +
                    " Dept.DeptName as Departamento," +
                    " FingerClient.ClientName as Biometrico, " +
                    "Status.StatusText as Tipo " +
                    "FROM(((Checkinout LEFT JOIN Userinfo ON Checkinout.Userid = Userinfo.Userid) " +
                    "LEFT JOIN Dept ON Userinfo.Deptid = Dept.Deptid)" +
                    " LEFT JOIN FingerClient ON Checkinout.Sensorid = FingerClient.ClientNumber)" +
                    " LEFT JOIN Status ON Checkinout.CheckType = Status.StatusChar " +
                "WHERE(((Format([CheckTime], 'yyyy-mm-dd')) Between '" + dateini + "' And '" + datefin + "'))";
            return dataload.accesconsulta(sql);
        }
        //espacio para cumpleñeros

        internal int Mactivaconteos2()
        {
            sql = "update invenfis set protejido=0 where grupoinvenfisID=32";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mcierraconteos2()
        {
            sql = "update invenfis set protejido=1 where grupoinvenfisID=32";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mcierraconteos1()
        {
            sql = "update invenfis set protejido=1 where grupoinvenfisID=31";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mactivaconteos1()
        {
            sql = "update invenfis set protejido=0 where grupoinvenfisID=31";
            return dataload.sqlProcedimiento(sql);
        }

        //cierra espacio modulo inventario
        internal DataSet listadoventaXarticulocliente(string fei, string fef, string articuloid)
        {
            sql = "SELECT  Top(100) tercero.nombrecompleto as NOMBRE_COMPLETO,documento.terceroID1 AS CC,tercero.telefono AS TEL1,tercero.movil as MOVIL,SUM(CAST(itart.cantidad AS float)) AS cantidad, SUM(itart.vrtotal) AS valor_total  FROM itart INNER JOIN articulo ON itart.articuloID = articulo.codigo  INNER JOIN documento ON itart.documentID = documento.id  INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo INNER JOIN tercero on tercero.id=documento.terceroID1  WHERE(documento.fecha BETWEEN '" + fei + "' AND '" + fef + "')   AND(tipodoc.clasedoc in ('FV', 'FP'))   AND(articulo.codigo = '" + articuloid + "')   GROUP BY documento.terceroID1,tercero.telefono,tercero.movil,tercero.nombrecompleto   ORDER BY cantidad DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaXarticulocajera(string fei, string fef, string articuloid)
        {
            sql = "SELECT " +
                "  articulo.detalle,documento.logusucreo, " +
                " SUM(CAST(itart.cantidad AS float)) AS cantidad, " +
                " SUM(itart.vrtotal) AS valor_total  " +
                " FROM itart INNER JOIN articulo ON itart.articuloID = articulo.codigo " +
                " INNER JOIN documento ON itart.documentID = documento.id " +
                " INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo " +
                " WHERE(documento.fecha BETWEEN '" + fei + "' AND '" + fef + "') " +
                " AND(tipodoc.clasedoc in ('FV', 'FP')) " +
                " AND(articulo.codigo = '" + articuloid + "')" +
                " GROUP BY documento.logusucreo,articulo.detalle " +
                " ORDER BY cantidad DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoTopVentas(string fei, string fef, string top)
        {
            sql = "SET NOCOUNT ON; " +
                "                declare @fecha1 as date = '" + fei + "'" +
                "                ,@fecha2 as date = '" + fef + "'" +
                "                select top(" + top + ") final.articuloID," +
                "	final.detalle," +
                "	FORMAT(final.cantidad, 'n', 'en-US')Cantidad," +
                "	Format(final.Ventas, 'C', 'EN-US')Ventas," +
                "	FORMAT(final.costo, 'C', 'EN-US')Costo," +
                "	FOrMAT(final.[Vr Utilidad], 'C', 'EN-US')[Vr Utilidad]," +
                "	SUM((final.[Vr Utilidad] / final.Ventas) * 100)[% Rent]," +
                "	cast(final.dev as decimal)Dev," +
                "	format(final.[vr Dev], 'C', 'EN-US')[Vr Dev]" +
                "            from(SELECT util.articuloID," +
                "                        util.detalle," +
                "                        util.cantidad," +
                "                        util.valores  Ventas," +
                "                        util.costo costo," +
                "                        SUM(util.valores - util.costo)[Vr Utilidad]," +
                "                        (util.dev)dev," +
                "                        util.[vr Dev]" +
                "                                    FROM(select  COALESCE(ventas.articuloID, s.articuloID) articuloID," +
                "                                    ventas.detalle," +
                "                                    round(sum(ventas.cantidad - coalesce(s.cantidad, 0)), 1)cantidad," +
                "                                    sum(ventas.valores - coalesce(s.valores, 0)) valores," +
                "                                    sum(ventas.costo - coalesce(s.costo, 0))costo," +
                "                                    round(coalesce(s.cantidad, 0), 2) as dev," +
                "                                    round(coalesce(sum(s.valores), 0), 1)[vr Dev]," +
                "                                    coalesce(SUM(s.costo), 0)[Vr CostoDev]" +
                "                                    FROM(select i.articuloID, a.detalle," +
                "            SUM(i.cantidad) cantidad," +
                "                                            sum(i.vrtotal)valores," +
                "                                            SUM(i.vrcostototal)costo" +
                "                                                from itart i" +
                "                                                inner" +
                "                                                join documento d on i.documentID = d.id" +
                "                                                inner" +
                "                                               join articulo a on a.codigo = i.articuloID" +
                "                                                inner" +
                "                                                join tipodoc td on td.codigo = d.tipo" +
                "                                                where d.fecha between @fecha1 and @fecha2" +
                "                                                        and td.clasedoc in ('FV', 'FP')" +
                "                                                        group by i.articuloID, a.detalle)ventas" +
                "                                                        left  JOIN" +
                "                                                                (select  i.articuloID, a.detalle," +
                "                                                                SUM(i.cantidad) cantidad," +
                "                                                                sum(i.vrtotal)valores," +
                "                                                                SUM(i.vrcostototal)costo" +
                "                                                                    from itart i" +
                "                                                                    inner" +
                "                                                                    join documento d on i.documentID = d.id" +
                "                                                                    inner" +
                "                                                                    join articulo a on a.codigo = i.articuloID" +
                "                                                                    inner" +
                "                                                                    join tipodoc td on td.codigo = d.tipo" +
                "                                                                    where d.fecha between @fecha1 and @fecha2" +
                "                                                                            and td.clasedoc in ('DV', 'DP')" +
                "                                                                            group by i.articuloID, a.detalle) s ON s.articuloID = ventas.articuloID" +
                "                                                                            group by ventas.articuloID, s.articuloID, ventas.detalle, ventas.cantidad, ventas.valores, ventas.costo, s.cantidad" +
                "                                                                        )util" +
                "                                                                            group by util.articuloID, util.detalle, util.cantidad, util.valores, util.costo, util.dev, util.[vr Dev])final" +
                "                                                                           group by final.articuloID, final.detalle,final.cantidad,final.Ventas,final.costo,final.[Vr Utilidad],final.[vr Dev],final.dev" +
                "                                                                            order by final.cantidad desc  ";
            return dataload.sqlconsulta(sql);
        } 
        internal DataSet ListadoVentasGrupo(string fei, string fef )//ventas por Grupo
        {
            sql = "SET NOCOUNT ON; " +
                "                                declare @fecha1 as date = '"+fei+"'" +
                "                                ,@fecha2 as date = '"+fef+"'" +
                "                         select final.grupoID," +
                "						 final.nombre," +
                "                	FORMAT(final.cantidad, 'n', 'en-US')Cantidad," +
                "                	Format(final.Ventas, 'C', 'EN-US')Ventas," +
                "                	FORMAT(final.costo, 'C', 'EN-US')Costo," +
                "                	FOrMAT(final.[Vr Utilidad], 'C', 'EN-US')[Vr Utilidad]," +
                "                	SUM((final.[Vr Utilidad] / final.Ventas) * 100)[% Rent]," +
                "                	cast(final.dev as decimal)Dev," +
                "                	format(final.[vr Dev], 'C', 'EN-US')[Vr Dev]" +
                "                            from(SELECT" +
                "                                        util.grupoID," +
                "                                        util.nombre," +
                "                                        util.cantidad," +
                "                                        util.valores  Ventas," +
                "                                        util.costo costo," +
                "                                        SUM(util.valores - util.costo)[Vr Utilidad]," +
                "                                        (util.dev)dev," +
                "                                        util.[vr Dev]" +
                "                                                    FROM" +
                "                                                    (select  COALESCE(ventas.grupoID, s.grupoID) grupoID," +
                "                                                    ventas.nombre," +
                "                                                    round(sum(ventas.cantidad - coalesce(s.cantidad, 0)), 1)cantidad," +
                "                                                    sum(ventas.valores - coalesce(s.valores, 0)) valores," +
                "                                                    sum(ventas.costo - coalesce(s.costo, 0))costo," +
                "                                                    round(coalesce(s.cantidad, 0), 2) as dev," +
                "                                                    round(coalesce(sum(s.valores), 0), 1)[vr Dev]," +
                "                                                    coalesce(SUM(s.costo), 0)[Vr CostoDev]" +
                "                                                    FROM(select a.grupoID, g.nombre," +
                "                                                        SUM(i.cantidad) cantidad," +
                "                                                            sum(i.vrtotal)valores," +
                "                                                            SUM(i.vrcostototal)costo" +
                "                                                                from itart i" +
                "                                                                inner" +
                "                                                                join documento d on i.documentID = d.id" +
                "                                                                inner" +
                "                                                   join articulo a on a.codigo = i.articuloID" +
                "                                                                 inner" +
                "                                                               join tipodoc td on td.codigo = d.tipo" +
                "                                                             inner" +
                "                                                                join grupo g on a.grupoID = g.codigo" +
                "                                                                where d.fecha between @fecha1 and @fecha2" +
                "                                                                        and td.clasedoc in ('FV', 'FP')" +
                "                                                                       group by a.grupoID, g.nombre)ventas" +
                "                                                                        left  JOIN" +
                "                                                                                (select a.grupoID, g.nombre," +
                "                                                                                SUM(i.cantidad) cantidad," +
                "                                                                                sum(i.vrtotal)valores," +
                "                                                                                SUM(i.vrcostototal)costo" +
                "                                                                                    from itart i" +
                "                                                                                    inner" +
                "                                                                                    join documento d on i.documentID = d.id" +
                "                                                                                    inner" +
                "                                                                                    join articulo a on a.codigo = i.articuloID" +
                "                                                                                    inner" +
                "                                                                                    join tipodoc td on td.codigo = d.tipo" +
                "                                                                                    inner" +
                "                                                                                    join grupo g on a.grupoID = g.codigo" +
                "                                                                                    where d.fecha between @fecha1 and @fecha2" +
                "                                                                                            and td.clasedoc in ('DV', 'DP')" +
                "                                                                                            group by a.grupoID, g.nombre) s ON s.grupoID = ventas.grupoID" +
                "                                                                                            group by s.grupoID, ventas.grupoID, s.nombre, ventas.nombre, ventas.cantidad, ventas.valores, ventas.costo, s.cantidad" +
                "                                                                                        )util" +
                "                                                                                            group by util.grupoID, util.nombre, util.cantidad, util.valores, util.costo, util.dev, util.[vr Dev])final" +
                "                                                                                           group by final.grupoID,final.nombre,final.cantidad,final.Ventas,final.costo,final.[Vr Utilidad],final.[vr Dev],final.dev" +
                "                                                                                            order by final.cantidad desc ";
            return dataload.sqlconsulta(sql);
        }//ventas por grupo
        internal DataSet RecordVentas(string fei, string fef,string proveedor)//Record de Ventas Nadia
        {
            if (!proveedor.IsEmpty())
            {
                sql = "SET NOCOUNT ON; " +
                    "                    declare @fecha1 as date = '"+fei+"'" +
                    "                    ,@fecha2 as date = '"+fef+"'" +
                    "                 SELECT" +
                    "                        util.codigo," +
                    "                		util.detalle," +
                    "                		util.[Nombre Linea]," +
                    "                		util.[Nombre Grupo]," +
                    "						util.[Nombre Marca]," +
                    "                		prov.proveedorID," +
                    "                		prov.nomprov[Nombre Proveedor]," +
                    "                		cast(util.cantidad as int)[Cant Ventas]," +
                    "                		cast(Util.valores as bigint)[Vr Ventas]," +
                    "                		cast(util.costo as bigint)[vr costo]," +
                    "                		cast(SUM(util.valores - util.costo) as bigint)[Vr Utilidad]," +
                    "                		cast((util.dev) as bigint)[Cant Dev]," +
                    "                		cast(util.[vr Dev] as bigint)[Vr Dev], " +
                    "                       cast(util.[Vr Dscto] as bigint)[Vr Dscto]" +
                    "                       FROM" +
                    "                        (select" +
                    "                            ventas.codigo," +
                    "                            ventas.detalle," +
                    "                            ventas.lineaID LineaID," +
                    "                            ventas.[Nombre Linea]," +
                    "                            ventas.grupoID," +
                    "                ventas.[Nombre Grupo]," +
                    "                            ventas.marcaID," +
                    "                            ventas.[Nombre Marca]," +
                    "                            sum(ventas.cantidad)cantidad," +
                    "                            sum(ventas.valores) valores," +
                    "                            sum(ventas.costo - costoDevol)costo," +
                    "                            sum(cantidadDevol) as dev," +
                    "                            sum(valoresDevol)[vr Dev]," +
                    "                            SUM(costoDevol)[Vr CostoDev]," +
                    "                            SUM(ValoresDscto)[Vr Dscto]" +
                    "                            FROM(select" +
                    "                                        a.codigo," +
                    "                                        a.detalle," +
                    "                                        a.lineaID," +
                    "                                        l.nombre[Nombre Linea]," +
                    "                                        a.grupoID," +
                    "                                        g.nombre[Nombre Grupo]," +
                    "                                        a.marcaID," +
                    "                m.nombre[Nombre Marca]," +
                    "                                        SUM(case when td.clasedoc in('FV', 'FP', 'FS') THEN i.cantidad else 0.00 end) cantidad," +
                    "                                        sum(case when td.clasedoc in('FV', 'FP', 'FS') then i.vrtotal else 0.00 end)valores," +
                    "                                        SUM(case when td.clasedoc in('FV', 'FP', 'FS') then i.vrcostototal else 0.00 end)costo," +
                    "                                        SUM(case when td.clasedoc in('DV', 'DP') then i.cantidad else 0.00 end) cantidadDevol," +
                    "                                        SUM(case when td.clasedoc in('DV', 'DP') then i.vrtotal else 0.00 end) valoresDevol," +
                    "                                        SUM(case when td.clasedoc in('DV', 'DP') then i.vrcostototal else 0.00 end) costoDevol, " +
                    "                                        SUM(case when td.clasedoc in('FV', 'FP', 'FS', 'DV', 'DP') then i.vrdto else 0.00 end) ValoresDscto" +
                    "                                 from itart i" +
                    "                                            inner join documento d on i.documentID = d.id" +
                    "                                            inner join articulo a on a.codigo = i.articuloID" +
                    "                                            inner join tipodoc td on td.codigo = d.tipo" +
                    "                                            inner join grupo g on a.grupoID = g.codigo" +
                    "                                            inner join linea l on a.lineaID = l.codigo" +
                    "                                            inner join marca m on a.marcaID = m.codigo" +
                    "                                where d.fecha between @fecha1 and @fecha2" +
                    "                                and td.clasedoc in ('FV', 'FP', 'DV', 'DP')" +
                    "                                group by a.codigo," +
                    "                					a.detalle," +
                    "                					a.lineaID," +
                    "									a.marcaID," +
                    "									m.nombre," +
                    "                					l.nombre," +
                    "                					a.grupoID," +
                    "                					g.nombre" +
                    "                				)ventas" +
                    "                                group by" +
                    "                                    ventas.detalle," +
                    "                					ventas.codigo," +
                    "                					ventas.lineaID," +
                    "                					ventas.[Nombre Linea]," +
                    "                					ventas.grupoID," +
                    "									ventas.marcaID," +
                    "									ventas.[Nombre Marca]," +
                    "                					ventas.[Nombre Grupo]," +
                    "                					ventas.cantidad," +
                    "                					ventas.valores," +
                    "                					ventas.costo" +
                    "                			)util OUTER APPLY" +
                    "                               (" +
                    "                                select top 1 proveedorID," +
                    "                                    coalesce(terp.nombrec, terp.nombre) nomprov" +
                    "                                from dbo.vwProvArt pa inner" +
                    "                                join dbo.tercero terp on pa.proveedorID = terp.id" +
                    "                                where pa.articuloID = util.codigo" +
                    "                                order by fecha desc" +
                    "                                ) as prov" +
                    "                                where prov.proveedorID = '"+proveedor+"'" +
                    "                            group by util.codigo," +
                    "                					util.detalle, " +
                    "                					util.grupoID," +
                    "                					util.[Nombre Linea]," +
                    "                					util.[Nombre Grupo], " +
                    "									util.[Nombre Marca]," +
                    "									util.marcaID," +
                    "                					util.LineaID, " +
                    "                					util.cantidad, " +
                    "                					util.valores, " +
                    "                					util.costo, " +
                    "                					util.dev, " +
                    "                					util.[vr Dev]," +
                    "                                   util.[Vr Dscto]," +
                    "                					prov.proveedorID," +
                    "                					prov.nomprov" +
                    "                            order by codigo asc";
            }
            else
            {
                sql = "SET NOCOUNT ON; " +
                    "                    declare @fecha1 as date = '" + fei + "'" +
                    "                    ,@fecha2 as date = '" + fef + "'" +
                    "                 SELECT" +
                    "                        util.codigo," +
                    "                		util.detalle," +
                    "                		util.[Nombre Linea]," +
                    "                		util.[Nombre Grupo]," +
                    "						util.[Nombre Marca]," +
                    "                		prov.proveedorID," +
                    "                		prov.nomprov[Nombre Proveedor]," +
                    "                		cast(util.cantidad as int)[Cant Ventas]," +
                    "                		cast(Util.valores as bigint)[Vr Ventas]," +
                    "                		cast(util.costo as bigint)[vr costo]," +
                    "                		cast(SUM(util.valores - util.costo) as bigint)[Vr Utilidad]," +
                    "                		cast((util.dev) as bigint)[Cant Dev]," +
                    "                		cast(util.[vr Dev] as bigint)[Vr Dev], " +
                    "                       cast(util.[Vr Dscto] as bigint)[Vr Dscto]" +
                    "                       FROM" +
                    "                        (select" +
                    "                            ventas.codigo," +
                    "                            ventas.detalle," +
                    "                            ventas.lineaID LineaID," +
                    "                            ventas.[Nombre Linea]," +
                    "                            ventas.grupoID," +
                    "                ventas.[Nombre Grupo]," +
                    "                            ventas.marcaID," +
                    "                            ventas.[Nombre Marca]," +
                    "                            sum(ventas.cantidad)cantidad," +
                    "                            sum(ventas.valores) valores," +
                    "                            sum(ventas.costo - costoDevol)costo," +
                    "                            sum(cantidadDevol) as dev," +
                    "                            sum(valoresDevol)[vr Dev]," +
                    "                            SUM(costoDevol)[Vr CostoDev]," +
                    "                            SUM(ValoresDscto)[Vr Dscto]" +
                    "                            FROM(select" +
                    "                                        a.codigo," +
                    "                                        a.detalle," +
                    "                                        a.lineaID," +
                    "                                        l.nombre[Nombre Linea]," +
                    "                                        a.grupoID," +
                    "                                        g.nombre[Nombre Grupo]," +
                    "                                        a.marcaID," +
                    "                m.nombre[Nombre Marca]," +
                    "                                        SUM(case when td.clasedoc in('FV', 'FP', 'FS') THEN i.cantidad else 0.00 end) cantidad," +
                    "                                        sum(case when td.clasedoc in('FV', 'FP', 'FS') then i.vrtotal else 0.00 end)valores," +
                    "                                        SUM(case when td.clasedoc in('FV', 'FP', 'FS') then i.vrcostototal else 0.00 end)costo," +
                    "                                        SUM(case when td.clasedoc in('DV', 'DP') then i.cantidad else 0.00 end) cantidadDevol," +
                    "                                        SUM(case when td.clasedoc in('DV', 'DP') then i.vrtotal else 0.00 end) valoresDevol," +
                    "                                        SUM(case when td.clasedoc in('DV', 'DP') then i.vrcostototal else 0.00 end) costoDevol, " +
                    "                                        SUM(case when td.clasedoc in('FV', 'FP', 'FS', 'DV', 'DP') then i.vrdto else 0.00 end) ValoresDscto" +
                    "                                 from itart i" +
                    "                                            inner join documento d on i.documentID = d.id" +
                    "                                            inner join articulo a on a.codigo = i.articuloID" +
                    "                                            inner join tipodoc td on td.codigo = d.tipo" +
                    "                                            inner join grupo g on a.grupoID = g.codigo" +
                    "                                            inner join linea l on a.lineaID = l.codigo" +
                    "                                            inner join marca m on a.marcaID = m.codigo" +
                    "                                where d.fecha between @fecha1 and @fecha2" +
                    "                                and td.clasedoc in ('FV', 'FP', 'DV', 'DP')" +
                    "                                group by a.codigo," +
                    "                					a.detalle," +
                    "                					a.lineaID," +
                    "									a.marcaID," +
                    "									m.nombre," +
                    "                					l.nombre," +
                    "                					a.grupoID," +
                    "                					g.nombre" +
                    "                				)ventas" +
                    "                                group by" +
                    "                                    ventas.detalle," +
                    "                					ventas.codigo," +
                    "                					ventas.lineaID," +
                    "                					ventas.[Nombre Linea]," +
                    "                					ventas.grupoID," +
                    "									ventas.marcaID," +
                    "									ventas.[Nombre Marca]," +
                    "                					ventas.[Nombre Grupo]," +
                    "                					ventas.cantidad," +
                    "                					ventas.valores," +
                    "                					ventas.costo" +
                    "                			)util OUTER APPLY" +
                    "                               (" +
                    "                                select top 1 proveedorID," +
                    "                                    coalesce(terp.nombrec, terp.nombre) nomprov" +
                    "                                from dbo.vwProvArt pa inner" +
                    "                                join dbo.tercero terp on pa.proveedorID = terp.id" +
                    "                                where pa.articuloID = util.codigo" +
                    "                                order by fecha desc" +
                    "                                ) as prov" +
                 
                    "                            group by util.codigo," +
                    "                					util.detalle, " +
                    "                					util.grupoID," +
                    "                					util.[Nombre Linea]," +
                    "                					util.[Nombre Grupo], " +
                    "									util.[Nombre Marca]," +
                    "									util.marcaID," +
                    "                					util.LineaID, " +
                    "                					util.cantidad, " +
                    "                					util.valores, " +
                    "                					util.costo, " +
                    "                					util.dev, " +
                    "                					util.[vr Dev]," +
                    "                                   util.[Vr Dscto]," +
                    "                					prov.proveedorID," +
                    "                					prov.nomprov" +
                    "                            order by codigo asc";
            }
            return dataload.sqlconsulta(sql);
        }//ventas por grupo
        internal DataSet listadoventaXlineacajera(string fei, string fef, string marcaid)
        {
            sql = "SELECT " +
                "  articulo.detalle,documento.logusucreo, " +
                " SUM(CAST(itart.cantidad AS float)) AS cantidad, " +
                " SUM(itart.vrtotal) AS valor_total  " +
                " FROM itart INNER JOIN articulo ON itart.articuloID = articulo.codigo " +
                " INNER JOIN documento ON itart.documentID = documento.id " +
                " INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo " +
                " WHERE(documento.fecha BETWEEN '" + fei + "' AND '" + fef + "') " +
                " AND(tipodoc.clasedoc in ('FV', 'FP')) " +
                " AND(articulo.codigo = '" + marcaid + "')" +
                " GROUP BY documento.logusucreo,articulo.detalle " +
                " ORDER BY cantidad DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoComprasrecibidas(string fei, string fef)//trae las proveedores con compras en fechas especificas
        {
            sql = "SELECT t.id, t.nombrecompleto FROM documento D " +
                "    inner join tercero t on D.terceroID1 = t.id" +
                "    inner join tipodoc td on td.codigo = D.tipo" +
                "    where td.clasedoc = 'FC'" +
                "    AND D.fecha between '" + fei + "' and '" + fef + "'" +
                "    group by t.nombrecompleto,t.id";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaXarticulocajeratop(string fei, string fef, string articuloid, string ccosto)
        {
            sql = "SELECT  Top(10) articulo.detalle" +
                " ,documento.logusucreo," +
                "  SUM(CAST(itart.cantidad AS float)) AS cantidad," +
                "  SUM(itart.vrtotal) AS valor_total " +
                " FROM itart " +
                " INNER JOIN articulo ON itart.articuloID = articulo.codigo " +
                " INNER JOIN documento ON itart.documentID = documento.id " +
                " INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo" +
                " WHERE(documento.fecha BETWEEN '" + fei + "' AND '" + fef + "')" +
                " AND(tipodoc.clasedoc in ('FV', 'FP')) " +
                " AND(articulo.codigo = '" + articuloid + "') and(documento.ccostoID='" + ccosto + "')" +
                " GROUP BY documento.logusucreo,articulo.detalle" +
                " ORDER BY cantidad DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaXmarcacajeratop(string fei, string fef, string marca, string ccosto)
        {
            sql = "SELECT " +
                "                 documento.logusucreo, " +
                "                 SUM(CAST(itart.cantidad AS float)) AS cantidad," +
                "                 SUM(itart.vrtotal) AS valor_total" +
                "                 FROM itart INNER JOIN articulo ON itart.articuloID = articulo.codigo" +
                "                 INNER JOIN documento ON itart.documentID = documento.id" +
                "                 INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo" +
                "                 INNER JOIN marca M ON M.codigo = articulo.marcaID" +
                "                 WHERE(documento.fecha BETWEEN '" + fei + "' AND '" + fef + "')" +
                "                 AND(tipodoc.clasedoc in ('FV', 'FP'))" +
                "                 AND(M.nombre = '" + marca + "')" +
                "                 and documento.bodegaID = '" + ccosto + "' " +
                "                 GROUP BY documento.logusucreo" +
                "                 ORDER BY cantidad DESC";
            return dataload.sqlconsulta(sql);
        }


        internal DataSet listadoventaDomicilio(string fei, string fef)
        {
            sql = "SELECT TOP (100) PERCENT DATEPART(DD, documento.logfecreo) AS DIAS," +
                "        bodega.nombre," +
                "        tercero.nombrecompleto as Vendedor," +
                "        articulo.detalle as Tipo_Domicilio," +
                "         SUM(CAST(itart.cantidad AS float)) AS cantidad," +
                "          SUM(itart.vrtotal) AS valor_total" +
                " FROM itart" +
                "        INNER JOIN articulo ON itart.articuloID = articulo.codigo" +
                "        INNER JOIN documento ON itart.documentID = documento.id" +
                "        INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo" +
                "        INNER JOIN tercero on tercero.id = documento.vendedorID" +
                "        inner join bodega on bodega.codigo = documento.bodegaID" +
                "                WHERE" +
                "                        (documento.fecha BETWEEN '" + fei + "' AND '" + fef + "')" +
                "                        AND(tipodoc.clasedoc in ('FV', 'FP'))   AND(articulo.codigo in ('22221', '22233', '22234'))" +
                "                        GROUP BY DATEPART(DD, documento.logfecreo), tercero.nombrecompleto,bodega.nombre,articulo.detalle" +
                "                        ORDER BY DIAS DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventalocalVERSA(string useri, string fei, string fef)
        {
            sql = "select format(Sum(vrtotal)," +
                "  '$ #,###.##') AS VALOR,count(*) as Facturas, " +
                " logusucreo from documento " +
                " where logusucreo LIKE ('%" + useri + "%') " +
                "  AND fecha BETWEEN '" + fei + "' AND '" + fef + "' " +
                " AND anulado=0 AND ccostoID = '000004' group by logusucreo";
            return dataload.sqlconsultaversalles(sql);
        }
        internal DataSet ventalocalVERSAreco(string fecha, string ccosto)
        {
            sql = "select logusucreo,  format(Sum(itfpago.vrfpago), '$ #,###.##') AS VALOR  FROM  itfpago INNER JOIN  documento AS do   INNER JOIN   tipodoc AS td ON do.tipo = td.codigo ON itfpago.documentID = do.id      inner join fpago as fp  on fp.codigo=itfpago.fpagoID    WHERE  fp.detalle='EFECTIVO VERSALLES' and do.fecha ='" + fecha + "' AND anulado=0 AND do.ccostoID = '" + ccosto + "' GROUP BY logusucreo";
            return dataload.sqlconsultaversalles(sql);
        }
        internal DataSet listadetalleventalocalVERSA(string useri, string fei, string fef)
        {
            sql = "select  fp.detalle, format(Sum(itfpago.vrfpago), '$ #,###.##') AS VALOR  FROM  itfpago INNER JOIN  documento AS do   INNER JOIN   tipodoc AS td ON do.tipo = td.codigo ON itfpago.documentID = do.id      inner join fpago as fp  on fp.codigo=itfpago.fpagoID    WHERE  logusucreo LIKE ('%" + useri + "%')  AND do.fecha BETWEEN '" + fei + "' AND '" + fef + "' AND anulado=0 AND do.ccostoID = '000004' GROUP BY fp.detalle";
            return dataload.sqlconsultaversalles(sql);
        }
        internal DataSet listaefectivo(string fecha, string ccosto)
        {
            sql = " select format(Sum(do.vrtotal), '$ #,###.##') AS VALOR, COUNT(*) AS CANT_TIKECT, do.logusucreo FROM dbo.itfpago INNER JOIN dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo ON dbo.itfpago.documentID = do.id WHERE  (do.fecha = '" + fecha + "') AND(td.clasedoc = 'FP') and itfpago.fpagoID='001' and do.ccostoID= '" + ccosto + "' GROUP BY  do.logusucreo order by VALOR DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet lineassupermio()
        {
            sql = " select concat(l.codigo,'/',l.nombre)as Nombre from linea as l ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mactabaja()
        {
            sql = "select act_id," +
                "                 act_fecha," +
                "                 act_ubicacion, " +
                "                 act_area," +
                "                  act_usuario," +
                "                        act_fcreo," +
                "                         baja_id," +
                "                         baja_fecha," +
                "                         baja_estado, " +
                "                         baja_destino," +
                "                         baja_fcreo," +
                "                         baja_usucreo," +
                "                         baja_idacta, " +
                "                           ar.serialArt," +
                "                         ar.nombreArt, " +
                "                           ar.fcompArt," +
                "                         area.nombrearea," +
                "                         u.nombUbica" +
                "                          from actas a" +
                "                                inner join baja_articulos b on b.baja_idacta = a.act_id" +
                "                                inner join articulo ar on ar.idArt = b.baja_idarticulo" +
                "                                inner join area area on area.id = act_area" +
                "                                inner join ubicacion u on u.idUbica = act_ubicacion";
            return dataload.sqlconsultamysql(sql);
        }
        internal DataSet mlistaactabaja(string id)
        {
            sql = "select act_id," +
                "                 act_fecha," +
                "                 act_ubicacion, " +
                "                 act_area," +
                "                  act_usuario," +
                "                        act_fcreo," +
                "                         baja_id," +
                "                         baja_fecha," +
                "                         baja_estado, " +
                "                         baja_destino," +
                "                         baja_fcreo," +
                "                         baja_usucreo," +
                "                         baja_idacta," +
                "                         ar.serialArt, " +
                "                         ar.nombreArt, " +
                "                           ar.fcompArt," +
                "                         area.nombrearea," +
                "                         u.nombUbica" +
                "                          from actas a" +
                "                                inner join baja_articulos b on b.baja_idacta = a.act_id" +
                "                                inner join articulo ar on ar.idArt = b.baja_idarticulo" +
                "                                inner join area area on area.id = act_area" +
                "                                inner join ubicacion u on u.idUbica = act_ubicacion" +
                "                                where act_id = " + id + "";
            return dataload.sqlconsultamysql(sql);
        }
        internal DataSet mlista_activos_asg(String pnombre, String pbd) //trae activos a cargo de cada empleado
        {
            sql = "select * from listaactivos_asg where ENCARGADO ='" + pnombre + "' ";
            return dataload.MySqlQuery(sql, pbd);
        }

        internal DataSet ventashoralinea(string Fecha, string linea, string bodega)
        {
            sql = "select " +
                "TOP (100) PERCENT DATEPART(HH, d.logfecreo) AS Rango_Hora, format(Sum(it.vrtotal), '$ #,###.##') AS V_Facturas " +

                "from documento d inner join itart it on d.id=it.documentid" +
                " inner join articulo art ON it.articuloID=art.codigo 	" +
                "inner join linea ln on art.lineaID=ln.codigo 	" +
                "INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +
                " where d.anulado=0 " +
                "and d.fecha='" + Fecha + "' " +
                "and ln.codigo='" + linea + "' " +
                "and  td.clasedoc IN('FP','FV')" +
                " AND d.ccostoID='" + bodega + "'  " +
                "GROUP BY DATEPART(HH, d.logfecreo) " +
                "order by Rango_Hora  ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet ventasXLINEA(string fechadesde, string fechahasta, string linea, string ccosto)
        {
            sql = " select art.codigo, art.detalle,    sum(it.cantidad)as cantidad , format(Sum(it.vrtotal), '$ #,###.##') AS V_Facturas" +
                "   from documento d inner" +
                "    join itart it on d.id = it.documentid  " +
                "Inner join articulo art ON it.articuloID = art.codigo " +
                "      inner   join linea ln on art.lineaID = ln.codigo " +
                "          INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo " +
                "    where d.anulado = 0 " +
                "       and d.fecha between '" + fechadesde + "' and '" + fechahasta + "'" +
                "          and ln.codigo = '" + linea + "'" +
                "    and td.clasedoc IN('FV' , 'FP','DP','DV') " +
                "   AND d.ccostoID = '" + ccosto + "' " +
                "    group by art.codigo,art.detalle";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet centrocosto()
        {
            sql = "select concat(codigo,' / ',nombre)as Nombre from ccosto ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet ventashoralineala13(string Fecha, string linea)
        {
            sql = "select TOP (100) PERCENT DATEPART(HH, d.logfecreo) AS Rango_Hora, format(Sum(it.vrtotal), '$ #,###.##') AS V_Facturas " +

                "from documento d inner join itart it on d.id=it.documentid" +
                " inner join articulo art ON it.articuloID=art.codigo 	" +
                "inner join linea ln on art.lineaID=ln.codigo 	" +
                "INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +
                " where d.anulado=0 " +
                "and d.fecha='" + Fecha + "' " +
                "and ln.codigo='" + linea + "' " +
                "and  (td.clasedoc = 'FP')" +
                " AND d.ccostoID='000002'  " +
                "GROUP BY DATEPART(HH, d.logfecreo) " +
                "order by Rango_Hora  ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Ventaslinearesumido(string fecha1, string fecha2)
        {
            sql = "   select " +
                " r.Linea," +
                " r.N_fact," +
                " format(r.V_ANTES_IVA, '$ ###,###.##')V_ANTES_IVA," +
                " FORMAT(cast(r.V_ANTES_IVA as BIGINT) / cast(r.N_fact as BIGINT), '$ ###,###.##')Pr_Venta" +
                "  from(" +
                " select  ln.nombre AS Linea" +
                "                        , count(distinct it.documentID)N_fact" +
                "                        , Sum(it.vrtotal) AS V_ANTES_IVA" +
                "                 from documento d inner join itart it on d.id = it.documentID and d.fecha between '" + fecha1 + "' and '" + fecha2 + "'" +
                "                 inner join articulo art ON it.articuloID = art.codigo" +
                "                 inner join linea ln on art.lineaID = ln.codigo" +
                "                 INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +
                "                 where" +
                "                    td.clasedoc IN('FV', 'FP')" +
                "                    and d.anulado = 0" +
                "                 group by ln.nombre)r";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet ventashoralineaversalles(string Fecha, string linea)
        {
            sql = "select TOP (100) PERCENT DATEPART(HH, d.logfecreo) AS Rango_Hora, format(Sum(it.vrtotal), '$ #,###.##') AS V_Facturas " +

                "from documento d inner join itart it on d.id=it.documentid" +
                " inner join articulo art ON it.articuloID=art.codigo 	" +
                "inner join linea ln on art.lineaID=ln.codigo 	" +
                "INNER JOIN dbo.tipodoc AS td ON d.tipo = td.codigo" +
                " where d.anulado=0 " +
                "and d.fecha='" + Fecha + "' " +
                "and ln.codigo='" + linea + "' " +
                "and  (td.clasedoc = 'FP')" +
                " AND d.ccostoID='000004'  " +
                "GROUP BY DATEPART(HH, d.logfecreo) " +
                "order by Rango_Hora  ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventashora(string Fecha, string costo)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA " +
                ",format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas " +
                ",COUNT(*) AS Cant " +
                ", COUNT(DISTINCT do.logusucreo) AS Users" +
                " FROM dbo.documento AS do" +
                " INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo " +
                "WHERE (do.fecha = '" + Fecha + "')" +
                " AND td.clasedoc IN ('FP','FV')" +
                " AND do.ccostoID='" + costo + "'" +
                " and do.anulado=0" +
                " GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventashora13(string Fecha)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA,format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas,COUNT(*) AS Cant, COUNT(DISTINCT do.logusucreo) AS Users FROM dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo WHERE (do.fecha = '" + Fecha + "') AND (td.clasedoc in ('FV', 'FP')) AND do.ccostoID='000002' and do.anulado=0 GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventashoraVERSA(string Fecha)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA,format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas,COUNT(*) AS Cant, COUNT(DISTINCT do.logusucreo) AS Users FROM dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo WHERE (do.fecha = '" + Fecha + "') AND (td.clasedoc in ('FV', 'FP')) AND do.ccostoID='000004' and do.anulado=0 GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventashoraCiudadela(string Fecha)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA, " +
                "format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas,COUNT(*) AS Cant, " +
                " COUNT(DISTINCT do.logusucreo) AS Users " +
                " FROM dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo " +
                " WHERE (do.fecha = '" + Fecha + "') AND (td.clasedoc in ('FV', 'FP')) AND do.ccostoID='000005' and do.anulado=0 GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listSalesDomicilios(string fecha1, string fecha2)
        {
            sql = "SELECT  documento.logfecreo AS Fecha,documento.numero as Numero_Factura, " +
                "        bodega.nombre as Sala_De_Ventas," +
                "        tercero.nombrecompleto as Domiciliario," +
                "        articulo.detalle as Tipo_Domicilio," +
                "         count(itart.cantidad) AS Cant," +
                "         format(SUM(documento.vrtotal),'$ #,###.##') AS Valor_Facturas  " +
                "                                FROM itart" +
                "        INNER JOIN articulo ON itart.articuloID = articulo.codigo" +
                "        INNER JOIN documento ON itart.documentID = documento.id" +
                "        INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo" +
                "        INNER JOIN tercero on tercero.id = documento.vendedorID" +
                "        inner join bodega on bodega.codigo = documento.bodegaID" +
                "                WHERE" +
                "                        (documento.fecha BETWEEN '" + fecha1 + "' AND '" + fecha2 + "')" +
                "                        AND(tipodoc.clasedoc in ('FV', 'FP'))  " +
                "                        AND(articulo.codigo in ('22221', '22233', '22234', '22266', '22267', '22268'))" +
                "                        group by documento.logfecreo,documento.numero,bodega.nombre," +
                "                          tercero.nombrecompleto,  articulo.detalle " +
                               "                        ORDER BY Fecha asc";
            return dataload.sqlconsulta(sql);
        }
        internal DataTable McreaFirma(String pcc, String pnombre, String ptipopersona, String pcelular, String pfirma, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PCC", pcc, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PNOMBRE", pnombre, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PTIPOPERSONA", ptipopersona, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PCELULAR", pcelular, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PFIRMA", pfirma, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_FIRMA", crearp, pbd);


            }
            catch (Exception ex)


            {

                throw ex;
            }
        }

        internal DataTable McreaFormato(String pName, String pFullPath, String pUser, String pArea, String plabel, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PNAME", pName, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PFULLPATH", pFullPath, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PUSER", pUser, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PAREA", pArea, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PLABEL", plabel, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_FORMATO", crearp, pbd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal DataTable McreaPERSONA(String pcc, String pnombre1, String pnombre2, String apellido1, String apellido2,
           String ptel, String pdireccion, String psexo, String ptipouser, String puser, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PCC", pcc, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PNOMBRE1", pnombre1, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PNOMBRE2", pnombre2, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PAPELLIDO1", apellido1, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PAPELLIDO2", apellido2, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PTELEFONO", ptel, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PDIR", pdireccion, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PSEXO", psexo, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PTIPOUSER", ptipouser, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPOR", puser, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_PERSONA", crearp, pbd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable Mcreausuario(String pid, String pusuario, String ppas, String pusu, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PID", pid, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PUSUARIO", pusuario, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPAS", ppas, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPOR", pusu, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("PRCREAR_USUARIO", crearp, pbd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataTable mCreapermiso(String pidpermiso, String prol, String pusuario, String pbd)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PIDPERMISO", pidpermiso, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PIDROL", prol, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PPOR", pusuario, "VARCHAR", ParameterDirection.Input));

                return con.ProcedureSelectDB("PRCREAR_PERMISO", crearp, pbd);

            }
            catch (Exception ex)


            {

                throw ex;
            }
        }
        internal DataSet Mlistadomenus(String pbd) //trae menus y el id para aprovechar en select
        {
            sql = "select menu_id||' / '|| menu_nombre AS MENU from MENUHTML";
            return dataload.oraconsulta(sql, pbd);
        }
        internal DataSet Mlistamenuid(String pbd, String perfil) //trae roles menus ids
        {
            sql = "SELECT MENU_HTML " +
                "FROM MENUHTML M INNER JOIN PERMISOS P on M.MENU_ID=P.PERM_IDMENUHTML " +
                "INNER JOIN TIPOPERSONA TP ON P.PERM_IDTIPOPERSONA=TP.TIPP_ID WHERE TP.TIPP_ID='" + perfil + "'";
            return dataload.oraconsulta(sql, pbd);
        }
        internal DataSet Mlistanombremenu(String pbd, String perfil) //trae roles menus ids
        {
            sql = "SELECT MENU_ID||' / '||M.MENU_NOMBRE AS NOMBRE " +
                "FROM MENUHTML M INNER JOIN PERMISOS P on M.MENU_ID = P.PERM_IDMENUHTML " +
                " INNER JOIN TIPOPERSONA TP ON P.PERM_IDTIPOPERSONA = TP.TIPP_ID WHERE TP.TIPP_ID = '" + perfil + "'";
            return dataload.oraconsulta(sql, pbd);
        }
        internal DataSet Mlistamrol(String pbd) //trae roles 
        {
            sql = "SELECT TIPP_ID|| ' / ' ||TIPP_NOMBRE AS NOMBRE FROM TIPOPERSONA";
            return dataload.oraconsulta(sql, pbd);
        }
        internal DataSet Mlistausuarios(String pbd)
        {
            sql = "select PERS_CC AS CC, PERS_NOMBRE1 AS NOMBRE_1 , PERS_NOMBRE2 AS NOMBRE_2 , PERS_APELLIDO1 as AP_PATERNO ,PERS_APELLIDO2 AS AP_MATERNO ,PERS_TEL AS TEL ,PERS_DIRECCION AS DIRECCION ,PERS_SEXO AS SEXO     ,(SELECT TIPP_NOMBRE FROM TIPOPERSONA WHERE TIPP_ID = PERS_TIPP_ID) AS ROL   from persona";
            return dataload.oraconsulta(sql, pbd);
        }

        internal DataTable MlistFiles(String area, String pbd)
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                RunLista.Add(new parametro("PAREA", area, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB(pbd + ".FN_LISTAFORMATOS", RunLista, pbd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal DataSet listanumeroid(String bd)
        {
            sql = "SELECT max(idArt+1) as idArt from articulo";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listaconsultor(String codbar, String Listaprecio, String bd)
        {
            sql = "SELECT a.codigo,  a.detalle, cd.codbarra,cast(valormiva as int)as " +
             " valormiva,cast(a.peso as int) as unidadmedida,cast(valormiva / peso as float) as precioxgramo, getdate() as fechaimpresion from articulo a " +
                " left " +
                     "          join dbo.artspromo aprom ON a.codigo = aprom.articuloID " +
                   "       left " +
                 "          join dbo.condicionpromo condiprom ON aprom.promocionID = condiprom.promocionID " +
               "          left JOIN dbo.promocion promo ON condiprom.promocionID = promo.id " +
               " left join codbar cd on cd.articuloID = a.codigo " +
             " left join precio pc on pc.articuloID = a.codigo and(pc.presentacionID = cd.presentacionID or(pc.presentacionID is null and cd.presentacionID is null)) " +
            " where inactivo = 0 and cd.CODBARRA = '" + codbar + "' and pc.listprecioID='" + Listaprecio + "' ";
            return dataload.MySqlQuery(sql, bd);
        }
        internal int Mcreaactivo(String pid, String pserial, String pnombre, String pmodelo, String pfabricante,
            String pcategoria, String pcoment, String pproveedor, String pfechacompra, String pvalor, String pusuario, String pgarantia, String bd)
        {

            sql = "INSERT INTO articulo (idArt,serialArt,nombreArt,modArt,fabriArt,categArt,proveedor,fcompArt,valoruntArt,timeGarant,comentArt,fcreacArt,inactivo,user) VALUES ('" + pid + "','" + pserial + "','" + pnombre + "',( SELECT idMod FROM modelo where nombMod='" + pmodelo + "'),(SELECT idFabric FROM fabricante where nombFabric='" + pfabricante + "'),( SELECT idCat FROM categoria where nombCat='" + pcategoria + "'),(SELECT idResp FROM persona where nomb='" + pproveedor + "'),'" + pfechacompra + "','" + pvalor + "','" + pgarantia + "','" + pcoment + "','" + pfechacompra + "',1,'" + pusuario + "') ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet Mlistadepreciacion(String bd)
        {

            sql = "call P_DEPRECIACION()";
            return dataload.MySqlQuery(sql, bd);
        }
        internal int Mupdateactivo(String pid, String pserial, String pnombre, String pcoment, String pgarantia,
           String pmodelo, String pfabricante, String pcategoria, String pproveedor,
           String pfechacompra, String pvalor, String pusuario, String bd)
        {

            sql = "call P_UPDATEACTIVO('" + pid + "','" + pserial + "','" + pnombre + "','" + pcoment + "','" + pgarantia + "','" + pmodelo + "','" + pfabricante + "','" + pcategoria + "','" + pproveedor + "','" + pfechacompra + "','" + pvalor + "','" + pusuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreaacta(String pid, String pusuario, String observa, String data, String bd)
        {

            sql = "INSERT INTO rol (idRol,nombRol,observaciones,fcreacion) VALUES ('" + pid + "','" + pusuario + "','" + observa + "','" + data + "') ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        //-------------------------------------------------------------------------------------------------------
        //ACTAS DE MANTENIMIENTOS
        //-------------------------------------------------------------------------------------------------------
        internal int McreaactaMantenimiento(String pproveedor, String data, String pusuario,
            String observa, String fechaacta, String bd)
        {
            sql = "INSERT INTO mantenimientos (mant_idproveedor,mant_fecha,mant_registradopor,mant_observaciones,mant_fcreado) VALUES ((select idResp from persona where nomb ='" + pproveedor + "'),'" + fechaacta + "','" + pusuario + "','" + observa + "','" + data + "') ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        //con este procedimiento se crean los detalles de mantenimiento y los detalles de aprobacion de trabajos
        internal int Mcreadetallesmantenimiento(String id, String idarticulo, String repuestos,
            int costomano, int costorespuesto,
             String detalle, String tipomant, String clasemant, String garantia, String pnumeroext, String bd)
        {
            sql = "call creadetalle_mante ('" + id + "','" + idarticulo + "','" + repuestos + "'," + costomano + "," + costorespuesto + ", " +
                " '" + detalle + "','" + tipomant + "','" + clasemant + "','" + garantia + "','" + pnumeroext + "') ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        //-------------------------------------------------------------------------------------------------------
        //con este crea mantenimiento desde una aprobacion de trabajo
        internal int Mcreaaprobacionasignacion(String id, String tercero, String observacion, String fecha, String usuario, String pidasig, String IDORDEN, String pbd)
        {
            sql = "call CREA_MANTENIMIENTO('" + id + "','" + tercero + "','" + observacion + "','" + fecha + "','" + usuario + "','" + pidasig + "','" + IDORDEN + "') ";
            return dataload.MysqlProce(sql, pbd);
        }
        //--------------------------------------------------------------------------------------------------------------------
        internal int McreadetallesactaMantenimiento(String pid, String pidarticulo,
            String prepuestos, String pcostoobra, String pcostorepuestos,
            String pdetalle, String ptipomantenimiento, String pnumeroext, String bd)
        {
            sql = "INSERT INTO detamantenimientos (detm_idmantenimiento,detm_idarticulo,detm_repuestos,detm_costomanoobra,detm_costorepuestos,detm_detalle,detm_tipomantenimiento,detm_numeroexterno) VALUES ('" + pid + "',(select idArt from articulo where serialArt='" + pidarticulo + "'),'" + prepuestos + "'," + pcostoobra + "," + pcostorepuestos + ",'" + pdetalle + "','" + ptipomantenimiento + "','" + pnumeroext + "') ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet mlistaactivosnombre(String bd)
        {
            sql = "select CONCAT(serialArt, ' / ', nombreArt) As Nombre  FROM articulo";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mlistaPROVEEDORES(String bd)
        {
            sql = "select nomb FROM persona where esproveedor=true";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mlistaPROVEEDORES2(String bd)
        {
            sql = "select concat(nomb,'/',tel)nomb FROM persona where esproveedor=true";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mlistaNUEVONUMEROACTA(String bd)
        {
            sql = "SELECT max(mant_id)+1 as id from mantenimientos";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mlistaNUEVONUMERObaja(String bd)
        {
            sql = "SELECT max(act_id)+1 as id from actas";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraemanteni(String pserial, String bd)
        {
            sql = "select m.mant_fecha as FECHA,d.detm_detalle as DETALLE_MANTENIMIENTO,d.detm_costomanoobra as $_MANO_OBRA,detm_numeroexterno as No_EXTERNO from mantenimientos m inner join detamantenimientos d on m.mant_id=d.detm_idmantenimiento  where  detm_idarticulo= (select idArt from articulo where serialArt='" + pserial + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        //trae la info para editar las actas de mantenimineto
        internal DataSet mtraeactaeditar(String pidacta, String bd)
        {
            sql = "select d.detm_id as ID ,concat(a.serialArt, ' / ',a.nombreart )as nombre ," +
                " d.detm_repuestos as Repuestos ,d.detm_costomanoobra as Mano_Obra ," +
                " d.detm_costorepuestos as Costo_Repuestos ,d.detm_detalle as Detalle," +
                " d.detm_tipomantenimiento as Tipo_Mant ,d.detm_numeroexterno as Numero_externo, d.detm_garantia as Time_Garantia " +
                " from detamantenimientos d  inner join mantenimientos m on d.detm_idmantenimiento = m.mant_id " +
                "inner join articulo a on d.detm_idarticulo=a.idArt  where m.mant_id = '" + pidacta + "'";
            return dataload.MySqlQuery(sql, bd);
        }
        //actualiza la linea de editing
        internal int Mupdatelineagridmanteni(String pid, String dato, String bd)
        {
            sql = "UPDATE detamantenimientos SET detm_repuestos='" + dato + "' WHERE detm_idmantenimiento='" + pid + "'";
            return dataload.MysqlProcedimiento(sql, bd);
        }

        internal DataSet mtraerespuestos(String pserial, String bd)
        {
            sql = "select m.mant_fecha AS FECHA,d.detm_repuestos AS REPUESTOS,d.detm_costorepuestos AS COSTO_REPUESTOS,d.detm_numeroexterno as No_EXTERNO from mantenimientos m inner join detamantenimientos d on m.mant_id=d.detm_idmantenimiento  where  detm_idarticulo= (select idArt from articulo where serialArt='" + pserial + "') and d.detm_repuestos<>'&nbsp;'";
            return dataload.MySqlQuery(sql, bd);
        }
        //con este metodo se trae desde el procedimineto los valores a cargar en el acta de asignacion
        internal DataSet mtraeactaasignacion(String id, String bd)
        {
            sql = "call LISTAASIGNACIONORDENMANTENIMIENTO('" + id + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        //con este metodo se trae desde el procedimineto los valores a cargar en el acta de asignacion
        internal DataSet mtraeactamantenimiento(String id, String bd)
        {
            sql = "call PLISTAR_MANTENIMIENTO('" + id + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraecategoriasactivos(String bd)
        {
            sql = "call P_LISTAR_CATEGORIA()";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraefabricante(String bd)
        {
            sql = "select nombFabric from fabricante";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraemodelo(String bd)
        {
            sql = "select nombMod from modelo";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraelinea(String bd)
        {
            sql = "select CONCAT(c.nombCat, ' / ', l.nombre) As Nombre from linea l inner join categoria c on l.Idcategoria=c.idcat";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraeproveedoractivos(String bd)
        {
            sql = "select nomb FROM persona where esproveedor = true";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraeactasdeentrega(String id, String bd)// procedimiento para mostrar en reporte las actas de entrega
        {
            sql = "call acta_entrega('" + id + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraeasignados(String id, String bd)
        {
            sql = "call LISTAASIGNACIONORDENMANTENIMIENTO('" + id + "')";
            return dataload.MySqlQuery(sql, bd);
        }
        //este es el metodo que utilice para crear el informe kike
        internal DataSet listadoidmantenimiento(String bd)
        {
            sql = "select * from PLISTAR_MANT";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraeconsecutivosmante(String bd)//este es jajajaja
        {
            sql = "call PLISTAR_MANTENIMIENTO('')";
            return dataload.MySqlQuery(sql, bd);
        }
        internal int mupdatedetalle_actasm(string pserial, string p_tipomante, string pdetalle,
            string pcosto_mano_obra, string prepuestos, string pnumero_externo,
            string pcosto_repuestos, string pidmantenimiento, string pidacta, string pgarantia, String bd)
        {
            sql = "update detamantenimientos set detm_idarticulo=(select idArt from articulo where serialArt='" + pserial + "')," +
                " detm_tipomantenimiento='" + p_tipomante + "',detm_detalle='" + pdetalle + "',detm_costomanoobra='" + pcosto_mano_obra + "'," +
                " detm_repuestos='" + prepuestos + "'  ,detm_numeroexterno='" + pnumero_externo + "',detm_costorepuestos='" + pcosto_repuestos + "', " +
                " detm_garantia='" + pgarantia + "' " +
                " where detm_idmantenimiento='" + pidmantenimiento + "' and detm_id='" + pidacta + "'";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int mdeletedeta_mante(string pidacta, String bd)
        {
            sql = "delete from detamantenimientos where detm_id='" + pidacta + "'";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int mupdate_actasm(string p_idproveedor, string pfecha, string pobservaciones, string pidacta, String bd)
        {
            sql = "update mantenimientos set mant_idProveedor=(select idResp from persona where nomb='" + p_idproveedor + "'),mant_fecha='" + pfecha + "',mant_observaciones='" + pobservaciones + "' where mant_id='" + pidacta + "'";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet mtraeproveedor(String bd)
        {
            sql = "select CONCAT(idResp, ' / ',id, ' / ',nomb) Proveedor FROM persona where esempleado=false and esproveedor=true";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet mtraeEmpleado(String bd)
        {
            sql = "select CONCAT(nomb) Proveedor FROM persona where esempleado=true";
            return dataload.MySqlQuery(sql, bd);

        }
        internal DataSet Mmployee(String bd)
        {
            sql = "select CONCAT(id,' / ',nomb) Employee FROM persona where esempleado=true";
            return dataload.MySqlQuery(sql, bd);

        }
        internal DataSet mtraeEmpleado_Sin_contra(String bd)
        {
            sql = "SELECT p.PERS_CC || '/' || p.PERS_NOMBRE1 ||' ' || p.PERS_APELLIDO1 NOMB from persona  p " +
                "WHERE NOT EXISTS(SELECT 1 FROM usuario u WHERE p.pers_id = u.usua_idpers)";
            return dataload.oraconsulta(sql, bd);

        }
        //-------------------------------------------------------------------------------------------------------
        //aqui inicia registro de mercancia
        //-------------------------------------------------------------------------------------------------------

        internal DataSet MValidafactura(String ntipo, String nNumero, String bd)
        {
            Sqls = "call P_VALIDA_FACTURA('" + ntipo + "','" + nNumero + "')";
            return dataload.MySqlQuery(Sqls, bd);
        }
        internal DataSet MlistaitemsRecibo_compra(String ntipo, String nNumero, String bd)
        {
            Sqls = "call P_LISTA_ITEMS_RECIBIDA('" + ntipo + "','" + nNumero + "')";
            return dataload.MySqlQuery(Sqls, bd);
        }
        internal int Mcreafactura(String ntipo, String nNumero, String puser, String bd)
        {
            sql = "call p_crea_rmercancia('" + ntipo + "','" + nNumero + "','" + puser + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreaitemsfactura(String nOrdenCompra,
            String pPlu,
            String pCant,
            String pDetalle,
            String pState,
            String pcantOc,
            String pcosto,
            String pedido,
            String pisDev,
            String iva,
            String pcodigo,
            String factor,
            String namepres,
            String costordencompra,
            String refProv,
            String bd) //RECIBIR MERCANCIA PEDIDA
        {

            sql = "call P_CREA_ITEMS_OC('" + nOrdenCompra + "'," +
                "'" + pPlu + "'," +
                "'" + pCant + "'," +
                "'" + pDetalle + "'," +
                "'" + pState + "'," +
                "'" + pcantOc + "'," +
                "'" + pcosto + "'," +
                "'" + pedido + "'," +
                "'" + pisDev + "'," +
                "'" + iva + "'," +
                "'" + pcodigo + "', " +
                " '" + factor + "'," +
                " '" + namepres + "','" + costordencompra + "','" + refProv + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mupdateitemsfactura(String nid, String pCant, String ncostonuevo, String pestado, String pboserva, String bd) //RECIBIR MERCANCIA PEDIDA
        {

            sql = "call P_UDATE_ITEMS_COMPRA('" + nid + "','" + pCant + "','" + ncostonuevo + "','" + pestado + "','" + pboserva + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int MinsertitemsBonificado(String nid, String pplu, String detalle, String bd) //RECIBIR MERCANCIA PEDIDA
        {

            sql = "call P_CREA_ITEMS_BON('" + nid + "','" + pplu + "','" + detalle + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcrea_devo_itemsfactura(String pplu, String pcodbarra, String nfactura, String pdetalle, String pcant, String bd)
        {

            sql = "call p_crea_devomercancia('" + pplu + "','" + pcodbarra + "','" + pdetalle + "','" + nfactura + "','" + pcant + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet mtrae_rmercancia(String idfactura, String bd)
        {
            sql = "call P_LISTA_CANT_RECIBIDA('" + idfactura + "')";
            return dataload.MySqlQuery(sql, bd);

        }
        internal DataSet mtrae_devo_mercancia(String idfactura, String bd)
        {
            sql = "call P_LISTA_DEVOMERCANCIA('" + idfactura + "')";
            return dataload.MySqlQuery(sql, bd);

        }
        internal DataSet mtrae_count_recibo(String idfactura, String bd)
        {
            sql = "select count(*) from detaordencompra dc inner join ordencompra oc on  oc.id=dc.Idordencompra where oc.numero='" + idfactura + "'";
            return dataload.MySqlQuery(sql, bd);

        }
        internal DataSet mtrae_count_devo(String idfactura, String bd)
        {
            sql = "select count(*) from devo_mercancia where idfactura='" + idfactura + "'";
            return dataload.MySqlQuery(sql, bd);

        }
        //-------------------------------------------------------------------------------------------------------
        //aqui Finaliza registro de mercancia
        //-------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------
        //aqui inicia incapacidades
        //-------------------------------------------------------------------------------------------------------
        internal int mcrea_incapacidad(string p_idempleado, string pobservaciones,
            string pfechaini, string pfechafin, string puser, String bd)
        {
            sql = "insert into incapacidades (INCA_IDPERSONA,INCA_MOTIVO,INCA_FECHAINICIAL,INCA_FECHAFINAL,INCA_FCREA,INCA_USUCREA)VALUE((select idResp  from persona where nomb='" + p_idempleado + "'),'" + pobservaciones + "','" + pfechaini + "','" + pfechafin + "',(select sysdate()),'" + puser + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int mcrea_Novedades(
            string p_idempleado,
            string pfechaini,
            int hours,
            bool diurno,
            bool nocturno,
            string pobservaciones,
           string puser,
           String bd)
        {
            sql = "insert into novedades (fecha, " +
                "empleado, " +
                "horas, " +
                "diurno, " +
                "Nocturno, " +
                "novedad, " +
                "datetimecreation, " +
                "usucrea ) " +
                $" VALUE('{pfechaini}',(select idResp from persona where nomb= '{p_idempleado}'),{hours},{diurno},{nocturno},'{pobservaciones}',(select sysdate()),'{puser}')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet listadoNovedadesAdmon(string fechaini,string fechafin, String bd)
        {
         
                sql = "SELECT " +
               "   n.Empleado, p.nomb Empleado," +
               "    SUM(CASE WHEN n.Diurno = 1 THEN n.horas ELSE 0 END) AS Horas_Diurnas," +
               "   SUM(CASE WHEN n.Nocturno = 1 THEN n.horas ELSE 0 END) AS Horas_Nocturnas," +
               "   SUM(n.horas) AS Total_horas," +
               "    n.usucrea Usuario " +
               " FROM" +
               "   Novedades n" +
               " INNER JOIN " +
               "   persona p ON p.idResp = n.Empleado" +
               $"    WHERE fecha BETWEEN " +
               $"    '{fechaini}' " +
               $"    AND '{fechafin}' " +
               " GROUP BY " +
               "    p.nomb, n.usucrea;";
       

            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listNovedades(string datein, string date_end,String bd)
        {
            sql = $"CALL P_LISTA_NOVEDADES('{datein}','{date_end}');";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listNovedadesUsuarios(string usuario, String bd)
        {
            sql = $"CALL P_LISTA_NOVEDADESUSUARIO('{usuario}');";
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listNovedadesAdmonDetails(string fechaini, string fechafin,string employee, String bd)
        {

            sql = "select n.Fecha, " +
               
                " n.novedad, " +
                " n.horas, " +
                " n.Diurno, " +
                " n.Nocturno, " +
                " n.DateTimeCreation, " +
                " n.usucrea " +
                " from" +
                "         novedades n" +
                "         inner join persona p on n.Empleado = p.idResp" +
                $"          where n.empleado ='{employee}' and n.fecha between '{fechaini}' and '{fechafin}' ";


            return dataload.MySqlQuery(sql, bd);
        }

        internal DataSet listadoNovedades(string usuario,String bd)
        {
            if (usuario == "")
            {
                sql = "SELECT n.id, " +
               "   p.nomb Empleado," +
               "    SUM(CASE WHEN n.Diurno = 1 THEN n.horas ELSE 0 END) AS Horas_Diurnas," +
               "   SUM(CASE WHEN n.Nocturno = 1 THEN n.horas ELSE 0 END) AS Horas_Nocturnas," +
               "   SUM(n.horas) AS Total_horas," +
               "    n.usucrea Usuario " +
               " FROM" +
               "   Novedades n" +
               " INNER JOIN " +
               "   persona p ON p.idResp = n.Empleado" +
               $"    WHERE fecha BETWEEN " +
               "    DATE_SUB(CURDATE(), INTERVAL (DAYOFWEEK(CURDATE()) + 5) % 7 DAY)" +
               "    AND DATE_ADD(CURDATE(), INTERVAL (7 - DAYOFWEEK(CURDATE())) DAY) " +
               " GROUP BY " +
               "    p.nomb, n.usucrea;";
            }
            else
            {
                sql = "SELECT n.id, " +
               "   p.nomb Empleado," +
               "    SUM(CASE WHEN n.Diurno = 1 THEN n.horas ELSE 0 END) AS Horas_Diurnas," +
               "   SUM(CASE WHEN n.Nocturno = 1 THEN n.horas ELSE 0 END) AS Horas_Nocturnas," +
               "   SUM(n.horas) AS Total_horas," +
               "    n.usucrea Usuario " +
               " FROM" +
               "   Novedades n" +
               " INNER JOIN " +
               "   persona p ON p.idResp = n.Empleado" +
               $"    WHERE n.usucrea='{usuario}' and fecha BETWEEN" +
               "    DATE_SUB(CURDATE(), INTERVAL (DAYOFWEEK(CURDATE()) + 5) % 7 DAY)" +
               "    AND DATE_ADD(CURDATE(), INTERVAL (7 - DAYOFWEEK(CURDATE())) DAY) " +
               " GROUP BY " +
               "    p.nomb, n.usucrea;";
            }
           
            return dataload.MySqlQuery(sql, bd);
        }
        internal DataSet listadoNovedadesusuario(string usuario, String bd)
        {
            if (usuario == "")
            {
                sql = "SELECT n.Id, n.fecha, " +
                   "                  p.nomb Empleado," +
                   "                  n.Novedad," +
                   "                   CASE WHEN n.Diurno = 1 THEN n.horas ELSE 0 END AS Horas_Diurnas," +
                   "                  CASE WHEN n.Nocturno = 1 THEN n.horas ELSE 0 END AS Horas_Nocturnas, n.horas," +
                   "      n.usucrea Usuario" +
                   "                FROM novedades n" +
                   "               INNER JOIN" +
                   "                  persona p ON p.idResp = n.Empleado" +
                   "                   WHERE  fecha BETWEEN" +
                   "                   DATE_SUB(CURDATE(), INTERVAL(DAYOFWEEK(CURDATE()) + 5) % 7 DAY)" +
                   "                  AND DATE_ADD(CURDATE(), INTERVAL (7 - DAYOFWEEK(CURDATE())) DAY) ";
            }
            else
            {
                sql = "SELECT n.Id, n.fecha, " +
                    "                  p.nomb Empleado," +
                    "                  n.Novedad," +
                    "                   CASE WHEN n.Diurno = 1 THEN n.horas ELSE 0 END AS Horas_Diurnas," +
                    "                  CASE WHEN n.Nocturno = 1 THEN n.horas ELSE 0 END AS Horas_Nocturnas, n.horas," +
                    "      n.usucrea Usuario" +
                    "                FROM novedades n" +
                    "               INNER JOIN" +
                    "                  persona p ON p.idResp = n.Empleado" +
                    $"                   WHERE n.usucrea = '{usuario}' and fecha BETWEEN" +
                    "                   DATE_SUB(CURDATE(), INTERVAL(DAYOFWEEK(CURDATE()) + 5) % 7 DAY)" +
                    "                  AND DATE_ADD(CURDATE(), INTERVAL (7 - DAYOFWEEK(CURDATE())) DAY) ";
            }

            return dataload.MySqlQuery(sql, bd);
        }
      
        internal int DeleteNovedades(string id, String bd)
        {
          sql= "delete from novedades where id='" + id + "'";

            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int mborraincapacidad(string p_idincapacidad, String bd)
        {
            sql = "delete from incapacidades where inca_id='" + p_idincapacidad + "'";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreanovedadincapacidad(string p_idincapacidad, string p_estado, string p_observa,
            string p_fecha, string p_user, String bd)
        {
            sql = "insert into estadoincapa (esti_idincapacidad,esti_estado,esti_observacion,esti_fecha,esti_fcreo,esti_usucreo)values('" + p_idincapacidad + "','" + p_estado + "','" + p_observa + "','" + p_fecha + "',(select sysdate()),'" + p_user + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet mtraeincapacidades(String bd)
        {
            sql = "select i.inca_id as ID,p.nomb as Nombre_Empleado, DATEDIFF(i.inca_fechafinal,i.inca_fechainicial)+1 as dias,i.inca_fechainicial as F_Inicial,i.inca_fechafinal as F_Final,i.inca_motivo as Motivo,inca_usucrea from incapacidades i inner join persona p on p.idResp=i.inca_idpersona";
            return dataload.MySqlQuery(sql, bd);

        }
        internal DataSet Mtraenovedadesincapacidad(string idincap, String bd)
        {
            sql = "select esti_estado as Estado,esti_observacion as Observacion,esti_fecha as Fecha,esti_usucreo as User from estadoincapa where esti_idincapacidad='" + idincap + "'";
            return dataload.MySqlQuery(sql, bd);

        }
        internal int Mupdateincapacidad(string p_idempleado, string pobservaciones, string pfechaini, string pfechafin, string puser, string pidincapacidad, String bd)
        {
            sql = "update incapacidades set INCA_IDPERSONA=(select idResp from persona where nomb='" + p_idempleado + "'),INCA_MOTIVO='" + pobservaciones + "',INCA_FECHAINICIAL='" + pfechaini + "',INCA_FECHAFINAL='" + pfechafin + "',INCA_USUCREA='" + puser + "' WHERE INCA_ID='" + pidincapacidad + "' ";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int MupdateNovedades(string id,string p_idempleado,string horas,bool diurno,bool nocturno, string pobservaciones, string pfechaini,  string puser, String bd)
        {
            sql = "update novedades       " +
                $"set fecha = '{pfechaini}'," +
                $"       Empleado = (select idResp from persona p where p.nomb= '{p_idempleado}')," +
                $"        Horas = '{horas}'," +
                $"        Diurno = {diurno} ," +
                $"       Nocturno = {nocturno} ," +
                $"        Novedad = '{pobservaciones}'," +
                $"      DateTimeCreation = sysdate(), usucrea= '{puser}' " +
                $" where id='{id}' ";
            return dataload.MysqlProcedimiento(sql, bd);
        }

        //-------------------------------------------------------------------------------------------------------
        //aqui finaliza incapacidades
        //-------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------
        //AQUI TERMINA ACTAS DE MANTENIMIENTOS 
        //-------------------------------------------------------------------------------------------------------
        //aqui ingreso cantidades al kardex
        internal int Mcreakardex(String pid, String entrada, String salida, String observa, String pusuario, String BodegaId, String pfechamov, String bd)
        {

            sql = "call P_CREA_KARDEX('" + pid + "','" + entrada + "','" + salida + "','" + observa + "','" + pusuario + "','" + BodegaId + "','" + pfechamov + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int McreaBAJA(String pfecha, String particulo, String pestado, String pdestino, String pusucreo, String pidacta, String bd)
        {

            sql = "call P_CREA_BAJA_ARTICULO('" + pfecha + "','" + particulo + "','" + pestado + "','" + pdestino + "','" + pusucreo + "','" + pidacta + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int McreaActaBaja(String pid, String pfecha, String pubicacion, String parea, String pusuario, String bd)
        {

            sql = "call P_CREA_ACTA('" + pid + "','" + pfecha + "','" + pubicacion + "','" + parea + "','" + pusuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int McreaUbicacion(String nombre, String usuario, String bd)
        {
            sql = "INSERT INTO ubicacion (nombUbica,fcreacion,user) VALUES ('" + nombre + "',(select sysdate()),'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreacantidadactivo(String pid, String pserial, String cantidad, String bd)
        {
            sql = "INSERT INTO cantproducto(id,idproducto,cantidad,idresponsable) VALUES('" + pid + "',(select idArt from articulo where serialArt='" + pserial + "'), '" + cantidad + "', 0)";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int masigarticulo(String fecha, String bd)
        {
            sql = "insert into asigarticulos(fcreacion)values('" + fecha + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }


        internal DataSet mselectfiscal(String pids, String bd)
        {
            sql = "select * from fiscal where idarticulo = (select idArt from articulo where serialArt='" + pids + "')";
            return dataload.MySqlQuery(sql, bd);
        }

        internal int Mupdatefiscal(String pid, String pidubica, String pidar, String pidartic, String pidacta, String bd)
        {
            sql = "update fiscal set idresponsable = (select idResp from persona where nomb='" + pid + "')" +
                " , idubicacion = (select idubica from ubicacion where nombUbica= '" + pidubica + "')" +
                " , idarea =(select id from area where nombrearea='" + pidar + "')" +
                " , idacta='" + pidacta + "'" +
                "  where idarticulo = (select idArt from articulo where serialArt='" + pidartic + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreamodelo(String nombre, String usuario, String bd)
        {
            sql = "INSERT INTO modelo (nombMod,fcreacion,user) VALUES ('" + nombre + "',(select sysdate()),'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreafabricante(String nombre, String usuario, String bd)
        {
            sql = "INSERT INTO fabricante (nombFabric,fcreacion,user) VALUES ('" + nombre + "',(select sysdate()),'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreacategoria(String nombre, String vida, String usuario, String bd)
        {
            sql = "INSERT INTO categoria (nombCat,fcreacion,vidaUtil,user,usermod) VALUES ('" + nombre + "',(select sysdate())," + vida + ",'" + usuario + "','" + usuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int McreaTercero(String cc, String nombre, String dir, String tele,
            String ciudad, String email, String usuario, String bd)
        {
            sql = "INSERT INTO persona (id,nomb,fcreacion,esempleado,usuario,pass,email,dir,tel,idciudad,esproveedor,user) VALUES ('" + cc + "','" + nombre + "',(select sysdate()),0,'','','" + email + "','" + dir + "','" + tele + "','" + ciudad + "',1,'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int McreaTerceroempleado(String cc, String nombre, String dir, String tele,
            String ciudad, String email, String usuario, String bd)
        {
            sql = "INSERT INTO persona (id,nomb,fcreacion,esempleado,usuario,pass,email,dir,tel,idciudad,esproveedor,user) VALUES ('" + cc + "','" + nombre + "',(select sysdate()),1,'','','" + email + "','" + dir + "','" + tele + "','" + ciudad + "',0,'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreafiscal(String pidartic, String pid, String usua, String pubica,
            String pidar, String fecha, String pidacta, String bd)
        {
            sql = "INSERT INTO fiscal (idarticulo,idresponsable,usuario,idubicacion,idarea,fmod1,idacta) VALUES ((select idArt from articulo where serialArt='" + pidartic + "'),(select idResp from persona where nomb='" + pid + "'),'" + usua + "'," +
                " (select idubica from ubicacion where nombUbica= '" + pubica + "')," +
                " (select id from area where nombrearea='" + pidar + "'),'" + fecha + "','" + pidacta + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcrea_area(string idubica, string pnombre, string puser, String bd)
        {
            sql = "INSERT INTO AREA SET IDUBICACION=(select idubica from ubicacion where nombUbica='" + idubica + "'),NOMBREAREA='" + pnombre + "',USER='" + puser + "'";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal int Mcreadetalleacta(String pidacta, String particulo, String presponsable
                , String pubicacion, String parea, String pobserva,
            String pfechaa, String pfechacrea, String user, String bd)
        {
            sql = "INSERT INTO detalleactas (idacta,idarticulo,idresponsable,idubicacion,idarea,observaciones,fechaAsignado,fechacreacion,user) VALUES ('" + pidacta + "',(select idArt from articulo where serialArt='" + particulo + "'),(select idResp from persona where nomb='" + presponsable + "'),(select idubica from ubicacion where nombUbica= '" + pubicacion + "'),(select id from area where nombrearea='" + parea + "'),'" + pobserva + "','" + pfechaa + "','" + pfechacrea + "','" + user + "')";
            return dataload.MysqlProcedimiento(sql, bd);
        }
        internal DataSet listadoprecios()
        {
            sql = "SELECT barrido_precios.barp_detalle as Detalle," +
                "barrido_precios.barp_codbarra as Codbar,barrido_precios.barp_precio as Precio," +
                "barrido_precios.barp_peso as Peso,barrido_precios.barp_plu as Plu," +
                "barrido_precios.barp_fecha as Fecha from barrido_precios";
            return dataload.sqlconsulta(sql);
        }
    }
}
