// Copyright (c) Charlie Poole, Rob Prouse and Contributors. MIT License - see LICENSE.txt

using System;

using Agility.Domain.Backlog;

using Sddke.Shared.Application;
using Sddke.Shared.Application.Ports;

namespace Agility.Application.Backlog.Queries.RetrieveProduct
{
    public class RetrieveProductHandler : IGenericHandler<RetrieveProductQuery, RetrieveProductQueryResponse>
    {
        private readonly IReadOnlyRepository<Product> readOnlyRepository;

        public RetrieveProductHandler(IReadOnlyRepository<Product> readOnlyRepository)
        {
            this.readOnlyRepository = readOnlyRepository;
        }

        public RetrieveProductQueryResponse Handle(RetrieveProductQuery input)
        {
            if (input is RetrieveProductByIdQuery retrieveProductByIdQuery)
            {
                return new RetrieveProductQueryResponse() { Product = readOnlyRepository.GetById(retrieveProductByIdQuery.ProductId) };
            }

            if (input is RetrieveProductByNameQuery retrieveProductByNameQuery)
            {
                return new RetrieveProductQueryResponse() { Product = readOnlyRepository.GetByExpression(entity => entity.Name.Equals(retrieveProductByNameQuery.ProductName)) };
            }

            throw new ApplicationException(nameof(input));
        }
        public Type ListenTo()
        {
            return typeof(RetrieveProductQuery);
        }
    }
}
