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
        public void InvokeAction_02_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType> action = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg1, arg2));
            Assert.AreEqual("action", ex!.ParamName);
        }

        [Test]
        public void InvokeAction_02_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;

            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg1, arg2);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2), Times.Once);
        }
    }
}
