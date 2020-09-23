#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using PrimeFuncPack.UnitTest.Tests.TestData;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class MockActionFactoryTests
    {
        [Fact]
        public void CreateMockAction_03_ThenInvoke_ExpectCallMockInvokeOnce()
        {
            var actualMock = MockActionFactory.CreateMockAction<string, SomeStruct, object>();

            var arg1 = "Some Text";
            var arg2 = new SomeStruct
            {
                Id = 11
            };
            var arg3 = new
            {
                Value = "Some Third"
            };

            actualMock.Object.Invoke(arg1, arg2, arg3);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3), Times.Once);
        }
    }
}