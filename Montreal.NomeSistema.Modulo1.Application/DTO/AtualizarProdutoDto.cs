using System;
using System.ComponentModel.DataAnnotations;

namespace Montreal.NomeSistema.Modulo1.Application.DTO
{
    public class AtualizarProdutoDto
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
    }
}
