using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Intranet.conexiona;
using System.Data;

namespace Intranet.modelo
{
    public class ModeloSql
    {
        Bdconexion con = new Bdconexion();
        Bdconexion dataload = new Bdconexion();
        String sql = String.Empty;
        String sql1 = String.Empty;


        internal DataSet Mdatoscontratonomina(String terceroID,
            String fechaini,
            String fechafin) //--Desprendible Nomina aqui sacamos el dato del contrato
        {
         sql = "declare @contratoID as nvarchar(20) " +
         "set @contratoID = (select contrato.id from th.contrato " +
         "where terceroID = '"+terceroID+"' " +
         "and fechaini<= CONVERT (date, GETDATE()) " +
         "and(fechafin is null or fechafin >= CONVERT (date, GETDATE()) )) " +
	     "select @contratoID as NumeroContrato";
            return dataload.sqlconsulta(sql);
        }



        //espacio para inventarios
        internal int mabreconteo(string codigo)
        {
            sql = "update invenfis set protejido=0, estado='Conteo Abierto'  where id='" + codigo + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal DataSet mverificausuariosincro()
        {
            sql = "select * from __VERSION";
            return dataload.sqlsincro(sql);
        }
        internal int mactivasincro()
        {
            sql = "ALTER login usuariosincro WITH PASSWORD = 'sincro123.'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int minactivasincro()
        {
            sql = "ALTER login usuariosincro WITH PASSWORD = 'Claveerrada'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int mlimpiaconteo(string codigo)
        {
            sql = "delete  invenfisdet where invenfisID='" + codigo + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int mcierraconteo(string codigo2)
        {
            sql = "update invenfis set protejido=1, estado='Conteo Cerrado'  where id='" + codigo2 + "'";
            return dataload.sqlProcedimiento(sql);
        }

        internal DataSet mtotalconteo1()
        {
            sql = "select count(*) from invenfis where grupoinvenfisID=31";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mlistaabiertos(string codigo)
        {
            sql = "select id,nombre from invenfis where protejido=0 and invenfis.grupoinvenfisID='" + codigo + "'";
            return dataload.sqlconsulta(sql);
        }
        // inicia recibo de mercancia
        internal DataSet Mlistaarticulos(string codigo)
        {
            sql = "select a.codigo,a.detalle,ta.piva,ta.codigo,factor=iif(p.factor is null,1,p.factor),nombre=iif(p.nombrepres is null,'UNIDAD',p.nombrepres),a.refprovee" +
                "       from codbar c" +
                "       left  join presentacion p on p.id = c.presentacionID" +
                "       inner  join articulo a on a.codigo = c.articuloID" +
                "       inner  join tariva ta on ta.codigo = a.tarivaID" +
                "       where c.codbarra = '"+codigo+"' ";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet MlistaCostoArticulos(string codigo)
        {
            sql = "select  top(1) vrcostounitneto  from codbar c  " +
                "                INNER JOIN arthistocompra ahc on ahc.articuloID = c.articuloID" +
                "   where codbarra = '"+codigo+"'  and ahc.fechahasta >= getdate() and ahc.proveedorID is not null  order by fechadesde desc";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mlista_cant_items(string codigo)
        {
            sql = "select a.codigo,cb.codbarra,a.detalle, a.inactivo   from articulo a  inner  join codbar cb on a.codigo = cb.articuloID   where cb.codbarra = '" + codigo + "'";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet mlista_ordencompra(string codigo,string numero)
        {
            sql = "SELECT d.tipo ," +
                "  d.numero, " +
                "  t.nombre," +
                "   d.fecha, " +
                "    d.TerceroID1 as Tercero,  " +
                "    format(d.vrsubtotal, '$ #,###.##') as [Valor Costo Total], " +
                "     d.logfecreo as [Fecha Creacion], " +
                "      d.logusucreo as Usuario," +
                "       count(it.articuloID) as Items" +
                "        from documento d" +
                "                         inner join tipodoc t on t.codigo = d.tipo" +
                "                     inner  join itart it on d.id = it.documentID" +
                "                                                  where d.tipo = '"+codigo+"'  and cast(numero as int)  = '"+numero+"'" +
                "                                                  group by d.tipo,d.numero,t.nombre,d.TerceroID1,d.vrsubtotal,d.fecha,d.logfecreo,d.logusucreo";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet Mlista_Items_ordencompra(string codigo, string numero)
        {
            sql = "SELECT it.articuloID," +
                "cast(it.cantidadpres as int)," +
                "a.detalle," +
                "it.vrcosto," +
                "ta.piva," +
                "ta.codigo , a.refprovee " +
                "                 from itart it" +
                "                  inner" +
                "                 join documento d on d.id = it.documentID" +
                "           inner" +
                "                 join tipodoc t on t.codigo = d.tipo" +
                "           inner" +
                "                 join articulo a on a.codigo = it.articuloID " +
                "                  inner  join tariva ta on ta.codigo=a.tarivaID " +
                "                       where   d.tipo = '"+codigo+"' and cast(d.numero as int) = '"+numero+"' ";
            return dataload.sqlconsulta(sql);
        }
        //TODO: AQUI
        internal DataSet mlista_esta_ono(string ptipo,string pnumero,string pcodbar)
        {
            sql = "SELECT it.articuloID,a.detalle, cast(it.cantidadpres as int) cant,d.numero,IT.vrcosto" +
                "                FROM ITART IT" +
                "                 inner join documento d on d.id = it.documentID" +
                "                 INNER join articulo a on a.codigo = it.articuloID" +
                "                 inner join codbar cb on a.codigo = cb.articuloID" +
                "                  left join presentacion p on p.articuloID = a.codigo and(p.id = cb.presentacionID or(p.id is null and cb.presentacionID is null))" +
                "                 WHERE d.tipo = '"+ptipo+"'" +
                "                 and d.numero = '"+pnumero+"'" +
                "                and cb.codbarra = '"+pcodbar+"'";
            return dataload.sqlconsulta(sql);
        }
        //finaliza recibo de mercancia
        internal DataSet mtotalconteo2()
        {
            sql = "select count(*) from invenfis where grupoinvenfisID=32";
            return dataload.sqlconsulta(sql);
        }
        internal DataSet RotacionInventario(string proveedor, string fecha1,string fecha2)
        {
            sql = "SET NOCOUNT ON;" +
                " declare @fecha1 as date = '"+fecha1+"'" +
                " ,@fecha2 as date = '" + fecha2 + "' " +
                "select" +
                "            fin.articuloID," +
                "			fin.Articulo," +
                "			 CantidadInicial," +
                "			round(CantidadInicial * costoPromedio, 2) as CostoInicial," +
                "			fin.cantventa," +
                "			fin.PromedioCantidadVentaDia," +
                "			fin.saldocant," +
                "			round(fin.saldocant * fin.costoPromedio, 2) as CostoFinal," +
                "					(fin.saldocant / fin.PromedioCantidadVentaDia) DiasInventario" +
                "					,FechaUltimoTraslado" +
                "					,FechaUltimaCompra," +
                "			fin.[Nombre Bodega]," +
                "			fin.Marca," +
                "			fin.Grupo," +
                "			fin.Linea," +
                "			fin.nombre as Proveedor," +
                "			fin.costoPromedio," +
                "			fin.proveedorID " +
                "from (" +
                "    SELECT  t.articuloID," +
                "           a.detalle[Articulo]," +
                "            t.cantventa," +
                "            t.cantventa / DATEDIFF(dd, @fecha1, @fecha2) as PromedioCantidadVentaDia," +
                "            t.saldocant," +
                "            t.saldocosto," +
                "            b.nombre[Nombre Bodega]," +
                "            ma.nombre[Marca]," +
                "            gr.nombre[Grupo]," +
                "            ln.nombre[Linea]," +
                "            --(SELECT TOP 1 proveedorID from arthistocompra lc WHERE lc.articuloID = t.articuloID AND @fecha2 >= lc.fechadesde AND @fecha2 <= lc.fechahasta) as proveedorID" +
                "            lc.proveedorID," +
                "			ter.nombre," +
                "			lc.fechadesde," +
                "			CantidadInicial," +
                "			UltimoTraslado.FechaUltimoTraslado," +
                "			UltimaCompra.FechaUltimaCompra," +
                "			costoPromedio" +
                "    FROM(" +
                "        SELECT COALESCE(venta.articuloID, s.articuloID) articuloID," +
                "            COALESCE(venta.bodegaID, s.bodegaID) bodegaID," +
                "            venta.cantventa," +
                "            s.saldocant," +
                "            venta.vrtotal," +
                "            s.saldocosto," +
                "            costoPromedio" +
                "        FROM(" +
                "                SELECT itventa.articuloID," +
                "                        itventa.bodegaID," +
                "                        SUM(itventa.vrtotal) vrtotal," +
                "                        SUM(itventa.cantidad) cantventa" +
                "                FROM dbo.itart itventa INNER JOIN dbo.documento venta ON itventa.documentID = venta.id" +
                "                        INNER JOIN dbo.tipodoc td ON venta.tipo = td.codigo" +
                "                WHERE venta.fecha BETWEEN @fecha1 AND @fecha2" +
                "                        AND venta.anulado = 0" +
                "                        AND td.clasedoc IN('FV', 'FP', 'DV', 'DP')" +
                "                GROUP BY itventa.articuloID" +
                "                        , itventa.bodegaID" +
                "            ) venta FULL JOIN" +
                "                (SELECT articuloID" +
                "                        , bodegaID" +
                "                        , saldocant" +
                "                        , saldocosto" +
                "                        , fn.costoPromedio" +
                "                FROM dbo.fnInventInventariosBase(@fecha2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0) fn" +
                "                ) s ON venta.articuloID = s.articuloID AND venta.bodegaID = s.bodegaID" +
                "        ) t" +
                "            OUTER APPLY(" +
                "            select top 1 d.fecha as FechaUltimoTraslado" +
                "            from dbo.documento d inner" +
                "            join itart it on it.documentID = d.id inner" +
                "            join tipodoc td on td.codigo = d.tipo" +
                "            where td.clasedoc = 'NT'" +
                "                    and it.articuloID = t.articuloID" +
                "                    and it.bodegaID = t.bodegaID" +
                "                    and d.fecha <= @fecha2" +
                "                    order by d.fecha desc" +
                "                )UltimoTraslado" +
                "            OUTER APPLY(" +
                "            select top 1 d.fecha as FechaUltimaCompra" +
                "            from dbo.documento d inner" +
                "            join itart it on it.documentID = d.id inner" +
                "            join tipodoc td on td.codigo = d.tipo" +
                "            where td.clasedoc = 'FC'" +
                "                    and it.articuloID = t.articuloID" +
                "                    and it.bodegaID = t.bodegaID" +
                "                    and d.fecha <= @fecha2" +
                "                    order by d.fecha desc" +
                "                )UltimaCompra" +
                "            inner join dbo.bodega b on b.codigo = t.bodegaID" +
                "            inner join articulo a on t.articuloID = a.codigo" +
                "            inner join dbo.grupo as gr on a.grupoID = gr.codigo" +
                "            inner join dbo.linea as ln on a.lineaID = ln.codigo" +
                "            inner join dbo.marca as ma on a.marcaID = ma.codigo" +
                "            left join(select SUM(it.cantidad) as CantidadInicial" +
                "							  ,it.articuloID" +
                "							  ,it.bodegaID" +
                "                       FROM dbo.itinvent it" +
                "                                INNER JOIN dbo.documento venta ON it.documentID = venta.id" +
                "                                INNER JOIN dbo.tipodoc td ON venta.tipo = td.codigo" +
                "                            WHERE venta.fecha < @fecha1" +
                "                                AND venta.anulado = 0" +
                "                                GROUP BY" +
                "                                it.articuloID,it.bodegaID" +
                " 					)salini on salini.articuloID = t.articuloID and t.bodegaID = salini.bodegaID" +
                "            LEFT JOIN(SELECT t.articuloID, t.proveedorID, t.fechadesde" +
                "                        FROM (" +
                "                            SELECT ROW_NUMBER() OVER(PARTITION BY articuloID ORDER BY articuloID, fechadesde desc) rnum," +
                "							articuloID, " +
                "							proveedorID," +
                "							fechadesde" +
                "                            from arthistocompra lc" +
                "                            WHERE @fecha2>= lc.fechadesde AND @fecha2<= lc.fechahasta) T" +
                "                          where T.rnum = 1 ) lc ON lc.articuloID = t.articuloID" +
                "            left join dbo.tercero as ter on ter.id = lc.proveedorID" +
                "            where a.inactivo = 0			)fin where fin.proveedorID = '"+proveedor+"'";
            return dataload.sqlconsulta(sql);
        }
        internal int mabreocierraRangoConteos(string pidinici, string pidfinn, int protejido)
        {
            sql = "update invenfis set protejido=" + protejido + ", estado='Conteo Cerrado'  where id between'" + pidinici + "' and '" + pidfinn + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int mFecharangoconteos(string pidIni, string pIdfin, string pFecha)
        {
            sql = "update invenfis set fecha='" + pFecha + "' where id between '" + pidIni + "' and '" + pIdfin + "'";
            return dataload.sqlProcedimiento(sql);
        }
        internal int mbodegarangoconteos(string pidIni, string pIdfin, string pbodega)
        {
            sql = "update invenfis set bodegaID='" + pbodega + "' where id between '" + pidIni + "' and '" + pIdfin + "'";
            return dataload.sqlProcedimiento(sql);
        }
        //termina inventarios


        //espacio para cumpleñeros
        internal DataSet mlistacumpleañeros()
        {
            sql = "SELECT T.claseter as TipoTer,T.id,T.nombrecompleto as Nombre,T.telefono FROM dbo.tercero T where MONTH(T.nacio)= Month(getdate()) and day(T.nacio)= day(getdate())";
            return dataload.sqlconsulta(sql);
        }
        internal int Mactivaconteos2()
        {
            sql = "update invenfis set protejido=0, estado='Conteo Abierto' where grupoinvenfisID=32";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mcierraconteos2()
        {
            sql = "update invenfis set protejido=1 , estado='Conteo Cerrado' where grupoinvenfisID=32";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mcierraconteos1()
        {
            sql = "update invenfis set protejido=1, estado='Conteo Cerrado'  where grupoinvenfisID=31";
            return dataload.sqlProcedimiento(sql);
        }
        internal int Mactivaconteos1()
        {
            sql = "update invenfis set protejido=0, estado='Conteo Abierto' where grupoinvenfisID=31";
            return dataload.sqlProcedimiento(sql);
        }

        //cierra espacio modulo inventario

        internal DataSet listadoarticulosfruver()
        {
            sql = "select concat(codigo,' / ',detalle)as articulo from articulo " +
                " where lineaID=010 " +
                " and inactivo=0  " +
                "   and grupoID<>'00000373' " +
                "  order by detalle asc";
            return dataload.sqlconsulta(sql);
        }
    }
}