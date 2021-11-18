using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.Data_Transfer_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IAEW_LogisticOperator_Center_API.Controllers
{
    [Authorize]
    [Route("api/ordenes_envio")]
    [ApiController]
    public class OrdenesEnvioController : ControllerBase
    {
        private readonly IOrdenesService _ordenesService;

        public OrdenesEnvioController(IOrdenesService ordenesService)
        {
            _ordenesService = ordenesService;
        }

        [Route("{orderId}")]
        [HttpGet()]
        public IActionResult GetById(long orderId)
        {
            var order = _ordenesService.GetById(orderId);
            return Ok(order);
        }

        [HttpPost()]
        [Authorize(Policy = "write::envios")]
        public IActionResult CreateOrder([FromBody] OrdenEnvio datosEnvio) 
        {
            var nuevoEnvio = _ordenesService.Create(datosEnvio);
            return Ok(nuevoEnvio);
        }

        [HttpPost("{orden_envio}/repartidor/{id_repartidor}")]
        [Authorize(Policy = "write::envios")]
        public IActionResult AssignDealer(long orden_envio , long id_repartidor)
        {
            var nuevoEnvio = _ordenesService.AssignDelivery(orden_envio, id_repartidor);
            return Ok(nuevoEnvio);
        }

        [HttpPost("{orden_envio}/entrega")]
        [Authorize(Policy = "write::envios")]
        public async Task<IActionResult> RegisterDelivery([FromRoute] long orden_envio)
        {
            var result = await _ordenesService.RegisterDelivery(orden_envio);

            return Ok();
        }
    }
}
