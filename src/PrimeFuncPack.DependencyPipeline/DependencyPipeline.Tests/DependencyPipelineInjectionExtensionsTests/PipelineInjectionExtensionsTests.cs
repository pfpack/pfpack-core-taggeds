#nullable enable

using Moq;
using System;

namespace PrimeFuncPack.Tests
{
    public sealed partial class PipelineInjectionExtensionsTests
    {
        private static Mock<IServiceProvider> CreateMockServiceProvider(
            in object? resultValue)
        {
            var mock = new Mock<IServiceProvider>();

            _ = mock
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns(resultValue);

            return mock;
        }
    }
}
