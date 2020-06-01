#nullable enable

using Microsoft.Extensions.DependencyInjection;

namespace PrimeFuncPack.DependencyInjection
{
    public interface IServiceCollectionProvider
    {
        protected IServiceCollection Services { get; }

        public IServiceCollection Complete()
            => Services;

        public IServiceCollection RegisterSingleton();

        public IServiceCollection RegisterScoped();

        public IServiceCollection RegisterTransient();
    }
}