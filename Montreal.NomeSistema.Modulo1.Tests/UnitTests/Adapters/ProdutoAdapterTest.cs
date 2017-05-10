using Montreal.NomeSistema.Modulo1.Application.Adapters;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;
using Montreal.NomeSistema.Modulo1.Domain.Produto;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Montreal.NomeSistema.Modulo1.Tests.UnitTests.Adapters
{
    public class ProdutoAdapterTest
    {
        [Fact]
        [Trait("Produtos", "Retorno com imagens relacionadas")]
        public void ProdutoAdapter_ConverterParaModel_DeveRetornarModelProdutoComImagem()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var imagemId = Guid.NewGuid();
            var produtoDtoEsperado = new ProdutoComRelacionamentosDto
            {
                Id = produtoId,
                Descricao = "Descrição novo Produto",
                Nome = "Nome novo produto",
                IdProdutoPai = null,
                Imagens = new List<ImagemDto>()
                    {
                        new ImagemDto
                        {
                            Id = imagemId,
                            IdProduto = produtoId,
                            Tipo = "Eletrônico"
                        }
                    }
            };

            var produto = new Produto
            {
                Id = produtoId,
                Descricao = "Descrição novo Produto",
                Nome = "Nome novo produto",
                IdProdutoPai = null,
                Imagens = new List<Imagem>()
                    {
                        new Imagem
                        {
                            Id = imagemId,
                            IdProduto = produtoId,
                            Tipo = "Eletrônico"
                        }
                    }
            };

            //Act
            var produtoDtoRetorno = ProdutoAdapter.ToProdutoComRelacionamentoDto(produto);

            //Assert
            Assert.Equal(produtoDtoEsperado.Id.ToString(), produtoDtoRetorno.Id.ToString());
            Assert.Equal(produtoDtoEsperado?.IdProdutoPai.ToString(), produtoDtoRetorno?.IdProdutoPai.ToString());
            Assert.Equal(produtoDtoEsperado.Imagens.FirstOrDefault().Id.ToString(), produtoDtoRetorno.Imagens.FirstOrDefault().Id.ToString());
            Assert.Equal(produtoDtoEsperado.Imagens.FirstOrDefault().IdProduto.ToString(), produtoDtoRetorno.Imagens.FirstOrDefault().IdProduto.ToString());
            Assert.Equal(produtoDtoEsperado.Imagens.FirstOrDefault().Tipo, produtoDtoRetorno.Imagens.FirstOrDefault().Tipo);
            Assert.Equal(produtoDtoEsperado.Nome, produtoDtoRetorno.Nome);
            Assert.Equal(produtoDtoEsperado.Descricao, produtoDtoRetorno.Descricao);
        }

        [Fact]
        [Trait("Produtos", "Retorno sem imagens relacionadas")]
        public void ProdutoAdapter_ConverterParaModel_DeveRetornarModelProdutoSemImagem()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var imagemId = Guid.NewGuid();
            var produtoDtoEsperado = new ProdutoSemRelacionamentosDto
            {
                Id = produtoId,
                Descricao = "Descrição novo Produto",
                Nome = "Nome novo produto"
            };

            var produto = new Produto
            {
                Id = produtoId,
                Descricao = "Descrição novo Produto",
                Nome = "Nome novo produto",
                IdProdutoPai = null,
                Imagens = new List<Imagem>()
                    {
                        new Imagem
                        {
                            Id = imagemId,
                            IdProduto = produtoId,
                            Tipo = "Eletrônico"
                        }
                    }
            };

            //Act
            var produtoDtoRetorno = ProdutoAdapter.ToProdutoComRelacionamentoDto(produto);

            //Assert
            Assert.Equal(produtoDtoEsperado.Id.ToString(), produtoDtoRetorno.Id.ToString());
            Assert.Equal(produtoDtoEsperado.Nome, produtoDtoRetorno.Nome);
            Assert.Equal(produtoDtoEsperado.Descricao, produtoDtoRetorno.Descricao);
        }
    }
}
