#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.Stubs;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class InjectionExtensionsTests
    {
        [Fact]
        public void UseInjection_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            IDependencyPipeline<RefType> sourcePipeline = null!;
            var services = Mock.Of<IServiceCollection>();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.UseInjection(services));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void UseInjection_ServicesAreNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.UseInjection(null!));
            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void UseInjection_ExpectImplDependencyInjector()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var services = Mock.Of<IServiceCollection>();
            var actual = sourcePipeline.UseInjection(services);

            _ = Assert.IsType<ImplDependencyInjection<RefType>>(actual);
        }

        [Fact]
        public void UseInjection_ThenFinish_ExpectSameServices()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var services = Mock.Of<IServiceCollection>();
            var actual = sourcePipeline.UseInjection(services);

            var actualServices = actual.Finish();
            Assert.Same(services, actualServices);
        }
    }
}
