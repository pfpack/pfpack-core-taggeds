#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class ImplDependencyInjectionTests
    {
        [Fact]
        public void New_ServicesAreNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());

            var ex = Assert.Throws<ArgumentNullException>(() => _ = new ImplDependencyInjection<RefType>(
                services: null!,
                resolver: mockResolver.Object.Resolve));

            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void New_ResolverAreNull_ExpectArgumentNullException()
        {
            var services = Mock.Of<IServiceCollection>();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = new ImplDependencyInjection<RefType>(
                services: services,
                resolver: null!));

            Assert.Equal("resolver", ex.ParamName);
        }
    }
}
