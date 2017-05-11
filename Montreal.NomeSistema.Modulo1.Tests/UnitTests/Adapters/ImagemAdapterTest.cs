using Montreal.NomeSistema.Modulo1.Application.Adapters;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;
using System;
using Xunit;

namespace Montreal.NomeSistema.Modulo1.Tests.UnitTests.Adapters
{
    public class ImagemAdapterTest
    {
        [Fact]
        [Trait("Imagem", "Conversão ImagemModel para dto")]
        public void ProdutoAdapter_ConverterParaModel_DeveRetornarModelProdutoSemImagem()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var imagemId = Guid.NewGuid();

            var imagemDtoEsperada = new ImagemDto
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };

            var imagem = new Imagem
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };

            //Act
            var imagemRetorno = ImagemAdapter.ToImagemDto(imagem);

            //Assert
            Assert.Equal(imagemDtoEsperada.Id.ToString(), imagemDtoEsperada.Id.ToString());
            Assert.Equal(imagemDtoEsperada.IdProduto.ToString(), imagemDtoEsperada.IdProduto.ToString());
            Assert.Equal(imagemDtoEsperada.Tipo, imagemDtoEsperada.Tipo);
        }

        [Fact]
        [Trait("Imagem", "Conversão dto para entidade")]
        public void ProdutoAdapter_ConverterParaModel_DeveRetornarModelImagemBaseadoEmOutraEntidade()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var imagemId = Guid.NewGuid();

            var imagemEsperada = new Imagem
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };

            var imagem = new Imagem
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };

            var imagemDto = new ImagemDto
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };
            

            //Act
            var modelRetorno = ImagemAdapter.ToImagemModel(imagemDto, imagem);

            //Assert
            Assert.Equal(imagemEsperada.Id.ToString(), modelRetorno.Id.ToString());
            Assert.Equal(imagemEsperada.IdProduto, modelRetorno.IdProduto);
            Assert.Equal(imagemEsperada.Tipo, modelRetorno.Tipo);
        }

        [Fact]
        [Trait("Imagem", "Conversão dto para entidade")]
        public void ProdutoAdapter_ConverterParaModel_DeveRetornarModelImagem()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            var imagemId = Guid.NewGuid();

            var imagemEsperada = new Imagem
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };

            var imagemDto = new ImagemDto
            {
                Id = imagemId,
                IdProduto = produtoId,
                Tipo = "png"
            };


            //Act
            var modelRetorno = ImagemAdapter.ToImagemModel(imagemDto);

            //Assert
            Assert.Equal(imagemEsperada.Id.ToString(), modelRetorno.Id.ToString());
            Assert.Equal(imagemEsperada.IdProduto, modelRetorno.IdProduto);
            Assert.Equal(imagemEsperada.Tipo, modelRetorno.Tipo);
        }
    }
}
