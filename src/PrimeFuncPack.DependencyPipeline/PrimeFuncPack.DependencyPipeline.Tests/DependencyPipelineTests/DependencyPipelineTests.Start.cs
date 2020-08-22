#nullable enable

using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using PrimeFuncPack.UnitTest.Moq;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    public sealed partial class DependencyPipelineTests
    {
        [Fact]
        public void Start_ResolverIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = DependencyPipeline.Start<StructType>(null!));
            Assert.Equal("resolver", ex.ParamName);
        }

        [Fact]
        public void Start_ExpectImplDependencyPipeline()
        {
            var actual = DependencyPipeline.Start(_ => new RefType());
            _ = Assert.IsType<ImplDependencyPipeline<RefType>>(actual);
        }

        [Fact]
        public void Start_ThenResolve_ExpectCallResolverOnce()
        {
            var mockResolver = MockFuncFactory.CreateMockResolver(new StructType());
            var actualPipeline = DependencyPipeline.Start(mockResolver.Object.Resolve);

            var serviceProvider = Mock.Of<IServiceProvider>();
            _ = actualPipeline.Resolve(serviceProvider);

            mockResolver.Verify(r => r.Resolve(serviceProvider), Times.Once);
        }

        [Fact]
        public void Start_ThenResolve_ExpectResolvedValue()
        {
            var source = new RefType
            {
                Id = GenerateInteger()
            };

            var actualPipeline = DependencyPipeline.Start(_ => source);
            var actual = actualPipeline.Resolve(Mock.Of<IServiceProvider>());

            Assert.Equal(source, actual);
        }
    }
}
