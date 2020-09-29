#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class MockFuncFactoryTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CreateMockFunc_01_ThenInvoke_ExpectActualResult(
            in bool isResultNull)
        {
            SomeStruct? result = isResultNull ? null : new SomeStruct { Id = 15 };

            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct?>(result);

            var source = "Some Text";
            var actual = actualMock.Object.Invoke(source);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(source), Times.Once);
        }
    }
}