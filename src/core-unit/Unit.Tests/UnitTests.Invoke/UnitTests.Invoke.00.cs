#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitTests
    {
        [Test]
        public void Invoke_00_ActionIsNull_ExpectArgumentNullException()
        {
            Action action = null!;
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.Invoke(action));

            Assert.AreEqual("action", ex!.ParamName);
        }

        [Test]
        public void Invoke_00_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction();
            var actual = Unit.Invoke(mockAction.Object.Invoke);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(), Times.Once);
        }
    }
}
