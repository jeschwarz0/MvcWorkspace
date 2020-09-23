using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MvcWorkspace.DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal MWContext context;
        internal DbSet<TEntity> dbSet;
        /// <summary>
        /// Constructs a GenericRepository with <c>context</c>.
        /// </summary>
        /// <param name="context">The context to set.</param>
        public GenericRepository(MWContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// Fetches rows from the database.
        /// </summary>
        /// <param name="filter">The query filter.</param>
        /// <param name="orderBy">The field to order by.</param>
        /// <param name="includeProperties">Includes properties?</param>
        /// <returns>An IEnumerable of records.</returns>
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        /// <summary>
        /// Fetches all rows from the database.
        /// </summary>
        /// <param name="orderBy">The field to order by.</param>
        /// <param name="includeProperties">Include properties?</param>
        /// <returns>An IEnumerable of all records.</returns>
        public IEnumerable<TEntity> GetAll(
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        /// <summary>
        /// Fetches the <c>TEntity</c> identified by id.
        /// </summary>
        /// <param name="id">The identifier object(probably int).</param>
        /// <returns>The <c>TEntity</c> at id.</returns>
        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        /// <summary>
        /// Inserts <c>entity</c> into the database.
        /// </summary>
        /// <param name="entity">The record to add.</param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        /// <summary>
        /// Deletes an object at <c>id</c>.
        /// </summary>
        /// <param name="id">The identifier object(probably int).</param>
        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        /// <summary>
        /// Deletes the selected object from the database.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}