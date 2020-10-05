#nullable enable

using Moq;
using Xunit;

namespace PrimeFuncPack.UnitTest.Moq.Tests
{
    partial class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockFunc_04_ThenInvoke_ExpectActualResult()
        {
            var result = new SomeType
            {
                Text = "Some Source"
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, object, string?, SomeType>(result);

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

            var actual = actualMock.Object.Invoke(arg1, arg2, arg3, arg4);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3, arg4), Times.Once);
        }
    }
}