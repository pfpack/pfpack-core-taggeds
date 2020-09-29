#nullable enable

using Moq;
using System;
using Xunit;

namespace PrimeFuncPack.UnitTest.Moq.Tests
{
    partial class MockActionFactoryTests
    {
        [Fact]
        public void CreateMockAction_16_ThenInvoke_ExpectCallMockInvokeOnce()
        {
            var actualMock = MockActionFactory.CreateMockAction<string, SomeStruct, object, string?, int, SomeStruct, DateTime?, SomeType, decimal, object, string, SomeStruct?, SomeType, bool, ValueType, SomeStruct>();

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
            var arg7 = Year2020May11;
            var arg8 = new SomeType();
            var arg9 = -15.9m;
            var arg10 = new object();
            var arg11 = string.Empty;
            var arg12 = default(SomeStruct?);
            var arg13 = new SomeType
            {
                Text = "Some New"
            };
            var arg14 = true;
            var arg15 = 21.5;
            var arg16 = new SomeStruct
            {
                Id = 51
            };

            actualMock.Object.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
            actualMock.Verify(f => f.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), Times.Once);
        }
    }
}