﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

using Agility.Api.Backlog.Domain.ValueObjects;

namespace Agility.Api.Backlog.Domain.Accounts
{
    public class TransactionCollection : Collection<Transaction>
    {
        public TransactionCollection()
        {

        }

        public TransactionCollection(IEnumerable<Transaction> list)
        {
            foreach (var item in list)
            {
                Items.Add(item);
            }
        }

        public Amount GetCurrentBalance()
        {
            Amount totalAmount = 0;

            //
            // TODO: Think on a better Strategy
            //

            foreach (var item in Items)
            {
                if (item is Debit)
                    totalAmount -= item.Amount;

                if (item is Credit)
                    totalAmount += item.Amount;
            }

            return totalAmount;
        }
    }
}
