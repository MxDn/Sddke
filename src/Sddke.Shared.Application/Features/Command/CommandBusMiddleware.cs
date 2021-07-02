// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System; 
using Sddke.Shared.Application.Ports;

namespace Sddke.Shared.Application.Features.Command
{
    /// <summary>
    /// The command bus middleware.
    /// </summary>
    public abstract class CommandBusMiddleware< TCollaborator> : 
       CommandHandler
        where TCollaborator : class, ICollaborator
    {
        protected TCollaborator collaborator;
        protected CommandHandler next;

        /// <summary>
        /// The .ctor.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="collaborator">The collaborator.</param>
        protected CommandBusMiddleware(CommandHandler next, TCollaborator collaborator)
        {
            this.next = next ?? throw new ApplicationExecption(nameof(next));
            this.collaborator = collaborator ?? throw new ApplicationExecption(nameof(collaborator));
        }

        public override Type ListenTo()
        {
            return this.next.ListenTo();
        }
    }
}
