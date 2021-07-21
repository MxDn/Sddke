using System;

namespace Agility.Api.Backlog.WebApi.UseCases.Withdraw
{
    public class WithdrawRequest
    {
        public Guid AccountId { get; set; }
        public Double Amount { get; set; }
    }
}
