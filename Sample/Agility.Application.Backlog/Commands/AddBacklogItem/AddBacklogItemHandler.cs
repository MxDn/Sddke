// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

using Agility.Domain.Backlog;

using Sddke.Shared.Application;
using Sddke.Shared.Application.Ports;

namespace Agility.Application.Backlog.Commands.AddBacklogItem
{
    public class AddBacklogItemHandler : IGenericHandler<AddBacklogItemCommand, AddBacklogItemResponse>
    {
        private readonly IWriteOnlyRepository<Product> writeOnlyRepository;
        private readonly IReadOnlyRepository<Product> readOnlyRepository;

        public AddBacklogItemHandler(IWriteOnlyRepository<Product> writeOnlyRepository, IReadOnlyRepository<Product> readOnlyRepository)
        {
            this.writeOnlyRepository = writeOnlyRepository;
            this.readOnlyRepository = readOnlyRepository;
        }

        public AddBacklogItemResponse Handle(AddBacklogItemCommand input)
        {
            Product? product = readOnlyRepository.GetById(input.ProductId);
            BackLogItem? backlogItem = product.AddBacklogItem(new Name(input.Name), new Description(input.Description));
            writeOnlyRepository?.Save(product);
            return new AddBacklogItemResponse() { BacklogItemId = backlogItem.Id };
        }
        public Type ListenTo()
        {
            return typeof(AddBacklogItemCommand);
        }
    }
}
