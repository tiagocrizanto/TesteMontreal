using Montreal.NomeSistema.Modulo1.Application.DTO;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.EF;
using System;
using System.Linq;
using System.Collections.Generic;

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
    }
}