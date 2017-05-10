using Montreal.NomeSistema.Modulo1.Data.Context;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.EF;

namespace Montreal.NomeSistema.Modulo1.Data.Repository.EF
{
    public class ImagemRepository : BaseRepository<Imagem>, IImagemRepository
    {
        public ImagemRepository(Modulo1Context modulo1Context)
            : base(modulo1Context)
        {

        }
    }
}