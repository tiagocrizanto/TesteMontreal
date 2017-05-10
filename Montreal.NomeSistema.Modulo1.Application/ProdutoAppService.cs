using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;
using System.Linq;
using System;
using System.Collections.Generic;
using Montreal.NomeSistema.Modulo1.Application.Adapters;

namespace Montreal.NomeSistema.Modulo1.Application
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosExcluindoRelacionamentos()
        {
            return _produtoService.GetAll().Select(x => ProdutoAdapter.ToProdutoSemRelacionamentoDto(x));
        }

        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentos()
        {
            return _produtoService.GetAll().ToList().Select(x => ProdutoAdapter.ToProdutoComRelacionamentoDto(x));
        }

        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentosPorId(Guid idProduto)
        {
            return _produtoService.FindAll(x => x.Id == idProduto || x.IdProdutoPai == idProduto).Select(x => ProdutoAdapter.ToProdutoComRelacionamentoDto(x));
        }

        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosFilhosPorIdProduto(Guid idProduto)
        {
            return _produtoService.FindAll(x => x.IdProdutoPai == idProduto).Select(x => ProdutoAdapter.ToProdutoComRelacionamentoDto(x));
        }

        public IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosSemRelacionamentosPorId(Guid idProduto)
        {
            return _produtoService.FindAll(x => x.Id == idProduto || x.IdProdutoPai == idProduto).Select(x => ProdutoAdapter.ToProdutoSemRelacionamentoDto(x));
        }
    }
}