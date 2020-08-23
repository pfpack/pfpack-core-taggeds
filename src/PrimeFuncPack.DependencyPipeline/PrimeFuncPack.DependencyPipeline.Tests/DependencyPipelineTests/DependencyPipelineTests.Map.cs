#nullable enable

using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.Stubs;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class DependencyPipelineTests
    {
        [Fact]
        public void Map_MapFunctionIsNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyPipeline<RefType> pipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = pipeline.Map<StructType>(null!));
            Assert.Equal("mapFunc", ex.ParamName);
        }

        [Fact]
        public void Map_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new StructType());
            IDependencyPipeline<StructType> sourcePipeline = new StubDependencyPipeline<StructType>(mockResolver.Object);

            var actualPipeline = sourcePipeline.Map(_ => new RefType());

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.RefTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void Map_ThenResolve_ExpectCallMapFuncOnce(
            in RefType? sourceValue)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            IDependencyPipeline<RefType?> sourcePipeline = new StubDependencyPipeline<RefType?>(mockResolver.Object);

            var mockMapFunc = MockFuncFactory.CreateMockFunc<RefType?, StructType>(new StructType());
            var actualPipeline = sourcePipeline.Map(mockMapFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            var expectedValue = sourceValue;
            mockMapFunc.Verify(f => f.Invoke(expectedValue), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.StructTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void Map_ThenResolve_ExpectMappedValue(
            in StructType mappedValue)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyPipeline<RefType> sourcePipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var mockMapFunc = MockFuncFactory.CreateMockFunc<RefType, StructType>(mappedValue);
            var actualPipeline = sourcePipeline.Map(mockMapFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(mappedValue, actual);
        }
    }
}
