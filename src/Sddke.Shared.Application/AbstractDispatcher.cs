using System;
using System.Collections.Generic;
using System.Linq;
namespace Sddke.Shared.Application
{
    public abstract class AbstractDispatcher : IDispatcher
    {
        private readonly Dictionary<Type, IHanlder> handlers = new Dictionary<Type, IHanlder>();

        public AbstractDispatcher(ICollection<IHanlder> handlers)
        {
            foreach (IHanlder? handler in handlers)
            {
                this.handlers.Add(handler.ListenTo(), handler);
            }
        }
        public TOutput Handle<TInput, TOutput>(TInput input)
        {
            Type? handlerType = handlers.Keys.Where(k => k.IsAssignableFrom(input.GetType())).FirstOrDefault();

            var handler = handlers[handlerType]
                       as IGenericHandler<TInput, TOutput>;
            if (handler == null)
            {
                return default;
            }

            return handler.Handle(input);
        }
        public void RegisterHandler(IHanlder handler) => handlers.Add(handler.ListenTo(), handler);

    }
}
