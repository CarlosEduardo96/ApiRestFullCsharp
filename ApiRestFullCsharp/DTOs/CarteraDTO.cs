using ApiRestFullCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ApiRestFullCsharp.InterfacesDTO;


namespace ApiRestFullCsharp.DTOs
{

    public class CarteraDTO : ConectionModel, ICartera
    {
        private MySqlCommand command;
        private MySqlDataReader reader;

        public CarteraModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public CarteraModel Insert(CarteraModel p)
        {
            throw new NotImplementedException();
        }

        public List<CarteraModel> SelectAll()
        {
            List<CarteraModel> lista = null;
            string sql = "select * from cartera";
            Conectar();
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                lista = new List<CarteraModel>();
                while (reader.Read()) {
                    CarteraModel c = new CarteraModel
                    {
                        id_car = Convert.ToInt32(reader["id_car"]),
                        Pesos = Convert.ToDouble(reader["Pesos"]),
                        TipoMoneda = reader["TipoMoneda"].ToString(),
                        id_p = Convert.ToInt32(reader["id_p"])
                    };
                    lista.Add(c);
                }
            }
            Desconectar();
            return lista;
        }

        public CarteraModel SelectById(int id)
        {
            CarteraModel select = null;
            Conectar();
            string sql = "select * from cartera where id_car=" + id;
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    select = new CarteraModel
                    {
                        id_car = Convert.ToInt32(reader["id_car"]),
                        Pesos = Convert.ToDouble(reader["Pesos"]),
                        TipoMoneda = reader["TipoMoneda"].ToString(),
                        id_p = Convert.ToInt32(reader["id_p"])
                    };
                }
            }
            Desconectar();
            return select;
        }

        public CarteraModel SelectByIdForeig(int idForeing)
        {
            CarteraModel select = null;
            Conectar();
            string sql = "select * from cartera where id_p=" + idForeing;
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    select = new CarteraModel
                    {
                        id_car = Convert.ToInt32(reader["id_car"]),
                        Pesos = Convert.ToDouble(reader["Pesos"]),
                        TipoMoneda = reader["TipoMoneda"].ToString(),
                        id_p = Convert.ToInt32(reader["id_p"])
                    };
                }
            }
            Desconectar();
            return select;
        }

        public CarteraModel Update(CarteraModel p)
        {
            throw new NotImplementedException();
        }
    }
}
