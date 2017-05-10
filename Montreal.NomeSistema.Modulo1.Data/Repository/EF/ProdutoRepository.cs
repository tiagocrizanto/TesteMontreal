using Montreal.NomeSistema.Modulo1.Data.Context;
using Montreal.NomeSistema.Modulo1.Domain.Produto;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;

namespace Montreal.NomeSistema.Modulo1.Data.Repository.EF
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Modulo1Context modulo1Context)
            : base(modulo1Context)
        {

        }
    }
}