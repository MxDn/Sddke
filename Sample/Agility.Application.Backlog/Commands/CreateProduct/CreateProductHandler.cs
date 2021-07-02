// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

using Agility.Domain.Backlog;

using Sddke.Shared.Application;
using Sddke.Shared.Application.Ports;

namespace Agility.Application.Backlog.Commands.CreateProduct
{
    /// <summary>
    /// The create product handler.
    /// </summary>
    public class CreateProductHandler : IGenericHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IWriteOnlyRepository<Product> writeOnlyRepository;

        public CreateProductHandler(IWriteOnlyRepository<Product> writeOnlyRepository)
        {
            this.writeOnlyRepository = writeOnlyRepository;
        }

        public CreateProductCommandResponse Handle(CreateProductCommand input)
        {
            var product = new Product(new Name(input?.ProductName));
            writeOnlyRepository?.Save(product);
            return new CreateProductCommandResponse() { ProductId = product.Id };
        }
        public Type ListenTo()
        {
            return typeof(CreateProductCommand);
        }
    }
}
