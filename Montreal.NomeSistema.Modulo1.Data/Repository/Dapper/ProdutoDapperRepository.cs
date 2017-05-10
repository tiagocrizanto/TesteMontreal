using System.Collections.Generic;
using Montreal.NomeSistema.Modulo1.Domain.Produto;
using Montreal.NomeSistema.Modulo1.Domain.Produto.Interfaces.Dapper;
using Montreal.NomeSistema.Core.Domain.Helpers.Database;
using Dapper;
using System;
using Dapper.Contrib.Extensions;

namespace Montreal.NomeSistema.Modulo1.Data.Repository.Dapper
{
    public class ProdutoDapperRepository : BaseDapperRepository<Produto>, IProdutoDapperRepository
    {
        public IEnumerable<Produto> ExemploGetTopX(int top)
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                var query = $"SELECT TOP {top} * FROM PRODUTO";

                return conn.Query<Produto>(query);
            }
        }

        public IEnumerable<Produto> ObterProdutosExcluindoRelacionamentos()
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                return conn.GetAll<Produto>();
            }
        }
    }
}