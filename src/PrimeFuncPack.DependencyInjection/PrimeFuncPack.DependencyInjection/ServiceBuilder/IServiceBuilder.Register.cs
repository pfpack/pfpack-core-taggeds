#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack.DependencyInjection
{
    partial interface IServiceBuilder<TService>
    {
        IServiceCollection IServiceCollectionProvider.RegisterSingleton()
            => Services.AddSingleton(Build);

        IServiceCollection IServiceCollectionProvider.RegisterScoped()
            => Services.AddScoped(Build);

        IServiceCollection IServiceCollectionProvider.RegisterTransient()
            => Services.AddTransient(Build);
    }
}
