using System;

namespace Montreal.NomeSistema.Modulo1.Domain.Imagem
{
    public class Imagem
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public Guid IdProduto { get; set; }

        public virtual Produto.Produto Produto { get; set; }
    }
}
