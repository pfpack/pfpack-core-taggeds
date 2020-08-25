#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.DependencyPipeline.Extensions;
using PrimeFuncPack.DependencyPipeline.Tests.Stubs;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class InjectionPipelineExtensionsTests
    {
        [Fact]
        public void InjectTransient_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            IDependencyPipeline<RefType> sourcePipeline = null!;
            var mockServices = MockServiceCollection.Create();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.InjectTransient(mockServices.Object));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void InjectTransient_ServicesAreNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.InjectTransient(null!));
            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void InjectTransient_ExpectRegisteredDependencyPipeline()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            ServiceDescriptor? actualDescriptor = null;
            var mockServices = MockServiceCollection.Create(sd => actualDescriptor = sd);

            var actual = sourcePipeline.InjectTransient(mockServices.Object);
            _ = Assert.IsType<RegisteredDependencyPipeline<RefType>>(actual);
        }

        [Fact]
        public void InjectTransient_ExpectCallAddTransientOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            ServiceDescriptor? actualDescriptor = null;
            var mockServices = MockServiceCollection.Create(sd => actualDescriptor = sd);

            _ = sourcePipeline.InjectTransient(mockServices.Object);
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);

            Assert.Equal(typeof(RefType), actualDescriptor!.ServiceType);
            Assert.Equal(ServiceLifetime.Transient, actualDescriptor!.Lifetime);
            Assert.NotNull(actualDescriptor!.ImplementationFactory);
        }

        [Fact]
        public void InjectTransient_ThenInvokeImplementationFactory_ExpectResolvedValue()
        {
            var resolved = new RefType();
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            var sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            Func<IServiceProvider, object>? actualFactory = null;
            var mockServices = MockServiceCollection.Create(sd => actualFactory = sd.ImplementationFactory);

            _ = sourcePipeline.InjectTransient(mockServices.Object);
            Assert.NotNull(actualFactory);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualFactory!.Invoke(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
            Assert.Equal(resolved, actual);
        }
    }
}
