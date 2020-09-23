#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class MockActionFactoryTests
    {
        [Fact]
        public void CreateMockAction_00_ThenInvoke_ExpectCallMockInvokeOnce()
        {
            var actualMock = MockActionFactory.CreateMockAction();

            actualMock.Object.Invoke();
            actualMock.Verify(f => f.Invoke(), Times.Once);
        }
    }
}