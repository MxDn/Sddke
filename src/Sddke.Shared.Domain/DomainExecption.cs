using System;

namespace Sddke.Shared.Domain
{
    public class DomainExecption : Exception
    {
        public DomainExecption(string message) : base(message)
        {
        }

        public DomainExecption() : base()
        {
        }

        public DomainExecption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
