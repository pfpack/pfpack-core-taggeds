using Moq;

namespace PrimeFuncPack.Core.Tests;

public sealed partial class OptionalTest
{
    private static Mock<IFunc<TResult>> CreateMockFunc<TResult>(TResult result)
    {
        var mock = new Mock<IFunc<TResult>>();

        _ = mock.Setup(f => f.Invoke()).Returns(result);
        _ = mock.Setup(f => f.InvokeAsync()).ReturnsAsync(result);
        _ = mock.Setup(f => f.InvokeValueAsync()).ReturnsAsync(result);

        return mock;
    }

    private static Mock<IFunc<TResult>> CreateMockFunc<T, TResult>(TResult result)
    {
        var mock = CreateMockFunc(result);

        _ = mock.Setup(f => f.Invoke(It.IsAny<T>())).Returns(result);
        _ = mock.Setup(f => f.InvokeAsync(It.IsAny<T>())).ReturnsAsync(result);
        _ = mock.Setup(f => f.InvokeValueAsync(It.IsAny<T>())).ReturnsAsync(result);

        return mock;
    }
}