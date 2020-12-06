#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeFuncAsync_13_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object, DateTime, StructType?, decimal, RefType, object, StructType, string, double> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;
            var arg5 = new { Value = PlusTwoHundredPointFive };
            var arg6 = Year2015March11H01Min15;
            var arg7 = NullTextStructType;
            var arg8 = MinusSeventyFivePointSeven;
            var arg9 = ZeroIdRefType;
            var arg10 = new object();
            var arg11 = CustomStringStructType;
            var arg12 = CustomText;
            var arg13 = PlusFortyOnePointSeventyFive;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(funcAsync, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13));
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public void InvokeFuncAsync_13_ExpectCallActionOnce()
        {
            var mockFuncAsync = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType, object, StructType, string, double>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;
            var arg5 = new { Value = PlusTwoHundredPointFive };
            var arg6 = Year2015March11H01Min15;
            var arg7 = (StructType?)null;
            var arg8 = (decimal?)MinusSeventyFivePointSeven;
            var arg9 = ZeroIdRefType;
            var arg10 = new object();
            var arg11 = CustomStringStructType;
            var arg12 = CustomText;
            var arg13 = PlusFortyOnePointSeventyFive;

            var actual = Unit.InvokeAction(mockFuncAsync.Object.Invoke, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13), Times.Once);
        }
    }
}
