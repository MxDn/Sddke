using System;
using System.Threading.Tasks;

using Agility.Api.Backlog.Domain.Accounts;

namespace Agility.Api.Backlog.Application.Repositories
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);
    }
}
