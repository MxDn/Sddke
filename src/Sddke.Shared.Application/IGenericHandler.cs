namespace Sddke.Shared.Application
{
    public interface IGenericHandler<TInput, TOutput> : IHanlder
    {
        TOutput Handle(TInput input);
    }
    public interface IGenericCqsHandler<TInput, TOutput> : IHanlder
    {
        TOutput Handle(TInput input);
    }
    public interface IGenericEbiHandler<TInput, TOutput> : IHanlder
    {
        void Handle(TInput input, TOutput output);
    }
}
