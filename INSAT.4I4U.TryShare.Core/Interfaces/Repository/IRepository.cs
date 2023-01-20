using INSAT._4I4U.TryShare.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NullDbSetException"></exception>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Gets entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NullDbSetException"></exception>
        /// <exception cref="EntityNotFoundException"></exception>
        Task<T?> GetByIdAsync(int id);
        /// <summary>
        /// CreateAsync a new entity in the database.
        /// </summary>
        /// <remarks>
        /// Throw an exception when trying to access a null set in the database
        /// </remarks>
        /// <param name="entity">The entity</param>
        /// <exception cref="NullDbSetException"></exception> 
        Task CreateAsync(T entity);
        /// <summary>
        /// Searchs the _repository for an entity of same <c>Id</c> as <paramref name="entity"/>
        /// and updates its values if found.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NullDbSetException"></exception>
        /// <exception cref="EntityNotFoundException"></exception>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="NullDbSetException"></exception>
        /// <exception cref="EntityNotFoundException"></exception>
        Task DeleteAsync(T entity);
    }
}
