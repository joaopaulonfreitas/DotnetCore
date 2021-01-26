using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    // public interface IEventoRepository  : IRepository<Evento>
    public interface IEventoRepository  : IRepository<Evento>
    {
        Task<Evento[]> GetAllEventosAsync();

    }
}