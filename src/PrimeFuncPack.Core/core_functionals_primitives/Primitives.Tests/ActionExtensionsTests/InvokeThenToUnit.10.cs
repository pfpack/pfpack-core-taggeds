#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Data;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.Data.DataGenerator;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class InvokeToUnitActionExtensionsTests
    {
        [Test]
        public void InvokeThenToUnit_10_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object, DateTime, StructType?, decimal, RefType, object> action = null!;

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

            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeThenToUnit_10_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType, object>();
            var action = new Action<StructType, RefType?, string, int, object?, DateTime, StructType?, decimal?, RefType, object>(mockAction.Object.Invoke);

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

            var actual = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10), Times.Once);
        }
    }
}
