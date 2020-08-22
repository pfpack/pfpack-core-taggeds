#nullable enable

using Moq;
using System;

namespace PrimeFuncPack.UnitTest.Moq
{
    public static class MockFuncFactory
    {
        public static Mock<IResolver<T>> CreateMockResolver<T>(
            in T result)
        {
            var mock = new Mock<IResolver<T>>();

            _ = mock
                .Setup(r => r.Resolve(It.IsAny<IServiceProvider>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<TResult>> CreateMockFunc<TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<TResult>>();

            _ = mock
                .Setup(f => f.Invoke())
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<TSource, TResult>> CreateMockFunc<TSource, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<TSource, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<TSource>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<TFirst, TSecond, TResult>> CreateMockFunc<TFirst, TSecond, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<TFirst, TSecond, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<TFirst>(), It.IsAny<TSecond>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<TFirst, TSecond, TThird, TResult>> CreateMockFunc<TFirst, TSecond, TThird, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<TFirst, TSecond, TThird, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<TFirst>(), It.IsAny<TSecond>(), It.IsAny<TThird>()))
                .Returns(result);

            return mock;
        }
    }
}
