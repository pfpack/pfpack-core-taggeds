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
        public void InvokeThenToUnit_06_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object, DateTime> action = null!;

            var arg1 = GenerateStructType();
            var arg2 = GenerateRefType();
            var arg3 = GenerateText();
            var arg4 = GenerateInteger();
            var arg5 = new { Value = GenerateDecimal() };
            var arg6 = DateTime.Now;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeThenToUnit_06_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?, DateTime>();
            var action = new Action<StructType, RefType?, string, int, object?, DateTime>(mockAction.Object.Invoke);

            var arg1 = GenerateStructType();
            var arg2 = (RefType?)null;
            var arg3 = GenerateText();
            var arg4 = GenerateInteger();
            var arg5 = new { Value = GenerateDecimal() };
            var arg6 = DateTime.Now;

            var actual = action.InvokeThenToUnit(arg1, arg2, arg3, arg4, arg5, arg6);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6), Times.Once);
        }
    }
}
