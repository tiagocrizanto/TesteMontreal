using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Montreal.NomeSistema.Modulo1.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Domain.Produto.Produto>
    {
        public ProdutoConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasMaxLength(255)
                .IsRequired();

            Property(x => x.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            HasMany(e => e.Imagens)
                .WithRequired(e => e.Produto)
                .HasForeignKey(e => e.IdProduto)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Produtos)
                .WithOptional(e => e.Produto1)
                .HasForeignKey(e => e.IdProdutoPai);

            ToTable("Produto");
        }
    }
}