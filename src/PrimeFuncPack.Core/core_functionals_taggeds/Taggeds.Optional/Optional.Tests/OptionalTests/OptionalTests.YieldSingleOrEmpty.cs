#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Linq;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class OptionalTests
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void YieldSingleOrEmpty_SourceIsPresent_ExpectSingleValue(
            in object? sourceValue)
        {
            var source = Optional<object?>.Present(sourceValue);
            var actual = source.YieldSingleOrEmpty();

            Assert.AreEqual(1, actual.Count());
            var actualValue = actual.Single();

            Assert.AreEqual(sourceValue, actualValue);
        }

        [Test]
        public void YieldSingleOrEmpty_SourceIsAbsent_ExpectEmpty()
        {
            var source = Optional<RefType>.Absent;
            var actual = source.YieldSingleOrEmpty();

            Assert.IsEmpty(actual);
        }
    }
}
