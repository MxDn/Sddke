using System;

namespace Sddke.Shared.Domain
{

    /// <summary>
    /// The domain execption.
    /// </summary>
    public class DomainExecption : Exception
    {

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="message">The message.</param>
        public DomainExecption(string message) : base(message)
        {
        }
    }
}
