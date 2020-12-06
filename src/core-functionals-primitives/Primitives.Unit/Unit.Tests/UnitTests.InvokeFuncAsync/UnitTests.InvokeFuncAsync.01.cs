#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeFuncAsync_01_ActionIsNull_ExpectArgumentNullException()
        {
            Func<StructType, Task<Unit>> funcAsync = null!;
            var arg = SomeTextStructType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeFuncAsync(funcAsync, arg));

            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void InvokeFuncAsync_01_ExpectCallActionOnce(
            in bool isArgNull)
        {
            var mockFuncAsync = MockActionFactory.CreateMockAction<RefType?>();

            var arg = isArgNull ? null : MinusFifteenIdRefType;
            var actual = Unit.InvokeAction(mockFuncAsync.Object.Invoke, arg);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(arg), Times.Once);
        }
    }
}
