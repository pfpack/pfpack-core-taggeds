#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Functionals.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeFuncValueAsync_00_FuncIsNull_ExpectArgumentNullException()
        {
            Func<ValueTask> funcAsync = null!;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeFuncValueAsync(funcAsync).AsTask());

            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public async Task InvokeFuncValueAsync_00_ExpectCallFuncOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc<ValueTask>(default);
            var actual = await Unit.InvokeFuncValueAsync(mockFuncAsync.Object.Invoke);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(f => f.Invoke(), Times.Once);
        }
    }
}
