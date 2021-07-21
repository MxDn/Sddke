using System.Threading.Tasks;

using Agility.Api.Backlog.Application.Commands.Withdraw;

using Microsoft.AspNetCore.Mvc;

namespace Agility.Api.Backlog.WebApi.UseCases.Withdraw
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IWithdrawService withdrawService;

        public AccountsController(IWithdrawService withdrawService)
        {
            this.withdrawService = withdrawService;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
        {
            var command = new WithdrawCommand(
                request.AccountId,
                request.Amount);

            WithdrawResult depositResult = await withdrawService.Process(command);

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
