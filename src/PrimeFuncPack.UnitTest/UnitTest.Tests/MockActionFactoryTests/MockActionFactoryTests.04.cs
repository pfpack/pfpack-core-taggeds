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
        public void CreateMockAction_04_ThenInvoke_ExpectCallMockInvokeOnce()
        {
            var actualMock = MockActionFactory.CreateMockAction<string, SomeStruct, object, string?>();

            var arg1 = "Some Text";
            var arg2 = new SomeStruct
            {
                Id = 11
            };
            var arg3 = new
            {
                Value = "Some Third"
            };
            var arg4 = default(string?);

            actualMock.Object.Invoke(arg1, arg2, arg3, arg4);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3, arg4), Times.Once);
        }
    }
}