
#nullable enable

using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class UnitTests
    {
        [Test]
        public async Task ThisAsync_ExpectSourceValue()
        {
            var source = Unit.Value;
            var actual = await source.ThisAsync();

            Assert.AreEqual(source, actual);
        }

        [Test]
        public void ThisValueAsync_ExpectValueTaskFromSourceValue()
        {
            var source = Unit.Value;
            var actualValueTask = source.ThisValueAsync();

            var expectedValueTask = new ValueTask<Unit>(source);
            Assert.AreEqual(expectedValueTask, actualValueTask);
        }
    }
}
