﻿using System;

namespace Agility.Api.Backlog.Application.Commands.Withdraw
{
    public class WithdrawCommand
    {
        public Guid AccountId { get; private set; }
        public Double Amount { get; private set; }

        public WithdrawCommand(Guid accountId, double amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
