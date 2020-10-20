#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void GetSamenessHashCode_SourceAndOtherAreDefault_ExpectValuesAreEqual()
        {
            var source = default(TaggedUnion<RefType, StructType>);
            var other = new TaggedUnion<RefType?, StructType>();

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void GetSamenessHashCode_SourceAndOtherAreSame_ExpectValuesAreEqual(
            in TaggedUnion<RefType, StructType> source)
        {
            var other = source;

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetSamenessHashCode_SourceFirstValueIsSameAsOtherFirstValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<object?, RefType>.First(sourceValue);
            var other = TaggedUnion<object?, RefType>.First(sourceValue);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetSamenessHashCode_SourceSecondValueIsSameAsOtherSecondValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<StructType?, object?>.Second(sourceValue);
            var other = TaggedUnion<StructType?, object?>.Second(sourceValue);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceIsDefaultAndOtherIsNotDefault_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            var other = TaggedUnion<StructType, RefType>.First(default);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void GetSamenessHashCode_SourceFirstValueIsSameAsOtherSecondValue_ExpectValuesAreNotEqual(
            in object? sourceValue)
        {
            var source = TaggedUnion<object?, object?>.First(sourceValue);
            var other = TaggedUnion<object?, object?>.Second(sourceValue);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceFirstValueAreNotEqualOtherFirstValue_ExpectValuesAreNotEqual()
        {
            var source = TaggedUnion<object, RefType>.First(new object());
            var other = TaggedUnion<object, RefType>.First(new object());

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceSecondValueIsNotSameAsOtherSecondValue_ExpectValuesAreNotEqual()
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

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceFirstValueIsSameAsOtherFirstButSecondTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var sourceValue = MinusFifteenIdRefType;

            var source = TaggedUnion<RefType?, StructType>.First(sourceValue);
            var other = TaggedUnion<RefType?, StructType?>.First(sourceValue);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceSecondValueIsSameAsOtherSecondButFirstTypesAreNotEquals_ExpectValuesAreNotEqual()
        {
            var sourceValue = SomeTextStructType;

            var source = TaggedUnion<int, StructType>.Second(sourceValue);
            var other = TaggedUnion<long, StructType>.Second(sourceValue);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }

        [Test]
        public void GetSamenessHashCode_SourceAndOtherAreDefaultButTypesAreNotEqual_ExpectValuesAreNotEqual()
        {
            var source = default(TaggedUnion<RefType, StructType>);
            var other = default(TaggedUnion<RefType, StructType?>);

            var sourceHashCode = source.GetSamenessHashCode();
            var otherHashCode = other.GetSamenessHashCode();

            Assert.AreNotEqual(sourceHashCode, otherHashCode);
        }
    }
}