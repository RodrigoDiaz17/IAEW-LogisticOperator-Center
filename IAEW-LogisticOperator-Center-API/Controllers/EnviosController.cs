using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAEW_LogisticOperator_Center_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly IOrdenesService _ordenesService;

        public EnviosController(IOrdenesService ordenesService)
        {
            _ordenesService = ordenesService;
        }

        [HttpGet("ordenes_envio/{orden_envio}")]
        public IActionResult GetById(long orden_envio)
        {
            // getear envio
            return Ok(new OrdenEnvio());
        }

        [HttpPost("ordenes_envio")]
        public IActionResult CreateOrder([FromBody] OrdenEnvio datosEnvio) 
        {
            // crear envio
            var createdUri = $"uri del envio creado a armar despues";
            var createdEnvio = new OrdenEnvio(); // retornar el envio creado despues
            return Created(createdUri, createdEnvio);
        }

        [HttpPost("ordenes_envio/{orden_envio}/repartidor/{id_repartidor}")]
        public IActionResult AssignDealer(long orden_envio , long id_repartidor)
        {
            // asignar repartidor
            
            return Ok();
        }

        [HttpPost("ordenes_envio/{orden_envio}/entrega")]
        public async Task<IActionResult> RegisterDelivery([FromRoute] long orden_envio)
        {
            var result = await _ordenesService.RegisterDelivery(orden_envio);

            return result ? Ok() : new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
