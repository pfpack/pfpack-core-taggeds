#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class InvokeThenToUnitActionExtensionsTests
    {
        [Test]
        public void InvokeThenToUnit_00_ActionIsNull_ExpectArgumentNullException()
        {
            Action action = null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit());

            Assert.AreEqual("action", ex!.ParamName);
        }

        [Test]
        public void InvokeThenToUnit_00_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction();
            var action = new Action(mockAction.Object.Invoke);

            var actual = action.InvokeThenToUnit();

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(), Times.Once);
        }
    }
}
