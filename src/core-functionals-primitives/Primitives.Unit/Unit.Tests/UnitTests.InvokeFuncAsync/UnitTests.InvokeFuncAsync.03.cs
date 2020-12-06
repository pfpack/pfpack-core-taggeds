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
        public void InvokeFuncAsync_03_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(funcAsync, arg1, arg2, arg3));
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public void InvokeFuncAsync_03_ExpectCallActionOnce()
        {
            var mockFuncAsync = MockActionFactory.CreateMockAction<StructType, RefType?, string>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;

            var actual = Unit.InvokeAction(mockFuncAsync.Object.Invoke, arg1, arg2, arg3);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(arg1, arg2, arg3), Times.Once);
        }
    }
}
