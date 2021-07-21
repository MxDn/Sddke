﻿using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Repositories;
using Agility.Api.Backlog.Application.Results;
using Agility.Api.Backlog.Domain.Accounts;
using Agility.Api.Backlog.Domain.ValueObjects;

namespace Agility.Api.Backlog.Application.Commands.Withdraw
{
    public class WithdrawService : IWithdrawService
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public WithdrawService(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<WithdrawResult> Process(WithdrawCommand command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Debit debit = new Debit(account.Id, command.Amount);
            account.Withdraw(debit);

            await accountWriteOnlyRepository.Update(account, debit);

            TransactionResult transactionResult = resultConverter.Map<TransactionResult>(debit);
            WithdrawResult result = new WithdrawResult(
                transactionResult,
                account.GetCurrentBalance().Value
            );

            return result;
        }
    }
}
