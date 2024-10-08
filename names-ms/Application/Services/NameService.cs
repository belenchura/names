using names_ms.Application.Dtos;
using names_ms.Application.Interfaces;
using names_ms.Domain.Filters;
using names_ms.Infrastructure.Repositories;

namespace names_ms.Application.Services
{
    public class NameService : INameService
    {
        private readonly INameRepository _nameRepository;
        private readonly IEnumerable<IFilterStrategy> _allFilters;

        public NameService(IEnumerable<IFilterStrategy> allFilters, INameRepository nameRepository)
        {
            _nameRepository = nameRepository;
            _allFilters = allFilters;
        }

        public IEnumerable<string> GetNames(NameFilterParameters filterParameters)
        {
            var names = _nameRepository.GetAllNames();

            // Aplica los filtros en cadena
            foreach (var filter in _allFilters)
            {
                if (filter.IsApplicable(filterParameters))
                {
                    names = filter.Apply(names, filterParameters);
                }
            }

            return names.Select(name => name.Name);
        }
    }
}
