#nullable enable

using Moq;
using Xunit;

namespace PrimeFuncPack.UnitTest.Moq.Tests
{
    partial class MockActionFactoryTests
    {
        [Fact]
        public void CreateMockAction_02_ThenInvoke_ExpectCallMockInvokeOnce()
        {
            var actualMock = MockActionFactory.CreateMockAction<string, SomeStruct>();

            var arg1 = "Some Text";
            var arg2 = new SomeStruct
            {
                Id = 11
            };

            actualMock.Object.Invoke(arg1, arg2);
            actualMock.Verify(f => f.Invoke(arg1, arg2), Times.Once);
        }
    }
}