
using Furniture.Domain.Entities.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities.Core
{

    public class EntityRepository<T> : IEntityRepository<T>
        where T : class, IEntity, new()
    {

        readonly DbContext _entitiesContext;

        public EntityRepository(DbContext entitiesContext)
        {

            if (entitiesContext == null)
            {

                throw new ArgumentNullException("entitiesContext");
            }

            _entitiesContext = entitiesContext;
        }

        public virtual IQueryable<T> GetAll()
        {

            return _entitiesContext.Set<T>();
        }

        public virtual IQueryable<T> AllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query = _entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {

                query = query.Include(includeProperty);
            }

            return query;
        }

        public T GetSingle(Guid key)
        {

            return GetAll().FirstOrDefault(x => x.Key == key);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            return _entitiesContext.Set<T>().Where(predicate);
        }

        public virtual PaginatedList<T> Paginate<TKey>(
                    int pageIndex, int pageSize,
                    Expression<Func<T, TKey>> keySelector)
        {

            return Paginate(pageIndex, pageSize, keySelector, null);
        }

        public virtual PaginatedList<T> Paginate<TKey>(
            int pageIndex, int pageSize,
            Expression<Func<T, TKey>> keySelector,
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {

            IQueryable<T> query =
                AllIncluding(includeProperties).OrderBy(keySelector);

            query = (predicate == null)
                ? query
                : query.Where(predicate);

            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual bool Add(T entity)
        {

            var dbEntityEntry = _entitiesContext.Entry<T>(entity);
            var addedT = _entitiesContext.Set<T>().Add(entity);
            return addedT != null;

        }

        public virtual void Edit(T entity)
        {

            var dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {

            var dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteGraph(T entity)
        {

            DbSet<T> dbSet = _entitiesContext.Set<T>();
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public virtual int Save()
        {


            return _entitiesContext.SaveChanges();
        }


    }
}