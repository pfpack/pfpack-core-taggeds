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
        public void InvokeThenToUnitValueAsync_06_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, RefType, string, int, object, DateTime, ValueTask> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;
            var arg5 = new { Value = PlusTwoHundredPointFive };
            var arg6 = Year2015March11H01Min15;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = funcAsync.InvokeThenToUnitValueAsync(arg1, arg2, arg3, arg4, arg5, arg6).AsTask());
            Assert.AreEqual("funcAsync", ex!.ParamName);
        }

        [Test]
        public async Task InvokeThenToUnitValueAsync_06_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, string, int, object?, DateTime, ValueTask>(default);
            var funcAsync = new Func<StructType, RefType?, string, int, object?, DateTime, ValueTask>(mockFuncAsync.Object.Invoke);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;
            var arg3 = TabString;
            var arg4 = MinusFortyFive;
            var arg5 = new { Value = PlusTwoHundredPointFive };
            var arg6 = Year2015March11H01Min15;

            var actual = await funcAsync.InvokeThenToUnitValueAsync(arg1, arg2, arg3, arg4, arg5, arg6);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(arg1, arg2, arg3, arg4, arg5, arg6), Times.Once);
        }
    }
}
