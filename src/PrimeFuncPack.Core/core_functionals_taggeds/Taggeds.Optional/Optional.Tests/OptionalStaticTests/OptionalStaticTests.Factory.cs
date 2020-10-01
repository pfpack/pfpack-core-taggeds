#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class OptionalStaticTests
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Present_ExpectPresent(
            in object? sourceValue)
        {
            var actual = Optional.Present(sourceValue);
            var expected = Optional<object?>.Present(sourceValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Absent_ExpectAbsent()
        {
            var actual = Optional.Absent<string>();
            var expected = Optional<string>.Absent;

            Assert.AreEqual(expected, actual);
        }
    }
}
