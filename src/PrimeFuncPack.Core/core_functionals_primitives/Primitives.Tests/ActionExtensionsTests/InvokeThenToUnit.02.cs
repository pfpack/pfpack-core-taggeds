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
        public void InvokeThenToUnit_02_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType> action = null!;

            var arg1 = GenerateStructType();
            var arg2 = GenerateRefType();

            var ex = Assert.Throws<ArgumentNullException>(() => _ = action.InvokeThenToUnit(arg1, arg2));
            Assert.AreEqual("action", ex.ParamName);
        }

        [Test]
        public void InvokeThenToUnit_02_ExpectCallActionOnce()
        {
            var mockAction = MockActionFactory.CreateMockAction<StructType, RefType?>();
            var action = new Action<StructType, RefType?>(mockAction.Object.Invoke);

            var arg1 = GenerateStructType();
            var arg2 = (RefType?)null;

            var actual = action.InvokeThenToUnit(arg1, arg2);

            Assert.AreEqual(Unit.Value, actual);
            mockAction.Verify(a => a.Invoke(arg1, arg2), Times.Once);
        }
    }
}
