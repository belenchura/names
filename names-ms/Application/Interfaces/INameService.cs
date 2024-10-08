using names_ms.Application.Dtos;

namespace names_ms.Application.Interfaces
{
    public interface INameService
    {
        IEnumerable<string> GetNames(NameFilterParameters filterParameters);

    }
}
