#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class EqualityComparerTest
    {
        [Test]
        public void GetHashCode_SourceAndOtherAreDefault_ExpectValuesAreEqual()
        {
            var source = default(TaggedUnion<object?, StructType>);
            var other = new TaggedUnion<object, StructType>();

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<object?, StructType>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<object, StructType>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceFirstValueIsSameAsOtherFirstValue_ExpectValuesAreEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<object?, RefType>.First(sourceValue);
            var other = TaggedUnion<object?, RefType>.First(sourceValue);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<object?, RefType>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<object?, RefType>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceSecondValueIsSameAsOtherSecondValue_ExpectValuesAreEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<StructType, object>.Second(sourceValue!);
            var other = TaggedUnion<StructType, object?>.Second(sourceValue);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<StructType, object>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<StructType, object?>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsNotDefault_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<object?, StructType>);
            var other = TaggedUnion<object?, StructType>.First(null);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<object?, StructType>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<object?, StructType>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceFirstValueIsSameAsOtherSecondValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<object?, object?>.First(sourceValue);
            var other = TaggedUnion<object?, object?>.Second(sourceValue);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<object?, object?>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<object?, object?>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceFirstValueAreNotEqualOtherFirstValue_ExpectValuesAreNotEqual()
        {
            var source = TaggedUnion<object, RefType>.First(new object());
            var other = TaggedUnion<object, RefType>.First(new object());

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<object, RefType>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<object, RefType>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSecondValueIsNotSameAsOtherSecondValue_ExpectValuesAreNotEqual()
        {
            var id = PlusFifteen;
            var sourceValue = new RefType
            {
                Id = id
            };
            var source = TaggedUnion<StructType, RefType?>.Second(sourceValue);

            var otherValue = new RefType
            {
                Id = id
            };
            var other = TaggedUnion<StructType, RefType?>.Second(otherValue);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<StructType, RefType?>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<StructType, RefType?>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceFirstValueIsSameAsOtherFirstButSecondTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var sourceValue = MinusFifteenIdRefType;

            var source = TaggedUnion<RefType?, StructType>.First(sourceValue);
            var other = TaggedUnion<RefType?, StructType?>.First(sourceValue);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<RefType?, StructType>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<RefType?, StructType?>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSecondValueIsSameAsOtherSecondButFirstTypesAreNotEquals_ExpectValuesAreNotEqual()
        {
            var sourceValue = SomeTextStructType;

            var source = TaggedUnion<int, StructType>.Second(sourceValue);
            var other = TaggedUnion<int?, StructType>.Second(sourceValue);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<int, StructType>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<int?, StructType>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceAndOtherAreDefaultButTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<RefType, StructType?>);
            var other = default(TaggedUnion<RefType, StructType>);

            var sourceEqualityComparer = new TaggedUnionEqualityComparer<RefType, StructType?>();
            var otherEqualityComparer = new TaggedUnionEqualityComparer<RefType, StructType>();

            var sourceHashCode = sourceEqualityComparer.GetHashCode(source);
            var otherHashCode = otherEqualityComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
