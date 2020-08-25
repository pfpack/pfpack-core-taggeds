#nullable enable

using Microsoft.Extensions.DependencyInjection;
using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.Stubs;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class DependencyInjectionTests
    {
        [Fact]
        public void Finish_ExpectServiceCollectionIsSame()
        {
            var mockServices = MockServiceCollection.Create();

            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyInjection<RefType> injection = new StubDependencyInjection<RefType>(mockServices.Object, mockResolver.Object);

            var actual = injection.Finish();
            Assert.Same(mockServices.Object, actual);
        }

        [Fact]
        public void Finish_ExpectCallAddTransientNever()
        {
            var mockServices = MockServiceCollection.Create();

            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyInjection<RefType> injection = new StubDependencyInjection<RefType>(mockServices.Object, mockResolver.Object);

            _ = injection.Finish();
            mockServices.Verify(s => s.Add(It.IsAny<ServiceDescriptor>()), Times.Never);
        }
    }
}
