using System.Threading.Tasks;

namespace Agility.Api.Backlog.Application.Commands.Withdraw
{
    public interface IWithdrawService
    {
        Task<WithdrawResult> Process(WithdrawCommand message);
    }
}
