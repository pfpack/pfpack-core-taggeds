#nullable enable

using PrimeFuncPack.DependencyPipeline.Tests.TestEntities;
using System;
using Xunit;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    partial class ImplDependencyPipelineTests
    {
        [Fact]
        public void New_ResolverIsNull_ExpectArgumentNullexception()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = new ImplDependencyPipeline<StructType>(null!));
            Assert.Equal("resolver", ex.ParamName);
        }
    }
}
