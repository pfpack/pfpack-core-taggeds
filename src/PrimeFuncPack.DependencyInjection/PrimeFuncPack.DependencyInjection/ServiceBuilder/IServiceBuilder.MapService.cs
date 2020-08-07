#nullable enable

using Microsoft.Extensions.DependencyInjection;
using System;

namespace PrimeFuncPack.DependencyInjection
{
    partial interface IServiceBuilder<TService>
    {
        public IServiceBuilder<TResult> Map<TResult>(Func<TService, TResult> map)
            where TResult : class
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return Services.UseBuilder(
                sp => Resolve(sp) switch { var service => map.Invoke(service) });
        }

        public IServiceBuilder<TResult> Map<TResult>(Func<IServiceProvider, TService, TResult> map)
            where TResult : class
        {
            _ = map ?? throw new ArgumentNullException(nameof(map));

            return Services.UseBuilder(
                sp => Resolve(sp) switch { var service => map.Invoke(sp, service) });
        }
    }
}