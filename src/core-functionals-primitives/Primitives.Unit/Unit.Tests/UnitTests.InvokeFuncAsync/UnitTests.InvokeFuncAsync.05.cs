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
        public void InvokeFuncAsync_05_ActionIsNull_ExpectArgumentNullException()
        {
            Action<StructType, RefType, string, int, object> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;
            var arg5 = new { Value = PlusTwoHundredPointFive };

            var ex = Assert.Throws<ArgumentNullException>(() => _ = Unit.InvokeAction(funcAsync, arg1, arg2, arg3, arg4, arg5));
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public void InvokeFuncAsync_05_ExpectCallActionOnce()
        {
            var mockFuncAsync = MockActionFactory.CreateMockAction<StructType, RefType?, string, int, object?>();

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;
            var arg5 = new { Value = PlusTwoHundredPointFive };

            var actual = Unit.InvokeAction(mockFuncAsync.Object.Invoke, arg1, arg2, arg3, arg4, arg5);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5), Times.Once);
        }
    }
}
