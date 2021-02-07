#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class UnitExtensionsInvoketValueAsyncTests
    {
        [Test]
        public void InvokeThenToUnitValueAsync_01_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, ValueTask> funcAsync = null!;
            var arg = SomeTextStructType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitValueAsync(arg).AsTask());

            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task InvokeThenToUnitValueAsync_01_ExpectCallFuncOnce(
            bool isArgNull)
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<RefType?, ValueTask>(default);
            var funcAsync = new Func<RefType?, ValueTask>(mockFuncAsync.Object.Invoke);

            var arg = isArgNull ? null : MinusFifteenIdRefType;
            var actual = await funcAsync.InvokeThenToUnitValueAsync(arg);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(arg), Times.Once);
        }
    }
}
