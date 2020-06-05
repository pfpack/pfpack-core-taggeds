#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.DependencyInjection
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