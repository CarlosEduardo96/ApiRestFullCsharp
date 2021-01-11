using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ApiRestFullCsharp.Models
{
    public class ConectionModel
    {
        private string host = "localhost";
        private int port = 3306;
        private string database = "registro";
        private string user = "root";
        private string pwd = "user";

        public MySqlConnection conn = null;

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

        public void Desconectar() {
            if (conn != null) {
                conn.Close();
                conn = null;
            }
        }

    }
}
