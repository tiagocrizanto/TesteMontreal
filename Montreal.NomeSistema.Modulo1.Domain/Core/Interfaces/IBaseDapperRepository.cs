using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces
{
    public interface IBaseDapperRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Insert(T obj);
        bool Update(T obj);
        bool Delete(T obj);
        IEnumerable<T> OrderBy(IEnumerable<T> source, string propertyName, bool isDescending);
        IEnumerable<T> FindPaged(Expression<Func<T, bool>> match, string sortProperty, int sortDirection, int pageIndex, int pageSize, string table, out int total);
    }
}