// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Sddke.Shared.Application.Features.Command
{
    public abstract class CommandHandler //: ICommandHandler<ICommand, ICommandResponse>
    {
        public abstract ICommandResponse Handle(ICommand command);

        public abstract Type ListenTo();
    }
}
