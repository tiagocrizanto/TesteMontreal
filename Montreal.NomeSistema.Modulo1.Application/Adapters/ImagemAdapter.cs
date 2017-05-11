using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;

namespace Montreal.NomeSistema.Modulo1.Application.Adapters
{
    public static class ImagemAdapter
    {
        public static Imagem ToImagemModel(ImagemDto imagemDto)
        {
            return new Imagem
            {
                Id = imagemDto.Id,
                IdProduto = imagemDto.IdProduto,
                Tipo = imagemDto.Tipo
            };
        }

        public static ImagemDto ToImagemDto(Imagem imagem)
        {
            return new ImagemDto
            {
                Id = imagem.Id,
                IdProduto = imagem.IdProduto,
                Tipo = imagem.Tipo
            };
        }

        public static Imagem ToImagemModel(ImagemDto imagemDto, Imagem imagemModel)
        {
            imagemModel.Id = imagemDto.Id;
            imagemModel.IdProduto = imagemDto.IdProduto;
            imagemModel.Tipo = imagemDto.Tipo;

            return imagemModel;
        }
    }
}