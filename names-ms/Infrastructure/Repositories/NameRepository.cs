using names_ms.Application.Interfaces;
using names_ms.Domain.Entities;
using Newtonsoft.Json;

namespace names_ms.Infrastructure.Repositories
{
    public class NameRepository : INameRepository
    {
        private readonly List<NameEntity> _names;

        public NameRepository()
        {
            var json = File.ReadAllText("Infrastructure/Data/names.json");
            var data = JsonConvert.DeserializeObject<Root>(json);
            _names = data.Response;
        }

        public IEnumerable<NameEntity> GetAllNames()
        {
            return _names;
        }
    }

    public class Root
    {
        public List<NameEntity> Response { get; set; }
    }
}
