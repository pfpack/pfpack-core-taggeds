#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeFuncAsync_02_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(funcAsync, arg1, arg2));
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public void InvokeFuncAsync_02_ExpectCallActionOnce()
        {
            var mockFuncAsync = MockActionFactory.CreateMockAction<StructType, RefType?>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;

            var actual = Unit.InvokeAction(mockFuncAsync.Object.Invoke, arg1, arg2);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(arg1, arg2), Times.Once);
        }
    }
}
