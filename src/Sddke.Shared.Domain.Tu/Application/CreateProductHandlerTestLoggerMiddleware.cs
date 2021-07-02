using System.Collections.Generic;
using Sddke.Shared.Application.Features.Command;
using Sddke.Shared.Application.Ports;
using Sddke.Shared.Tu.Application.Commands;
using Sddke.Shared.Tu.Application.Commands.CreateProduct;
namespace Sddke.Shared.Tu.Application
{
    public class CommandHandlerPerformanceLoggerMiddleware :
        CommandBusMiddleware<TestPerformanceLogger>
    {
        public CommandHandlerPerformanceLoggerMiddleware() : this(new CreateProductHandler(), new TestPerformanceLogger())
        {
        }

        public CommandHandlerPerformanceLoggerMiddleware(
            CommandHandler next, TestPerformanceLogger collaborator) :
            base(next, collaborator)
        {
        }
         
        public override ICommandResponse Handle(ICommand command)
        {
            collaborator.Log(command);
            var response = this.next.Handle(command);
            collaborator.Log(response);
            return response;
        }
    }
}
