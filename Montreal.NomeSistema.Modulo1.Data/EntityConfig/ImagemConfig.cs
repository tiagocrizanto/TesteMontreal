using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Montreal.NomeSistema.Modulo1.Data.EntityConfig
{
    public class ImagemConfig : EntityTypeConfiguration<Domain.Imagem.Imagem>
    {
        public ImagemConfig()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("Imagem");
        }
    }
}