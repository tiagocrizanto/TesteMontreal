using Montreal.NomeSistema.Modulo1.Application.DTO;
using System;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Application
{
    public interface IImagemAppService
    {
        IEnumerable<ImagemDto> ObterImagensPorIdProduto(Guid idProduto);
    }
}