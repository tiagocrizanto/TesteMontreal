using Montreal.NomeSistema.Modulo1.Domain.Core;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.Dapper;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.EF;

namespace Montreal.NomeSistema.Modulo1.Domain.Imagem.Services
{
    public class ImagemService : BaseService<Imagem>, IImagemService
    {
        private readonly IImagemRepository _imagemRepository;
        private readonly IImagemDapperRepository _imagemDapperRepository;

        public ImagemService(IBaseRepository<Imagem> baseRepository, IImagemRepository imagemRepository, IImagemDapperRepository imagemDapperRepository)
            : base(baseRepository)
        {
            _imagemRepository = imagemRepository;
            _imagemDapperRepository = imagemDapperRepository;
        }
    }
}