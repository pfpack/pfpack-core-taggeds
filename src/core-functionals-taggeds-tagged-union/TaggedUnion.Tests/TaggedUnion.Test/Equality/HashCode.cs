#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void GetHashCode_SourceAndOtherAreDefault_ExpectValuesAreEqual()
        {
            var source = default(TaggedUnion<RefType, StructType>);
            var other = new TaggedUnion<RefType?, StructType>();

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceFirstValueIsSameAsOtherFirstValue_ExpectValuesAreEqual(
            object? sourceValue)
        {
            var source = TaggedUnion<object?, StructType>.First(sourceValue);
            var other = TaggedUnion<object?, StructType>.First(sourceValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceSecondValueIsSameAsOtherSecondValue_ExpectValuesAreEqual(
            object? sourceValue)
        {
            var source = TaggedUnion<RefType?, object?>.Second(sourceValue);
            var other = TaggedUnion<RefType?, object>.Second(sourceValue!);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsNotDefault_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<RefType?, StructType>);
            var other = TaggedUnion<RefType?, StructType>.First(null);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceFirstValueIsSameAsOtherSecondValue_ExpectValuesAreNotEqual(
            object? sourceValue)
        {
            var source = TaggedUnion<object?, object?>.First(sourceValue);
            var other = TaggedUnion<object?, object?>.Second(sourceValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceFirstValueAreNotEqualOtherFirstValue_ExpectValuesAreNotEqual()
        {
            var source = TaggedUnion<object, StructType>.First(new object());
            var other = TaggedUnion<object, StructType>.First(new object());

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

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
            var source = TaggedUnion<StructType?, RefType>.Second(sourceValue);

            var otherValue = new RefType
            {
                Id = id
            };
            var other = TaggedUnion<StructType?, RefType>.Second(otherValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceFirstValueIsSameAsOtherFirstButSecondTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var sourceValue = MinusFifteenIdRefType;

            var source = TaggedUnion<RefType?, StructType>.First(sourceValue);
            var other = TaggedUnion<RefType?, StructType?>.First(sourceValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSecondValueIsSameAsOtherSecondButFirstTypesAreNotEquals_ExpectValuesAreNotEqual()
        {
            var sourceValue = SomeTextStructType;

            var source = TaggedUnion<int, StructType>.Second(sourceValue);
            var other = TaggedUnion<long, StructType>.Second(sourceValue);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceAndOtherAreDefaultButTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<RefType, StructType>);
            var other = default(TaggedUnion<RefType, StructType?>);

            var sourceHashCode = source.GetHashCode();
            var otherHashCode = other.GetHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
