#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalTaggedUnionExtensionsTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void ToTaggedUnion_OptionalIsPresent_ExpectActualIsFirst(
            object? sourceValue)
        {
            var optional = Optional.Present(sourceValue);
            var actual = optional.ToTaggedUnion();

            var expected = TaggedUnion<object?, Unit>.First(sourceValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToTaggedUnion_OptionalIsAbsent_ExpectActualIsSecond()
        {
            var optional = Optional.Absent<RefType>();
            var actual = optional.ToTaggedUnion();

            var expected = TaggedUnion<RefType, Unit>.Second(Unit.Value);
            Assert.AreEqual(expected, actual);
        }
    }
}
