#nullable enable

using Moq;
using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using System;
using Xunit;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class RegisteredDependencyPipelineTests
    {
        [Fact]
        public void Resolve_ServiceProviderIsNull_ExpectArgumentNullException()
        {
            IDependencyPipeline<RefType> pipeline = new RegisteredDependencyPipeline<RefType>();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = pipeline.Resolve(null!));
            Assert.Equal("serviceProvider", ex.ParamName);
        }

        [Fact]
        public void Resolve_ExpectCallGetServiceOnce()
        {
            IDependencyPipeline<RefType> pipeline = new RegisteredDependencyPipeline<RefType>();
            var mockServiceProvider = CreateMockServiceProvider(new RefType());

            _ = pipeline.Resolve(mockServiceProvider.Object);
            mockServiceProvider.Verify(sp => sp.GetService(typeof(RefType)), Times.Once);
        }

        [Fact]
        public void Resolve_ServiceResultIsExpectedType_ExpectValueFromServiceProvider()
        {
            IDependencyPipeline<RefType> pipeline = new RegisteredDependencyPipeline<RefType>();

            var result = new RefType
            {
                Id = GenerateInteger()
            };
            var mockServiceProvider = CreateMockServiceProvider(result);

            var actual = pipeline.Resolve(mockServiceProvider.Object);
            Assert.Same(result, actual);
        }

        [Fact]
        public void Resolve_ServiceResultIsNull_ExpectInvalidOperationException()
        {
            IDependencyPipeline<RefType> pipeline = new RegisteredDependencyPipeline<RefType>();

            RefType result = null!;
            var mockServiceProvider = CreateMockServiceProvider(result);

            var ex = Assert.Throws<InvalidOperationException>(() => _ = pipeline.Resolve(mockServiceProvider.Object));
            Assert.Contains(typeof(RefType).FullName, ex.Message);
        }

        [Fact]
        public void Resolve_ServiceResultIsNotExpectedType_ExpectInvalidOperationException()
        {
            IDependencyPipeline<RefType> pipeline = new RegisteredDependencyPipeline<RefType>();

            var result = new object();
            var mockServiceProvider = CreateMockServiceProvider(result);

            var ex = Assert.Throws<InvalidOperationException>(() => _ = pipeline.Resolve(mockServiceProvider.Object));
            Assert.Contains(typeof(RefType).FullName, ex.Message);
        }
    }
}
