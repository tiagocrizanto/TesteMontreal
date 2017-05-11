using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        bool Create(T entity);
        bool Create(IList<T> entities);
        bool CreateOrUpdate(T entity);
        bool CreateOrUpdate(IList<T> entities);
        bool Update(T entity);
        bool Update(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Delete(object entityPK);
        bool Delete(IEnumerable<T> entities);
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
