#nullable enable

using Moq;
using System;

namespace PrimeFuncPack.DependencyPipeline.Tests
{
    public sealed partial class RegisteredDependencyPipelineTests
    {
        private static Mock<IServiceProvider> CreateMockServiceProvider(
            in object result)
        {
            var mock = new Mock<IServiceProvider>();

            _ = mock
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns(result);

            return mock;
        }
    }
}
