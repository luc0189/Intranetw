using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Intranet.modelo;

namespace Intranet.Controlador
{
    public class Controlasql
    {
        Modelos sb = new Modelos();

        public object MessageBox { get; private set; }

        internal DataSet Cconsusuario(string usua, string PS,string pbd)
        {
           try
            {
               return sb.validacionUsuario(usua, PS,pbd);
            }
          catch (Exception ex)

          
            {
                throw ex;


            }
       }

        public static DataSet CSalaventas(string pbd)
        {
            Modelos sb = new Modelos();
            try
            {
                return sb.Salasventas( pbd);
            }
            catch (Exception ex)


            {
                throw ex;


            }
        }


        public static DataSet listaRecogida(string pCcosto)
        {
            Modelos sb = new Modelos();
            String Ptipoefectivo = "";
            if (pCcosto.Equals("000001"))
            {
                Ptipoefectivo = "EFECTIVO CENTRO";

            }
            if (pCcosto.Equals("000002"))
            {
                Ptipoefectivo = "EFECTIVO CENTRO";

            }
            if (pCcosto.Equals("000004"))
            {
                Ptipoefectivo = "EFECTIVO VERSALLES";

            }
            if (pCcosto.Equals("000005"))
            {
                Ptipoefectivo = "EFECTIVO CIUDADELA";

            }

            try
            {
                return sb.listadorecogida(pCcosto, Ptipoefectivo);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Cagregarecogida(string pccosto, string pempleado, string pvalor, string pusuario)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.IngresaRecogida(pccosto, pempleado, pvalor, pusuario);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static int CClog_cumples(string pnombre, string ptel, string sms, string pusuario,string pdb)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MClog_cumple(pnombre,ptel, sms,pusuario,pdb);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static DataSet ClistaLog_cumples(string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MListalog_cumple(pbd);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistaprecio(string pbarra,string plista)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.MListaprecio(pbarra,plista);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistasaldo(string articulo,string pbodega)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MListasaldo(articulo,pbodega);
            }
            catch (Exception e)

            {

                throw e;
            }
        }



        public static DataSet Clistadescarticuloid(string pplu)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MListadescuentoarticuloid(pplu);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistadeslinea(string linea)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MListadescuentolinea(linea);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistadesgrupo(string grupo)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MListadescuentogrupo(grupo);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistadesmarca(string marca)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MListadescuentomarca(marca);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistadomenus(string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mlistadomenus(pbd);
            }
            catch (Exception e)

            {

                throw e;
            }
        }




        public static DataSet ClistaRoll(string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mlistamrol(pbd);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistadonombremenu(string pbd, string perfil)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mlistanombremenu(pbd, perfil);
            }
            catch (Exception e)

            {
                
                throw e;
            }
        }
        public static DataSet Clistamenuid(string pbd,string perfil)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mlistamenuid(pbd,perfil);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataSet Clistausuarios(string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mlistausuarios(pbd);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        public static DataTable ClistFiles(string area,string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MlistFiles(area,pbd);
            }
            catch (Exception e)

            {

                throw e;
            }
        }
        //aqui voy
        public static DataSet listaactivos(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadogeneral(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaHistoriaActivos(string serial,string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadoHistoriaActivos(serial,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }

        public static DataSet listaactas(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadoActas(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet actas_entrega(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mactas_entrega(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet a_precios()
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mprecios();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet acta(string ip, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadoacta(ip,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet perfil(string pcc, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadoPerfil(pcc, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listageneral(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadogeneral(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaserial(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listaseriales(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventa(string fi, string ff,string costo)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventa(fi,ff,costo);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        // aqui inicia modulo de inventarios
        public static int Cabreconteo(string pid)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mabreconteo(pid);
            }
            catch (Exception e)


            {

                throw e;
            }
        }
        public int abreconteo(string codigo)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mabreconteo(codigo);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Ccierraconteo(string pid)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mcierraconteo(pid);
            }
            catch (Exception e)


            {
              
                throw e; 
            }
        }
        public static int Climpiaconteo(string pid)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mlimpiaconteo(pid);
            }
            catch (Exception e)


            {

                throw e;
            }
        }
        public static DataSet Cprecios()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoprecios();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Ctotalconteo1()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mtotalconteo1();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Ctotalconteo2()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mtotalconteo2();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clistacumpleañeros()//espacio para cumpleañeros
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistacumpleañeros();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        } public static DataSet CRotaciondias(string fechai,string fechaf,string salav)//espacio para cumpleañeros
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Rotaciondias(fechai,fechaf,salav);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clistadoasistencia(string fechaini,string fechafin)//espacio para asistencia biometrico
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistadatoasistencia(fechaini,fechafin);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Ccierraconteo2()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Mcierraconteos2();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Cactivaconteo2()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Mactivaconteos2();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Cactivaconteo1()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Mactivaconteos1();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Ccierraconteo1()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Mcierraconteos1();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }

        //aqui termina modulo de inventario
        //aquii inicia carnes BASCULAS
        //-----------------------------------------------------------------------
        public static DataSet listaventascarnesBAS16(string grupo, string fi, string ff)
        {
            Modelos usu = new Modelos();
            string dato = "";
            if (grupo == "00000357")
            {
                dato = "POLLO";
            }
            if (grupo == "00000356")
            {
                dato = "CERDO";
            }
            if (grupo == "360")
            {
                dato = "RES";
            }
           
            try
            {
                return usu.listadocarnesBS16(dato, fi, ff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet listaventascarnesBAS13(string grupo, string fi, string ff)
        {
            Modelos usu = new Modelos();
            string dato = "";
            if (grupo == "00000357")
            {
                dato = "POLLO";
            }
            if (grupo == "00000356")
            {
                dato = "CARNE DE CERDO";
            }
            if (grupo == "360")
            {
                dato = "CARNE DE RES";
            }
            try
            {
                return usu.listadocarnesBS13(dato, fi, ff);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet ListaventascarnesBasculas(string grupo, string fi, string ff,string tienda)
        {
            Modelos usu = new Modelos();
            string dato = "";
            if (grupo == "00000357")
            {
                dato = "POLLO";
            }
            if (grupo == "00000356")
            {
                dato = "CERDO";
            }
            if (grupo == "360")
            {
                dato = "RES";
            }
            try
            {
                return usu.ListadocarnesBasculas(dato, fi, ff,tienda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //-----------------------------------------------------------------------
        //aquii inicia carnes BNET
        //-----------------------------------------------------------------------
        public static DataSet listaventascarnesBnet( string grupo,string fi, string ff,string tienda)
        {
            Modelos usu = new Modelos();
            
            
                try
                {
                    return usu.ListadocarnesBnet(grupo, fi, ff, tienda);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
            
            

        }
        public static DataSet ListaventascarnesBnetDev(string grupo, string fi, string ff, string tienda)
        {
            Modelos usu = new Modelos();


            try
            {
                return usu.ListadodVBnet(grupo, fi, ff, tienda);
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
        public static DataSet Clistadesnomina(string terceroID, string fi, string ff)
        {
            Modelos usu = new Modelos();
            string excluye = "AF,AP,SS";

            try
            {
                return usu.Mdatosnomina(excluye,terceroID,fi,ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventascarnes13(string grupo, string fi, string ff)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listadocarnes13(grupo, fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventascarnesversa(string grupo, string fi, string ff)
        {
            Modelos usu = new Modelos();
           
            try
            {
                return usu.listadocarnesversa(grupo, fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        //------------------------------------------------------------------------
        public static DataSet listaventa13(string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventa13(fi,ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventa(string fecha,string costo)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventatotal(fecha,costo);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventa13total(string fecha)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventa13total(fecha);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventa16total(string fecha)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventa16total(fecha);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventaversatotal(string fecha)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventaversatotal(fecha);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listadoventaCiudadelatotal(string fecha)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventaciudadelatotal(fecha);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaventaVERSA(string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventaVERSA(fi,ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }

        }
        public static DataSet listaventaCiudadela(string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoventaCiudadela(fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }

        }
        public static DataSet listaventalocalVERSA(string useri,string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listaventalocalVERSA(useri,fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }

        }
        public static DataSet listadetalleventalocalVERSA(string useri, string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadetalleventalocalVERSA(useri, fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }

        }
        public static DataSet listaventaXhora(string fecha,string costo)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listaventashora(fecha,costo);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public static DataSet listaventaXhora13(string fecha)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listaventashora13(fecha);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet Listallenatabla(string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.llenatabla(pbd);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet listaventaXhoraVERSA(string fecha)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listaventashoraVERSA(fecha);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet listaventaXhoraCiudadela(string fecha)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listaventashoraCiudadela(fecha);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet ClistsSalesDomicilios(string Fecha1,string Fecha2)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listSalesDomicilios(Fecha1,Fecha2);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet listaventasXarticulocliente(string fechai, string fechaf, string articuloid)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listadoventaXarticulocliente(fechai, fechaf, articuloid);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet listaventasXarticulotop(string fechai, string fechaf, string articuloid,string pccosto)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listadoventaXarticulocajeratop(fechai, fechaf, articuloid,pccosto);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public static DataSet listaventasXarticulo(string fechai,string fechaf,string articuloid)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listadoventaXarticulocajera(fechai,fechaf,articuloid);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        internal DataTable Clistausercc(string pcc,  string pbd)
        {
            try
            {
                return sb.Mlistausercc(pcc, pbd);
            }
            catch (Exception e)


            {

                throw e;
            }
        }
        internal DataTable Ccrearfirma(string pcc, string pnombre, string ptipopersona,
          string pcelular, string pfirma, string pbd)
        {
            try
            {
                return sb.McreaFirma(pcc, pnombre,ptipopersona,pcelular,pfirma, pbd);
            }
            catch (Exception e)


            {

                throw e;
            }
        }

        internal DataTable Ccrearformato(string pnombre, string pFullPath, string pUser,
         string pArea, string plabel, string pbd)
        {
            try
            {
                return sb.McreaFormato( pnombre,pFullPath,pUser,pArea,plabel, pbd);
            }
            catch (Exception e)


            {

                throw e;
            }
        }

        internal DataTable Ccrearpersona(string pcc, string pnombre1, string pnombre2,
            string papellido1, string papellido2, string ptel,
            string pdireccion, string psexo, string ptipoperid,
          string puser,string pbd)
        {
            try
            {
                return sb.McreaPERSONA(pcc, pnombre1, pnombre2, papellido1, papellido2, ptel,
            pdireccion, psexo, ptipoperid, puser,pbd);
            }
            catch (Exception e)


            {
                
                throw e;
            }
        }
        internal DataTable CcrearUsuario(string pid, string pusuario, string ppas,
            string pusu,string pbd)
        {
            try
            {
                return sb.Mcreausuario(pid, pusuario, ppas, pusu,pbd);
            }
            catch (Exception e)


            {

                throw e;
            }
        }
        public static int Ccreaactivo(string pid, string pserial, string pnombre,string pmodelo
            ,string pfabricante,string pcategoria,string coment,string proveedor, string garantia
            ,string fechacompra,string valor,string pusu,string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreaactivo(pid,pserial,pnombre,pmodelo,pfabricante,
                    pcategoria,coment,proveedor,fechacompra,valor,pusu,garantia, pbd);
            }
            catch (Exception e)


            {

                throw e;
            }
        }
        public static int CcreaModelo( string nombre, string pusu,string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreamodelo(nombre, pusu,pbd );
            }
            catch (Exception e)


            {

                throw e;
            }
        }
        //aqui inicia recibo mercancia
        public static int Ccreanofactura(string ptipo, string pnumero,string userr, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreafactura(ptipo,pnumero,userr, pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static DataSet CValidaFactura(string idfactura,string tipo, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MValidafactura( tipo, idfactura, pbd);
               
            }
            catch (Exception e)

            {
                throw e;
            }

          
        }
        public static DataSet ClistaitemsRecibo_compra(string tipo, string idfactura,  string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MlistaitemsRecibo_compra(tipo, idfactura, pbd);

            }
            catch (Exception e)

            {
                throw e;
            }


        }
        public static int CcreaitemsOC(string pIdCompra, string pPLU, string pCantidad, string pNameArticulo, string pEstado,string cantOc,string pcosto,string pedido,string pisDev,string iva,string pcodigo,string factor,string namepres , string costoordencompra,string refProv, string pBd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreaitemsfactura(pIdCompra,pPLU,pCantidad,pNameArticulo,pEstado,cantOc,pcosto,pedido, pisDev,iva,pcodigo,factor,namepres,costoordencompra,refProv, pBd);
            }
            catch (Exception e)

            {
                throw e;
            }
        } 
        public static int CupdateitemsOC(string pId, string pCantidad, string pCostonuevo, string pEstado, string pobserva, string pBd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mupdateitemsfactura(pId,pCantidad,pCostonuevo,pEstado,pobserva,pBd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static int CInsertitemsbonificado(string pId, string plu, string detalle, string pBd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.MinsertitemsBonificado(pId,plu,detalle, pBd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static int Ccrea_devo_itemsfactura(string plu, string codbar, string idfactura, string detalle, string cant, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcrea_devo_itemsfactura(plu, codbar, idfactura, detalle, cant, pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static DataSet Clista_rmercancia(string pidfactura,string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mtrae_rmercancia(pidfactura,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_devomercancia(string pidfactura, string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mtrae_devo_mercancia(pidfactura, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_count_recibo(string pidfactura, string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mtrae_count_recibo(pidfactura, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_count_devo(string pidfactura, string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mtrae_count_devo(pidfactura, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        //aqui finaliza el recibo de mercancia
        public static int Ccreaentradakardex(string id,string entrada,string salida,string observa,string pusu,string pbodegaid,string fechamov,string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreakardex(id,entrada,salida,observa,pusu,pbodegaid,fechamov,pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
     
            public static int CcreaActabaja(string id, string fecha, string Ubicacion,
            string area, string usuario, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.McreaActaBaja(id, fecha,Ubicacion,area,usuario, pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static int CcreabajaArticulo(string fecha,string articulo,
            string estado,string destino,string usuario,string idacta, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.McreaBAJA(fecha,articulo,estado,destino,usuario,idacta,pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }

        public static int CcreaFabricante(string nombre, string pusu, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreafabricante(nombre, pusu,pbd);
            }
            catch (Exception e)
             {

                throw e;
            }
        }
        public static int Ccreacategoria(string nombre, string vida, string pusu, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreacategoria(nombre,vida, pusu,pbd);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static int CcreaTercero(string cc,string nombre,string dir,string tel,
            string ciudad,string email, string pusu, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.McreaTercero(cc,nombre,dir,tel,ciudad,email, pusu,pbd);
            }
            catch (Exception e)
            {
                   throw e;
            }
        }
        public static int CcreaTerceroempleado(string cc, string nombre, string dir, string tel,
            string ciudad, string email, string pusu, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.McreaTerceroempleado(cc, nombre, dir, tel, ciudad, email, pusu,pbd);
            }
            catch (Exception e)
             {
                throw e;
            }
        }
        public static int Ccreaacta(string pid, string usuario, string observa,string data, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreaacta(pid, usuario,observa,data,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //ACTAS DE MANTENIMIENTOS
        //-----------------------------------------------------------------------------------
        public static DataSet ClistaPROVEEDORES(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistaPROVEEDORES(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet ClistaPROVEEDORES2(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistaPROVEEDORES2(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet ClistaNUEVONUMEROACTA(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistaNUEVONUMEROACTA(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet ClistaNUEVONUMERObaja(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistaNUEVONUMERObaja(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        // public static int CcreaactaMantenimiento( string pproveedor, string data, string pusuario, string observa, string fechaacta)
        //{
        //  Modelos usu = new Modelos();
        //try
        //{
        //  return usu.McreaactaMantenimiento( pproveedor,data,pusuario, observa,fechaacta);
        //}
        //catch (Exception e)


        // {

        //   throw;
        //    }
        //}
        public static int Ccreaorden( string bodega, string area, string clase, string descripcion,
            string stado,string usuario, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreaordentrabajo(bodega,area, clase, descripcion,stado,usuario,pbd
                    );
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static int Ccreaasigtrabajo(string pid, string pproveedor, string pfecha, string usuario, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreaasigtrabajo(pid,pproveedor,pfecha,  usuario,pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        public static DataSet Cllenaselectasig_admon(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mllenaselectordenesasignadas(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_mant_preaprobadas(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Mlista_mant_preaprobados(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_detamant_preaprobadas(string id, string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadetallesmant_preaprobados(id,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Cmaxid_mantenimientos(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.maxidmantenimientos(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }

        public static DataSet Cllenaselectasig_Noadmin(string usuario, string pbd)
        {
            Modelos usu = new Modelos();
           
                try
                {
                    return usu.mllenaselectordenes_Noadmin(usuario,pbd);
                }
                catch (Exception ex)
                {
                    throw ex; // para lanzar la exception o complementar la capturada
                }
            
            
        }
        public static DataSet Clistagridasignados(string usuario,string rol, string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listaordenesasignadas(usuario,rol,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clistagridradicados(string usuario,string rol, string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listaordenesradicadas(usuario,rol,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clistaclasemantenimiento(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listatipomantenimiento(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clistaprecios()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listadoprecios();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clistaarea(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listaarea(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
     
        public static DataSet Clistaubicacion(string pbd)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.listaubicacion(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        
            public static int Cupdate_mant_valores(string cid, string cvalorobra,string cvalorrepuesto,string cnumeroexterno,string bd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mupdate_mant_valores(cid,cvalorobra,cvalorrepuesto,cnumeroexterno,bd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int CcreaUbicacion(string nombre, string pusu, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.McreaUbicacion(nombre, pusu,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int ccreadetalleactamante(string pidacta, string particulo, string prepuesto,
            string pcostoobra,string pcostorepuestos,string pdetalle,string ptipomantenimiento,
            string pnumeroexterno, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.McreadetallesactaMantenimiento(pidacta,particulo,prepuesto,pcostoobra,
                    pcostorepuestos,pdetalle,ptipomantenimiento,pnumeroexterno,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int ccreaaprueba_asignac(string pidacta, string ptercero, string pobservacion, string pfecha,
            string pusuario, string idasigna,string IDORDEN,string bd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreaaprobacionasignacion(pidacta, ptercero, pobservacion,pfecha,pusuario,
                    idasigna,IDORDEN,bd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }
        //detalles cuando la aprobacion no tiene que ver con activos fijos
        public static int ccreadeta_Act_Mant_Na(string pidacta, string prepuesto, int pcostomano,
            int pcostorepuesto, string pdetalle, string ptipomant, string pclaseman,
            string pgarantia,string pnumero, string pbd)
        {
           
            String pidarticulo = "";
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreadetallesmantenimiento(pidacta, pidarticulo, prepuesto, pcostomano,
                    pcostorepuesto, pdetalle, ptipomant, pclaseman, pgarantia,pnumero,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Ccrea_detalles_mant_conArticulo(string pidacta,string pidarticulo,
            string prepuesto, int  pcostomano,int pcostorepuesto,string pdetalle, string ptipomant, 
            string pclaseman, string pgarantia, string pnum, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreadetallesmantenimiento(pidacta, pidarticulo, prepuesto, pcostomano,
                    pcostorepuesto, pdetalle, ptipomant, pclaseman, pgarantia, pnum,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int ccreadetallesaprobacion(string pidacta, string prepuesto, string pdetalle, 
            string ptipomant,string pclaseman,string pgarantia, string pbd)
        {
            int pcostorepuesto = 0;
            string pnum = "";
            int pcostomano = 0;
            String pidarticulo = "";
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreadetallesmantenimiento(pidacta,pidarticulo,prepuesto,pcostomano,
                    pcostorepuesto,pdetalle,ptipomant,pclaseman,pgarantia,pnum,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //CON ESTE PROCEDIMIENTO SE CREA LOS DETALLES CUANDO TIENE QUE VER CON ACTIVOS FIJOS
        public static int ccreadetallesaprobacionactivos(string pidacta,string pidarticulo, 
            string prepuesto, string pdetalle, string ptipomant, string pclaseman, string pgarantia, string pbd)
        {
            int pcostorepuesto = 0;
            int pcostomano =0;
            string pnum = "";
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreadetallesmantenimiento(pidacta, pidarticulo, prepuesto,
                    pcostomano, pcostorepuesto, pdetalle, ptipomant, pclaseman, pgarantia,pnum,pbd);
            }
            catch (Exception e)

            {
                throw e;
            }
        }


        //TERMINA ACTAS DE MANTENIMIENTOS
        //-----------------------------------------------------------------------------------
        public static int cupdatefiscal(string pid, string pubica, string pidarea, string pserial,string idacta, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mupdatefiscal(pid, pubica, pidarea,pserial,idacta,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //metodo para crear una linea en Fiscal
        public static int ccreafiscal(string particulo, string presponsable, string pusua,
            string pubicacion,string parea,string pfecha,string p_idacta, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreafiscal(particulo,presponsable,pusua,pubicacion,parea,pfecha,p_idacta,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int ccreaasigarticulo( string pfecha, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.masigarticulo(pfecha,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        internal DataTable Ccreapermiso(string pidpermiso, string pidrol,string pusuario,string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mCreapermiso(pidpermiso,pidrol,pusuario, pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int cupdatelineamant(string pdato, string pid, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mupdatelineagridmanteni(pdato,pid,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int ccreadetalleacta(string pidacta, string particulo,string presponsable
                ,string pubicacion,string parea, string pobserva,
            string pfechaa,string pfechacrea,string user, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreadetalleacta(pidacta,particulo,presponsable,pubicacion,
                    parea,pobserva,pfechaa,pfechacrea,user,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Ccreaupdateacta(string pid, string pserial, string pcantidad, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreacantidadactivo(pid, pserial, pcantidad,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Ccreacantidadactivo(string pid,string pserial, string pcantidad, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreacantidadactivo(pid,pserial, pcantidad,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
         }
        public static DataSet listnumeroid(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listanumeroid(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        
             public static DataSet selectfiscal(string pids, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mselectfiscal(pids,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaactivoserial(string serial, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadoserial(serial,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listakardexreport(string serial,string fini,string ffin,string ubicacion, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadokardex(serial,fini,ffin,ubicacion, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Cdelete_kardex(string id, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mdeleteitems_kardex(id, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaactivonombre(string nombre, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listadonombre(nombre, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listaactivo(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.listado(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet traemanteni(string pserial, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraemanteni(pserial,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        //public static DataSet actage_mante()
        //{
        //  Modelos usu3 = new Modelos();
        //try
        //{
        //  return usu3.Mcrea_a
        //}
        //catch (Exception)
        // {

        //   throw;
        //}
        //}
        
              public static DataSet Cventashoralinea(string pfecha,string plinea,string pbodega)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.ventashoralinea(pfecha,plinea,pbodega);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Clista_tercerosbnet(string pcc)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mlista_tercerosBnet(pcc);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet CSale_supermarkets(string pfecha, string plinea, string pcosto)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mlista_acom_Ventaspuntos(pfecha, plinea, pcosto);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Ccosto()
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.centrocosto();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ClistDeployeeDelivery(string pcc,string pdb)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.MlistDeployeeDelivery(pcc,pdb);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet cventasxlinea(string fecha1,string fecha2,string linea,string costo)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.ventasXLINEA(fecha1,fecha2,linea,costo);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Cventas_linea(string fecha1, string fecha2,  string costo)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.MventasLINEA(fecha1, fecha2,  costo);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Cventas_linea_general(string fecha1, string fecha2)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Ventaslinearesumido(fecha1, fecha2);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataTable clistausercc(string cc,string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mlistausercc(cc,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataTable clistauseruser(string user, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mlistauseruser(user, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Cventashoralineala13(string pfecha, string plinea)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.ventashoralineala13(pfecha, plinea);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme 
            }
        }
        public static DataSet Cventasresumidolinea(string pfechaini, string pfechahasta,string pcosto)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.MventasResmidoporlinea(pfechaini, pfechahasta, pcosto);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet CBajasFruver(string pfechaini, string pfechahasta,string pcosto)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.MBajasFruver(pfechaini, pfechahasta, pcosto);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet CRotacionInventarioProveedor(string pfechaini, string pfechahasta, string pproveedor)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.MRoracioninventarioProveedor(pfechaini, pfechahasta, pproveedor);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Crotacion(string pfechaini,  string nit)
        {
            Modelos usu2 = new Modelos();
           

            try
            {
                return usu2.Mrotacion(pfechaini, nit);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Cventastotaleslinea(string pfechaini, string pfechahasta, string pcosto)
        {
            Modelos usu2 = new Modelos();
            string metros="0";
            if (pcosto.Equals("000001"))
            {
                metros = "674";
            }
            if (pcosto.Equals("000002"))
            {
                metros = "180";
            }
            if (pcosto.Equals("000004"))
            {
                metros = "735";
            }
            if (pcosto.Equals("000005"))
            {
                metros = "660";
            }

            try
            {
                return usu2.Mventastotalesporlinea(pfechaini, pfechahasta, pcosto,metros);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Cventasmesanterior(string pfechaini, string pfechahasta, string pcosto)
        {
            Modelos usu2 = new Modelos();
          
            try
            {
                return usu2.Mventascontramesanterior(pfechaini, pfechahasta, pcosto);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet CventasAñoanterior(string pfechaini, string pfechahasta, string pcosto)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.MventascontraAñoanterior(pfechaini, pfechahasta, pcosto);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet Cventashoralineaversalles(string pfecha, string plinea)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.ventashoralineaversalles(pfecha, plinea);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet cactasbaja()
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mactabaja();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet traelineassupermio()
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.lineassupermio();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }

        //con este metodo se trae la informacion para el informe
        public static DataSet ctraeactaasignacion(string id, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeactaasignacion(id,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraeactamantenimiento(string id, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeactamantenimiento(id, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraecategoriaactivos( string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraecategoriasactivos( pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraefabricante(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraefabricante(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraeproveedoractivos(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeproveedoractivos(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraemodelo(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraemodelo(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraelinea(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraelinea(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraeactaentrega(string id, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeactasdeentrega(id, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
           public static DataSet ctraeactaasignado(string id, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeasignados(id, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet lista_idmanteni(string pdb)
        {
            Modelos usu2 = new Modelos();
            try
            {
                return usu2.listadoidmantenimiento(pdb);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static DataSet Clista_abiertos(string id)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlistaabiertos(id);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet traeactamantenimiento(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeconsecutivosmante(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        // trae la informacion para editar las actas de mantenimiento
        
    public static int cupdate_actasm(string pidproveedor, string pfecha,  string pobserva, string pidacta, string pbd)
                {
                    Modelos usu = new Modelos();
                     try
                        {
                        return usu.mupdate_actasm(pidproveedor,pfecha,pobserva,pidacta,pbd);
                        }
                     catch (Exception e)
                     {
                        throw e;
                      }
                }
        //INCAPACIDADES
        
             public static int Cupdateincapacidad(string pidempleado, string pobserva, string pfini,
                 string pffin, string puser, string pidincapacidad, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mupdateincapacidad(pidempleado, pobserva, pfini, pffin, puser,pidincapacidad,pbd);
            }
            catch (Exception e)
            {
             throw e;
            }
        }
        public static int cborraincapacidad(string pid, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mborraincapacidad(pid,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataSet Ctraenovedadesincapacidades(string idincapa, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mtraenovedadesincapacidad(idincapa,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }

        public static DataSet CtraeIncapacidad(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeincapacidades(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static int ccrea_incapacidades(string pidempleado,string pobserva, string pfini,
            string pffin, string puser, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mcrea_incapacidad(pidempleado,pobserva, pfini,pffin,puser,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int ccrea_novedadincapacidades(string p_idincapacidad, string p_estado,
            string pobserva, string p_fecha, string puser, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcreanovedadincapacidad(p_idincapacidad, p_estado, pobserva, p_fecha, puser,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Cdelete_detalleactas(string pidacta, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mdeletedeta_mante( pidacta,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Cupdateitemsacta(string serial,string ptmante,string pdetalle,
            string pCmanoobra,string prepuestos,string pnumero_externo,string pcosto_repuestos,
            string pid,string pidarticulo,string pgarant, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.mupdatedetalle_actasm(serial,ptmante,pdetalle,pCmanoobra,prepuestos,
                    pnumero_externo,pcosto_repuestos,pid,pidarticulo,pgarant,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataSet ctraeactaeditar(string pserial, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeactaeditar(pserial,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        
        public static DataSet ctraeproveedor(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeproveedor(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        //para llenar select 
        public static DataSet ctraeEmpleado(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeEmpleado(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet cEmployee(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.Mmployee(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraeEmpleado_Sin_contra(string bd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraeEmpleado_Sin_contra(bd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        //------------------------------------------------
        // trae la informacion principal de un activo fijo
        //-----------------------------------------------
        public static DataSet ctraelistaactivos_asg(string nombre, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mlista_activos_asg(nombre, pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet ctraeinfoactivo(string pserial, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.activodatosgenerales(pserial,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        //-----------------------------------------------------
        public static DataSet traerepuestos(string pserial, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mtraerespuestos(pserial,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o compleme
            }
        }
        public static DataSet listasaldos(string pidart, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.mlistasaldos(pidart,pbd
                    );
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet listasaldo(string pidart,string pbodega, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.msaldoactual(pidart,pbodega,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet saldokardex(string pfechaini,string pfechafin,string pidart,string pbodega, string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.msaldokardex(pfechaini,pfechafin,pidart,pbodega,pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet saldokardexgeneral(string pbd)
        {
            Modelos usu2 = new Modelos();

            try
            {
                return usu2.msaldokardexgeneral(pbd);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        //aqui inicia la 14 distribuciones
        public static DataSet Clista_la14aux(string fi, string ff,string cuenta)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.MClista_la14aux(fi, ff,cuenta);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        
        public static DataSet Clista_la14VENTAS(string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.MClista_la14VENTAS(fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet CListaVentas_la14VENTAS(string fi, string ff)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.MVentas_la14VENTAS(fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int CCrea_area(string pidubica, string nombre, string user, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mcrea_area(pidubica, nombre, user,pbd);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataSet clistadepreciacion( string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mlistadepreciacion(pbd);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static DataSet clistaconsultor(string pcodbar,string plistaprecio ,string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.listaconsultor(pcodbar, plistaprecio,pbd);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static int cupdateactivo(string pid, string pserial, string pnombre, string coment, string garantia,string pmodelo,string pfabricante,
            string pcategoria, string proveedor, string fechacompra, string valor, string pusu, string pbd)
        {
            Modelos usu = new Modelos();
            try
            {
                return usu.Mupdateactivo(pid,pserial,pnombre,coment,garantia,pmodelo,pfabricante,pcategoria,proveedor,fechacompra,valor,pusu,pbd);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}