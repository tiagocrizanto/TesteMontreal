using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Montreal.NomeSistema.Modulo1.Application.DTO
{
    public class ProdutoDto
    {
        /// <summary>Id do produto</summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>Nome do produto</summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>Descrição do produto</summary>
        [Required]
        public string Descricao { get; set; }
        /// <summary>Sub produto de um produto</summary>
        public Guid? IdProdutoPai { get; set; }

        /// <summary>Imagens do produto</summary>
        public ICollection<ImagemDto> Imagens { get; set; }
    }
}