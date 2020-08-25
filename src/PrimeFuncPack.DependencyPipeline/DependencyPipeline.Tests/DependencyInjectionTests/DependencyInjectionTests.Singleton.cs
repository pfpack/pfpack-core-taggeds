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
    partial class DependencyInjectionTests
    {
        [Fact]
        public void AsSingleton_ExpectServiceCollectionIsSame()
        {
            var mockServices = MockServiceCollection.Create();

            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyInjection<RefType> injection = new StubDependencyInjection<RefType>(mockServices.Object, mockResolver.Object);

            var actual = injection.AsSingleton();
            Assert.Same(mockServices.Object, actual);
        }

        [Fact]
        public void AsSingleton_ExpectCallAddSingletonOnce()
        {
            ServiceDescriptor? actualDescriptor = null;
            var mockServices = MockServiceCollection.Create(sd => actualDescriptor = sd);

            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyInjection<RefType> injection = new StubDependencyInjection<RefType>(mockServices.Object, mockResolver.Object);

            _ = injection.AsSingleton();
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Once);

            Assert.Equal(typeof(RefType), actualDescriptor!.ServiceType);
            Assert.Equal(ServiceLifetime.Singleton, actualDescriptor!.Lifetime);
            Assert.NotNull(actualDescriptor!.ImplementationFactory);
        }

        [Fact]
        public void AsSingleton_ThenInvokeImplementationFactory_ExpectResolvedValue()
        {
            Func<IServiceProvider, object>? actualFactory = null;
            var mockServices = MockServiceCollection.Create(sd => actualFactory = sd.ImplementationFactory);

            var resolved = new RefType();
            var mockResolver = MockFuncFactory.CreateMockResolver(resolved);
            IDependencyInjection<RefType> injection = new StubDependencyInjection<RefType>(mockServices.Object, mockResolver.Object);

            _ = injection.AsSingleton();
            Assert.NotNull(actualFactory);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualFactory!.Invoke(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
            Assert.Equal(resolved, actual);
        }
    }
}
