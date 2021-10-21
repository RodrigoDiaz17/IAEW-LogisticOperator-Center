using IAEW_LogisticOperator_Center_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace IAEW_LogisticOperator_Center_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidoresController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [Route("{repartidorId}")]
        [HttpGet]
        public IActionResult GetById(long repartidorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Repartidor repartidor)
        {
            return Ok();
        }

        [Route("{repartidorId}")]
        [HttpDelete]
        public IActionResult Delete(long repartidorId)
        {
            return Ok();
        }
    }
}
