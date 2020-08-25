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
        public void AndFourth_SourcePipelineIsNull_ExpectArgumentNullException()
        {
            IDependencyPipeline<(RefType, int, DateTime, string)> sourcePipeline = null!;

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And(otherPipeline));
            Assert.Equal("sourcePipeline", ex.ParamName);
        }

        [Fact]
        public void AndFourth_OtherPipelineIsNull_ExpectArgumentNullException()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((new RefType(), GenerateInteger(), DateTime.Now, GenerateText()));
            var sourcePipeline = new StubDependencyPipeline<(RefType, int, DateTime, string)>(mockSourceResolver.Object);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = sourcePipeline.And<RefType, int, DateTime, string, StructType>(null!));
            Assert.Equal("otherPipeline", ex.ParamName);
        }

        [Fact]
        public void AndFourth_ThenResolve_ExpectCallResolveSourceOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((new RefType(), GenerateInteger(), DateTime.Now, GenerateText()));
            var sourcePipeline = new StubDependencyPipeline<(RefType, int, DateTime, string)>(mockSourceResolver.Object);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockSourceResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void AndFourth_ThenResolve_ExpectCallResolveOtherOnce()
        {
            var mockSourceResolver = MockFuncFactory.CreateMockResolver((new RefType(), GenerateInteger(), DateTime.Now, GenerateText()));
            var sourcePipeline = new StubDependencyPipeline<(RefType, int, DateTime, string)>(mockSourceResolver.Object);

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var otherPipeline = new StubDependencyPipeline<StructType>(mockOtherResolver.Object);

            var actualPipeline = sourcePipeline.And(otherPipeline);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockOtherResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(TestEntityTestData.StructTypeTestSource), MemberType = typeof(TestEntityTestData))]
        public void AndFourth_ThenResolve_ExpectResolvedtupleValue(
            in StructType firstValue)
        {
            var secondValue = GenerateDecimal();
            DateTime thirdValue = DateTime.Now.AddYears(5);

            var fourthValue = GenerateText();
            var sourceValue = (firstValue, secondValue, thirdValue, fourthValue);

            var mockSourceResolver = MockFuncFactory.CreateMockResolver(sourceValue);
            var sourcePipeline = new StubDependencyPipeline<(StructType, decimal, DateTime, string)>(mockSourceResolver.Object);

            var otherValue = new RefType
            {
                Id = GenerateInteger()
            };

            var mockOtherResolver = MockFuncFactory.CreateMockResolver(otherValue);
            var otherPipeline = new StubDependencyPipeline<RefType>(mockOtherResolver.Object);

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
