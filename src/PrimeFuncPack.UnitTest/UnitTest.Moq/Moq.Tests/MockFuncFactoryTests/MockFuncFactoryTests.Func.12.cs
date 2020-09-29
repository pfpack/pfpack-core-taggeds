#nullable enable

using Moq;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Moq.Tests
{
    partial class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockFunc_12_ThenInvoke_ExpectActualResult()
        {
            var result = new SomeStruct
            {
                Id = -21
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, object, string?, int, SomeStruct, DateTime?, SomeType, decimal, object, string, SomeStruct?, SomeStruct>(result);

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
            var arg5 = 15;
            var arg6 = default(SomeStruct);
            var arg7 = Year2020Jan15;
            var arg8 = new SomeType();
            var arg9 = -15.9m;
            var arg10 = new object();
            var arg11 = string.Empty;
            var arg12 = default(SomeStruct?);

            var actual = actualMock.Object.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12), Times.Once);
        }
    }
}