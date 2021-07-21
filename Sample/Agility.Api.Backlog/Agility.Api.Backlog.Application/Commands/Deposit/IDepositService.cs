using System.Threading.Tasks;

namespace Agility.Api.Backlog.Application.Commands.Deposit
{
    public interface IDepositService
    {
        Task<DepositResult> Process(DepositCommand command);
    }
}
