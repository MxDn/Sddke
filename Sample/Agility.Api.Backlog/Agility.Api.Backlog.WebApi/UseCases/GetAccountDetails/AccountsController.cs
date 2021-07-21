using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Commands.Close;
using Agility.Api.Backlog.Application.Commands.Deposit;
using Agility.Api.Backlog.Application.Commands.Withdraw;
using Agility.Api.Backlog.Application.Queries;
using Agility.Api.Backlog.WebApi.Model;

using Microsoft.AspNetCore.Mvc;

namespace Agility.Api.Backlog.WebApi.UseCases.GetAccountDetails
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsQueries accountsQueries;

        public AccountsController(
            IAccountsQueries accountsQueries)
        {
            this.accountsQueries = accountsQueries;
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{accountId}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            var account = await accountsQueries.GetAccount(accountId);

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            return new ObjectResult(new AccountDetailsModel(
                account.AccountId,
                account.CurrentBalance,
                transactions));
        }
    }
}
