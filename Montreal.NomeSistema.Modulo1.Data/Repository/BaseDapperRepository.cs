using Dapper.Contrib.Extensions;
using Montreal.NomeSistema.Core.Domain.Helpers.Database;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Montreal.NomeSistema.Modulo1.Data.Repository
{
    public class BaseDapperRepository<T> : IBaseDapperRepository<T> where T : class
    {
        public bool Delete(T obj)
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                return conn.Delete(obj);
            }
        }

        public T Get(int id)
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                return conn.Get<T>(id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                return conn.GetAll<T>();
            }
        }

        public void Insert(T obj)
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                conn.Insert(obj);
            }
        }

        public IEnumerable<T> OrderBy(IEnumerable<T> source, string propertyName, bool isDescending)
        {
            throw new NotImplementedException();
        }

        public bool Update(T obj)
        {
            using (var conn = new SqlConnectionHelper(ConnectionsStringHelper.DapperConnection))
            {
                return conn.Update(obj);
            }
        }
    }
}