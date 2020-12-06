#nullable enable

using Moq;
using NUnit.Framework;
using PrimeFuncPack.UnitTest.Moq;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public void InvokeFuncAsync_00_ActionIsNull_ExpectArgumentNullException()
        {
            Func<Task<Unit>> funcAsync = null!;
            var ex = Assert.ThrowsAsync<ArgumentNullException>(() => _ = Unit.InvokeFuncAsync(funcAsync));

            Assert.AreEqual("funcAsync", ex.ParamName);
        }

        [Test]
        public async Task InvokeFuncAsync_00_ExpectCallActionOnce()
        {
            var mockFuncAsync = MockFuncFactory.CreateMockFunc(Task.FromResult<Unit>(default));
            var actual = await Unit.InvokeFuncAsync(mockFuncAsync.Object.Invoke);

            Assert.AreEqual(Unit.Value, actual);
            mockFuncAsync.Verify(a => a.Invoke(), Times.Once);
        }
    }
}
