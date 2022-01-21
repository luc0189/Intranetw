using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Intranet.conexiona
{
    public class Bdconexion
    {
        public String Conection_DB()
        {
            return ConfigurationManager.ConnectionStrings["BD"].ConnectionString;
        }
        public DataTable ProcedureSelectDB(string procedimiento, List<parametro> parametros,string BD)
        {
            OracleConnection DbConn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.113)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=XE)));User ID='" + BD + "';Password=Team0103; Unicode=true");
          
            DataTable datos = new DataTable();

            try
            {
                #region Define Procedimiento
                OracleDataReader cursor;
                DbConn.Open();
                OracleCommand DbCommand = new OracleCommand(procedimiento, DbConn);
                DbCommand.CommandType = System.Data.CommandType.StoredProcedure;
                #endregion Define Procedimiento

                #region Parametros
                foreach (parametro p in parametros)
                {
                    DbCommand.Parameters.Add(new OracleParameter(p.Nombre, p.Tipo));
                    DbCommand.Parameters[p.Nombre].Direction = p.Direccion;
                    if (p.Direccion == ParameterDirection.Input)
                        DbCommand.Parameters[p.Nombre].Value = p.Valor;
                }
                #endregion
                cursor = DbCommand.ExecuteReader();
                datos.Load(cursor);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                if (DbConn != null)
                    if (DbConn.State == ConnectionState.Open)
                        DbConn.Close();
            }
            return datos;
        }
        public MySqlConnection conexion;
        public OracleConnection conexionoracle;

        public void cadenaConexionPROCESS ()
        {
            conexion = new MySqlConnection("server=192.168.1.133;port=3306;database=procesosadmon;Uid=root;pwd=dibal;SslMode=none; mysql_set_charset('utf8')");
            
        }
        public void cadenaConexion(string pbd)
        {
            conexion = new MySqlConnection("server=192.168.1.133;port=3306;database='"+ pbd + "';Uid=root;pwd=dibal;SslMode=none;default command timeout=3600");
        }
        public void cadenaConexioncarnes()
        {
            conexion = new MySqlConnection("server=192.168.1.133;port=3306;database=sys_datos_dfs;Uid=root;pwd=dibal;SslMode=none");
        }
        public void cadenaConexioncarnesVERSA()
        {
            conexion = new MySqlConnection("server=192.168.2.115;port=3306;database=sys_datos_dfs;Uid=root;pwd=dibal;SslMode=none");
        }
        public void cadenaConexioncarnesLA13()
        {
            conexion = new MySqlConnection("server=192.168.1.40;port=3306;database=sys_datos_dfs;Uid=root;pwd=dibal;SslMode=none");
        }
        public void cadenaConexionOra()
        {
            OracleConnection conexion = new OracleConnection("Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.113)(PORT = 1521))(CONNECT_DATA = (SERVER = dedicated)(SERVICE_NAME = XE))); User ID = LCSYSTEM; Password = Team0103; Unicode = true");
        
        }

        public bool abriConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
        }
        public bool abriConexioncarnes()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }
        }
        public bool abriConexionoracle()
        {
            try
            {
                conexionoracle.Open();
                return true;
            }
            catch (OracleException ex)
            {
                return false;
                throw ex;
            }
        }
        public bool cerrarConexion()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
                throw ex;
            }

        }
        public bool cerrarConexionoracle()
        {
            try
            {
                conexionoracle.Close();
                return true;
            }
            catch (OracleException ex)
            {
                return false;
                throw ex;
            }

        }
        public DataSet MySqlQueryprocess(String SQL)
        {
            cadenaConexionPROCESS();
            MySqlCommand comando = new MySqlCommand(String.Format(SQL), this.conexion);

            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                abriConexion();
                datos.Fill(tabla);
            }
            catch (Exception ) // atrapa la excepcion que hereden de System.Exception
            {

                return null;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                cerrarConexion();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet MySqlQuery(String SQL,String bd)
        {
            cadenaConexion(bd);
            MySqlCommand comando = new MySqlCommand(String.Format(SQL), this.conexion);
           
            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                abriConexion();
                datos.Fill(tabla);
            }
            catch (Exception ex) // atrapa la excepcion que hereden de System.Exception
            {
              
                throw  ex ;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                cerrarConexion();
                comando.Dispose();
            }
            return tabla;
        }

        public DataSet MySqlQuerycarnes(String SQL)
        {
            cadenaConexioncarnes();
            MySqlCommand comando = new MySqlCommand(String.Format(SQL), this.conexion);
            comando.CommandTimeout = 0;
            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                abriConexioncarnes();
                datos.Fill(tabla);
            }
            catch (Exception ex) // atrapa la excepcion que hereden de System.Exception
            {
                throw ex;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                cerrarConexion();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet MySqlQuerycarnesVERSA(String SQL)
        {
            cadenaConexioncarnesVERSA();
            MySqlCommand comando = new MySqlCommand(String.Format(SQL), this.conexion);
            comando.CommandTimeout = 0;
            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                abriConexioncarnes();
                datos.Fill(tabla);
            }
            catch (Exception ex) // atrapa la excepcion que hereden de System.Exception
            {

                throw ex;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                cerrarConexion();
                comando.Dispose();
            }
            return tabla;
        }

        public DataSet MySqlQuerycarnesLA13(String SQL)
        {
            cadenaConexioncarnesLA13();
            MySqlCommand comando = new MySqlCommand(String.Format(SQL), this.conexion);

            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                abriConexioncarnes();
                datos.Fill(tabla);
            }
            catch (Exception ex) // atrapa la excepcion que hereden de System.Exception
            {

                throw ex;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                cerrarConexion();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet oraconsulta(String SQL,String BD)
        {
            //NO OLVIDE QUE SI NO FUNCIONA EN OTRO SERVIDOR ES PORQUE LE HACE FALTA EL ODA
            //OracleConnection conexion = new OracleConnection(this.cadenaConexionOra());
            //base de datos remota y tambien copiar al webconfig OJO"
            OracleConnection conexion = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.113)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=XE)));User ID='" + BD+"';Password=Team0103; Unicode=true");
            OracleCommand comando = new OracleCommand(SQL, conexion);
            OracleDataAdapter datos = new OracleDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                conexion.Open();
                datos.Fill(tabla);
            }
            catch (Exception problema) // atrapa la excepcion que hereden de System.Exception
            {
                throw problema;
                    //new Exception(problema.Message);
                //return problema;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                conexion.Close();
                comando.Dispose();
            }
            return tabla;
        }
        private OleDbConnection connection = new OleDbConnection();
        public DataSet accesconsulta(String sql)
        {
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = \\192.168.1.133\standard\ret.mdb;Jet OLEDB:Database Password= ;Persist Security Info=False;";
            OleDbCommand comando = new OleDbCommand(sql, connection);
            OleDbDataAdapter datos = new OleDbDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                connection.Open();
                datos.Fill(tabla);

                connection.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                connection.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet orala14consulta(String SQL)
        {
            //OracleConnection conexion = new OracleConnection(this.cadenaConexionOra());
            //base de datos remota y tambien copiar al webconfig OJO"
            OracleConnection conexion = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.10.2)(PORT=1521))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=doors)));User ID=la_14;Password=doors*-+; Unicode=true");
            OracleCommand comando = new OracleCommand(SQL, conexion);
            OracleDataAdapter datos = new OracleDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                conexion.Open();
                datos.Fill(tabla);
            }
            catch (Exception) // atrapa la excepcion que hereden de System.Exception
            {
                return null;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                conexion.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet sqlconsultamysql(String SQL)
        {
            MySqlConnection sqlconn = new MySqlConnection("server=192.168.1.133;port=3306;database=lcsystem;Uid=root;pwd=dibal;SslMode=none");
            MySqlCommand comando = new MySqlCommand(SQL, sqlconn);
            MySqlDataAdapter datos = new MySqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                sqlconn.Open();
                datos.Fill(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlconn.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet sqlconsulta(String SQL)
        {
            //SqlConnection sqlconn = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False");
            SqlConnection sqlconn = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False");
            SqlCommand comando = new SqlCommand(SQL, sqlconn);
            comando.CommandTimeout = 0;
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                sqlconn.Open();
                datos.Fill(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlconn.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet sqlsincro(String SQL)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=usuariosincro;Password=sincro123.;User Instance=False");
            SqlCommand comando = new SqlCommand(SQL, sqlconn);
            comando.CommandTimeout = 0;
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                sqlconn.Open();
                datos.Fill(tabla);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                sqlconn.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public DataSet sqlconsulta2(String SQL)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False");
            SqlCommand comando = new SqlCommand(SQL, sqlconn);
            comando.CommandTimeout = 0;
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                sqlconn.Open();
                datos.Fill(tabla);
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                sqlconn.Close();
                comando.Dispose();
            }
            return tabla;
        }

        public DataSet sqlconsultaversalles(String SQL)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=192.168.1.113;Initial Catalog=supermioversalles;Persist Security Info=True;User ID=dba;Password=Supermioserver123*;User Instance=False");
            SqlCommand comando = new SqlCommand(SQL, sqlconn);
            comando.CommandTimeout = 0;
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataSet tabla = new DataSet();
            try
            {
                sqlconn.Open();
                datos.Fill(tabla);
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                sqlconn.Close();
                comando.Dispose();
            }
            return tabla;
        }
        public int MysqlProce(string SQL, string bd)
        {

            int registros = 0;
            MySqlConnection conexion = new MySqlConnection("server=192.168.1.133;port=3306;database='"+bd+"';Uid=root;pwd=dibal;SslMode=none");
            conexion.Open();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandTimeout = 0;
            MySqlTransaction transaction = conexion.BeginTransaction();

            try
            {
                comando.Transaction = transaction;
                comando.CommandText = SQL;
                registros = comando.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception EX) // atrapa la excepcion que hereden de System.Exception
            {
                transaction.Rollback();
                registros = 0;
                throw EX;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                conexion.Close();
                comando.Dispose();
            }

            return registros;
        }
        public int MysqlProcedimiento(string SQL,string pbd)
        {
          
            int registros = 0;
            MySqlConnection conexion = new MySqlConnection("server=192.168.1.133;port=3306;database='"+ pbd + "';Uid=root;pwd=dibal;SslMode=none");
            conexion.Open();
           MySqlCommand comando = conexion.CreateCommand();
            comando.CommandTimeout = 0;
            MySqlTransaction transaction = conexion.BeginTransaction();

            try
            {
                comando.Transaction = transaction;
                comando.CommandText = SQL;
                registros = comando.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex) // atrapa la excepcion que hereden de System.Exception
            {
                transaction.Rollback();
                registros = 0;
                throw ex;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                conexion.Close();
                comando.Dispose();
            }
      
            return registros;
        }
        public int sqlProcedimiento(string SQL)
        {
            int registrossql = 0;
            SqlConnection conexionsql = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False");
            conexionsql.Open();
            SqlCommand comandosql = conexionsql.CreateCommand();
            comandosql.CommandTimeout = 0;
            SqlTransaction transactionsql = conexionsql.BeginTransaction();

            try
            {
                comandosql.Transaction = transactionsql;
                comandosql.CommandText = SQL;
                registrossql = comandosql.ExecuteNonQuery();

                transactionsql.Commit();
            }
            catch (Exception) // atrapa la excepcion que hereden de System.Exception
            {
                transactionsql.Rollback();
                registrossql = 0;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                conexionsql.Close();
                comandosql.Dispose();
            }

            return registrossql;
        }
        public SqlConnection conexionsql;

        public void cadenaConexionsql()
        {
            conexionsql = new SqlConnection("Data Source=192.168.1.113,7433;Initial Catalog=supermio;Persist Security Info=True;User ID=l.sanchez;Password=Team0103;User Instance=False");
        }

        public bool abriConexionsql()
        {
            try
            {
                conexionsql.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }
        }

        public bool cerrarConexionsql()
        {
            try
            {
                conexionsql.Close();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
                throw ex;
            }

        }


        public DataSet OraProcedimiento(String SQL)
        {
            cadenaConexionOra();
            OracleCommand comando = new OracleCommand(String.Format(SQL), this.conexionoracle);

           OracleDataAdapter datos = new OracleDataAdapter(comando);
            DataSet tabla = new DataSet();
            //Excepciones (bloques: try - catch - finally)
            try // Se ejecuta hasta que termine o se genere una excepcion
            {
                abriConexionoracle();
                datos.Fill(tabla);
            }
            catch (Exception ex) // atrapa la excepcion que hereden de System.Exception
            {

                throw ex;
            }
            finally  // se ejecuta si se produce o no una excepcion 
            {
                cerrarConexionoracle();
                comando.Dispose();
            }
            return tabla;
        }





    }
}