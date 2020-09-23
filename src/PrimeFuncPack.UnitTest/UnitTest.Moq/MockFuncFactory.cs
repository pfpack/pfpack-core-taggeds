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

        public static Mock<IFunc<T1, T2, TResult>> CreateMockFunc<T1, T2, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, TResult>> CreateMockFunc<T1, T2, T3, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, TResult>> CreateMockFunc<T1, T2, T3, T4, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>(), It.IsAny<T14>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>(), It.IsAny<T14>(), It.IsAny<T15>()))
                .Returns(result);

            return mock;
        }

        public static Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>> CreateMockFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            in TResult result)
        {
            var mock = new Mock<IFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>>();

            _ = mock
                .Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>(), It.IsAny<T14>(), It.IsAny<T15>(), It.IsAny<T16>()))
                .Returns(result);

            return mock;
        }
    }
}
