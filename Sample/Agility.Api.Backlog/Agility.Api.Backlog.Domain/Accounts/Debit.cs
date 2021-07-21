using System;

using Agility.Api.Backlog.Domain.ValueObjects;

namespace Agility.Api.Backlog.Domain.Accounts
{
    public class Debit : Transaction
    {
        protected Debit()
        {

        }

        public Debit(Guid accountId, Amount amount)
            : base(accountId, amount)
        {

        }

        public override string Description
        {
            get
            {
                return "Debit";
            }
        }
    }
}
