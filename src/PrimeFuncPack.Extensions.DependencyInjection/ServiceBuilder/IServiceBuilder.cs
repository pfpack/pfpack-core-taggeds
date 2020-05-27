#nullable enable

namespace PrimeFuncPack.Extensions.DependencyInjection
{
    public partial interface IServiceBuilder<TService> : IServiceCollectionProvider
        where TService : class
    {
    }
}