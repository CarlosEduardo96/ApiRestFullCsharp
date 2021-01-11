using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFullCsharp.Models;

namespace ApiRestFullCsharp.InterfacesDTO
{
    interface IPersona
    {
        public List<PersonaModel> SelectAll();
        public PersonaModel SelectById(int id);
        public List<PersonaModel> SelectByName(string name);
        public PersonaModel Insert(PersonaModel P);
        public void Delete(int id);
        public void Edit(Models.PersonaModel p);
    }
}
