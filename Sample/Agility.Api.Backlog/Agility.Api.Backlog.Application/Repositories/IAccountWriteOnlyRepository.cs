using System.Threading.Tasks;

using Agility.Api.Backlog.Domain.Accounts;

namespace Agility.Api.Backlog.Application.Repositories
{
    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account, Credit credit);
        Task Update(Account account, Transaction transaction);
        Task Delete(Account account);
    }
}
