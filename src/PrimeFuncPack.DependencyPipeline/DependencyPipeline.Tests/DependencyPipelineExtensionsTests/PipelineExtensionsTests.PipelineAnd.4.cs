#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.Tests.TestEntityDateGenerator;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Tests
{
    partial class PipelineExtensionsTests
    {
        [Fact]
        public void AndFourth_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            DependencyPipeline<(RefType, int, DateTime, string)> sourcePipeline = null!;

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And(otherPipeline));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void AndFourth_OtherPipelineIsNull_ExpectArgumentNullException()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((GenerateRefType(), GenerateInteger(), DateTime.Now, GenerateText()));
            var sourcePipeline = new DependencyPipeline<(RefType, int, DateTime, string)>(mockSourceResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And<RefType, int, DateTime, string, StructType>(null!));
            Assert.Equal("otherPipeline", ex.ParamName);
        }

        [Fact]
        public void AndFourth_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((GenerateRefType(), GenerateInteger(), DateTime.Now, GenerateText()));
            var sourcePipeline = new DependencyPipeline<(RefType, int, DateTime, string)>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockSourceResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void AndFourth_ThenResolve_ExpectCallResolveOtherOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((GenerateRefType(), GenerateInteger(), DateTime.Now, GenerateText()));
            var sourcePipeline = new DependencyPipeline<(RefType, int, DateTime, string)>(mockSourceResolver.Object.Resolve);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var otherPipeline = new DependencyPipeline<StructType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockOtherResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(StructTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void AndFourth_ThenResolve_ExpectResolvedtupleValue(
            in StructType firstValue)
        {
            var secondValue = GenerateDecimal();
            var thirdValue = DateTime.Now.AddYears(5);

            var fourthValue = GenerateText();
            var sourceValue = (firstValue, secondValue, thirdValue, fourthValue);

            var mockSourceResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new DependencyPipeline<(StructType, decimal, DateTime, string)>(mockSourceResolver.Object.Resolve);

            var otherValue = GenerateRefType();
            var mockOtherResolver = MockFuncFactory.CreateMockResolver(otherValue);
            var otherPipeline = new DependencyPipeline<RefType>(mockOtherResolver.Object.Resolve);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(firstValue, actual.First);
            Assert.Equal(secondValue, actual.Second);
            Assert.Equal(thirdValue, actual.Third);
            Assert.Equal(fourthValue, actual.Fourth);
            Assert.Equal(otherValue, actual.Fifth);
        }
    }
}
