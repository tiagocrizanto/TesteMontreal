using Montreal.NomeSistema.Modulo1.Data.EntityConfig;
using Montreal.NomeSistema.Modulo1.Domain.Imagem;
using Montreal.NomeSistema.Modulo1.Domain.Produto;
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Data.Context
{
    public class Modulo1Context : DbContext
    {
        public Modulo1Context()
            : base("ApplicationContext")
        {
            //Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<Modulo1Context>(new SeedData());
        }

        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ImagemConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());
        }
    }

    public class SeedData : DropCreateDatabaseAlways<Modulo1Context>
    {
        protected override void Seed(Modulo1Context context)
        {
            var imagens = new string[] { "png", "jpg", "gif" };
            var subProdutos = new int[] { 2, 4, 5, 7};

            var celular = new Produto
            {
                Id = Guid.Parse("c56a4180-65aa-42ec-a945-5fd21dec0538"),
                Descricao = "Celular de última geração",
                IdProdutoPai = null,
                Nome = "Celular Galaxy S8",
                Imagens = new List<Imagem>()
            };

            celular.Imagens.Add(new Imagem
            {
                IdProduto = celular.Id,
                Tipo = "jpg"
            });

            celular.Imagens.Add(new Imagem
            {
                IdProduto = celular.Id,
                Tipo = "gif"
            });

            context.Produto.Add(celular);

            var acessorio = new Produto
            {
                Descricao = "Emborrachada na cor preta",
                IdProdutoPai = celular.Id,
                Nome = "Capa celular Galaxy S8",
                Imagens = new List<Imagem>()
            };

            acessorio.Imagens.Add(new Imagem
            {
                IdProduto = acessorio.Id,
                Tipo = "png"
            });

            var acessorio1 = new Produto
            {
                Descricao = "Material gorila glass",
                IdProdutoPai = celular.Id,
                Nome = "Película de vidro",
                Imagens = new List<Imagem>()
            };

            acessorio1.Imagens.Add(new Imagem
            {
                IdProduto = acessorio1.Id,
                Tipo = "png"
            });

            context.Produto.Add(acessorio);
            context.Produto.Add(acessorio1);

            //Adiciona items aleatórios
            for (int i = 0; i < 1; i++)
            {
                var produto = new Produto
                {
                    Id = Guid.NewGuid(),
                    Descricao = $"Produto {i}",
                    Nome = $"Nome {i}"
                };

                context.Produto.Add(produto);

                context.Imagem.Add(new Imagem
                {
                    IdProduto = produto.Id,
                    Tipo = imagens [new Random().Next(0, imagens.Length)]
                });

                if(subProdutos.Any(x => x == i))
                {
                    var subproduto = new Produto
                    {
                        IdProdutoPai = produto.Id,
                        Descricao = $"SubProduto de {i}",
                        Nome = "Sub produto",
                        Imagens = new List<Imagem>()
                    };

                    subproduto.Imagens.Add(new Imagem
                    {
                        Id = subproduto.Id,
                        Tipo = imagens[new Random().Next(0, imagens.Length)]
                    });

                    context.Produto.Add(subproduto);
                }
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}