using Montreal.NomeSistema.Modulo1.Application;
using Montreal.NomeSistema.Modulo1.Data.Context;
using Montreal.NomeSistema.Modulo1.Data.Interfaces;
using Montreal.NomeSistema.Modulo1.Data.Repository;
using Montreal.NomeSistema.Modulo1.Data.Repository.Dapper;
using Montreal.NomeSistema.Modulo1.Data.Repository.EF;
using Montreal.NomeSistema.Modulo1.Data.UoW;
using Montreal.NomeSistema.Modulo1.Domain.Core;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.Dapper;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.EF;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Services;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.Dapper;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Services;
using SimpleInjector;

namespace Montreal.NomeSistema.Modulo1.Infra
{
    public class BootStrapperModulo1
    {
        public static void Register(Container container)
        {
            //Context
            container.Register<Modulo1Context>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            //App
            container.Register<IImagemAppService, ImagemAppService>(Lifestyle.Scoped);
            container.Register<IProdutoAppService, ProdutoAppService>(Lifestyle.Scoped); 

            //Domain
            container.Register(typeof(IBaseService<>), typeof(BaseService<>), Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IImagemService, ImagemService>(Lifestyle.Scoped);

            //Repository > EF
            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);
            container.Register<IImagemRepository, ImagemRepository>(Lifestyle.Scoped);
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);

            //Repository > Dapper
            container.Register(typeof(IBaseDapperRepository<>), typeof(BaseDapperRepository<>), Lifestyle.Scoped);
            container.Register<IImagemDapperRepository, ImagemDapperRepository>(Lifestyle.Scoped);
            container.Register<IProdutoDapperRepository, ProdutoDapperRepository>(Lifestyle.Scoped);
        }
    }
}