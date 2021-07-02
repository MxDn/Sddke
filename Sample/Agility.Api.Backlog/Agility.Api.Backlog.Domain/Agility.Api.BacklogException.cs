using System;

namespace Agility.Api.Backlog.Domain
{
    public class Agility.Api.BacklogException : Exception
    {
        public Agility.Api.BacklogException()
        { }

public Agility.Api.BacklogException(string message)
            : base(message)
        { }

public Agility.Api.BacklogException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
