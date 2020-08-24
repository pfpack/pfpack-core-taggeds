#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.DependencyPipeline
{
    public interface IDependencyInjection<TService>
        where TService : class
    {
        protected IServiceCollection Services { get; }

        public IServiceCollection Finish()
            => Services;

        public IServiceCollection AsTransient()
            => Services.AddTransient(Resolve);

        public IServiceCollection AsScoped()
            => Services.AddScoped(Resolve);

        public IServiceCollection AsSingleton()
            => Services.AddSingleton(Resolve);

        protected TService Resolve(IServiceProvider serviceProvider);
    }
}
