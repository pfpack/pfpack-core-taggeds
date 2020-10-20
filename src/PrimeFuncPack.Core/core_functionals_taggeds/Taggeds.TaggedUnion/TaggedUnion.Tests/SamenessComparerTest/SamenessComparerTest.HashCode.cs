#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class SamenessComparerTest
    {
        [Test]
        public void GetHashCode_SourceAndOtherAreDefault_ExpectValuesAreEqual()
        {
            var source = default(TaggedUnion<RefType, StructType>);
            var other = new TaggedUnion<RefType?, StructType>();

            var sourceSamenessComparer = TaggedUnionSamenessComparer<RefType, StructType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<RefType?, StructType>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void GetSamenessHashCode_SourceAndOtherAreSame_ExpectValuesAreEqual(
            in TaggedUnion<RefType, StructType> source)
        {
            var other = source;

            var sourceSamenessComparer = TaggedUnionSamenessComparer<RefType, StructType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<RefType, StructType>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceFirstValueIsSameAsOtherFirstValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<object?, StructType?>.First(sourceValue);
            var other = TaggedUnion<object?, StructType?>.First(sourceValue);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<object?, StructType?>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<object?, StructType?>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceSecondValueIsSameAsOtherSecondValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<RefType, object?>.Second(sourceValue);
            var other = TaggedUnion<RefType, object?>.Second(sourceValue);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<RefType, object?>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<RefType, object?>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceIsDefaultAndOtherIsNotDefault_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            var other = TaggedUnion<StructType, RefType>.First(default);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<StructType, RefType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<StructType, RefType>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetHashCode_SourceFirstValueIsSameAsOtherSecondValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<object?, object?>.First(sourceValue);
            var other = TaggedUnion<object?, object?>.Second(sourceValue);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<object?, object?>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<object?, object?>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceFirstValueAreNotEqualOtherFirstValue_ExpectValuesAreNotEqual()
        {
            var text = SomeString;

            var source = TaggedUnion<object, RefType>.First(new { Text = text });
            var other = TaggedUnion<object, RefType>.First(new { Text = text });

            var sourceSamenessComparer = TaggedUnionSamenessComparer<object, RefType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<object, RefType>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSecondValueIsNotSameAsOtherSecondValue_ExpectValuesAreNotEqual()
        {
            var id = int.MinValue;
            var sourceValue = new RefType
            {
                Id = id
            };
            var source = TaggedUnion<StructType, RefType>.Second(sourceValue);

            var otherValue = new RefType
            {
                Id = id
            };
            var other = TaggedUnion<StructType, RefType>.Second(otherValue);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<StructType, RefType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<StructType, RefType>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceFirstValueIsSameAsOtherFirstButSecondTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var sourceValue = MinusFifteenIdRefType;

            var source = TaggedUnion<RefType, StructType>.First(sourceValue);
            var other = TaggedUnion<RefType, StructType?>.First(sourceValue);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<RefType, StructType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<RefType, StructType?>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceSecondValueIsSameAsOtherSecondButFirstTypesAreNotEquals_ExpectValuesAreNotEqual()
        {
            var sourceValue = SomeTextStructType;

            var source = TaggedUnion<int, StructType>.Second(sourceValue);
            var other = TaggedUnion<long, StructType>.Second(sourceValue);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<int, StructType>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<long, StructType>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetHashCode_SourceAndOtherAreDefaultButTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<RefType, DateTime>);
            var other = default(TaggedUnion<RefType, DateTime?>);

            var sourceSamenessComparer = TaggedUnionSamenessComparer<RefType, DateTime>.Default;
            var otherSamenessComparer = TaggedUnionSamenessComparer<RefType, DateTime?>.Default;

            var sourceHashCode = sourceSamenessComparer.GetHashCode(source);
            var otherHashCode = otherSamenessComparer.GetHashCode(other);

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}
