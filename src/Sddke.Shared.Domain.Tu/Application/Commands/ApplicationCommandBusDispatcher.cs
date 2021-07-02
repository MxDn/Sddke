﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sddke.Shared.Application.Features.Command;

namespace Sddke.Shared.Tu.Application.Commands
{

    public class ApplicationCommandBusDispatcher : CommandBusDispatcher
    {
        public ApplicationCommandBusDispatcher(ICollection<CommandHandler> handlers) : base(handlers)
        {
        }
    }
}
