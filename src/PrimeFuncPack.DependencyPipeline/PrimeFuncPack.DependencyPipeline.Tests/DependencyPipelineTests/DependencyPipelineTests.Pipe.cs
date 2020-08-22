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
        public void Pipe_PipeFunctionIsNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new RefType());
            IDependencyPipeline<RefType> pipeline = new StubDependencyPipeline<RefType>(mockResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = pipeline.Pipe<StructType>(null!));
            Assert.Equal("pipeFunc", ex.ParamName);
        }

        [Fact]
        public void Pipe_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new StructType());
            IDependencyPipeline<StructType> sourcePipeline = new StubDependencyPipeline<StructType>(mockResolver.Object);

            var actualPipeline = sourcePipeline.Pipe((sp, value) => new RefType());

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.StructTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void Pipe_ThenResolve_ExpectCallPipeFuncOnce(
            in StructType sourceValue)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            IDependencyPipeline<StructType> sourcePipeline = new StubDependencyPipeline<StructType>(mockResolver.Object);

            var mockPipeFunc = MockFuncFactory.CreateMockFunc<IServiceProvider, StructType, RefType>(new RefType());
            var actualPipeline = sourcePipeline.Pipe(mockPipeFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            var expectedValue = sourceValue;
            mockPipeFunc.Verify(f => f.Invoke(serviceProvider, expectedValue), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.RefTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void Pipe_ThenResolve_ExpectInvokedResultValue(
            in RefType? result)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new StructType());
            IDependencyPipeline<StructType> sourcePipeline = new StubDependencyPipeline<StructType>(mockResolver.Object);

            var mockPipeFunc = MockFuncFactory.CreateMockFunc<IServiceProvider, StructType, RefType?>(result);
            var actualPipeline = sourcePipeline.Pipe(mockPipeFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(result, actual);
        }
    }
}
