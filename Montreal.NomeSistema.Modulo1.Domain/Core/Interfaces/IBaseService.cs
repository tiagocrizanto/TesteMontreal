using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        void Create(T entity);
        void Create(IList<T> entities);
        void CreateOrUpdate(T entity);
        void CreateOrUpdate(IList<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(object entityPK);
        void Delete(IEnumerable<T> entities);
        T FindByPK(object entityPK);
        T FindByPK(Guid entityPK);
        T FindFirstOrDefault(Expression<Func<T, bool>> match);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match);
        IEnumerable<T> GetAll();
        IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, Boolean isDescending);
        IEnumerable<T> FindPaged(Expression<Func<T, bool>> match, string sortProperty, int sortDirection, int pageIndex, int pageSize, out int total);
        void Dispose();
    }
}
