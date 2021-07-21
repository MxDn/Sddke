using System;
using System.Runtime.Serialization;

namespace Sddke.Shared.Infrastructure
{
    [Serializable]
    internal class InfrastructureExecption : Exception
    {
        public InfrastructureExecption()
        {
        }

        public InfrastructureExecption(string message) : base(message)
        {
        }

        public InfrastructureExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InfrastructureExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
