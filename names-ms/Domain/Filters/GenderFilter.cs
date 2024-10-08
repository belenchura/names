using names_ms.Application.Dtos;
using names_ms.Domain.Entities;

namespace names_ms.Domain.Filters
{
    public class GenderFilter : IFilterStrategy
    {
        public bool IsApplicable(NameFilterParameters parameters)
        {
            return !string.IsNullOrEmpty(parameters.Gender);
        }

        IEnumerable<NameEntity> IFilterStrategy.Apply(IEnumerable<NameEntity> names, NameFilterParameters parameters)
        {
            return names
                    .Where(n => n.Gender.Equals(parameters.Gender, StringComparison.OrdinalIgnoreCase));
        }
    }
}
