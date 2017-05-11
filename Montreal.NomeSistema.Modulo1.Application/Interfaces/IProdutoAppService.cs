using Montreal.NomeSistema.Modulo1.Application.DTO;
using System;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Application
{
    public interface IProdutoAppService
    {
        bool AdicionarProduto(ProdutoDto produtoDto);
        bool ExcluirProduto(Guid id);
        bool AtualizarProduto(AtualizarProdutoDto produto);
        ProdutoComRelacionamentosDto RetornarProdutoPorId(Guid id);
        IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosExcluindoRelacionamentos();
        IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentos();
        IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentosPorId(Guid idProduto);
        IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosSemRelacionamentosPorId(Guid idProduto);
        IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosFilhosPorIdProduto(Guid idProduto);
    }
}