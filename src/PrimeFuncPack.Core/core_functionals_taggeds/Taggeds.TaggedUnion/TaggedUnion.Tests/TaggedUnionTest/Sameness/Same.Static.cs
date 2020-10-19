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
        public void SameStatic_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<StructType, RefType?>);
            var unionB = new TaggedUnion<StructType, RefType?>();

            var actual = TaggedUnion<StructType, RefType?>.Same(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void SameStatic_UnionAIsUnionAreSameAsSource_ExpectTrue(
            in TaggedUnion<RefType, StructType> source)
        {
            var unionA = source;
            var unionB = source;

            var actual = TaggedUnion<RefType, StructType>.Same(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void SameStatic_UnionAFirstValueSameUnionBFirstValue_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType?, RefType>.First(null);
            var unionB = TaggedUnion<StructType?, RefType>.First(null);

            var actual = TaggedUnion<StructType?, RefType>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionASecondValueSameUnionBSecondValue_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType?>.Second(MinusFifteenIdRefType);
            var unionB = TaggedUnion<StructType, RefType?>.Second(MinusFifteenIdRefType);

            var actual = TaggedUnion<StructType, RefType?>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = default(TaggedUnion<RefType?, StructType>);
            var unionB = TaggedUnion<RefType?, StructType>.First(null);

            var actual = TaggedUnion<RefType?, StructType>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = default(TaggedUnion<object, StructType>);
            var unionB = TaggedUnion<object, StructType>.Second(default);

            var actual = TaggedUnion<object, StructType>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.First(SomeTextStructType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var actual = TaggedUnion<StructType, RefType>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, RefType>.First(PlusFifteenIdRefType);
            var unionB = TaggedUnion<RefType, RefType>.Second(PlusFifteenIdRefType);

            var actual = TaggedUnion<RefType, RefType>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var actual = TaggedUnion<StructType, RefType>.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void SameStatic_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.First(SomeTextStructType);

            var actual = TaggedUnion<StructType, StructType>.Same(unionA, unionB);
            Assert.False(actual);
        }
    }
}