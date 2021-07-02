using System;

namespace Agility.Api.Backlog.Application.Commands.Deposit
{
    public class DepositCommand
    {
        public Guid AccountId { get; private set; }
        public Double Amount { get; private set; }

        public DepositCommand(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
