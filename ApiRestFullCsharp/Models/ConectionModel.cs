using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ApiRestFullCsharp.Models
{
    /// <summary>
    /// Configuracion de la base de datos
    /// </summary>
    public class ConectionModel
    {
        private string host = "localhost";
        private int port = 3306;
        private string database = "registro";
        private string user = "root";
        private string pwd = "user";

        /// <summary>
        /// Coneccion a la base de datos
        /// </summary>
        public MySqlConnection conn = null;

        /// <summary>
        /// Realiza la coneccion a la base de datos
        /// </summary>
        public void Conectar() {
            if (conn == null){
                conn = new MySqlConnection();
                conn.ConnectionString = "server= " + host + "; port="+port+"; Database=" + database + "; Uid=" + user + "; pwd=" + pwd;
                conn.Open();
            }
            else {
                Desconectar();
            }
        }

        /// <summary>
        /// Finaliza la coneccion de la base de datos
        /// </summary>
        public void Desconectar() {
            if (conn != null) {
                conn.Close();
                conn = null;
            }
        }

        /// <summary>
        /// Realiza consultas mas avanzadas
        /// </summary>
        /// <param name="sqlcomand"></param>
        /// <returns name="result"> Retorna MySqlReader</returns>
        public MySqlDataReader ConsultMultiTable(string sqlcomand)
        {
            MySqlDataReader result = null;
            Conectar();
            MySqlCommand query = new MySqlCommand(sqlcomand, conn);
            result = query.ExecuteReader();
            Desconectar();
            return result;
        }

    }
}
