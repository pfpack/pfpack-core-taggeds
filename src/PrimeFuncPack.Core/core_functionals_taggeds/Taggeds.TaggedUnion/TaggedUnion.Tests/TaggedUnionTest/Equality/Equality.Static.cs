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
        public void EqualsStatic_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<RefType, StructType>);
            var unionB = new TaggedUnion<RefType, StructType>();

            var actual = TaggedUnion<RefType, StructType>.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_UnionAFirstValueEqualsUnionBFirstValue_ExpectTrue()
        {
            var aValue = new StructType
            {
                Text = SomeString
            };
            var unionA = TaggedUnion<StructType, RefType?>.First(aValue);

            var bValue = new StructType
            {
                Text = SomeString
            };
            var unionB = (TaggedUnion<StructType, RefType?>)bValue;

            var actual = TaggedUnion<StructType, RefType?>.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_UnionASecondValueEqualsUnionBSecondValue_ExpectTrue()
        {
            var unionA = TaggedUnion<StructType, RefType?>.Second(MinusFifteenIdRefType);
            var unionB = (TaggedUnion<StructType, RefType?>)MinusFifteenIdRefType;

            var actual = TaggedUnion<StructType, RefType?>.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void EqualsStatic_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, RefType>);
            var unionB = TaggedUnion<StructType, RefType>.First(default);

            var actual = TaggedUnion<StructType, RefType>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, RefType?>);
            var unionB = TaggedUnion<StructType, RefType?>.Second(null);

            var actual = TaggedUnion<StructType, RefType?>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.First(SomeTextStructType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var actual = TaggedUnion<StructType, RefType>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, RefType>.First(PlusFifteenIdRefType);
            var unionB = TaggedUnion<RefType, RefType>.Second(PlusFifteenIdRefType);

            var actual = TaggedUnion<RefType, RefType>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var actual = TaggedUnion<StructType, RefType>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.First(SomeTextStructType);

            var actual = TaggedUnion<StructType, StructType>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionAFirstValueIsNotEqualUnionBFirstValue_ExpectFalse()
        {
            var id = PlusFifteen;

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

            var actual = TaggedUnion<RefType, StructType?>.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void EqualsStatic_UnionASecondValueIsNotEqualUnionBSecondValue_ExpectFalse()
        {
            var aValue = new StructType
            {
                Text = SomeString
            };
            var unionA = TaggedUnion<RefType, StructType>.Second(aValue);

            var bValue = new StructType
            {
                Text = EmptyString
            };
            var unionB = TaggedUnion<RefType, StructType>.Second(bValue);

            var actual = TaggedUnion<RefType, StructType>.Equals(unionA, unionB);
            Assert.False(actual);
        }
    }
}