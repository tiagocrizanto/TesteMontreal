namespace Montreal.NomeSistema.Modulo1.Data.Interfaces
{
    public interface IUnitOfWork : System.IDisposable
    {
        void Commit();
    }
}
