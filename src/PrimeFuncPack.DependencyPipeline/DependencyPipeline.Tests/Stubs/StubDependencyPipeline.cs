#nullable enable

using PrimeFuncPack.UnitTest.Moq;
using System;

namespace PrimeFuncPack.DependencyPipeline.Tests.Stubs
{
    internal sealed class StubDependencyPipeline<T> : IDependencyPipeline<T>
    {
        private readonly IResolver<T> resolver;

        public StubDependencyPipeline(in IResolver<T> resolver)
            => this.resolver = resolver;

        public T Resolve(IServiceProvider serviceProvider)
            => resolver.Resolve(serviceProvider);
    }
}
