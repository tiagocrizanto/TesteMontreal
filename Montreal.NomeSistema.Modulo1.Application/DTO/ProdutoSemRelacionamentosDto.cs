using System;
using System.Collections.Generic;

namespace Montreal.NomeSistema.Modulo1.Application.DTO
{
    /// <summary>
    /// Representa um produto sem suas imagens relacionadas
    /// </summary>
    public class ProdutoSemRelacionamentosDto
    {
        /// <summary>Id do Produto</summary>
        public Guid Id { get; set; }
        /// <summary>Nome do produto</summary>
        public string Nome { get; set; }
        /// <summary>Descrição do produto</summary>
        public string Descricao { get; set; }
    }
}