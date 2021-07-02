using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Repositories;
using Agility.Api.Backlog.Application.Results;
using Agility.Api.Backlog.Domain.Accounts;
using Agility.Api.Backlog.Domain.ValueObjects;

namespace Agility.Api.Backlog.Application.Commands.Deposit
{
    public class DepositService : IDepositService
    {
        private readonly IAccountReadOnlyRepository accountReadOnlyRepository;
        private readonly IAccountWriteOnlyRepository accountWriteOnlyRepository;
        private readonly IResultConverter resultConverter;

        public DepositService(
            IAccountReadOnlyRepository accountReadOnlyRepository,
            IAccountWriteOnlyRepository accountWriteOnlyRepository,
            IResultConverter resultConverter)
        {
            this.accountReadOnlyRepository = accountReadOnlyRepository;
            this.accountWriteOnlyRepository = accountWriteOnlyRepository;
            this.resultConverter = resultConverter;
        }

        public async Task<DepositResult> Process(DepositCommand command)
        {
            Account account = await accountReadOnlyRepository.Get(command.AccountId);
            if (account == null)
                throw new AccountNotFoundException($"The account {command.AccountId} does not exists or is already closed.");

            Credit credit = new Credit(account.Id, command.Amount);
            account.Deposit(credit);

            await accountWriteOnlyRepository.Update(account, credit);

            TransactionResult transactionResult = resultConverter.Map<TransactionResult>(credit);
            DepositResult result = new DepositResult(transactionResult, account.GetCurrentBalance().Value);

            return result;
        }
    }
}
