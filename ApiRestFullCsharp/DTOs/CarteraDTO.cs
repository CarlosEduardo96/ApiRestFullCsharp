using ApiRestFullCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ApiRestFullCsharp.InterfacesDTO;


namespace ApiRestFullCsharp.DTOs
{
    /// <summary>
    /// Interactua con la tabla Cartera en la base de datos
    /// </summary>
    public class CarteraDTO : ConectionModel, ICartera
    {
        private MySqlCommand command;
        private MySqlDataReader reader;       

        /// <summary>
        /// Elimina el resgitro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CarteraModel Delete(int id)
        {
            CarteraModel del = SelectById(id);
            if (del != null) {
                Conectar();
                string sql = "delete from cartera where id_car="+del.id_car;
                command = new MySqlCommand(sql,conn);
                command.ExecuteNonQuery();
                Desconectar();
            }            
            return del;
        }

        /// <summary>
        /// Inserta el registro en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public CarteraModel Insert(CarteraModel c)
        {
            Conectar();
            string sql = string.Format("Insert into cartera values(null,{0},'{1}',{2});",
                c.Pesos,c.TipoMoneda,c.id_p);
            command = new MySqlCommand(sql,conn);
            command.ExecuteNonQuery();
            c.id_car = Convert.ToInt32(command.LastInsertedId);
            Desconectar();
            return c;
        }
        /// <summary>
        /// Selecciona todos los registros
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Busca la cartera por su id en la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Realiza la consulta por la llave foranea
        /// </summary>
        /// <param name="idForeing"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Actualiza el registro en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public CarteraModel Update(CarteraModel c)
        {
            CarteraModel upgrade = SelectById(c.id_car);
            if (upgrade != null) {
                Conectar();
                string sql = string.Format("update cartera set Pesos={0}, TipoMoneda='{1}' where id_car={2};",
                    c.Pesos,c.TipoMoneda,c.id_car);
                command = new MySqlCommand(sql,conn);
                command.ExecuteNonQuery();
                upgrade = c;
                Desconectar();
            }
            return upgrade;
        }
    }
}
