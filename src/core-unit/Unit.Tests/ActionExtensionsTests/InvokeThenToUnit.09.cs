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
        public void InvokeThenToUnit_09_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object, DateTime, StructType?, decimal, RefType> action = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusTwentyOne;
            var arg5 = new { Value = PlusOneHundredPointFive };
            var arg6 = Year2017March25H19Min31;
            var arg7 = NullTextStructType;
            var arg8 = MinusSeventyOnePointThree;
            var arg9 = ZeroIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeThenToUnit_09_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType>();
            var action = new Action<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType>(mockAction.Object.Invoke);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusTwentyOne;
            var arg5 = new { Value = PlusOneHundredPointFive };
            var arg6 = Year2017March25H19Min31;
            var arg7 = (StructType?)null;
            var arg8 = (decimal?)MinusSeventyOnePointThree;
            var arg9 = ZeroIdRefType;

            var actual = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9), Times.Once);
        }
    }
}
