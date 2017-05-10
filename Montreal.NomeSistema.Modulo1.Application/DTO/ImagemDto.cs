using System;

namespace Montreal.NomeSistema.Modulo1.Application.DTO
{
    /// <summary>
    /// Representa imagens relacionadas a produtos
    /// </summary>
    public class ImagemDto
    {
        /// <summary>ID da imagem</summary>
        public Guid Id { get; set; }
        /// <summary>Tipo da imagem PNG, JPG e GIF</summary>
        public string Tipo { get; set; }
        /// <summary>Id do produto da imagem</summary>
        public Guid IdProduto { get; set; }
    }
}