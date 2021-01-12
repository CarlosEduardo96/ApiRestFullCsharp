using ApiRestFullCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using ApiRestFullCsharp.InterfacesDTO;

namespace ApiRestFullCsharp.DTOs
{

    public class PersonaDTO : ConectionModel , IPersona
    {
        private MySqlCommand command;
        private MySqlDataReader reader;

        public PersonaDTO() { }

        public PersonaModel Delete(int id)
        {
            PersonaModel p = SelectById(id);
            if ( p!= null)
            {
                Conectar();
                string sql = string.Format("delete from personas where id={0}", id);
                command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();               
                Desconectar();
        }

            return p;
        }

        public PersonaModel Update(PersonaModel p)
        {
            PersonaModel Upgrade = SelectById(p.id);
            if (Upgrade != null) {
                string sql = string.Format("update personas set nombre='{0}', sexo='{1}', edad={2} where id={3}",
                    p.nombre,p.sexo,p.edad,p.id);
                Conectar();
                command = new MySqlCommand(sql,conn);
                command.ExecuteNonQuery();
                Desconectar();
                Upgrade = p;
            }           
            
            return Upgrade;
        }

        public PersonaModel Insert(PersonaModel persona)
        {
            Conectar();
            string sql = String.Format("insert into personas values(null,'{0}','{1}',{2})",
                persona.nombre, persona.sexo, persona.edad);
            command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            persona.id = Convert.ToInt32(command.LastInsertedId);
            Desconectar();
            return persona;
        }

        public List<PersonaModel> SelectAll()
        {

            List<PersonaModel> lista = null;
            Conectar();
            string sql = "select * from personas;";
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                lista = new List<PersonaModel>();
                while (reader.Read()) {

                    PersonaModel p = new PersonaModel {
                        id = int.Parse(reader["id"].ToString()),
                        nombre= reader["nombre"].ToString(),
                        sexo = reader["sexo"].ToString(),
                        edad = int.Parse(reader["edad"].ToString())
                    };

                    lista.Add(p);
                }
            }           
            Desconectar();
            return lista;
        }

        public PersonaModel SelectById(int id)
        {
            PersonaModel p = null;
            Conectar();
            string sql = string.Format("select * from personas where id={0}",id);
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    p = new PersonaModel
                    {
                        id = int.Parse(reader["id"].ToString()),
                        nombre = reader["nombre"].ToString(),
                        sexo = reader["sexo"].ToString(),
                        edad = int.Parse(reader["edad"].ToString())
                    };
                }
            }
            Desconectar();
            return p;
        }

        public List<PersonaModel> SelectByName(string name)
        {
            List<PersonaModel> lista = null;
            Conectar();

            string sql = "select * from personas where nombre like '%"+name+"'";
            command = new MySqlCommand(sql,conn);
            reader = command.ExecuteReader();
            if (reader.HasRows) {
                lista = new List<PersonaModel>();
                while (reader.Read()) {
                    PersonaModel P = new PersonaModel {
                        id = int.Parse(reader["id"].ToString()),
                        nombre = reader["nombre"].ToString(),
                        sexo = reader["sexo"].ToString(),
                        edad = int.Parse(reader["edad"].ToString())
                    };

                    lista.Add(P);
                }
            }
            Desconectar();
            return lista;
        }
    }
}
