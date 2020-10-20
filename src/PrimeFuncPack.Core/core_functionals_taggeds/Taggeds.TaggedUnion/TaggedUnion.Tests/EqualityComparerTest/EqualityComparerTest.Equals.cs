#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class EqualityComparerTest
    {
        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<StructType, RefType>);
            var unionB = new TaggedUnion<StructType, RefType>();

            var equalityComparer = TaggedUnionEqualityComparer<StructType, RefType>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Equals_UnionAFirstValueEqualsUnionBFirstValue_ExpectTrue(
            in object? sourceValue)
        {
            var unionA = TaggedUnion<object?, RefType>.First(sourceValue);
            var unionB = TaggedUnion<object?, RefType>.First(sourceValue);

            var equalityComparer = TaggedUnionEqualityComparer<object?, RefType>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_UnionASecondValueEqualsUnionBSecondValue_ExpectTrue()
        {
            var text = SomeString.ToUpper();

            var aValue = new StructType
            {
                Text = text
            };
            var unionA = TaggedUnion<object, StructType>.Second(aValue);

            var bValue = new StructType
            {
                Text = text
            };
            var unionB = (TaggedUnion<object, StructType>)bValue;

            var equalityComparer = TaggedUnionEqualityComparer<object, StructType>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, object>);
            var unionB = TaggedUnion<StructType, object>.First(default);

            var equalityComparer = TaggedUnionEqualityComparer<StructType, object>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = default(TaggedUnion<int, RefType?>);
            var unionB = TaggedUnion<int, RefType?>.Second(null);

            var equalityComparer = TaggedUnionEqualityComparer<int, RefType?>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<RefType, StructType>);

            var equalityComparer = TaggedUnionEqualityComparer<RefType, StructType>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, StructType>.First(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);

            var equalityComparer = TaggedUnionEqualityComparer<StructType, StructType>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.Second(MinusFifteenIdRefType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var equalityComparer = TaggedUnionEqualityComparer<StructType, RefType>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
        {
            var sourceValue = new object();

            var unionA = TaggedUnion<object, object>.Second(sourceValue);
            var unionB = TaggedUnion<object, object>.First(sourceValue);

            var equalityComparer = TaggedUnionEqualityComparer<object, object>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAFirstValueIsNotEqualUnionBFirstValue_ExpectFalse()
        {
            var unionA = TaggedUnion<object, StructType?>.First(new object());
            var unionB = TaggedUnion<object, StructType?>.First(new object());

            var equalityComparer = TaggedUnionEqualityComparer<object, StructType?>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionASecondValueIsNotEqualUnionBSecondValue_ExpectFalse()
        {
            var aValue = new DateTime(2017, 05, 15);
            var unionA = TaggedUnion<RefType, DateTime>.Second(aValue);

            var bValue = aValue.AddDays(1);
            var unionB = TaggedUnion<RefType, DateTime>.Second(bValue);

            var equalityComparer = TaggedUnionEqualityComparer<RefType, DateTime>.Default;

            var actual = equalityComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }
    }
}
