using System;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Application.DTO
{
    /// <summary>
    /// Representa um produto com suas imagens relacionadas
    /// </summary>
    public class ProdutoComRelacionamentosDto
    {
        /// <summary>Id do Produto</summary>
        public Guid Id { get; set; }
        /// <summary>Indica que é um subproduto</summary>
        public Guid? IdProdutoPai { get; set; }
        /// <summary>Nome do produto</summary>
        public string Nome { get; set; }
        /// <summary>Descrição do produto</summary>
        public string Descricao { get; set; }
        /// <summary>Coleção de imagens do produto</summary>
        public ICollection<ImagemDto> Imagens { get; set; }
    }
}