using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {

        public EventoRepository(ProAgilContext context): base(context)
        {

        }

        public async Task<Evento[]> GetAllEventosAsync()
        {
            return await Get().ToArrayAsync();           
        }


        // public async Task<Evento> GetEventById(int EventoId, bool includePalestrantes)
        // {
        //     return await GetById();
        // }

    }
}