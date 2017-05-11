using System;
using System.Linq;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;
using Montreal.NomeSistema.Modulo1.Domain.Produto;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Application.Adapters
{
    public static class ProdutoAdapter
    {
        public static ProdutoComRelacionamentosDto ToProdutoComRelacionamentoDto(Produto produto)
        {
            return new ProdutoComRelacionamentosDto
            {
                Descricao = produto.Descricao,
                Id = produto.Id,
                IdProdutoPai = produto.IdProdutoPai,
                Nome = produto.Nome,
                Imagens = produto.Imagens.Select(x => new ImagemDto
                {
                    Id = x.Id,
                    IdProduto = x.IdProduto,
                    Tipo = x.Tipo
                }).ToList()
            };
        }

        public static ProdutoSemRelacionamentosDto ToProdutoSemRelacionamentoDto(Produto produto)
        {
            return new ProdutoSemRelacionamentosDto
            {
                Descricao = produto.Descricao,
                Id = produto.Id,
                Nome = produto.Nome
            };
        }

        public static Produto ToProdutoModel(ProdutoDto produtoDto)
        {
            return new Produto
            {
                Descricao = produtoDto.Descricao,
                Id = produtoDto.Id,
                Nome = produtoDto.Nome,
                IdProdutoPai = produtoDto?.IdProdutoPai,
                Imagens = produtoDto.Imagens?.Select(x => new Imagem
                {
                    Id = x.Id,
                    IdProduto = x.IdProduto,
                    Tipo = x.Tipo
                }).ToList()
            };
        }

        public static Produto ToProdutoModel(AtualizarProdutoDto produtoDto, Produto produtoModel)
        {
            produtoModel.Descricao = produtoDto.Descricao;
            produtoModel.Id = produtoDto.Id;
            produtoModel.Nome = produtoDto.Nome;
            produtoModel.IdProdutoPai = produtoDto?.IdProdutoPai;

            return produtoModel;
        }
    }
}