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

        public override bool Create(Imagem imagem)
        {
            if (FindByPK(imagem.Id) != null)
                return false;

            base.Create(imagem);

            return true;
        }

        public override bool Update(Imagem imagem)
        {
            //Verifica se a imagem está relacionada ao produto
            if (FindByPK(imagem.Id).IdProduto != imagem.IdProduto)
                return false;

            return base.Update(imagem);
        }
    }
}