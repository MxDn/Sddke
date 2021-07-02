// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Sddke.Shared.Application.Features.Command;
using Sddke.Shared.Tu.Application.Commands;
using Sddke.Shared.Tu.Application.Commands.CreateProduct;
using Xunit;
using Xunit.Abstractions;

namespace Sddke.Shared.Tu.Application
{

    public  class ApplicationCommandBusDispatcherTest
    {
        private readonly ITestOutputHelper output;

        public ApplicationCommandBusDispatcherTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void GivenSatoriAsProductNameWhereCreateWhenProductCreatedNameShouldBeSatori()
        {
            var handlers = new List<CommandHandler>
                {new CommandHandlerPerformanceLoggerMiddleware(new CreateProductHandler(),new TestPerformanceLogger(this.output))};
            var dispatcher = new ApplicationCommandBusDispatcher(handlers);
            var response = dispatcher.Handle(new CreateProductCommand { ProductName = "MyJira" });
            Assert.NotNull((response as CreateProductCommandResponse)?.ProductId);
        }
    }
}
