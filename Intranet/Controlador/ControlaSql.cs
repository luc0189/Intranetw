using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using Intranet.modelo;

namespace Intranet.Controlador
{
    public class ControlaSql
    {
        ModeloSql sb = new ModeloSql();

        // aqui inicia modulo de inventarios
        public static int Cabreconteo(string pid)
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mabreconteo(pid);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static DataSet Cconteosabiertos()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mconteosabiertos();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Cconteoscerrados()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mconteoscerrados();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Cactivasincro()
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mactivasincro();
            }
            catch (Exception e)
            {

                throw e;
            }
        } 
        public static int Cinactivasincro()
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.minactivasincro();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public string GetRespuestaDocRelacionados(string fecha)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False"))
            {
                using (SqlCommand cmd = new SqlCommand("spCustom_CtasSalidaInv", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    SqlParameter respuesta = new SqlParameter("@RowsAffected", SqlDbType.NVarChar, 1000)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(respuesta);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return respuesta.Value.ToString();
                }
            }
        }
        public static DataSet Cverificausuariosincro()
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mverificausuariosincro();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public int abreconteo(string codigo)
        {
            ModeloSql usu = new ModeloSql();

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
            ModeloSql usu = new ModeloSql();
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
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mlimpiaconteo(pid);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static int CabreoCierraRangoConteos(string pidIni, string pidFin, int pProte)
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mabreocierraRangoConteos(pidIni, pidFin, pProte);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int CfechaRangoConteos(string pidIni, string pidFin, string pfecha)
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mFecharangoconteos(pidIni, pidFin, pfecha);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //aqui inicia recibo mercancia
        public static DataSet Clista_articulos(string id)
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.Mlistaarticulos(id);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }

        public static DataSet Clista_CostoArticulos(string id)
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.MlistaCostoArticulos(id);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_orden_compra(string pcodigo,string pnumero )
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.mlista_ordencompra(pcodigo,pnumero);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_Items_orden_compra(string pcodigo, string pnumero)
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.Mlista_Items_ordencompra(pcodigo, pnumero);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_esta_ono(string p_tipo,string p_ndoc, string cod_bar)
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.mlista_esta_ono(p_tipo,p_ndoc, cod_bar);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        //finaliza recibo de mercancia

        public static DataSet listaarticulosfruver()
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.listadoarticulosfruver();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_abiertos(string id)
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.mlistaabiertos(id);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int CbodegaRangoConteos(string pidIni, string pidFin, string pbodegaid)
        {
            ModeloSql usu = new ModeloSql();
            try
            {
                return usu.mbodegarangoconteos(pidIni, pidFin, pbodegaid);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Ccierraconteo2()
        {
            ModeloSql usu = new ModeloSql();

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
            ModeloSql usu = new ModeloSql();

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
            ModeloSql usu = new ModeloSql();

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
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.Mcierraconteos1();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Ctotalconteo1()
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.mtotalconteo1();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_dif_conteos()
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlista_dif_Conteos();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Clista_Dif_Items_conteos(string zona)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.mlista_Dif_Items_conteos(zona);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static int Cconteo_revisado(string zona)
        {
            Modelos usu = new Modelos();

            try
            {
                return usu.Mconteo_revisado(zona);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
        public static DataSet Ctotalconteo2()
        {
            ModeloSql usu = new ModeloSql();

            try
            {
                return usu.mtotalconteo2();
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }

        public static DataSet Clistanumerocontratonimina(string terceroID, string fi, string ff)
        {
            ModeloSql usu = new ModeloSql();
            

            try
            {
                return usu.Mdatoscontratonomina(terceroID, fi, ff);
            }
            catch (Exception ex)
            {
                throw ex; // para lanzar la exception o complementar la capturada
            }
        }
    }
}