using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.Dapper
{
    public interface IProdutoDapperRepository : IBaseDapperRepository<Produto>
    {
        IEnumerable<Produto> ExemploGetTopX(int top);
        IEnumerable<Produto> ObterProdutosExcluindoRelacionamentos();
    }
}
