using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.EF;
using System;
using System.Linq;
using System.Collections.Generic;
using Montreal.NomeSistema.Modulo1.Application.Adapters;

namespace Montreal.NomeSistema.Modulo1.Application
{
    public class ImagemAppService : IImagemAppService
    {
        private readonly IImagemService _imagemService;

        public ImagemAppService(IImagemService imagemService)
        {
            _imagemService = imagemService;
        }

        public IEnumerable<ImagemDto> ObterImagensPorIdProduto(Guid idProduto)
        {
            return _imagemService.FindAll(x => x.IdProduto == idProduto).Select(x => new ImagemDto
            {
                Id = x.Id,
                Tipo = x.Tipo,
                IdProduto = x.IdProduto
            });
        }

        public bool AdicionarImagem(ImagemDto imagemDto)
        {
            return _imagemService.Create(ImagemAdapter.ToImagemModel(imagemDto));
        }

        public bool ExcluirImagem(Guid id)
        {
            if (_imagemService.FindByPK(id) == null)
                return false;

            _imagemService.Delete(id);

            return true;
        }

        public bool AtualizarImagem(ImagemDto imagemDto)
        {
            var imagem = _imagemService.FindByPK(imagemDto.Id);
            if (imagem == null)
                return false;

            //Verifica se a imagem pertence ao produto
            if (imagem.Id != imagemDto.Id)
                return false;

            _imagemService.Update(ImagemAdapter.ToImagemModel(imagemDto, imagem));
            return true;
        }

        public ImagemDto RetornarImagemPorId(Guid id)
        {
            var imagem = _imagemService.FindByPK(id);
            if (imagem == null)
                return null;

            return ImagemAdapter.ToImagemDto(imagem);
        }
    }
}