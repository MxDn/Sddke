using System.Threading.Tasks;

namespace Agility.Api.Backlog.Application.Commands.Close
{
    public interface ICloseService
    {
        Task<CloseResult> Process(CloseCommand command);
    }
}
