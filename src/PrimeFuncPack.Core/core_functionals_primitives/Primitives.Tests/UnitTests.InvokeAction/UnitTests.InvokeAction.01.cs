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
        public void InvokeAction_01_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType> action = null!;
            var arg = GenerateStructType();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg));

            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void InvokeAction_01_ExpectCallActionOnce(
            in bool isArgNull)
        {
            var mockAction = MockActionFactory.CreateMockAction<RefType?>();

            var arg = isArgNull ? null : GenerateRefType();
            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg), Times.Once);
        }
    }
}
