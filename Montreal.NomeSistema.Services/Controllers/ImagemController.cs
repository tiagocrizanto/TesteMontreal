using Montreal.NomeSistema.Modulo1.Application;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Web.Http;

namespace Montreal.NomeSistema.Services.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento de imagens
    /// </summary>
    public class ImagemController : ApiController
    {
        private readonly IImagemAppService _imagemAppService;

        public ImagemController(IImagemAppService imagemAppService)
        {
            _imagemAppService = imagemAppService;
        }

        /// <summary>
        /// Adiciona imagens para um produto
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AdicionarImagem([FromBody] ImagemDto imagem)
        {
            if (ModelState.IsValid)
            {
                if (_imagemAppService.AdicionarImagem(imagem))
                    return new HttpResponseMessage(HttpStatusCode.OK);

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao adicionar o produto. Verifique se o produto já está cadastrado ou se um subproduto possui um produto");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        /// <summary>
        /// Excluir uma imagem do banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ExcluirImagem([FromUri] Guid id)
        {
            if(_imagemAppService.ExcluirImagem(id))
                return new HttpResponseMessage(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Erro ao excluir a imagem");
        }

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage AtualizarImagem([FromBody] ImagemDto imagem)
        {
            if (_imagemAppService.AtualizarImagem(imagem))
                return new HttpResponseMessage(HttpStatusCode.OK);

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        /// <summary>
        /// Retorna um produto de acordo com o id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ImagemDto RetornarImagemPorId([FromUri] Guid id)
        {
            var imagem = _imagemAppService.RetornarImagemPorId(id);
            if (imagem != null)
                return imagem;

            return null;
        }
    }
}