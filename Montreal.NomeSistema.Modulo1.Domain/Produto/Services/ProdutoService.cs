using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Montreal.NomeSistema.Modulo1.Domain.Core;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.Dapper;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.EF;

namespace Montreal.NomeSistema.Modulo1.Domain.Produto.Services
{
    public class ProdutoService : BaseService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoDapperRepository _produtoDapperRepository;

        public ProdutoService(IBaseRepository<Produto> baseService, IProdutoRepository produtoRepository, IProdutoDapperRepository produtoDapperRepository)
            : base(baseService)
        {
            _produtoDapperRepository = produtoDapperRepository;
            _produtoRepository = produtoRepository;
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