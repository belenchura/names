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

        /// <summary>
        /// Obtiene una lista de nombres filtrados.
        /// </summary>
        /// <param name="filterParameters">Parámetros para filtrar los nombres.</param>
        /// <returns>
        /// Una lista de nombres que coinciden con los criterios de filtrado.
        /// En caso de no encontrar coincidencias, se retornará una lista vacía.
        /// </returns>
        /// <response code="200">Devuelve una lista de nombres filtrados.</response>
        /// <response code="400">Si los parámetros de filtrado son inválidos.</response>
        [HttpGet]
        public IActionResult GetNames([FromQuery] NameFilterParameters filterParameters)
        {
            var result = _nameService.GetNames(filterParameters);
            return Ok(result);
        }
    }
}
