using System;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Domain.Produto
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid? IdProdutoPai { get; set; }

        public virtual ICollection<Imagem.Imagem> Imagens { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual Produto Produto1 { get; set; }
    }
}