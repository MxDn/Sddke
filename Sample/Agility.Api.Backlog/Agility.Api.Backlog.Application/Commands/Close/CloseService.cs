﻿using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Repositories;
using Agility.Api.Backlog.Domain.Accounts;

namespace Agility.Api.Backlog.Application.Commands.Close
{
    public class CloseService : ICloseService
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public CloseService(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<CloseResult> Process(CloseCommand command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            account.Close();

            await accountWriteOnlyRepository.Delete(account);

            CloseResult result = resultConverter.Map<CloseResult>(account);

            return result;
        }
    }
}
