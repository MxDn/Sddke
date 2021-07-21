
namespace Agility.Api.Backlog.Domain
{
    public class DomainException : Agility.Api.BacklogException
    {
        public string BusinessMessage { get; private set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
