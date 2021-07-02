using Agility.Api.Backlog.Application.Results;

namespace Agility.Api.Backlog.Application.Commands.Withdraw
{
    public class WithdrawResult
    {
        public TransactionResult Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }

        public WithdrawResult()
        {

        }

        public WithdrawResult(TransactionResult transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
