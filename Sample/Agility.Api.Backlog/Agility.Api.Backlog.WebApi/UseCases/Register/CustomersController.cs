using System.Collections.Generic;
using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Commands.Register;
using Agility.Api.Backlog.WebApi.Model;

using Microsoft.AspNetCore.Mvc;

namespace Agility.Api.Backlog.WebApi.UseCases.Register
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IRegisterService registerService;

        public CustomersController(IRegisterService registerService)
        {
            this.registerService = registerService;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterRequest request)
        {
            var command = new RegisterCommand(request.PIN, request.Name, request.InitialAmount);
            RegisterResult result = await registerService.Process(command);

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in result.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            AccountDetailsModel account = new AccountDetailsModel(
                result.Account.AccountId,
                result.Account.CurrentBalance,
                transactions);

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            Model model = new Model(
                result.Customer.CustomerId,
                result.Customer.Personnummer,
                result.Customer.Name,
                accounts
            );

            return CreatedAtRoute("GetCustomer", new { customerId = model.CustomerId }, model);
        }
    }
}
