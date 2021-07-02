using System;
using System.Collections.Generic;

namespace Agility.Api.Backlog.Application.Results
{
    public class AccountResult
    {
        public Guid AccountId { get; set; }
        public double CurrentBalance { get; set; }
        public List<TransactionResult> Transactions { get; set; }
    }
}
