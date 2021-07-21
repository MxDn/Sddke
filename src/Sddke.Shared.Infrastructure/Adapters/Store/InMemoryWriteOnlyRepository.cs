using System;
using System.Collections.Generic;

using Sddke.Shared.Application.Ports.Store;
using Sddke.Shared.Domain;

namespace Sddke.Shared.Infrastructure.Adapters
{
    public class InMemoryWriteOnlyRepository<TEntity> : IWriteOnlyRepository<TEntity>
        where TEntity : Entity, IAggregateRoot
    {
        private readonly ICollection<TEntity> entities;
        public InMemoryWriteOnlyRepository(ICollection<TEntity> entities) => this.entities = entities;

        public void Delete(TEntity entity) => throw new global::System.NotImplementedException();
        public void Save(TEntity entity)
        {
            if (entities.Contains(entity))
                throw new InfrastructureExecption($"already exist {entity.Id}");
            entities.Add(entity);
        }
        public void Update(TEntity entity)
        {
            if (!entities.Contains(entity))
                throw new InfrastructureExecption($"not exist {entity.Id}");
            entities.Add(entity);
        }
    }
}
