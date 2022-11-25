using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Infrastructure.Exceptions
{
    /// <summary>
    /// The exception that is thrown when attempting to access a null DbSet in the DbContext
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class NullDbSetException : Exception
    {
        public NullDbSetException() { }
        public NullDbSetException(string dbSet) : base($"DbSet {dbSet} is null in application context") { }
        public NullDbSetException(string dbSet, Exception inner) : base($"DbSet {dbSet} is null in application context", inner) { }
        protected NullDbSetException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string entity) : base($"Entity {entity} not found in database") { }
        public EntityNotFoundException(string entity, string entityId) : base($"{entity} with id {entityId} not found in the database") { }
        public EntityNotFoundException(string entity, string entityId, Exception inner) : base($"{entity} with id {entityId} not found in the database", inner) { }
        protected EntityNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
