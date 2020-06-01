#nullable enable

namespace PrimeFuncPack.DependencyInjection
{
    public partial interface IServiceBuilder<TService> : IServiceCollectionProvider
        where TService : class
    {
    }
}