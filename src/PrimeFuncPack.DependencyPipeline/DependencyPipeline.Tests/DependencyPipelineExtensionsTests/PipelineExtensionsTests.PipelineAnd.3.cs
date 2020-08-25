#nullable enable

using Moq;
using PrimeFuncPack.DependencyPipeline.Extensions;
using PrimeFuncPack.DependencyPipeline.Tests.Stubs;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class PipelineExtensionsTests
    {
        [Fact]
        public void AndThird_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            IDependencyPipeline<(RefType, int, DateTime)> sourcePipeline = null!;

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And(otherPipeline));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void AndThird_OtherPipelineIsNull_ExpectArgumentNullException()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((new RefType(), GenerateInteger(), DateTime.Now));
            var sourcePipeline = new StubDependencyPipeline<(RefType, int, DateTime)>(mockSourceResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And<RefType, int, DateTime, StructType>(null!));
            Assert.Equal("otherPipeline", ex.ParamName);
        }

        [Fact]
        public void AndThird_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((new RefType(), GenerateInteger(), DateTime.Now));
            var sourcePipeline = new StubDependencyPipeline<(RefType, int, DateTime)>(mockSourceResolver.Object);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockSourceResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void AndThird_ThenResolve_ExpectCallResolveOtherOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((new RefType(), GenerateInteger(), DateTime.Now));
            var sourcePipeline = new StubDependencyPipeline<(RefType, int, DateTime)>(mockSourceResolver.Object);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockOtherResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.RefTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void AndThird_ThenResolve_ExpectResolvedtupleValue(
            in RefType? firstValue)
        {
            var secondValue = GenerateDecimal();
            DateTime thirdValue = DateTime.Now.AddYears(5);
            var sourceValue = (firstValue, secondValue, thirdValue);

            var mockSourceResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new StubDependencyPipeline<(RefType?, decimal, DateTime)>(mockSourceResolver.Object);

            var otherValue = new StructType
            {
                Text = GenerateText()
            };

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(otherValue);
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            var actual = actualPipeline.Resolve(serviceProvider);

            Assert.Equal(firstValue, actual.First);
            Assert.Equal(secondValue, actual.Second);
            Assert.Equal(thirdValue, actual.Third);
            Assert.Equal(otherValue, actual.Fourth);
        }
    }
}
