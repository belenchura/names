using names_ms.Domain.Filters;
using System.ComponentModel.DataAnnotations;

namespace names_ms.Application.Dtos
{
    public class NameFilterParameters
    {
        [StringLength(1, ErrorMessage = "Gender must be at most 1 character long.")]
        public string? Gender { get; set; }
        [StringLength(1, ErrorMessage = "NameStartsWith must be at most 1 character long.")]
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
