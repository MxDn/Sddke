using System;
using System.Threading.Tasks;

using Agility.Api.Backlog.Application;
using Agility.Api.Backlog.Application.Queries;
using Agility.Api.Backlog.Application.Results;
using Agility.Api.Backlog.Domain.Accounts;

using MongoDB.Driver;

namespace Agility.Api.Backlog.Infrastructure.MongoDataAccess.Queries
{
    public class AccountsQueries : IAccountsQueries
    {
        private readonly Context context;
        private readonly IResultConverter mapper;

        public AccountsQueries(Context context, IResultConverter mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AccountResult> GetAccount(Guid accountId)
        {
            Account data = await context
                .Accounts
                .Find(e => e.Id == accountId)
                .SingleOrDefaultAsync();

            if (data == null)
                throw new AccountNotFoundException($"The account {accountId} does not exists or is not processed yet.");

            AccountResult accountResult = this.mapper.Map<AccountResult>(data);

            return accountResult;
        }
    }
}
