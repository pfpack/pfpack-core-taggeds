#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class InvokeThenToUnitActionExtensionsTests
    {
        [Test]
        public void InvokeThenToUnit_16_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object, DateTime, StructType?, decimal, RefType, object, StructType, string, double, RefType, string, long> action = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusTwentyOne;
            var arg5 = new { Value = PlusOneHundredPointFive };
            var arg6 = Year2017March25H19Min31;
            var arg7 = NullTextStructType;
            var arg8 = MinusSeventyOnePointThree;
            var arg9 = ZeroIdRefType;
            var arg10 = new object();
            var arg11 = OtherTextStructType;
            var arg12 = SomeOtherText;
            var arg13 = PlusTwentyOnePointSeventyFive;
            var arg14 = MinusFifteenIdRefType;
            var arg15 = ThreeWhiteSpacesString;
            var arg16 = long.MaxValue;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16));
            Assert.AreEqual("action", ex!.ParamName);
        }

        [Test]
        public void InvokeThenToUnit_16_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType, object, StructType, string, double, object?, string, long>();
            var action = new Action<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType, object, StructType, string, double, object?, string, long>(mockAction.Object.Invoke);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusTwentyOne;
            var arg5 = new { Value = PlusOneHundredPointFive };
            var arg6 = Year2017March25H19Min31;
            var arg7 = (StructType?)null;
            var arg8 = (decimal?)MinusSeventyOnePointThree;
            var arg9 = ZeroIdRefType;
            var arg10 = new object();
            var arg11 = OtherTextStructType;
            var arg12 = SomeOtherText;
            var arg13 = PlusTwentyOnePointSeventyFive;
            var arg14 = (object?)null;
            var arg15 = ThreeWhiteSpacesString;
            var arg16 = long.MaxValue;

            var actual = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16), Times.Once);
        }
    }
}
