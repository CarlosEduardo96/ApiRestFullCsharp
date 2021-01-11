using ApiRestFullCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullCsharp.DTOs
{

    public class CarteraDTO : Models.ConectionModel , InterfacesDTO.ICartera
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(CarteraModel p)
        {
            throw new NotImplementedException();
        }

        public void Insert(CarteraModel p)
        {
            throw new NotImplementedException();
        }

        public List<CarteraModel> SelectAll()
        {
            throw new NotImplementedException();
        }

        public CarteraModel SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public CarteraModel SelectByIdForeig(int idForeing)
        {
            throw new NotImplementedException();
        }
    }
}
