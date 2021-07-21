// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Sddke.Shared.Application.Features.Command;

namespace Sddke.Shared.Tu.Application.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand
    {
        public string ProductName { get; set; }
    }
}
