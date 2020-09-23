#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.Tests.TestEntityDateGenerator;

namespace PrimeFuncPack.Tests
{
    partial class PipelineExtensionsTests
    {
        [Fact]
        public void AndFirst_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<RefType> sourcePipeline = null!;

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And(otherPipeline));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void AndFirst_OtherPipelineIsNull_ExpectArgumentNullException()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var sourcePipeline = new DependencyPipeline<RefType>(mockSourceResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And<RefType, StructType>(null!));
            Assert.Equal("otherPipeline", ex.ParamName);
        }

        [Fact]
        public void AndFirst_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var sourcePipeline = new DependencyPipeline<RefType>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockSourceResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void AndFirst_ThenResolve_ExpectCallResolveOtherOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver(GenerateRefType());
            var sourcePipeline = new DependencyPipeline<RefType>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockOtherResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(RefTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void AndFirst_ThenResolve_ExpectResolvedtupleValue(
            in RefType sourceValue)
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new DependencyPipeline<RefType>(mockSourceResolver.Object.Resolve);

            var otherValue = GenerateStructType();
            var mockOtherResolver = MockFuncFactory.CreateMockResolver(otherValue);
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(sourceValue, actual.First);
            Assert.Equal(otherValue, actual.Second);
        }
    }
}
