using System;

using Agility.Api.Backlog.Domain.ValueObjects;

namespace Agility.Api.Backlog.Domain.Accounts
{
    public class Credit : Transaction
    {
        protected Credit()
        {

        }

        public Credit(Guid accountId, Amount amount)
            : base(accountId, amount)
        {

        }

        public override string Description
        {
            get
            {
                return "Credit";
            }
        }
    }
}
