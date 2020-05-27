#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.Extensions.DependencyInjection
{
    partial interface IServiceBuilder<TService>
    {
        public TService Resolve(IServiceProvider serviceProvider)
            =>
            serviceProvider.GetService<TService>() switch
            {
                null => Build(serviceProvider),
                var service => service
            };

        public TService Build(IServiceProvider serviceProvider);
    }
}