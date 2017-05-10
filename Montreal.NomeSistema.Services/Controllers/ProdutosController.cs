using Montreal.NomeSistema.Modulo1.Application;
using Montreal.NomeSistema.Modulo1.Application.DTO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Montreal.NomeSistema.Services.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento e obtenção de produtos
    /// </summary>
    [RoutePrefix("v1/Produtos")]
    public class ProdutosController : ApiController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IImagemAppService _imagemAppService;

        public ProdutosController(IProdutoAppService produtoAppService, IImagemAppService imagemAppService)
        {
            _produtoAppService = produtoAppService;
            _imagemAppService = imagemAppService;
        }

        /// <summary>
        /// Recuperar todos os Produtos excluindo os relacionamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosExcluindoRelacionamentos()
        {
            return _produtoAppService.ObterProdutosExcluindoRelacionamentos();
        }

        /// <summary>
        /// Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem);
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentos()
        {
            return _produtoAppService.ObterProdutosComRelacionamentos();
        }

        /// <summary>
        /// Recuperar todos os Produtos excluindo os relacionamentos utilizando um id de produto específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProdutoSemRelacionamentosDto> ObterProdutosSemRelacionamentosPorId([FromUri] Guid id)
        {
            return _produtoAppService.ObterProdutosSemRelacionamentosPorId(id);
        }

        /// <summary>
        /// Recuperar todos os Produtos incluindo um relacionamento específico (Produto ou Imagem)
        /// utilizando um id de produto específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosComRelacionamentosPorId([FromUri]Guid id)
        {
            return _produtoAppService.ObterProdutosComRelacionamentosPorId(id);
        }

        /// <summary>
        /// Recupera a coleção de produtos filhos por um id de produto específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProdutoComRelacionamentosDto> ObterProdutosFilhosPorIdProduto([FromUri] Guid id)
        {
            return _produtoAppService.ObterProdutosFilhosPorIdProduto(id);
        }

        /// <summary>
        /// Recupera a coleção de Imagens para um id de produto específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ImagemDto> ObterImagensPorIdProduto([FromUri]Guid id)
        {
            return _imagemAppService.ObterImagensPorIdProduto(id);
        }
    }
}