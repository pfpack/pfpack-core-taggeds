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
        public void CreateMockFunc_00_ThenInvoke_ExpectActualResult(
            in bool isResultNull)
        {
            SomeStruct? result = isResultNull ? null : new SomeStruct { Id = 15 };

            var actualMock = MockFuncFactory.CreateMockFunc(result);
            var actual = actualMock.Object.Invoke();

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(), Times.Once);
        }
    }
}