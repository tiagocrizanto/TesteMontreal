using Montreal.NomeSistema.Modulo1.Data.Context;
using Montreal.NomeSistema.Modulo1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Montreal.NomeSistema.Modulo1.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly Modulo1Context _modulo1Context;

        public BaseRepository(Modulo1Context modulo1Context)
        {
            _modulo1Context = modulo1Context;
        }

        public void Create(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                ValidadeDomainConstraints(entity);
                _modulo1Context.Entry(entity).State = EntityState.Added;
            }

            _modulo1Context.SaveChanges();
        }

        public void Create(T entity)
        {
            _modulo1Context.Set<T>().Add(entity);
            _modulo1Context.SaveChanges();
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                ValidadeDomainConstraints(entity);
                _modulo1Context.Entry(entity).State = EntityState.Deleted;
            }

            _modulo1Context.SaveChanges();
        }

        public void Delete(object entityPK)
        {
            var item = _modulo1Context.Set<T>().Find(entityPK);
            _modulo1Context.Set<T>().Remove(item);
            _modulo1Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _modulo1Context.Set(typeof(T)).Attach(entity);
            _modulo1Context.Set<T>().Remove(entity);
            _modulo1Context.SaveChanges();
        }

        public void Dispose()
        {
            _modulo1Context.Dispose();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match)
        {
            return _modulo1Context.Set<T>().Where(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _modulo1Context.Set<T>();
        }

        public T FindByPK(object entityPK)
        {
            return _modulo1Context.Set<T>().Find(entityPK);
        }

        public T FindFirstOrDefault(Expression<Func<T, bool>> match)
        {
            return _modulo1Context.Set<T>().FirstOrDefault(match);
        }

        public IEnumerable<T> FindPaged(Expression<Func<T, bool>> match, string sortProperty, int sortDirection, int pageIndex, int pageSize, out int total)
        {
            var findResults = _modulo1Context.Set<T>().Where(match);
            findResults = OrderBy(findResults, sortProperty, sortDirection == 0);
            total = findResults.Count();
            return findResults.Skip(((pageIndex) - 1) * pageSize).Take(pageSize).ToList();
        }

        public IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isDescending)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            if (type.GetProperty(propertyName) != null)
            {
                PropertyInfo pi = type.GetProperty(propertyName);
                Expression expr = Expression.Property(arg, pi);
                type = pi.PropertyType;

                Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
                LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

                string methodName = isDescending ? "OrderByDescending" : "OrderBy";
                object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
                return (IQueryable<T>)result;
            }
            return source;
        }

        public void ReloadEntity(T entity)
        {
            _modulo1Context.Entry(entity).Reload();
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                ValidadeDomainConstraints(entity);
                _modulo1Context.Entry(entity).State = EntityState.Modified;
            }

            _modulo1Context.SaveChanges();
        }

        public void Update(T entity)
        {
            ValidadeDomainConstraints(entity);
            _modulo1Context.Entry(entity).State = EntityState.Modified;
            _modulo1Context.SaveChanges();
        }

        private void ValidadeDomainConstraints(T entity)
        {
            if (entity != null)
            {
                PropertyInfo[] properties = entity.GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    ValidateDomainMaxLength(entity, property);
                    ValidateDomainRequired(entity, property);
                }
            }
        }

        private void ValidateDomainMaxLength(T entity, PropertyInfo property)
        {
            object[] maxLength = property.GetCustomAttributes(typeof(MaxLengthAttribute), false);

            if (maxLength != null && maxLength.Length == 1)
            {
                MaxLengthAttribute maxLengthAttribute = (MaxLengthAttribute)maxLength[0];
                int max = maxLengthAttribute.Length;
                object value = entity.GetType().GetProperty(property.Name).GetValue(entity, null);

                if (value != null)
                {
                    string stringValue = value.ToString();
                    if (stringValue.Length > max)
                    {
                        throw new Exception(string.Format("The field {0} value must not be longer than {1} characters", property.Name, max));
                    }
                }
            }
            else
            {
                object[] maxRange = property.GetCustomAttributes(typeof(RangeAttribute), false);

                if (maxRange != null && maxRange.Length == 1)
                {
                    RangeAttribute maxRangeAttribute = (RangeAttribute)maxRange[0];
                    double max = Convert.ToDouble(maxRangeAttribute.Maximum);

                    object value = entity.GetType().GetProperty(property.Name).GetValue(entity, null);

                    if (value != null)
                    {
                        double converteddouble = Convert.ToDouble(value.ToString());
                        if (converteddouble > max)
                        {
                            throw new Exception(string.Format("The field {0} value must not be longer than {1} characters", property.Name, max));
                        }
                    }
                }
            }
        }

        private void ValidateDomainRequired(T entity, PropertyInfo property)
        {
            object[] required = property.GetCustomAttributes(typeof(RequiredAttribute), false);

            if (required != null && required.Length == 1)
            {
                var requiredAttribute = (RequiredAttribute)required[0];
                var value = entity.GetType().GetProperty(property.Name).GetValue(entity, null);

                if (value == null)
                {
                    throw new Exception(string.Format("The field {0} is required", property.Name));
                }
                else if (value.GetType() == typeof(string) && value == null)
                {
                    throw new Exception(string.Format("The field {0} is required", property.Name));
                }

            }
        }
    }
}