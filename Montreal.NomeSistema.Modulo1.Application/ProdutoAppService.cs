using Montreal.NomeSistema.Modulo1.Application.Adapters;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;
using System.Linq;
using System;
using System.Collections.Generic;

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
            return _produtoService.GetAll().Select(x => new ProdutoSemRelacionamentosDto
            {
                Descricao = x.Descricao,
                Id = x.Id,
                Nome = x.Nome
            });
        }

        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentos()
        {
            return _produtoService.GetAll().ToList().Select(x => new ProdutoComRelacionamentosDto
            {
                Descricao = x.Descricao,
                Id = x.Id,
                Nome = x.Nome,
                Imagens = x.Imagens.Where(p => p.IdProduto == x.Id).Select(q => new ImagemDto
                {
                    Id = q.Id,
                    IdProduto = q.IdProduto,
                    Tipo = q.Tipo
                }).ToList()
            });
        }

        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentosPorId(Guid idProduto)
        {
            return _produtoService.FindAll(x => x.Id == idProduto || x.IdProdutoPai == idProduto).Select(x => new ProdutoComRelacionamentosDto
            {
                Descricao = x.Descricao,
                Id = x.Id,
                IdProdutoPai = x.IdProdutoPai,
                Nome = x.Nome,
                Imagens = x.Imagens.Where(p => p.IdProduto == x.Id).Select(q => new ImagemDto
                {
                    Id = q.Id,
                    IdProduto = q.IdProduto,
                    Tipo = q.Tipo
                }).ToList()
            });
        }

        public IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosFilhosPorIdProduto(Guid idProduto)
        {
            return _produtoService.FindAll(x => x.IdProdutoPai == idProduto).Select(x => new ProdutoSemRelacionamentosDto
            {
                Descricao = x.Descricao,
                Id = x.Id,
                Nome = x.Nome
            });
        }

        public IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosSemRelacionamentosPorId(Guid idProduto)
        {
            return _produtoService.FindAll(x => x.Id == idProduto || x.IdProdutoPai == idProduto).Select(x => new ProdutoSemRelacionamentosDto
            {
                Descricao = x.Descricao,
                Id = x.Id,
                Nome = x.Nome
            });
        }
    }
}