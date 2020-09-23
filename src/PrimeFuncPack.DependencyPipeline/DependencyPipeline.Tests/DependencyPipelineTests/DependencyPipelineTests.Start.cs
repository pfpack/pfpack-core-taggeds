#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.Tests.TestEntityDateGenerator;

namespace PrimeFuncPack.Tests
{
    public sealed partial class DependencyPipelineTests
    {
        [Fact]
        public void Start_ResolverIsNull_ExpectArgumentNullException()
        {
            Resolver<StructType> resolver = null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = DependencyPipeline.Start(resolver));

            Assert.Equal("resolver", ex.ParamName);
        }

        [Fact]
        public void Start_ThenResolve_ServiceProviderIsNull_ExpectArgumentNullException()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var actualPipeline = DependencyPipeline.Start(mockResolver.Object.Resolve);

            var ex = Assert.Throws<ArgumentNullException>(() => _ = actualPipeline.Resolve(null!));
            Assert.Equal("serviceProvider", ex.ParamName);
        }

        [Fact]
        public void Start_ThenResolve_ExpectCallResolverOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(GenerateStructType());
            var actualPipeline = DependencyPipeline.Start(mockResolver.Object.Resolve);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Theory]
        [MemberData(nameof(RefTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void Start_ThenResolve_ExpectResolvedValue(
            in RefType? source)
        {
            var sourceValue = source;
            var actualPipeline = DependencyPipeline.Start(_ => sourceValue);

            var actual = actualPipeline.Resolve(Mock.Of<IServiceProvider>());
            Assert.Same(source, actual);
        }

        [Fact]
        public void StartFromValue_ThenResolve_ServiceProviderIsNull_ExpectArgumentNullException()
        {
            var actualPipeline = DependencyPipeline.Start(GenerateStructType());

            var ex = Assert.Throws<ArgumentNullException>(() => _ = actualPipeline.Resolve(null!));
            Assert.Equal("serviceProvider", ex.ParamName);
        }

        [Theory]
        [MemberData(nameof(RefTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void StartFromRefType_ThenResolve_ExpectResolvedValue(
            in RefType? source)
        {
            var actualPipeline = DependencyPipeline.Start(source);

            var actual = actualPipeline.Resolve(Mock.Of<IServiceProvider>());
            Assert.Same(source, actual);
        }

        [Theory]
        [MemberData(nameof(StructTypeTestSource), MemberType = typeof(TestEntityDateGenerator))]
        public void StartFromStructType_ThenResolve_ExpectResolvedValue(
            in StructType source)
        {
            var actualPipeline = DependencyPipeline.Start(source);

            var actual = actualPipeline.Resolve(Mock.Of<IServiceProvider>());
            Assert.Equal(source, actual);
        }

        [Fact]
        public void StartUnitPipeline_ThenResolve_ServiceProviderIsNull_ExpectArgumentNullException()
        {
            var actualPipeline = DependencyPipeline.Start();

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = actualPipeline.Resolve(null!);
            });

            Assert.Equal("serviceProvider", ex.ParamName);
        }

        [Fact]
        public void StartUnitPipeline_ThenResolve_ExpectUnit()
        {
            var actualPipeline = DependencyPipeline.Start();

            var actual = actualPipeline.Resolve(Mock.Of<IServiceProvider>());
            Assert.Equal(Unit.Value, actual);
        }
    }
}
