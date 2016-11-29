using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Commons.Model;

namespace Commons.Repository
{
    public class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public BusinessDbContext Db;

        public BaseRepository(DbContext db)
        {
            Db = db as BusinessDbContext;
        }

        public virtual IQueryable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var query = Db.Set<TEntity>().AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                var properties = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var includeProperty in properties)
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }        
            return query;
        }

        public IQueryable<TEntity> Get()
        {
            var query = Db.Set<TEntity>().AsQueryable();
            return query;
        }
        public TEntity GetById(string id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return Db.Set<TEntity>().Add(entity);
        }

        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            var range = Db.Set<TEntity>().AddRange(entities);
            return range;
        }

        public virtual bool Delete(TEntity entity)
        {
            var remove = Db.Set<TEntity>().Remove(entity);
            return true;
        }

        public virtual bool Edit(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            var changes = Db.SaveChanges();
            return changes > 0;
        }
    }
}