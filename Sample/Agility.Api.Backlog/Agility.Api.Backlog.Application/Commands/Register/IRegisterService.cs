using System.Threading.Tasks;

namespace Agility.Api.Backlog.Application.Commands.Register
{
    public interface IRegisterService
    {
        Task<RegisterResult> Process(RegisterCommand message);
    }
}
