using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace Intranet.conexiona
{
    public class parametro
    {
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public OracleType Tipo { get; set; }
        public ParameterDirection Direccion { get; set; }
        public int Ubicacion { get; set; }

        public parametro(string nombre, string valor, string tipo, ParameterDirection direccion)
        {
            Nombre = nombre;
            Valor = valor;
            Tipo = oratipo(tipo);
            Direccion = direccion;
        }
        private OracleType oratipo(string tipo)
        {
            switch (tipo)
            {
                case "CURSOR":
                    return OracleType.Cursor;
                case "NUMBER":
                    return OracleType.Number;
                case "VARCHAR2":
                    return OracleType.VarChar;
                case "DATE":
                    return OracleType.DateTime;
                case "CLOB":
                    return OracleType.Clob;
                case "BLOB":
                    return OracleType.Blob;
                default:
                    return OracleType.VarChar;
            }

        }

    }
}