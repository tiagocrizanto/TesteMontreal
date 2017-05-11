using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Montreal.NomeSistema.Modulo1.Domain.Core
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual bool Create(TEntity entity)
        {
            try
            {
                _baseRepository.Create(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Create(IList<TEntity> entities)
        {
            try
            {
                _baseRepository.Create(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool CreateOrUpdate(TEntity entity)
        {
            try
            {
                if (_baseRepository.FindByPK((int)entity.GetType().GetProperty("id").GetValue(entity)) == null ||
                    (int)entity.GetType().GetProperty("id").GetValue(entity) == 0)
                    Create(entity);
                else
                    Update(entity);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool CreateOrUpdate(IList<TEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    CreateOrUpdate(entity);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Update(TEntity entity)
        {
            try
            {
                _baseRepository.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Update(IEnumerable<TEntity> entities)
        {
            try
            {
                _baseRepository.Update(entities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Delete(TEntity id)
        {
            try
            {
                _baseRepository.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Delete(object entityPK)
        {
            try
            {
                _baseRepository.Delete(entityPK);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual bool Delete(IEnumerable<TEntity> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    Delete((int)entity.GetType().GetProperty("Id").GetValue(entity));
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual TEntity FindByPK(object id)
        {
            try
            {
                return _baseRepository.FindByPK(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual TEntity FindByPK(Guid id)
        {
            try
            {
                return _baseRepository.FindByPK(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual TEntity FindFirstOrDefault(Expression<Func<TEntity, bool>> match)
        {
            try
            {
                return _baseRepository.FindFirstOrDefault(match);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar pela PK", ex);
            }
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                return _baseRepository.FindAll(expression).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _baseRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public virtual IQueryable<TEntity> OrderBy(IQueryable<TEntity> source, string propertyName, bool isDescending)
        {
            try
            {
                return _baseRepository.OrderBy(source, propertyName, isDescending);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ordenar", ex);
            }
        }

        public virtual IEnumerable<TEntity> FindPaged(Expression<Func<TEntity, bool>> match, string sortProperty, int sortDirection, int pageIndex, int pageSize, out int total)
        {
            return _baseRepository.FindPaged(match, sortProperty, sortDirection, pageIndex, pageSize, out total);
        }

        public virtual void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}