#nullable enable

using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class ImplDependencyPipelineTests
    {
        [Fact]
        public void Resolve_ServiceProviderIsNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new StructType());
            IDependencyPipeline<StructType> pipeline = new ImplDependencyPipeline<StructType>(mockResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = pipeline.Resolve(null!));
            Assert.Equal("serviceProvider", ex.ParamName);
        }

        [Fact]
        public void Resolve_ExpectCallResolverOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new StructType());
            IDependencyPipeline<StructType> pipeline = new ImplDependencyPipeline<StructType>(mockResolver.Object.Resolve);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = pipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.RefTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void Resolve_ExpectResolvedValue(
            RefType? resolvedValue)
        {
            var value = resolvedValue;
            IDependencyPipeline<RefType?> pipeline = new ImplDependencyPipeline<RefType?>(_ => value);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = pipeline.Resolve(serviceProvider);

            Assert.Same(resolvedValue, actual);
        }
    }
}
