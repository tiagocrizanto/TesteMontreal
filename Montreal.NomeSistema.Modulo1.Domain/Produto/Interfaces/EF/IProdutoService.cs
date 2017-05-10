using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF
{
    public interface IProdutoService : IBaseService<Produto>
    {
        IEnumerable<Produto> ObterProdutosExcluindoRelacionamentos();
    }
}
