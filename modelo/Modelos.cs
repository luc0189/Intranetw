using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.conexiona;
using System.Data;

namespace Intranet.modelo
{
    public class Modelos
    {
        Bdconexion con = new Bdconexion();
        Bdconexion dataload = new Bdconexion();
        String sql = String.Empty;
        String sql1 = String.Empty;
        internal DataSet listadoacta(String ip)
        {
            sql = "@call acta('"+ip+"');";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet listadoactivo()
        {
            sql = "select a.inactivo as Activo,f.idarticulo as ID,a.serialArt as Serial,a.nombreArt as NOMBRE_ACTIVO,p.nomb as Asignado_a,u.nombUbica as Ubicacion from articulo a inner join fiscal f on f.idarticulo=a.idArt inner join persona p on f.idresponsable= p.idResp inner join ubicacion  u on u.idUbica=f.idubicacion";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet listadoActas()
        {
            sql = "SELECT IDACTA,FECHACREACION,NOMB,NOMBUBICA,OBSERVACIONES FROM DETALLEACTAS  INNER JOIN PERSONA ON IDRESPONSABLE=IDRESP  INNER JOIN UBICACION ON IDUBICACION=IDUBICA GROUP BY IDACTA";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet mlistasaldos(string idart)
        {
            sql = "select nombUbica as Ubicacicion,(sum(kard_entrada) - sum(kard_salida)) as Saldos   from kardex k  inner join ubicacion u on k.kard_bodegaid=u.idUbica where kard_idarticulo=(select idArt from articulo where serialArt='" + idart + "') group by kard_bodegaid";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet msaldoactual(string idart,string bodega)
        {
            sql = "select nombUbica as Ubicacicion,(sum(kard_entrada) - sum(kard_salida)) as Saldos   from kardex k  inner join ubicacion u on k.kard_bodegaid=u.idUbica where kard_idarticulo=(select idArt from articulo where serialArt='"+idart+"') AND u.idUbica=(SELECT AU.idUbica FROM ubicacion AU WHERE AU.nombUbica='"+bodega+"') group by kard_bodegaid";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet listado()
        {
            sql = "select a.inactivo as activo,a.idArt as Id,a.serialArt as Serial,a.nombreArt as NOMBRE_ACTIVO,a.valoruntArt as VALOR,a.timeGarant as GARANTIA, p.nomb as Proveedor,a.fcompArt as Fecha_Compra  from articulo a inner join persona p on a.proveedor= p.idResp";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet msaldokardexgeneral()
        {
            sql = " SELECT a.nombreArt, SUM(k.kard_entrada)-sum(k.kard_salida) as saldos, u.nombUbica from kardex k inner join articulo a  on k.kard_idarticulo= a.idArt inner join ubicacion u        on k.kard_bodegaid= u.idUbica group by kard_idarticulo, kard_bodegaid order by a.nombreArt asc";
            return dataload.MySqlQuery(sql);
        }
       
        internal DataSet msaldokardex(string fechaini, string fechafin,string serial,string pbodega)
        {
            sql = "select kard_fecha as Fecha_creacion,kard_fechamovimiento as Fecha,kard_registradopor as Usuario,kard_entrada AS ENTRADA,kard_salida AS SALIDA, kard_comentario AS DETALLE from kardex where kard_idarticulo= (select idArt from articulo where serialArt='"+serial+"') AND kard_fecha between '"+fechaini+"' and '"+ fechafin +" 23:59:00'  and kard_bodegaid=(select idUbica from ubicacion where nombUbica='" + pbodega + "')";
            return dataload.MySqlQuery(sql);
        }
        //con esta parte del codigo puedo llenar los select2 sin necesidad del sql local
        //-----------------------------------------------------------------------------
        internal DataSet listaseriales()
        {
            sql = "select CONCAT(serialArt, ' / ', nombreArt) As Nombre  FROM articulo";
            return dataload.MySqlQuery(sql);
        }
        //-----------------------------------------------------------------
        //con esta parte del codigo lleno la informacion principal de un activo fijo
        //-----------------------------------------------------------------------------
        internal DataSet activodatosgenerales(String pserial)
        {
            sql = "select a.serialArt, nombreArt,m.nombMod,f.nombFabric,c.nombCat,p.nomb,a.fcompArt,a.valoruntArt,comentArt,a.timeGarant from articulo a inner join modelo m on m.idMod=a.modArt inner join fabricante f on f.idFabric=a.fabriArt inner join categoria c on c.idcat=a.categArt inner join persona p on p.idResp=a.proveedor where a.serialArt='" + pserial + "'";
            return dataload.MySqlQuery(sql);
        }
        //-----------------------------------------------------------------
        //----------------------------------------------------------------
        // aqui consulta carnes todos los puntos  BNET
        //----------------------------------------------------------------
        internal DataSet listadocarnes16(String pgrupo,String fechaini,String fechafin)
        {
            sql = "select itart.presentacion ,cast (sum(itart.cantidad)as float) cantidad from itart, documento, articulo, tipodoc where articulo.codigo=itart.articuloID and itart.documentID= documento.id and documento.tipo= tipodoc.codigo and fecha between  '"+fechaini+"' and '"+fechafin+"' and tipodoc.clasedoc='FP' and grupoID='"+pgrupo+"' and documento.ccostoId='000001' group by presentacion,documento.ccostoId";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadocarnes13(String pgrupo, String fechaini, String fechafin)
        {
            sql = "select itart.presentacion ,cast (sum(itart.cantidad)as float) cantidad from itart, documento, articulo, tipodoc where articulo.codigo=itart.articuloID and itart.documentID= documento.id and documento.tipo= tipodoc.codigo and fecha between  '" + fechaini + "' and '" + fechafin + "' and tipodoc.clasedoc='FP' and grupoID='" + pgrupo + "' and documento.ccostoId='000002' group by presentacion,documento.ccostoId";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadocarnesversa(String pgrupo, String fechaini, String fechafin)
        {
            sql = "select itart.presentacion ,cast (sum(itart.cantidad)as float) cantidad from itart, documento, articulo, tipodoc where articulo.codigo=itart.articuloID and itart.documentID= documento.id and documento.tipo= tipodoc.codigo and fecha between  '" + fechaini + "' and '" + fechafin + "' and tipodoc.clasedoc='FP' and grupoID='" + pgrupo + "' and documento.ccostoId='000004' group by presentacion,documento.ccostoId";
            return dataload.sqlconsultaversalles(sql);
        }
        //----------------------------------------------------------------
        //-----------------------------------------------------------------
        //----------------------------------------------------------------
        // aqui consulta carnes todos los puntos  BASCULAS
        //----------------------------------------------------------------
        internal DataSet listadocarnesBS16(String pgrupo, String fechaini, String fechafin)
        {
            string dato = "";
            if (pgrupo== "00000357")
            {
                dato = "POLLO";
            }
            sql = "SELECT dat_ticket_linea.descripcion, SUM(dat_ticket_linea.peso)as Peso FROM dat_ticket_cabecera, dat_ticket_linea where dat_ticket_cabecera.idticket = dat_ticket_linea.idticket  and dat_ticket_cabecera.idbalanzamaestra = dat_ticket_linea.idbalanzamaestra and dat_ticket_cabecera.fecha between '"+fechaini+" 00:23:23' and '"+fechafin+" 23:01:01'and nombreseccion = '"+dato+"' GROUP BY descripcion";
            return dataload.MySqlQuerycarnes(sql);
        }
        internal DataSet listadocarnesBS13(String pgrupo, String fechaini, String fechafin)
        {
            string dato = "";
            if (pgrupo == "00000357")
            {
                dato = "POLLO";
            }
            sql = "SELECT dat_ticket_linea.descripcion, SUM(dat_ticket_linea.peso)as Peso FROM dat_ticket_cabecera, dat_ticket_linea where dat_ticket_cabecera.idticket = dat_ticket_linea.idticket  and dat_ticket_cabecera.idbalanzamaestra = dat_ticket_linea.idbalanzamaestra and dat_ticket_cabecera.fecha between '" + fechaini + " 00:23:23' and '" + fechafin + " 23:01:01'and nombreseccion = '" + dato + "' GROUP BY descripcion";
            return dataload.MySqlQuerycarnesLA13(sql);
        }
        internal DataSet listadocarnesBVERSA(String pgrupo, String fechaini, String fechafin)
        {
            string dato = "";
            if (pgrupo == "00000357")
            {
                dato = "POLLO";
            }
            sql = "SELECT dat_ticket_linea.descripcion, SUM(dat_ticket_linea.peso)as Peso FROM dat_ticket_cabecera, dat_ticket_linea where dat_ticket_cabecera.idticket = dat_ticket_linea.idticket  and dat_ticket_cabecera.idbalanzamaestra = dat_ticket_linea.idbalanzamaestra and dat_ticket_cabecera.fecha between '" + fechaini + " 00:23:23' and '" + fechafin + " 23:01:01'and nombreseccion = '" + dato + "' GROUP BY descripcion";
            return dataload.MySqlQuerycarnesVERSA(sql);
        }
        //----------------------------------------------------------------
        internal DataSet listadogeneral()
        {
            sql = "select a.inactivo,a.serialArt,a.nombreArt,fr.nombFabric,p.nomb,u.nombUbica from articulo a inner join fiscal f on a.idArt=idarticulo inner join fabricante fr on a.fabriArt=fr.idFabric inner join persona p on f.idresponsable=p.idResp  inner join ubicacion u on f.idubicacion=u.idUbica";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet validacionUsuario(string usuario, string contraseña)
        {
            sql = " select USUA_NOMBRE,PERS_TIPP_ID FROM LCSYSTEM.USUARIO INNER JOIN LCSYSTEM.PERSONA ON USUA_IDPERS = PERS_ID  WHERE USUA_NOMBRE= '"+usuario+"' and USUA_PASS='"+contraseña+"'";
            return dataload.oraconsulta(sql);
        }
        internal DataSet llenatabla()
        {
            sql = "select PERS_ID AS ID,PERS_NOMBRE1 AS PRIMER_NOMBRE,PERS_APELLIDO1 AS PRIMER_APELLIDO FROM LCSYSTEM.PERSONA";
            return dataload.oraconsulta(sql);
        }
        internal DataSet listadoventa16(string fei,string fef)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(DD, do.logfecreo) AS DIAS, format(Sum(do.vrsubtotal), '$ #,###.##') AS VALOR,COUNT(vrsubtotal) AS Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE(do.fecha BETWEEN '"+fei+"' AND '"+fef+"')  AND(td.clasedoc = 'FP')  AND do.ccostoID = '000001'  and do.anulado=0 GROUP BY DATEPART(DD, do.logfecreo) order by DIAS";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventa16total(string fecha)
        {
            sql = "SELECT   format(Sum(do.vrsubtotal), '$ #,###.##') AS Total_Ventas,COUNT(vrsubtotal) AS Total_Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE fecha='"+fecha+"'  AND(td.clasedoc = 'FP')  AND do.ccostoID = '000001'  and do.anulado=0 ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventa13total(string fecha)
        {
            sql = "SELECT   format(Sum(do.vrsubtotal), '$ #,###.##') AS Total_Ventas,COUNT(vrsubtotal) AS Total_Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE fecha='" + fecha + "'  AND(td.clasedoc = 'FP')  AND do.ccostoID = '000002'  and do.anulado=0 ";

            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaversatotal(string fecha)
        {
            sql = "SELECT format(Sum(do.vrsubtotal), '$ #,###.##') AS Total_Ventas,COUNT(vrsubtotal) AS Total_Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE fecha='" + fecha + "'  AND(td.clasedoc = 'FP')  AND do.ccostoID = '000004'  and do.anulado=0 ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventa13(string fei, string fef)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(DD, do.logfecreo) AS DIAS, format(Sum(do.vrsubtotal), '$ #,###.##') AS VALOR,COUNT(vrsubtotal) AS Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE(do.fecha BETWEEN '"+fei+"' AND '"+fef+"')  AND(td.clasedoc = 'FP')  AND do.ccostoID = '000002'  and do.anulado=0 GROUP BY DATEPART(DD, do.logfecreo) order by DIAS";
            return dataload.sqlconsulta(sql);
        }
        //espacio para la 14 distribuciones
        internal DataSet MClista_la14aux(string fei, string fef, string fcuenta)
        {
            string H = ".,";
            sql = "SELECT * FROM (SELECT COD_CUENTA as CUENTA,I.FCH_DOCUMENTO,TIPO_DOCUMENTO(ID_TIPO_DOCUMENTO) TIPO, NUM_DOCUMENTO as NO_DOCU,'$'||TO_CHAR(VALOR,'999G999G999G999G999','NLS_NUMERIC_CHARACTERS = " + H+"')  VALOR, NIT_TERCERO(I.ID_TERCERO) TERCERO,I.OBSER AS OBSERVACIONES_DOCU FROM CO_CUENTAS C,CO_DOCUMENTOS D, CO_DOCUMENTO_ITEMS I WHERE D.ID_DOCUMENTO = I.ID_DOCUMENTO  AND C.ID_CUENTA    = I.ID_CUENTA  AND COD_CUENTA LIKE('" + fcuenta+"'||'%')  AND I.FCH_DOCUMENTO BETWEEN TO_DATE('"+fei+"','YYYY-MM-DD') AND TO_DATE('"+fef+ "','YYYY-MM-DD') AND C.ID_SISTEMA = '1'ORDER BY COD_CUENTA,I.FCH_DOCUMENTO)";
            return dataload.orala14consulta(sql);
        }
        internal DataSet MClista_la14VENTAS(string fei, string fef)
        {
            string H = ".,";
            sql = "SELECT  '$'||TO_CHAR(Sum(VENT_TOT_SIN_IVA),'999G999G999G999G999','NLS_NUMERIC_CHARACTERS =.,')  VALOR ,VENDEDOR FROM V_VENTAS  WHERE FECHA BETWEEN TO_DATE('"+fei+"','YYYY-MM-DD') AND TO_DATE('"+fef+"','YYYY-MM-DD') GROUP BY VENDEDOR  ORDER BY VALOR DESC";
            return dataload.orala14consulta(sql);
        }

        //espacio para inventarios
        internal int mabreconteo(string codigo)
        {
            sql = "update invenfis set protejido=0 where id='"+codigo+"'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int mlimpiaconteo(string codigo)
        {
            sql = "delete from invenfisdet where invenfisID='" + codigo + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int mcierraconteo(string codigo2)
        {
            sql = "update invenfis set protejido=1 where id='" + codigo2 + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal DataSet mtotalconteo1()
        {
            sql = "select count(*) from invenfis where grupoinvenfisID=31";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mtotalconteo2()
        {
            sql = "select count(*) from invenfis where grupoinvenfisID=32";
            return dataload.sqlconsulta(sql);
        }
        internal int Mactivaconteos2()
        {
            sql = "update invenfis set protejido=0 where grupoinvenfisID=32";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mactivaconteos1()
        {
            sql = "update invenfis set protejido=0 where grupoinvenfisID=31";
            return dataload.sqlProcedimiento(sql);
        }

        //cierra espacio modulo inventario
        internal DataSet listadoventaXarticulocajera(string fei, string fef,string articuloid)
        {
            sql = "SELECT  Top(10) articulo.detalle,documento.logusucreo, SUM(CAST(itart.cantidad AS float)) AS cantidad, SUM(itart.vrtotal) AS valor_total FROM itart INNER JOIN articulo ON itart.articuloID = articulo.codigo INNER JOIN documento ON itart.documentID = documento.id INNER JOIN tipodoc ON documento.tipo = tipodoc.codigo WHERE(documento.fecha BETWEEN '"+fei+"' AND '"+fef+"') AND(tipodoc.clasedoc = 'FP') AND(articulo.codigo = '"+articuloid+"') GROUP BY documento.logusucreo,articulo.detalle ORDER BY cantidad DESC";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listadoventaVERSA(string fei, string fef)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(DD, do.logfecreo) AS DIAS, format(Sum(do.vrsubtotal), '$ #,###.##') AS VALOR,COUNT(vrsubtotal) AS Facturas FROM  dbo.documento AS do INNER JOIN  dbo.tipodoc AS td ON do.tipo = td.codigo WHERE(do.fecha BETWEEN '" + fei + "' AND '" + fef + "')  AND(td.clasedoc = 'FP')  AND do.ccostoID = '000004'  and do.anulado=0 GROUP BY DATEPART(DD, do.logfecreo) order by DIAS";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventalocalVERSA(string useri,  string fei, string fef)
        {
            sql = "select format(Sum(vrtotal), '$ #,###.##') AS VALOR,count(*) as Facturas,logusucreo from documento where logusucreo LIKE ('%"+useri+"%')  AND fecha BETWEEN '"+fei+"' AND '"+fef+ "' AND anulado=0 AND ccostoID = '000004' group by logusucreo";
            return dataload.sqlconsultaversalles(sql);
        }
        internal DataSet ventalocalVERSAreco(string fecha, string ccosto)
        {
            sql = "select logusucreo,  format(Sum(itfpago.vrfpago), '$ #,###.##') AS VALOR  FROM  itfpago INNER JOIN  documento AS do   INNER JOIN   tipodoc AS td ON do.tipo = td.codigo ON itfpago.documentID = do.id      inner join fpago as fp  on fp.codigo=itfpago.fpagoID    WHERE  fp.detalle='EFECTIVO VERSALLES' and do.fecha ='"+fecha+"' AND anulado=0 AND do.ccostoID = '"+ccosto+"' GROUP BY logusucreo";
            return dataload.sqlconsultaversalles(sql);
        }
        internal DataSet listadetalleventalocalVERSA(string useri, string fei, string fef)
        {
            sql = "select  fp.detalle, format(Sum(itfpago.vrfpago), '$ #,###.##') AS VALOR  FROM  itfpago INNER JOIN  documento AS do   INNER JOIN   tipodoc AS td ON do.tipo = td.codigo ON itfpago.documentID = do.id      inner join fpago as fp  on fp.codigo=itfpago.fpagoID    WHERE  logusucreo LIKE ('%"+useri+"%')  AND do.fecha BETWEEN '"+fei+"' AND '"+fef+"' AND anulado=0 AND do.ccostoID = '000004' GROUP BY fp.detalle";
            return dataload.sqlconsultaversalles(sql);
        }
        internal DataSet listaefectivo(string fecha, string ccosto )
        {
            sql = " select format(Sum(do.vrtotal), '$ #,###.##') AS VALOR, COUNT(*) AS CANT_TIKECT, do.logusucreo FROM dbo.itfpago INNER JOIN dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo ON dbo.itfpago.documentID = do.id WHERE  (do.fecha = '"+fecha+"') AND(td.clasedoc = 'FP') and itfpago.fpagoID='001' and do.ccostoID= '"+ccosto+"' GROUP BY  do.logusucreo order by VALOR DESC";
            return dataload.sqlconsulta(sql);
        }
       
        internal DataSet listaventashora16(string Fecha)
        {
            sql= "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA,format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas,COUNT(*) AS Cant, COUNT(DISTINCT do.logusucreo) AS Users FROM dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo WHERE (do.fecha = '" + Fecha+"') AND (td.clasedoc = 'FP') AND do.ccostoID='000001' and do.anulado=0 GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet listaventashora13(string Fecha)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA,format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas,COUNT(*) AS Cant, COUNT(DISTINCT do.logusucreo) AS Users FROM dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo WHERE (do.fecha = '" + Fecha+"') AND (td.clasedoc = 'FP') AND do.ccostoID='000002' and do.anulado=0 GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }

        internal DataSet listaventashoraVERSA(string Fecha)
        {
            sql = "SELECT  TOP (100) PERCENT DATEPART(HH, do.logfecreo) AS HORA,format(Sum(do.vrsubtotal), '$ #,###.##') AS V_Facturas,COUNT(*) AS Cant, COUNT(DISTINCT do.logusucreo) AS Users FROM dbo.documento AS do INNER JOIN dbo.tipodoc AS td ON do.tipo = td.codigo WHERE (do.fecha = '"+Fecha+"') AND (td.clasedoc = 'FP') AND do.ccostoID='000004' and do.anulado=0 GROUP BY DATEPART(HH, do.logfecreo)";
            return dataload.sqlconsulta(sql);
        }
        internal DataTable McreaPERSONA(String pcc, String pnombre1, String pnombre2, String apellido1, String apellido2,
           String ptel, String pdireccion, String psexo, String ptipouser, String puser)
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
                return con.ProcedureSelectDB("LCSYSTEM.PRCREAR_PERSONA", crearp);


            }
            catch (Exception ex)


            {

                throw;
            }
        }
        internal DataTable Mcreausuario(String pid, String pusuario, String ppas, String pusu)
        {
            try
            {
                List<parametro> crearp = new List<parametro>();
                crearp.Add(new parametro("VALIDAREGISTRO", "", "CURSOR", ParameterDirection.Output));
                crearp.Add(new parametro("PID", pid, "NUMBER", ParameterDirection.Input));
                crearp.Add(new parametro("PUSUARIO", pusuario, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPAS", ppas, "VARCHAR", ParameterDirection.Input));
                crearp.Add(new parametro("PPOR", pusu, "VARCHAR", ParameterDirection.Input));
                return con.ProcedureSelectDB("LCSYSTEM.PRCREAR_USUARIO", crearp);
                
            }
            catch (Exception ex)


            {

                throw;
            }
        }
        internal DataTable Mlistausuarios()
        {
            try
            {
                List<parametro> RunLista = new List<parametro>();
                RunLista.Add(new parametro("CONSULTA", "", "CURSOR", ParameterDirection.ReturnValue));
                return con.ProcedureSelectDB("LCSYSTEM.FN_LISTAUSUARIOS", RunLista);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        internal DataSet listanumeroid()
        {
            sql = "SELECT max(idArt+1) as idArt from articulo";
            return dataload.MySqlQuery(sql);
        }
        internal int Mcreaactivo(String pid, String pserial, String pnombre, String pmodelo, String pfabricante,
            String pcategoria, String pcoment, String pproveedor, String pfechacompra, String pvalor, String pusuario, String pgarantia)
        {
          
                sql = "INSERT INTO articulo (idArt,serialArt,nombreArt,modArt,fabriArt,categArt,proveedor,fcompArt,valoruntArt,timeGarant,comentArt,fcreacArt,inactivo,user) VALUES ('"+pid+"','" + pserial + "','" + pnombre + "',( SELECT idMod FROM modelo where nombMod='" + pmodelo + "'),(SELECT idFabric FROM fabricante where nombFabric='" + pfabricante + "'),( SELECT idCat FROM categoria where nombCat='" + pcategoria + "'),(SELECT idResp FROM persona where nomb='" + pproveedor + "'),'" + pfechacompra + "','" + pvalor + "','" + pgarantia + "','" + pcoment + "','" + pfechacompra + "',1,'" + pusuario + "') ";
                return dataload.MysqlProcedimiento(sql);
        }
        internal int Mcreaacta(String pid,String pusuario, String observa,String data)
        {

            sql = "INSERT INTO rol (idRol,nombRol,observaciones,fcreacion) VALUES ('" + pid + "','" + pusuario + "','" + observa + "','" + data + "') ";
            return dataload.MysqlProcedimiento(sql);
        }
        //-------------------------------------------------------------------------------------------------------
        //ACTAS DE MANTENIMIENTOS
        //-------------------------------------------------------------------------------------------------------
        internal int McreaactaMantenimiento( String pproveedor, String data,String pusuario, String observa,String fechaacta)
        {
            sql = "INSERT INTO mantenimientos (mant_idproveedor,mant_fecha,mant_registradopor,mant_observaciones,mant_fcreado) VALUES ((select idResp from persona where nomb ='" + pproveedor + "'),'" + fechaacta + "','" + pusuario + "','"+observa+"','"+data+"') ";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int McreadetallesactaMantenimiento(String pid, String pidarticulo, String prepuestos, String pcostoobra, String pcostorepuestos, String pdetalle,String ptipomantenimiento,String pnumeroext)
        {
            sql = "INSERT INTO detamantenimientos (detm_idmantenimiento,detm_idarticulo,detm_repuestos,detm_costomanoobra,detm_costorepuestos,detm_detalle,detm_tipomantenimiento,detm_numeroexterno) VALUES ('" + pid + "',(select idArt from articulo where serialArt='" + pidarticulo + "'),'" + prepuestos + "',"+pcostoobra+"," + pcostorepuestos + ",'" + pdetalle + "','"+ptipomantenimiento+"','"+pnumeroext+"') ";
            return dataload.MysqlProcedimiento(sql);
        }
        internal DataSet mlistaactivosnombre()
        {
            sql = "select CONCAT(serialArt, ' / ', nombreArt) As Nombre  FROM articulo";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet mlistaPROVEEDORES()
        {
            sql = "select nomb FROM persona where esproveedor=true";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet mlistaNUEVONUMEROACTA()
        {
            sql = "SELECT count(mant_id)+1 as id from mantenimientos";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet mtraemanteni(String pserial)
        {
            sql = "select m.mant_fecha as FECHA,d.detm_detalle as DETALLE_MANTENIMIENTO,d.detm_costomanoobra as $_MANO_OBRA,detm_numeroexterno as No_EXTERNO from mantenimientos m inner join detamantenimientos d on m.mant_id=d.detm_idmantenimiento  where  detm_idarticulo= (select idArt from articulo where serialArt='"+pserial+"')and d.detm_";
            return dataload.MySqlQuery(sql);
        }
        //trae la info para editar las actas de mantenimineto
        internal DataSet mtraeactaeditar(String pidacta)
        {
            sql = "select d.detm_id as ID ,concat(a.serialArt, ' / ',a.nombreart )as nombre ,d.detm_repuestos as Repuestos ,d.detm_costomanoobra as Mano_Obra ,d.detm_costorepuestos as Costo_Repuestos ,d.detm_detalle as Detalle,d.detm_tipomantenimiento as Tipo_Mant ,d.detm_numeroexterno as Numero_externo  from detamantenimientos d  inner join mantenimientos m on d.detm_idmantenimiento = m.mant_id inner join articulo a on d.detm_idarticulo=a.idArt  where m.mant_id = '" + pidacta+"'";
            return dataload.MySqlQuery(sql);
        }
        //actualiza la linea de editing
        internal int Mupdatelineagridmanteni(String pid, String dato)
        {
            sql = "UPDATE detamantenimientos SET detm_repuestos='"+dato+"' WHERE detm_idmantenimiento='"+pid+"'";
            return dataload.MysqlProcedimiento(sql);
        }
        internal DataSet mtraerespuestos(String pserial)
        {
            sql = "select m.mant_fecha AS FECHA,d.detm_repuestos AS REPUESTOS,d.detm_costorepuestos AS COSTO_REPUESTOS,d.detm_numeroexterno as No_EXTERNO from mantenimientos m inner join detamantenimientos d on m.mant_id=d.detm_idmantenimiento  where  detm_idarticulo= (select idArt from articulo where serialArt='" + pserial + "') and d.detm_repuestos<>'&nbsp;'";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet mtraeconsecutivosmante()
        {
            sql = "select mant_id as id_acta,mant_idProveedor as Id_T,(select nomb from persona where idResp=mant_idProveedor)as Proveedor,mant_fecha as fecha,mant_observaciones from mantenimientos ";
            return dataload.MySqlQuery(sql);
        }
        internal int mupdatedetalle_actasm(string pserial,string p_tipomante,string pdetalle,string pcosto_mano_obra,string prepuestos,string pnumero_externo,string pcosto_repuestos, string pidmantenimiento,string pidacta)
        {
            sql = "update detamantenimientos set detm_idarticulo=(select idArt from articulo where serialArt='"+pserial+"'),detm_tipomantenimiento='"+p_tipomante+"',detm_detalle='"+pdetalle+"',detm_costomanoobra='"+pcosto_mano_obra+"',detm_repuestos='"+prepuestos+"'  ,detm_numeroexterno='"+pnumero_externo+"',detm_costorepuestos='"+pcosto_repuestos+"' where detm_idmantenimiento='"+pidmantenimiento+ "' and detm_id='"+pidacta+"'";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int mdeletedeta_mante(string pidacta)
        {
            sql = "delete from detamantenimientos where detm_id='" + pidacta + "'";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int mupdate_actasm(string p_idproveedor, string pfecha, string pobservaciones, string pidacta)
        {
            sql = "update mantenimientos set mant_idProveedor=(select idResp from persona where nomb='"+ p_idproveedor + "'),mant_fecha='"+ pfecha + "',mant_observaciones='"+pobservaciones+"' where mant_id='"+pidacta+"'";
            return dataload.MysqlProcedimiento(sql);
        }
        internal DataSet mtraeproveedor()
        {
            sql = "select CONCAT(idResp, ' / ',id, ' / ',nomb) Proveedor FROM persona where esempleado=false and esproveedor=true";
            return dataload.MySqlQuery(sql);
        }
        internal DataSet mtraeEmpleado()
        {
            sql = "select CONCAT(nomb) Proveedor FROM persona where esempleado=true";
            return dataload.MySqlQuery(sql);

        }

        //-------------------------------------------------------------------------------------------------------
        //aqui inicia incapacidades
        //-------------------------------------------------------------------------------------------------------
        internal int mcrea_incapacidad(string p_idempleado, string pobservaciones, string pfechaini, string pfechafin, string puser)
        {
            sql = "insert into incapacidades (INCA_IDPERSONA,INCA_MOTIVO,INCA_FECHAINICIAL,INCA_FECHAFINAL,INCA_FCREA,INCA_USUCREA)VALUE((select idResp  from persona where nomb='"+p_idempleado+"'),'"+pobservaciones+"','"+pfechaini+"','"+pfechafin+"',(select sysdate()),'"+puser+"')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int mborraincapacidad(string p_idincapacidad)
        {
            sql ="delete from incapacidades where inca_id='"+p_idincapacidad+"'";
            return dataload.MysqlProcedimiento(sql);
        }
        internal DataSet mtraeincapacidades()
        {
            sql = "select i.inca_id as ID,p.nomb as Nombre_Empleado, DATEDIFF(i.inca_fechafinal,i.inca_fechainicial)+1 as dias,i.inca_fechainicial as F_Inicial,i.inca_fechafinal as F_Final,i.inca_motivo as Motivo,inca_usucrea from incapacidades i inner join persona p on p.idResp=i.inca_idpersona";
            return dataload.MySqlQuery(sql);

        }
        internal int Mupdateincapacidad(string p_idempleado, string pobservaciones, string pfechaini, string pfechafin, string puser,string pidincapacidad)
        {
            sql = "update incapacidades set INCA_IDPERSONA=(select idResp from persona where nomb='"+p_idempleado+"'),INCA_MOTIVO='"+pobservaciones+"',INCA_FECHAINICIAL='"+pfechaini+"',INCA_FECHAFINAL='"+pfechafin+"',INCA_USUCREA='"+puser+"' WHERE INCA_ID='"+pidincapacidad+"' ";
            return dataload.MysqlProcedimiento(sql);
        }

        //-------------------------------------------------------------------------------------------------------
        //aqui finaliza incapacidades
        //-------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------
        //AQUI TERMINA ACTAS DE MANTENIMIENTOS 
        //-------------------------------------------------------------------------------------------------------
        //aqui ingreso cantidades al kardex
        internal int Mcreakardex(String pid, String entrada, String salida,  String observa, String pusuario,String BodegaId,String pfechamov)
        {

            sql = "INSERT INTO kardex (kard_idarticulo,kard_entrada,kard_salida,kard_comentario,kard_registradopor,kard_fecha,kard_bodegaid,kard_fechamovimiento) VALUES((select idArt from articulo where serialArt='" + pid + "')," + entrada+", "+salida+", '"+observa+"', '"+pusuario+ "',(select sysdate()),(select idUbica from ubicacion where nombUbica= '"+BodegaId+"' ),'"+pfechamov+"')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int McreaUbicacion(String nombre, String usuario)
        {
            sql = "INSERT INTO ubicacion (nombUbica,fcreacion,user) VALUES ('" + nombre + "',(select sysdate()),'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int Mcreacantidadactivo(String pid,String pserial, String cantidad)
        {
            sql = "INSERT INTO lcsystem.cantproducto(id,idproducto,cantidad,idresponsable) VALUES('"+pid+"',(select idArt from articulo where serialArt='"+pserial+"'), '"+cantidad+"', 0)";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int masigarticulo(String fecha)
        {
            sql = "insert into asigarticulos(fcreacion)values('" + fecha + "')";
            return dataload.MysqlProcedimiento(sql);
        }

        internal DataSet mselectfiscal(String pids)
        {
            sql = "select * from fiscal where idarticulo = (select idArt from articulo where serialArt='" + pids + "')";
            return dataload.MySqlQuery(sql);
        }
       
        internal int Mupdatefiscal(String pid, String pidubica, String pidar,String pidartic)
        {
            sql = "update fiscal set idresponsable = (select idResp from persona where nomb='" + pid+ "'), idubicacion = (select idubica from ubicacion where nombUbica= '" + pidubica + "'), idarea =(select id from area where nombrearea='" + pidar + "') where idarticulo = (select idArt from articulo where serialArt='" + pidartic + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int Mcreamodelo(String nombre,String usuario)
        {
            sql = "INSERT INTO modelo (nombMod,fcreacion,user) VALUES ('"+nombre+"',(select sysdate()),'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int Mcreafabricante(String nombre, String usuario)
        {
            sql = "INSERT INTO fabricante (nombFabric,fcreacion,user) VALUES ('" + nombre + "',(select sysdate()),'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int Mcreacategoria(String nombre, String vida,String usuario)
        {
            sql = "INSERT INTO categoria (nombCat,fcreacion,vidaUtil,user,usermod) VALUES ('" + nombre + "',(select sysdate())," + vida + ",'" + usuario + "','" + usuario + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int McreaTercero(String cc,String nombre, String dir, String tele, String ciudad, String email, String usuario)
        {
            sql = "INSERT INTO persona (id,nomb,fcreacion,esempleado,usuario,pass,email,dir,tel,idciudad,esproveedor,user) VALUES ('" + cc + "','" + nombre + "',(select sysdate()),0,'','','" + email + "','" + dir + "','" + tele + "','" + ciudad + "',1,'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int McreaTerceroempleado(String cc, String nombre, String dir, String tele, String ciudad, String email, String usuario)
        {
            sql = "INSERT INTO persona (id,nomb,fcreacion,esempleado,usuario,pass,email,dir,tel,idciudad,esproveedor,user) VALUES ('" + cc + "','" + nombre + "',(select sysdate()),1,'','','" + email + "','" + dir + "','" + tele + "','" + ciudad + "',0,'" + usuario + "')";
            return dataload.MysqlProcedimiento(sql);
        }
        internal int Mcreafiscal(String pidartic, String pid, String usua,String pubica, String pidar,String fecha)
        {
            sql = "INSERT INTO fiscal (idarticulo,idresponsable,usuario,idubicacion,idarea,fmod1) VALUES ((select idArt from articulo where serialArt='" + pidartic + "'),(select idResp from persona where nomb='" + pid + "'),'"+usua+ "',(select idubica from ubicacion where nombUbica= '" + pubica + "'),(select id from area where nombrearea='" + pidar + "'),'"+fecha+"')";
            return dataload.MysqlProcedimiento(sql);
        }
        
            internal int Mcreadetalleacta(String pidacta, String particulo, String presponsable
                , String pubicacion, String parea, String pcantidad, String pobserva, String pfechaa, String pfechacrea, String user)
        {
            sql = "INSERT INTO detalleactas (idacta,idarticulo,idresponsable,idubicacion,idarea,cant,observaciones,fechaAsignado,fechacreacion,user) VALUES ('"+pidacta+"',(select idArt from articulo where serialArt='" + particulo + "'),(select idResp from persona where nomb='" + presponsable + "'),(select idubica from ubicacion where nombUbica= '" + pubicacion + "'),(select id from area where nombrearea='" + parea + "'),'" + pcantidad + "','" + pobserva + "','" + pfechaa + "','" + pfechacrea + "','" + user + "')";
            return dataload.MysqlProcedimiento(sql);
        }
    }
}
