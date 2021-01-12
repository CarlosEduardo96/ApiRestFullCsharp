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
    /// <summary>
    /// Trae registros con base a las carteras del cliente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CarteraController : ControllerBase
    {

        /// <summary>
        /// Trae todas las carteras registradas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="240">No se encontraron resultados</response>
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

        /// <summary>
        /// Trae el registro de cartera por el id
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Trae el registro de la cartera por el id de la persona
        /// </summary>
        /// <param name="ForeingKey"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No se encontraron resultados</response>
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

        /// <summary>
        /// Elimina la cartera por medio de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Success</response>
        /// <response code="400">No existe el registro</response>
        [HttpDelete("delete")]
        public IActionResult Delete(int id) {
            CarteraDTO query = new CarteraDTO();
            PaqueteDTO pack = new PaqueteDTO();

            CarteraModel cartera = query.Delete(id);

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
                return BadRequest(pack);
            }
        }

        /// <summary>
        /// Crea una cartera nueva
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPut("create")]
        public IActionResult Create(CarteraModel c) {
            CarteraDTO query = new CarteraDTO();
            PaqueteDTO pack = new PaqueteDTO();

            CarteraModel insert = query.Insert(c);
            if (insert != null)
            {
                List<CarteraModel> data = new List<CarteraModel>();
                data.Add(insert);

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
        /// <summary>
        /// Actualiza los datos de la cartera del cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        public IActionResult Update(CarteraModel c) {
            PaqueteDTO pack = new PaqueteDTO();
            CarteraDTO query = new CarteraDTO();

            CarteraModel upgrade = query.Update(c);

            if (upgrade != null) {
                List<CarteraModel> data = new List<CarteraModel>();
                data.Add(upgrade);

                pack.status = 200;
                pack.msn = "Success";
                pack.data = data.ToArray();
                return Ok(pack);
            }
            else
            {
                pack.status = 400;
                pack.msn = "Error al insertar los datos";
                return BadRequest(pack);
            }
        }

    }
}
