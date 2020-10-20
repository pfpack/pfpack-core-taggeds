#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionStaticTest
    {
        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<StructType, RefType>);
            var unionB = new TaggedUnion<StructType, RefType>();

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
        public void Equals_UnionAFirstValueEqualsUnionBFirstValue_ExpectTrue(
            in object? sourceValue)
        {
            var unionA = TaggedUnion<object?, StructType>.First(sourceValue);
            var unionB = TaggedUnion<object?, StructType>.First(sourceValue);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_UnionASecondValueEqualsUnionBSecondValue_ExpectTrue()
        {
            var text = "some-text";

            var aValue = new StructType
            {
                Text = text
            };
            var unionA = TaggedUnion<RefType, StructType>.Second(aValue);

            var bValue = new StructType
            {
                Text = text
            };
            var unionB = (TaggedUnion<RefType, StructType>)bValue;

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = default(TaggedUnion<RefType?, StructType>);
            var unionB = TaggedUnion<RefType?, StructType>.First(null);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = default(TaggedUnion<object, StructType>);
            var unionB = TaggedUnion<object, StructType>.Second(default);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<RefType, StructType>);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, StructType>.First(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, RefType>.Second(ZeroIdRefType);
            var unionB = TaggedUnion<RefType, RefType>.First(ZeroIdRefType);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAFirstValueIsNotEqualUnionBFirstValue_ExpectFalse()
        {
            var id = MinusFifteen;

            var aValue = new RefType
            {
                Id = id
            };
            var unionA = TaggedUnion<RefType, StructType?>.First(aValue);

            var bValue = new RefType
            {
                Id = id
            };
            var unionB = TaggedUnion<RefType, StructType?>.First(bValue);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionASecondValueIsNotEqualUnionBSecondValue_ExpectFalse()
        {
            var aValue = new StructType
            {
                Text = SomeString
            };
            var unionA = TaggedUnion<RefType, StructType>.Second(aValue);

            var bValue = new StructType
            {
                Text = SomeString.ToLower()
            };
            var unionB = TaggedUnion<RefType, StructType>.Second(bValue);

            var actual = TaggedUnion.Equals(unionA, unionB);
            Assert.False(actual);
        }
    }
}
