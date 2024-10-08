using names_ms.Application.Dtos;
using names_ms.Domain.Entities;
using System.Xml.Linq;

namespace names_ms.Domain.Filters
{
    public class NameStartsWithFilter : IFilterStrategy
    {
        public bool IsApplicable(NameFilterParameters parameters)
        {
            return !string.IsNullOrEmpty(parameters.NameStartsWith);
        }

        public IEnumerable<NameEntity> Apply(IEnumerable<NameEntity> names, NameFilterParameters parameters)
        {
            return names
                    .Where(n => n.Name.StartsWith(parameters.NameStartsWith, StringComparison.OrdinalIgnoreCase));
        }
    }
}
