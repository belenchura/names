using names_ms.Domain.Entities;

namespace names_ms.Application.Interfaces
{
    public interface INameRepository
    {
        public IEnumerable<NameEntity> GetAllNames();
    }
}
