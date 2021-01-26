namespace ProAgil.Repository
{
    public interface IUnitOfWork
    {

        // IProAgilRepository ProAgilRepository {get;}
        IEventoRepository EventoRepository {get;}

        void Commit();
    }
}