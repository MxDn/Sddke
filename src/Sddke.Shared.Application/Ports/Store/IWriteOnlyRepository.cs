using Sddke.Shared.Domain;

namespace Sddke.Shared.Application.Ports.Store
{
    public interface IWriteOnlyRepository<TEntity>
         where TEntity : Entity, IAggregateRoot
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
