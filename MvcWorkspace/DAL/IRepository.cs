using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcWorkspace.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Fetches rows from the database.
        /// </summary>
        /// <param name="filter">The query filter.</param>
        /// <param name="orderBy">The field to order by.</param>
        /// <param name="includeProperties">Includes properties?</param>
        /// <returns>An IEnumerable of records.</returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        /// <summary>
        /// Fetches all rows from the database.
        /// </summary>
        /// <param name="orderBy">The field to order by.</param>
        /// <param name="includeProperties">Include properties?</param>
        /// <returns>An IEnumerable of all records.</returns>
        IEnumerable<TEntity> GetAll(
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
        /// <summary>
        /// Fetches the <c>TEntity</c> identified by id.
        /// </summary>
        /// <param name="id">The identifier object(probably int).</param>
        /// <returns>The <c>TEntity</c> at id.</returns>
        TEntity GetByID(object id);
        /// <summary>
        /// Inserts <c>entity</c> into the database.
        /// </summary>
        /// <param name="entity">The record to add.</param>
        void Insert(TEntity entity);
        /// <summary>
        /// Deletes an object at <c>id</c>.
        /// </summary>
        /// <param name="id">The identifier object(probably int).</param>
        void Delete(object id);
        /// <summary>
        /// Deletes the selected object from the database.
        /// </summary>
        /// <param name="entityToDelete">The entity to delete.</param>
        void Delete(TEntity entityToDelete);
        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entityToUpdate">The entity to update.</param>
        void Update(TEntity entityToUpdate);
    }
}
