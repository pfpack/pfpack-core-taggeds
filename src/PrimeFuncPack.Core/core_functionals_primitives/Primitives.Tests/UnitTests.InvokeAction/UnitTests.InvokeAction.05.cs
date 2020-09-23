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
        public void InvokeAction_05_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object> action = null!;

            var arg1 = GenerateStructType();
            var arg2 = GenerateRefType();
            var arg3 = GenerateText();
            var arg4 = GenerateInteger();
            var arg5 = new { Value = GenerateDecimal() };

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg1, arg2, arg3, arg4, arg5));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeAction_05_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?>();

            var arg1 = GenerateStructType();
            var arg2 = (RefType?)null;
            var arg3 = GenerateText();
            var arg4 = GenerateInteger();
            var arg5 = new { Value = GenerateDecimal() };

            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg1, arg2, arg3, arg4, arg5);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5), Times.Once);
        }
    }
}
