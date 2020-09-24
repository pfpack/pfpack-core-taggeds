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
        public void InvokeAction_02_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType> action = null!;

            var arg1 = GenerateStructType();
            var arg2 = GenerateRefType();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(action, arg1, arg2));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeAction_02_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?>();

            var arg1 = GenerateStructType();
            var arg2 = (RefType?)null;

            var actual = Unit.InvokeAction(mockAction.Object.Invoke, arg1, arg2);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2), Times.Once);
        }
    }
}
