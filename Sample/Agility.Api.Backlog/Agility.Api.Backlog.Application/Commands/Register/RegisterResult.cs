using System;
using System.Collections.Generic;
using System.Text;

using Agility.Api.Backlog.Application.Results;

namespace Agility.Api.Backlog.Application.Commands.Register
{
    public class RegisterResult
    {
        public CustomerResult Customer { get; private set; }
        public AccountResult Account { get; private set; }

        public RegisterResult()
        {

        }

        public RegisterResult(CustomerResult customer, AccountResult account)
        {
            Customer = customer;
            Account = account;
        }
    }
}
