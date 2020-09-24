#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using PrimeFuncPack.UnitTest.Tests.TestData;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockFunc_03_ThenInvoke_ExpectActualResult()
        {
            var result = new SomeType
            {
                Text = "Some Source"
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, object, SomeType>(result);

            var arg1 = "Some Text";
            var arg2 = new SomeStruct
            {
                Id = 11
            };
            var arg3 = new
            {
                Value = "Some Third"
            };

            var actual = actualMock.Object.Invoke(arg1, arg2, arg3);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3), Times.Once);
        }
    }
}