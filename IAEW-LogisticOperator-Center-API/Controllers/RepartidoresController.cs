using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

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
            return Ok();
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

        [Route("{repartidorId}")]
        [HttpDelete]
        public IActionResult Delete(long repartidorId)
        {
            return Ok();
        }
    }
}
