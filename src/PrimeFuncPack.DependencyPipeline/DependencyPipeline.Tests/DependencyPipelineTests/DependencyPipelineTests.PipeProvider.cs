#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.Tests.TestEntityDateGenerator;

namespace PrimeFuncPack.Tests
{
    partial class DependencyPipelineTests
    {
        [Fact]
        public void PipeProvider_PipeFunctionIsNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var pipeline = new DependencyPipeline<RefType>(mockResolver.Object.Resolve);

            Func<IServiceProvider, RefType, StructType> pipeFunc = null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = pipeline.Pipe(pipeFunc));

            Assert.Equal("pipeFunc", ex.ParamName);
        }

        [Fact]
        public void PipeProvider_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var sourcePipeline = new DependencyPipeline<StructType>(mockResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.Pipe((sp, value) => GenerateRefType());

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(StructTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void PipeProvider_ThenResolve_ExpectCallPipeFuncOnce(
            in StructType sourceValue)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new DependencyPipeline<StructType>(mockResolver.Object.Resolve);

            var mockPipeFunc = MockFuncFactory.CreateMockFunc<IServiceProvider, StructType, RefType>(GenerateRefType());
            var actualPipeline = sourcePipeline.Pipe(mockPipeFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            var expectedValue = sourceValue;
            mockPipeFunc.Verify(f => f.Invoke(serviceProvider, expectedValue), Times.Once);
        }

        [Theory]
        [MemberData(nameof(RefTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void PipeProvider_ThenResolve_ExpectInvokedResultValue(
            in RefType? result)
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var sourcePipeline = new DependencyPipeline<StructType>(mockResolver.Object.Resolve);

            var mockPipeFunc = MockFuncFactory.CreateMockFunc<IServiceProvider, StructType, RefType?>(result);
            var actualPipeline = sourcePipeline.Pipe(mockPipeFunc.Object.Invoke);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(result, actual);
        }
    }
}
