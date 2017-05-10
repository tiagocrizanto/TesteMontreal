using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void Create(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(object entityPK);
        void Delete(IEnumerable<T> entities);
        T FindByPK(object entityPK);
        T FindFirstOrDefault(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindPaged(Expression<Func<T, bool>> match, string sortProperty, int sortDirection, int pageIndex, int pageSize, out int total);
        IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isDescending);
        void Dispose();
    }
}
