// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System.Collections.Generic;

using Sddke.Shared.Application;

namespace Agility.Application.Backlog
{
    /// <summary>
    /// The application command bus dispatcher.
    /// </summary>
    public class ApplicationBusDispatcher
        : AbstractDispatcher
    {
        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="handlers">The handlers.</param>
        public ApplicationBusDispatcher(ICollection<IHanlder> handlers) : base(handlers)
        {
        }
    }
}
