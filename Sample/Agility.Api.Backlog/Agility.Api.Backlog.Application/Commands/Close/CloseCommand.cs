using System;

namespace Agility.Api.Backlog.Application.Commands.Close
{
    public class CloseCommand
    {
        public Guid AccountId { get; private set; }

        public CloseCommand(Guid guid)
        {
            AccountId = guid;
        }
    }
}
