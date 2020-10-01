#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class OptionalTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ThisAsync_ExpectSourceValue(
            bool isPresent)
        {
            var source = isPresent ? Optional<StructType>.Present(SomeTextStructType) : Optional<StructType>.Absent;

            var actual = await source.ThisAsync();
            Assert.AreEqual(source, actual);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ThisValueAsync_ExpectValueTaskWithSourceValue(
            bool isPresent)
        {
            var source = isPresent ? Optional<RefType>.Present(ZeroIdRefType) : Optional<RefType>.Absent;
            var actual = source.ThisValueAsync();

            var expected = ValueTask.FromResult(source);
            Assert.AreEqual(expected, actual);
        }
    }
}
