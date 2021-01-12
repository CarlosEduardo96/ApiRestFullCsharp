using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFullCsharp.DTOs;
using ApiRestFullCsharp.Models;

namespace ApiRestFullCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteraController : ControllerBase
    {

        
        [HttpGet]        
        public IActionResult SelectAll() {
            CarteraDTO query = new CarteraDTO();
            PaqueteDTO pack = new PaqueteDTO();

            List<CarteraModel> lista = query.SelectAll();

            if (lista != null)
            {
                pack.status = 200;
                pack.msn = "Success";
                pack.data = lista.ToArray();
                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "No se encontraron registros";
                return Ok(pack);
            }          

        }
        
        [HttpPost("ById")]
        public IActionResult SelectById(int id) {
            CarteraDTO query = new CarteraDTO();
            PaqueteDTO pack = new PaqueteDTO();

            CarteraModel cartera = query.SelectById(id);
            if (cartera != null)
            {
                List<CarteraModel> data = new List<CarteraModel>();
                data.Add(cartera);
                pack.status = 200;
                pack.msn = "Success";
                pack.data = data.ToArray();
                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "No se encontraron resultados";
                return BadRequest(pack);
            }

        }

        [HttpPost("ByPersonaId")]
        public IActionResult SelectByForeingKey(int ForeingKey) {
            CarteraDTO query = new CarteraDTO();
            PaqueteDTO pack = new PaqueteDTO();

            CarteraModel c = query.SelectByIdForeig(ForeingKey);

            if (c != null)
            {
                List<CarteraModel> data = new List<CarteraModel>();
                data.Add(c);
                pack.status = 200;
                pack.msn = "Success";
                pack.data = data.ToArray();
                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "No se encontraron resultados";
                return BadRequest(pack);
            }
        }
    }
}
