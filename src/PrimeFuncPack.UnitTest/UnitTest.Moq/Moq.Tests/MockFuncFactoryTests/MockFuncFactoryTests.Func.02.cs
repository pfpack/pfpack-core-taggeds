#nullable enable

using Moq;
using Xunit;

namespace PrimeFuncPack.UnitTest.Moq.Tests
{
    partial class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockFunc_02_ThenInvoke_ExpectActualResult()
        {
            var result = new SomeType
            {
                Text = "Some Source"
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, SomeType>(result);

            var arg1 = "Some Text";
            var arg2 = new SomeStruct
            {
                Id = 11
            };

            var actual = actualMock.Object.Invoke(arg1, arg2);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(arg1, arg2), Times.Once);
        }
    }
}