using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Commands.Deposit;

using Microsoft.AspNetCore.Mvc;

namespace Agility.Api.Backlog.WebApi.UseCases.Deposit
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IDepositService depositService;

        public AccountsController(
            IDepositService depositService)
        {
            this.depositService = depositService;
        }

        /// <summary>
        /// Deposit from an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            var command = new DepositCommand(
                request.AccountId,
                request.Amount);

            DepositResult depositResult = await depositService.Process(command);

            if (depositResult == null)
            {
                return new NoContentResult();
            }

            Model model = new Model(
                depositResult.Transaction.Amount,
                depositResult.Transaction.Description,
                depositResult.Transaction.TransactionDate,
                depositResult.UpdatedBalance
            );

            return new ObjectResult(model);
        }
    }
}
