using System.Linq;
using System.Collections.Generic;
using Montreal.NomeSistema.Modulo1.Domain.Core;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.Dapper;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;
using System;
using Montreal.NomeSistema.Modulo1.Domain.Imagem.Interfaces.EF;

namespace Montreal.NomeSistema.Modulo1.Domain.Produto.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IImagemRepository _imagemRepository;
        private readonly IProdutoDapperRepository _produtoDapperRepository;

        public ProdutoService(IBaseRepository<Produto> baseService, IProdutoRepository produtoRepository, IProdutoDapperRepository produtoDapperRepository,
            IImagemRepository imagemRepository)
            : base(baseService)
        {
            _produtoDapperRepository = produtoDapperRepository;
            _produtoRepository = produtoRepository;
            _imagemRepository = imagemRepository;
        }

        public IEnumerable<Produto> ObterProdutosExcluindoRelacionamentos()
        {
            return _produtoDapperRepository.ObterProdutosExcluindoRelacionamentos();
        }

        public override bool Create(Produto produto)
        {
            if (FindByPK(produto.Id) != null)
                return false;

            //Retornar falso se tentar inserir um produto filho sem pai
            if (produto.IdProdutoPai != null && FindAll(x => x.Id == produto.IdProdutoPai) == null)
                return false;

            base.Create(produto);
            return true;
        }

        public override bool Delete(object id)
        {
            var produto = FindByPK(id);

            if(produto.Imagens.Any())
                _imagemRepository.Delete(produto.Imagens.ToList());

            if (produto.Produtos.Any())
            {
                //Remove as imagens dos subprodutos
                foreach (var imagemProdutos in produto.Produtos)
                {
                    _imagemRepository.Delete(imagemProdutos.Imagens.ToList());
                }

                //remove o subproduto
                _produtoRepository.Delete(produto.Produtos.ToList());
            }

            return base.Delete(id);
        }

        public override bool Update(Produto produto)
        {
            if (FindAll(x => x.Id == produto.IdProdutoPai) == null)
                return false;

            base.Update(produto);
            return true;
        }

        /// <summary>
        /// Exemplo da utilização do repositório Dapper
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        private IEnumerable<Produto> ExemploGetTopX(int top)
        {
            return _produtoDapperRepository.ExemploGetTopX(top);
        }
    }
}