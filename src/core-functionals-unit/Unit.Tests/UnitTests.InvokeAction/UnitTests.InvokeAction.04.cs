#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeAction_04_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int> action = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg1, arg2, arg3, arg4));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeAction_04_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string, int>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;

            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg1, arg2, arg3, arg4);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3, arg4), Times.Once);
        }
    }
}
