using Montreal.NomeSistema.Modulo1.Application;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Montreal.NomeSistema.Modulo1.Tests.UnitTests
{
    public class ImagemTests
    {
        [Fact]
        [Trait("Produtos", "Retorno imagens de um produto por id produto")]
        public void Produto_RecuperarProdutos_DeveRetornarImagensPorIdProduto()
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

            var imagens = new List<ImagemDto>
            {
                new ImagemDto
                {
                    Id = Guid.NewGuid(),
                    IdProduto = produtoId,
                    Tipo = "Gif"
                }
            };

            //Act
            var produtoAppService = new Mock<IImagemAppService>();
            produtoAppService.Setup(x => x.ObterImagensPorIdProduto(produtoId)).Returns(imagens);
            produtoAppService.Object.ObterImagensPorIdProduto(produtoId);

            //Assert
            produtoAppService.Verify(x => x.ObterImagensPorIdProduto(produtoId), Times.Once());
        }
    }
}
