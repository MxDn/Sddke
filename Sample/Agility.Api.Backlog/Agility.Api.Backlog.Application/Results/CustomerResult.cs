﻿using System;
using System.Collections.Generic;

namespace Agility.Api.Backlog.Application.Results
{
    public class CustomerResult
    {
        public Guid CustomerId { get; set; }
        public string Personnummer { get; set; }
        public string Name { get; set; }
        public IReadOnlyList<AccountResult> Accounts { get; private set; }

        public CustomerResult()
        {

        }

        public CustomerResult(Guid customerId, string personnummer, string name,
            List<AccountResult> accounts)
        {
            CustomerId = customerId;
            Personnummer = personnummer;
            Name = name;
            Accounts = accounts;
        }
    }
}
