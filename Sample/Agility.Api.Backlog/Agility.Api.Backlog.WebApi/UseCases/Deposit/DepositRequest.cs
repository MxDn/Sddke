using System;

namespace Agility.Api.Backlog.WebApi.UseCases.Deposit
{
    public class DepositRequest
    {
        public Guid AccountId { get; set; }
        public Double Amount { get; set; }
    }
}
