namespace ProAgil.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private EventoRepository _eventoRepository;
        public ProAgilContext _context;

        public UnitOfWork(ProAgilContext context)
        {
            _context = context;
        }

        public IEventoRepository EventoRepository
        {
            get
            {
                return _eventoRepository = _eventoRepository ?? new EventoRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}