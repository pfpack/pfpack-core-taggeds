#nullable enable

using System;

namespace PrimeFuncPack.Extensions.DependencyInjection
{
    public delegate TService ServiceResolver<out TService>(IServiceProvider serviceProvider)
        where TService : class;
}
