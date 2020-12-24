#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionExtensionsTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void ToOptional_UnionIsFirst_ExpectPresent(
            object? sourceValue)
        {
            var union = TaggedUnion<object?, Unit>.First(sourceValue);
            var actual = union.ToOptional();

            var expected = Optional.Present(sourceValue);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToOptional_UnionIsDefault_ExpectAbsent()
        {
            var union = default(TaggedUnion<StructType, Unit>);
            var actual = union.ToOptional();

            var expected = Optional.Absent<StructType>();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToOptional_UnionIsSecond_ExpectAbsent()
        {
            var union = TaggedUnion<RefType, Unit>.Second(Unit.Value);
            var actual = union.ToOptional();

            var expected = Optional.Absent<RefType>();
            Assert.AreEqual(expected, actual);
        }
    }
}
