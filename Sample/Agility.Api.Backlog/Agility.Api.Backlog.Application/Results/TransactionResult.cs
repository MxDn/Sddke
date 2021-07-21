using System;

namespace Agility.Api.Backlog.Application.Results
{
    public class TransactionResult
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
