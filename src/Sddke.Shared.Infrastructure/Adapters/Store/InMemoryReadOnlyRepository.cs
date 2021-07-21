using System;
using System.Collections.Generic;
using System.Linq;

using Sddke.Shared.Application.Ports.Store;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Infrastructure.Adapters
{
    public class InMemoryReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        private readonly IReadOnlyCollection<TEntity> entities;

        public InMemoryReadOnlyRepository(IReadOnlyCollection<TEntity> entities) => this.entities = entities;

        public IQueryable<TEntity> GetAllByExpression(Func<TEntity, bool> expression) => entities.Where(expression).AsQueryable();
        public TEntity GetById(Guid id) => entities.Where(entity => entity.Id.Equals(id)).FirstOrDefault();
        public TEntity GetOneByExpression(Func<TEntity, bool> expression) => entities.Where(expression).FirstOrDefault();
    }
}
