using names_ms.Application.Dtos;
using names_ms.Domain.Entities;

namespace names_ms.Domain.Filters
{
    public interface IFilterStrategy
    {
        bool IsApplicable(NameFilterParameters parameters);
        IEnumerable<NameEntity> Apply(IEnumerable<NameEntity> names, NameFilterParameters parameters);
    }
}
