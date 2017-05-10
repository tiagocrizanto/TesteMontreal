using Montreal.NomeSistema.Modulo1.Application;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;
using Montreal.NomeSistema.Modulo1.Domain.Produto;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.Dapper;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Services;
using Montreal.NomeSistema.Services.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Montreal.NomeSistema.Modulo1.Tests.UnitTests
{
    public class ProdutoTests
    {
        //[Trait]
        //[Theory(DisplayName = "Users valid login")]
        //[Trait("LoginService", "ValidLogin")]
        //[InlineData("usuario", "senha")]

        [Fact]
        [Trait("Produtos", "Retorno sem retorno imagens relacionadas")]
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
        [Trait("Produtos", "Retorno sem retorno imagens relacionadas")]
        public void Controller()
        {
            //Arrange
            var produtosAppService = new Mock<IProdutoAppService>();
            var imagensAppService = new Mock<IImagemAppService>();
            var controller = new ProdutosController(produtosAppService.Object, imagensAppService.Object);

            //Act
            //var value = controller.ObterProdutosComRelacionamentos();

            //Assert
            //var value1 = value;
        }
    }
}
