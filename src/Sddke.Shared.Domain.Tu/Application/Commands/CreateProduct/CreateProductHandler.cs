// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics.CodeAnalysis;
using Sddke.Shared.Application.Features.Command;
using Sddke.Shared.Tu.Domain;

namespace Sddke.Shared.Tu.Application.Commands.CreateProduct
{


    public class CreateProductHandler :CommandHandler//, ICommandHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        public override ICommandResponse Handle(ICommand command)
        {
            var product = new Product(new Name((command as CreateProductCommand)?.ProductName));
            return new CreateProductCommandResponse() { ProductId = product.Id };
        }
        public override Type ListenTo() => typeof(CreateProductCommand); 
    }
}
