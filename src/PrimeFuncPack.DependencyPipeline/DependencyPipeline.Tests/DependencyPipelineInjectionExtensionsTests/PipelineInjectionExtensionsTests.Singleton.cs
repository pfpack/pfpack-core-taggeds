#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.Tests.TestEntityDateGenerator;

namespace PrimeFuncPack.Tests
{
    partial class PipelineInjectionExtensionsTests
    {
        [Fact]
        public void InjectSingleton_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<RefType> sourcePipeline = null!;
            var mockServices = MockServiceCollection.Create();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.InjectSingleton(mockServices.Object));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void InjectSingleton_ServicesAreNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.InjectSingleton(null!));
            Assert.Equal("services", ex.ParamName);
        }

        [Fact]
        public void InjectSingleton_ExpectCallAddSingletonOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            ServiceDescriptor? actualDescriptor = null;
            var mockServices = MockServiceCollection.Create(sd => actualDescriptor = sd);

            _ = sourcePipeline.InjectSingleton(mockServices.Object);
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);

            Assert.Equal(typeof(RefType), actualDescriptor!.ServiceType);
            Assert.Equal(ServiceLifetime.Singleton, actualDescriptor!.Lifetime);
            Assert.NotNull(actualDescriptor!.ImplementationFactory);
        }

        [Fact]
        public void InjectSingleton_ThenInvokeImplementationFactory_ExpectResolvedValue()
        {
            var resolved = GenerateRefType();
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            Func<IServiceProvider, object>? actualFactory = null;
            var mockServices = MockServiceCollection.Create(sd => actualFactory = sd.ImplementationFactory);

            _ = sourcePipeline.InjectSingleton(mockServices.Object);
            Assert.NotNull(actualFactory);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualFactory!.Invoke(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
            Assert.Equal(resolved, actual);
        }

        [Fact]
        public void InjectSingleton_ThenResolve_ExpectGetServiceFromProviderOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = MockServiceCollection.Create();
            var actualPipeline = sourcePipeline.InjectSingleton(mockServices.Object);

            var mockServiceProvider = CreateMockServiceProvider(GenerateRefType());
            _ = actualPipeline.Resolve(mockServiceProvider.Object);

            mockServiceProvider.Verify(sp => sp.GetService(typeof(RefType)), Times.Once);
        }

        [Fact]
        public void InjectSingleton_ThenResolve_ServiceFromProviderIsNull_ExpectInvalidOperationException()
        {
            var resolved = GenerateRefType();
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            var sourcePipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            var mockServices = MockServiceCollection.Create();
            var actualPipeline = sourcePipeline.InjectSingleton(mockServices.Object);

            var mockServiceProvider = CreateMockServiceProvider(null);
            var ex = Assert.Throws<InvalidOperationException>(() => _ = actualPipeline.Resolve(mockServiceProvider.Object));

            Assert.Contains(typeof(RefType).FullName, ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void InjectSingleton_ThenResolve_ExpectValueFromServiceProvider()
        {
            var resolved = GenerateRefType();
            var sourcePipeline = new DependencyPipeline<RefType>(_ => resolved);

            var mockServices = MockServiceCollection.Create();
            var actualPipeline = sourcePipeline.InjectSingleton(mockServices.Object);

            var valueFromProvider = GenerateRefType();
            var mockServiceProvider = CreateMockServiceProvider(valueFromProvider);

            var actual = actualPipeline.Resolve(mockServiceProvider.Object);
            Assert.Same(valueFromProvider, actual);
        }
    }
}
