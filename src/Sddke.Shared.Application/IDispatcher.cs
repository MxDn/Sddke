namespace Sddke.Shared.Application
{
    public interface IDispatcher
    {
        void RegisterHandler(IHanlder handler);

        TOutput Handle<TInput, TOutput>(TInput input);
    }
}
