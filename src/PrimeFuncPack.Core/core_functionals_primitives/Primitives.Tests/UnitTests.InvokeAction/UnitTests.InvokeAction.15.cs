#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Data;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeAction_15_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object, DateTime, StructType?, decimal, RefType, object, StructType, string, double, RefType, string> action = null!;

            var arg1 = GenerateStructType();
            var arg2 = GenerateRefType();
            var arg3 = GenerateText();
            var arg4 = GenerateInteger();
            var arg5 = new { Value = GenerateDecimal() };
            var arg6 = DateTime.Now;
            var arg7 = GenerateStructType();
            var arg8 = GenerateDecimal();
            var arg9 = GenerateRefType();
            var arg10 = new object();
            var arg11 = GenerateStructType();
            var arg12 = GenerateText();
            var arg13 = 21.75;
            var arg14 = GenerateRefType();
            var arg15 = GenerateText();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeAction_15_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType, object, StructType, string, double, object?, string>();

            var arg1 = GenerateStructType();
            var arg2 = (RefType?)null;
            var arg3 = GenerateText();
            var arg4 = GenerateInteger();
            var arg5 = new { Value = GenerateDecimal() };
            var arg6 = DateTime.Now;
            var arg7 = (StructType?)null;
            var arg8 = (decimal?)GenerateDecimal();
            var arg9 = GenerateRefType();
            var arg10 = new object();
            var arg11 = GenerateStructType();
            var arg12 = GenerateText();
            var arg13 = 21.75;
            var arg14 = (object?)null;
            var arg15 = GenerateText();

            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15), Times.Once);
        }
    }
}
