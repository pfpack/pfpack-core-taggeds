#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeAction_03_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string> action = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg1, arg2, arg3));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeAction_03_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?, string>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;

            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg1, arg2, arg3);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2, arg3), Times.Once);
        }
    }
}
