#nullable enable

using Moq;
using Xunit;

namespace PrimeFuncPack.UnitTest.Moq.Tests
{
    partial class MockActionFactoryTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CreateMockAction_01_ThenInvoke_ExpectCallMockInvokeOnce(
            in bool isArgNull)
        {
            var actualMock = MockActionFactory.CreateMockAction<SomeStruct?>();
            SomeStruct? arg = isArgNull ? null : new SomeStruct { Id = 15 };

            actualMock.Object.Invoke(arg);
            actualMock.Verify(f => f.Invoke(arg), Times.Once);
        }
    }
}