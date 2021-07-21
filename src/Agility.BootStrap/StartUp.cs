// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

using Agility.Application.Backlog;
using Agility.Application.Backlog.Commands.AddBacklogItem;
using Agility.Application.Backlog.Commands.CreateProduct;
using Agility.Application.Backlog.Queries.RetrieveProduct;
using Agility.Domain.Backlog;

using Sddke.Shared.Application;
using Sddke.Shared.Infrastructure.Adapters;

namespace Agility.BootStrap
{
    /// <summary>
    /// The start up.
    /// </summary>
    public class StartUp
    {
        private static ApplicationBusDispatcher _applicationBus;
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">The args.</param>
        private static void Main(string[] args) => Initialise();

        /// <summary>
        /// The initialise.
        /// </summary>
        /// <returns>The result.</returns>
        public static ApplicationBusDispatcher Initialise()
        {
            if (_applicationBus == null)
            {
                var products = new List<Product>();
                var handlers = new List<IHanlder>();
                var InMemoryWriteOnlyRepository = new InMemoryWriteOnlyRepository<Product>(products);
                var InMemoryReadOnlyRepository = new InMemoryReadOnlyRepository<Product>(products);
                handlers.Add(new CreateProductHandler(InMemoryWriteOnlyRepository));
                handlers.Add(new RetrieveProductHandler(InMemoryReadOnlyRepository));
                handlers.Add(new AddBacklogItemHandler(InMemoryWriteOnlyRepository, InMemoryReadOnlyRepository));
                _applicationBus = new ApplicationBusDispatcher(handlers);
            }
            return _applicationBus;
        }
    }
}
