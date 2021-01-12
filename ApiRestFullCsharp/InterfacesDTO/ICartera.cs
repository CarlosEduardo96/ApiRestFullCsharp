using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFullCsharp.Models;

namespace ApiRestFullCsharp.InterfacesDTO
{
    interface ICartera
    {
        public List<CarteraModel> SelectAll();
        public CarteraModel SelectById(int id);
        public CarteraModel SelectByIdForeig(int idForeing);
        public CarteraModel Insert(CarteraModel p);
        public CarteraModel Delete(int id);
        public CarteraModel Update(CarteraModel p);
    }
}
