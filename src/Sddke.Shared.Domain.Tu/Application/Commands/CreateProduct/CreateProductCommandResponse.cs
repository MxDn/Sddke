// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Sddke.Shared.Application.Features.Command;

namespace Sddke.Shared.Tu.Application.Commands.CreateProduct
{
    public class CreateProductCommandResponse : ICommandResponse
    {
        public Guid ProductId { get; set; }
    }
}
