using names_ms.Domain.Filters;
using System.ComponentModel.DataAnnotations;

namespace names_ms.Application.Dtos
{
    public class NameFilterParameters
    {
        /// <summary>
        /// Género del nombre: F (femenino) o M (masculino).
        /// </summary>
        /// <example>M</example>
        [MaxLength(1, ErrorMessage = "El género debe tener un solo carácter.")]
        public string? Gender { get; set; }

        /// <summary>
        /// Inicia con el nombre.
        /// </summary>
        /// <example>A</example>
        [MaxLength(1, ErrorMessage = "El prefijo del nombre debe tener un solo carácter.")]
        public string? NameStartsWith { get; set; }

        // Método que devuelve el valor del parámetro para cada filtro
        public string? GetParameterForFilter(Type filterType)
        {
            return filterType switch
            {
                Type t when t == typeof(GenderFilter) => Gender,
                Type t when t == typeof(NameStartsWithFilter) => NameStartsWith,
                _ => null
            };
        }
    }
}
