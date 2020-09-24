#nullable enable

using Moq;
using PrimeFuncPack.UnitTest.Moq;
using PrimeFuncPack.UnitTest.Tests.TestData;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Tests
{
    partial class MockFuncFactoryTests
    {
        [Fact]
        public void CreateMockFunc_13_ThenInvoke_ExpectActualResult()
        {
            var result = new SomeStruct
            {
                Id = -21
            };
            var actualMock = MockFuncFactory.CreateMockFunc<string, SomeStruct, object, string?, int, SomeStruct, DateTime?, SomeType, decimal, object, string, SomeStruct?, SomeType, SomeStruct>(result);

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
            var arg7 = DateTime.Now;
            var arg8 = new SomeType();
            var arg9 = -15.9m;
            var arg10 = new object();
            var arg11 = string.Empty;
            var arg12 = default(SomeStruct?);
            var arg13 = new SomeType
            {
                Text = "Some New"
            };

            var actual = actualMock.Object.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

            Assert.Equal(result, actual);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), Times.Once);
        }
    }
}