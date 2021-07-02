
namespace Agility.Api.Backlog.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
