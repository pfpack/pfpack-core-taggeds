#nullable enable

using Moq;

namespace PrimeFuncPack.UnitTest.Moq
{
    public static class MockActionFactory
    {
        public static Mock<IAction> CreateMockAction()
        {
            var mock = new Mock<IAction>();

            _ = mock.Setup(f => f.Invoke());

            return mock;
        }

        public static Mock<IAction<T>> CreateMockAction<T>()
        {
            var mock = new Mock<IAction<T>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T>()));

            return mock;
        }

        public static Mock<IAction<T1, T2>> CreateMockAction<T1, T2>()
        {
            var mock = new Mock<IAction<T1, T2>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3>> CreateMockAction<T1, T2, T3>()
        {
            var mock = new Mock<IAction<T1, T2, T3>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4>> CreateMockAction<T1, T2, T3, T4>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5>> CreateMockAction<T1, T2, T3, T4, T5>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6>> CreateMockAction<T1, T2, T3, T4, T5, T6>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>(), It.IsAny<T14>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>(), It.IsAny<T14>(), It.IsAny<T15>()));

            return mock;
        }

        public static Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> CreateMockAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>()
        {
            var mock = new Mock<IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>();

            _ = mock.Setup(f => f.Invoke(It.IsAny<T1>(), It.IsAny<T2>(), It.IsAny<T3>(), It.IsAny<T4>(), It.IsAny<T5>(), It.IsAny<T6>(), It.IsAny<T7>(), It.IsAny<T8>(), It.IsAny<T9>(), It.IsAny<T10>(), It.IsAny<T11>(), It.IsAny<T12>(), It.IsAny<T13>(), It.IsAny<T14>(), It.IsAny<T15>(), It.IsAny<T16>()));

            return mock;
        }
    }
}
