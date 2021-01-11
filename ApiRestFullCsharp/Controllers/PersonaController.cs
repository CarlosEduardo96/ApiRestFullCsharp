using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestFullCsharp.Models;
using ApiRestFullCsharp.DTOs;

namespace ApiRestFullCsharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public IActionResult SelectAll() {
            PersonaDTO p = new PersonaDTO();
            List<PersonaModel> lista = p.SelectAll();

            PaqueteDTO pack = new PaqueteDTO();

            if (lista != null)
            {
                pack.status = 200;
                pack.msn = "Success";
                pack.data = lista.ToArray();
                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "No se encontraron resultados";
                pack.data = null;
                return BadRequest(pack);
            }            
            
        }

        [HttpPost("ByName")]
        public IActionResult SelectByName(string name) {
            PersonaDTO p = new PersonaDTO();
            PaqueteDTO pack = new PaqueteDTO();

            List<PersonaModel> lista = p.SelectByName(name);
            if (lista != null)
            {
                pack.status = 200;
                pack.msn = "Success";
                pack.data = lista.ToArray();

                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "No se encontraron resultados";
                pack.data = null;
                return BadRequest(pack);
            }
        }

        [HttpPut("create")]
        public IActionResult Create(PersonaModel p) {
            
            PersonaDTO insertp = new PersonaDTO();
            List<PersonaModel> data = new List<PersonaModel>();

            data.Add(insertp.Insert(p));

            PaqueteDTO paquete = new PaqueteDTO();  
            
            paquete.status = 200;
            paquete.msn = "Success";
            paquete.data= data.ToArray();
            return Ok(paquete);
        }
    }
    
}
