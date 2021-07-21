using System;

namespace Agility.Api.Backlog.Application.Commands.Close
{
    public class CloseResult
    {
        public Guid AccountId { get; private set; }
        public CloseResult()
        {

        }

        public CloseResult(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
