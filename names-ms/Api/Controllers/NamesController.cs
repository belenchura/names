using Microsoft.AspNetCore.Mvc;
using names_ms.Application.Dtos;
using names_ms.Application.Interfaces;

namespace names_ms.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NamesController : ControllerBase
    {
        private readonly INameService _nameService;

        public NamesController(INameService nameService)
        {
            _nameService = nameService;
        }

        [HttpPost("filter")]
        public IActionResult GetNames([FromBody] NameFilterParameters filterParameters)
        {
            // Obtener los nombres filtrados a través del servicio
            var result = _nameService.GetNames(filterParameters);

            // Retornar los nombres como JSON
            return Ok(result);
        }
    }
}
