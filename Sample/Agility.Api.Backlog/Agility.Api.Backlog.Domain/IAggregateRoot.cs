
namespace Agility.Api.Backlog.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Version { get; }
    }
}