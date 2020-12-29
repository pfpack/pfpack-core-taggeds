#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeFuncAsync_02_FuncIsNull_ExpectArgumentNullException()
        {
            Func<StructType, RefType, Task> funcAsync = null!;

            var arg1 = SomeTextStructType;
            var arg2 = PlusFifteenIdRefType;

            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeFuncAsync(funcAsync, arg1, arg2));
            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public async Task InvokeFuncAsync_02_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<StructType, RefType?, Task>(Task.CompletedTask);

            var arg1 = SomeTextStructType;
            var arg2 = (RefType?)null;

            var actual = await Unit.InvokeFuncAsync(mockFuncAsync.Object.Invoke, arg1, arg2);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(arg1, arg2), Times.Once);
        }
    }
}
