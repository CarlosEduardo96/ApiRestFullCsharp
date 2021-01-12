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
    /// <summary>
    /// Trae los datos de las personas registradas
    /// </summary>
    [Route("api/[controller]")]    
    [ApiController]
    public class PersonaController : ControllerBase
    {

        /// <summary>
        /// Trae todos los registros de personas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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

        /// <summary>
        /// Trae datos de la persona por id
        /// </summary>        
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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

        /// <summary>
        /// Trae datos de la persona por nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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
        /// <summary>
        /// Registra a una nueva pernosa
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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

        /// <summary>
        /// Elimina a la persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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
        /// <summary>
        /// Actualiza datos de la persona por su id,
        /// Devuelve un mensaje de error si la persona no esta registrada
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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
