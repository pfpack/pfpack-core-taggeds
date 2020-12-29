#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;

namespace PrimeFuncPack.Core.Functionals.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeAction_00_ActionIsNull_ExpectArgumentNullException()
        {
            Action action = null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action));

            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeAction_00_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction();
            var actual = Unit.InvokeAction(mockAction.Object.Invoke);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(), Times.Once);
        }
    }
}
