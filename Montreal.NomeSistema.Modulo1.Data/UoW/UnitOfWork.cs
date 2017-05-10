using Montreal.NomeSistema.Modulo1.Data.Context;
using Montreal.NomeSistema.Modulo1.Data.Interfaces;

namespace Montreal.NomeSistema.Modulo1.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private Modulo1Context _context;

        public UnitOfWork(Modulo1Context context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}