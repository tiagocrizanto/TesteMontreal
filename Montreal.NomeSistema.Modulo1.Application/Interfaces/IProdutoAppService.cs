using Montreal.NomeSistema.Modulo1.Application.DTO;
using System;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Application
{
    public interface IProdutoAppService
    {
        IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosExcluindoRelacionamentos();
        IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentos();
        IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentosPorId(Guid idProduto);
        IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosSemRelacionamentosPorId(Guid idProduto);
        IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosFilhosPorIdProduto(Guid idProduto);
    }
}