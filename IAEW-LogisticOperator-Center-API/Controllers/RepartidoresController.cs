using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.Data_Transfer_Objects;

namespace IAEW_LogisticOperator_Center_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidoresController : ControllerBase
    {

        private readonly IRepartidoresService _repartidoresService;

        public RepartidoresController(IRepartidoresService repartidoresService)
        {
            _repartidoresService = repartidoresService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var repartidores = _repartidoresService.GetAll();
            return Ok(repartidores);
        }

        [Route("{repartidorId}")]
        [HttpGet]
        public ActionResult GetById(long repartidorId)
        {
            var repartidor = _repartidoresService.GetById(repartidorId);
            return Ok(repartidor);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Repartidor repartidor)
        {
            var nuevoRepartidor = _repartidoresService.Create(repartidor);
            return Ok(nuevoRepartidor);
        }

        [HttpPut]
        public ActionResult Update(RepartidorDto dto)
        {
            var repartidor = _repartidoresService.Update(dto);
            return Ok(repartidor);
        }

        [Route("{repartidorId}")]
        [HttpDelete]
        public IActionResult Delete(long repartidorId)
        {
            var repartidor = _repartidoresService.Delete(repartidorId);
            return Ok(repartidor);
        }
    }
}
