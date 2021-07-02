// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;

namespace Sddke.Shared.Application.Features.Command
{
    public class CommandBusDispatcher 
    {
        private readonly Dictionary<Type, CommandHandler> handlers = new Dictionary<Type,CommandHandler>();

        public CommandBusDispatcher(ICollection<CommandHandler> handlers)
        {
            foreach (var handler in handlers)
            {
                this.handlers.Add(handler.ListenTo(), handler);
            }
        }

        public ICommandResponse Handle(ICommand command) => handlers[command.GetType()].Handle(command);
        
    }
}
