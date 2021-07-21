using System;

using Sddke.Shared.Application.Ports;
namespace Sddke.Shared.Application
{
    public class BusMiddleware<TInput, TOutput, TCollaborator> :
       IGenericHandler<TInput, TOutput>
        where TCollaborator : class, ICollaborator
    {
        protected TCollaborator collaborator;
        protected IGenericHandler<TInput, TOutput> next;

        protected BusMiddleware(IGenericHandler<TInput, TOutput> next, TCollaborator collaborator)
        {
            this.next = next ?? throw new ApplicationExecption(nameof(next));
            this.collaborator = collaborator ?? throw new ApplicationExecption(nameof(collaborator));
        }

        public TOutput Handle(TInput input)
        {
            collaborator.BeforeHandle(input);
            TOutput output = next.Handle(input);
            collaborator.AfterHandle(output);
            return output;
        }
        public Type ListenTo() => next.ListenTo();
    }
}
