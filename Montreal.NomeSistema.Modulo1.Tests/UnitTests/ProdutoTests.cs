using Montreal.NomeSistema.Modulo1.Application;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Montreal.NomeSistema.Modulo1.Tests.UnitTests
{
    public class ProdutoTests
    {
        [Fact]
        [Trait("Produtos", "Retorno sem imagens relacionadas")]
        public void Produto_RecuperarProdutos_DeveRetornarProdutosExcluindoRelacionamento()
        {
            //Arrange
            var produtoId = Guid.NewGuid();

            var produto = new List<ProdutoSemRelacionamentosDto>
            {
                new ProdutoSemRelacionamentosDto
                {
                    Id = produtoId,
                    Descricao = "Derscrição novo Produto",
                    Nome = "Nome novo produto"
                }
            };

            //Act
            var produtoAppService = new Mock<IProdutoAppService>();
            produtoAppService.Setup(x => x.ObterProdutosExcluindoRelacionamentos()).Returns(produto);
            produtoAppService.Object.ObterProdutosExcluindoRelacionamentos();

            //Assert
            produtoAppService.Verify(x => x.ObterProdutosExcluindoRelacionamentos(), Times.Once());
        }

        [Fact]
        [Trait("Produtos", "Retorno imagens relacionadas")]
        public void Produto_RecuperarProdutos_DeveRetornarProdutosComRelacionamentos()
        {
            //Arrange
            var produtoId = Guid.NewGuid();

            var produto = new List<ProdutoComRelacionamentosDto>
            {
                new ProdutoComRelacionamentosDto
                {
                    Id = produtoId,
                    Descricao = "Derscrição novo Produto",
                    Nome = "Nome novo produto",
                    Imagens = new List<ImagemDto>()
                    {
                        new ImagemDto
                        {
                            Id = Guid.NewGuid(),
                            IdProduto = produtoId,
                            Tipo = "Eletrônico"
                        }
                    }
                }
            };

            //Act
            var produtoAppService = new Mock<IProdutoAppService>();
            produtoAppService.Setup(x => x.ObterProdutosComRelacionamentos()).Returns(produto);
            produtoAppService.Object.ObterProdutosComRelacionamentos();

            //Assert
            produtoAppService.Verify(x => x.ObterProdutosComRelacionamentos(), Times.Once());
        }

        [Fact]
        [Trait("Produtos", "Retorno sem imagens relacionadas por id produto")]
        public void Produto_RecuperarProdutos_DeveRetornarProdutosSemRelacionamentosPorIdProduto()
        {
            //Arrange
            var produtoId = Guid.NewGuid();

            var produto = new List<ProdutoSemRelacionamentosDto>
            {
                new ProdutoSemRelacionamentosDto
                {
                    Id = produtoId,
                    Descricao = "Derscrição novo Produto",
                    Nome = "Nome novo produto"
                }
            };

            //Act
            var produtoAppService = new Mock<IProdutoAppService>();
            produtoAppService.Setup(x => x.ObterProdutosSemRelacionamentosPorId(produtoId)).Returns(produto);
            produtoAppService.Object.ObterProdutosSemRelacionamentosPorId(produtoId);

            //Assert
            produtoAppService.Verify(x => x.ObterProdutosSemRelacionamentosPorId(produtoId), Times.Once());
        }

        [Fact]
        [Trait("Produtos", "Retorno com imagens relacionadas por id produto")]
        public void Produto_RecuperarProdutos_DeveRetornarProdutosComRelacionamentosPorIdProduto()
        {
            //Arrange
            var produtoId = Guid.NewGuid();

            var produto = new List<ProdutoComRelacionamentosDto>
            {
                new ProdutoComRelacionamentosDto
                {
                    Id = produtoId,
                    Descricao = "Derscrição novo Produto",
                    Nome = "Nome novo produto",
                    Imagens = new List<ImagemDto>()
                    {
                        new ImagemDto
                        {
                            Id = Guid.NewGuid(),
                            IdProduto = produtoId,
                            Tipo = "Eletrônico"
                        }
                    }
                }
            };

            //Act
            var produtoAppService = new Mock<IProdutoAppService>();
            produtoAppService.Setup(x => x.ObterProdutosComRelacionamentosPorId(produtoId)).Returns(produto);
            produtoAppService.Object.ObterProdutosComRelacionamentosPorId(produtoId);

            //Assert
            produtoAppService.Verify(x => x.ObterProdutosComRelacionamentosPorId(produtoId), Times.Once());
        }

        [Fact]
        [Trait("Produtos", "Retorno filhos de um produto por id produto")]
        public void Produto_RecuperarProdutos_DeveRetornarProdutosFilhosPorIdProduto()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var produto2Id = Guid.NewGuid();

            var produto = new List<ProdutoComRelacionamentosDto>
            {
                new ProdutoComRelacionamentosDto
                {
                    Id = produtoId,
                    Descricao = "Derscrição novo Produto",
                    Nome = "Nome novo produto",
                    Imagens = new List<ImagemDto>()
                    {
                        new ImagemDto
                        {
                            Id = Guid.NewGuid(),
                            IdProduto = produtoId,
                            Tipo = "Eletrônico"
                        }
                    }
                },
                new ProdutoComRelacionamentosDto
                {
                    Id = produto2Id,
                    Descricao = "Derscrição novo Produto 1",
                    Nome = "Nome novo produto 1",
                    IdProdutoPai = produtoId,
                    Imagens = new List<ImagemDto>()
                    {
                        new ImagemDto
                        {
                            Id = Guid.NewGuid(),
                            IdProduto = produto2Id,
                            Tipo = "Eletrônico"
                        }
                    }
                }
            };

            //Act
            var produtoAppService = new Mock<IProdutoAppService>();
            produtoAppService.Setup(x => x.ObterProdutosFilhosPorIdProduto(produtoId)).Returns(produto);
            produtoAppService.Object.ObterProdutosFilhosPorIdProduto(produtoId);

            //Assert
            produtoAppService.Verify(x => x.ObterProdutosFilhosPorIdProduto(produtoId), Times.Once());
        }
    }
}
