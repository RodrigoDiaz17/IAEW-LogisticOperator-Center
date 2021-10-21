using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("ordenes_envio/{orden_envio}")]
        public IActionResult GetById(long id)
        {
            // getear envio
            return Ok(new DatosEnvio());
        }

        [HttpPost("ordenes_envio")]
        public IActionResult CreateOrder([FromBody] DatosEnvio datosEnvio) 
        {
            // crear envio
            var createdUri = $"uri del envio creado a armar despues";
            var createdEnvio = new DatosEnvio(); // retornar el envio creado despues
            return Created(createdUri, createdEnvio);
        }

        [HttpPost("ordenes_envio/{orden_envio}/repartidor/{id_repartidor}")]
        public IActionResult AssignDealer(long orden_envio , long id_repartidor)
        {
            // asignar repartidor
            
            return Ok();
        }

        [HttpPost("ordenes_envio/{orden_envio}/entrega")]
        public IActionResult RegisterDelivery([FromRoute] long orden_envio)
        {
            // actualizar estado y activar webhook

            return Ok();
        }
    }
}
