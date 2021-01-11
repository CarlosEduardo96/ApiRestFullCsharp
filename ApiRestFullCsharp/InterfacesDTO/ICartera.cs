using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullCsharp.InterfacesDTO
{
    interface ICartera
    {
        public List<Models.CarteraModel> SelectAll();
        public Models.CarteraModel SelectById(int id);
        public Models.CarteraModel SelectByIdForeig(int idForeing);
        public void Insert(Models.CarteraModel p);
        public void Delete(int id);
        public void Edit(Models.CarteraModel p);
    }
}
