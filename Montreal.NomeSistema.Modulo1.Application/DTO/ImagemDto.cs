using System;
using System.ComponentModel.DataAnnotations;

namespace Montreal.NomeSistema.Modulo1.Application.DTO
{
    /// <summary>
    /// Representa imagens relacionadas a produtos
    /// </summary>
    public class ImagemDto
    {
        /// <summary>ID da imagem</summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>Tipo da imagem PNG, JPG e GIF</summary>
        [Required]
        public string Tipo { get; set; }
        /// <summary>Id do produto da imagem</summary>
        [Required]
        public Guid IdProduto { get; set; }
    }
}