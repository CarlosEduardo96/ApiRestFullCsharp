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
                return BadRequest(pack);
            }            
            
        }

        [HttpPost("ById")]
        public IActionResult SelectById(int id) {
            PersonaDTO select = new PersonaDTO();
            PaqueteDTO pack = new PaqueteDTO();
            PersonaModel p = select.SelectById(id);

            if (p != null)
            {
                List<PersonaModel> data = new List<PersonaModel>();
                data.Add(p);
                pack.status = 200;
                pack.msn = "Success";
                pack.data = data.ToArray();
                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "No se encontraron resultados con el id "+id;
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
                pack.msn = "No se encontraron resultados con el nombre de "+name;                
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

        [HttpDelete("delete")]
        public IActionResult Delete(int id) {

            PaqueteDTO paquete = new PaqueteDTO();
            PersonaDTO p = new PersonaDTO();            
            
            PersonaModel deletep = p.Delete(id);

            if (deletep != null)
            {
                List<PersonaModel> data = new List<PersonaModel>();
                data.Add(deletep);
                paquete.status = 200;
                paquete.msn = "Success";
                paquete.data = data.ToArray();
                return Ok(paquete);
            }
            else {
                paquete.status = 400;
                paquete.msn = "El id "+id+" no esta registrado";
                return BadRequest(paquete);
            }
        }

        [HttpPost("edit")]
        public IActionResult Update(PersonaModel request) {
            PersonaDTO persona = new PersonaDTO();
            PaqueteDTO pack = new PaqueteDTO();
            
            PersonaModel upgrade = persona.Update(request);
            if (upgrade != null)
            {

                List<PersonaModel> data = new List<PersonaModel>();
                data.Add(upgrade);
                pack.status = 200;
                pack.msn = "Success";
                pack.data = data.ToArray();
                return Ok(pack);
            }
            else {
                pack.status = 400;
                pack.msn = "La persona no esta registrada";
                return BadRequest(pack);
            }
            
        }

    }
    
}
