#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class TaggedUnionStaticTest
    {
        [Test]
        public void Same_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<RefType, StructType?>);
            var unionB = new TaggedUnion<RefType, StructType?>();

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void Same_UnionAIsUnionAreSameAsSource_ExpectTrue(
            in TaggedUnion<RefType, StructType> source)
        {
            var unionA = source;
            var unionB = source;

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void Same_UnionAFirstValueSameUnionBFirstValue_ExpectFalse()
        {
            var sourceValue = ZeroIdRefType;

            var unionA = TaggedUnion<RefType, object>.First(sourceValue);
            var unionB = TaggedUnion<RefType, object>.First(sourceValue);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionASecondValueSameUnionBSecondValue_ExpectFalse()
        {
            var sourceValue = SomeTextStructType;

            var unionA = TaggedUnion<RefType?, StructType>.Second(sourceValue);
            var unionB = TaggedUnion<RefType?, StructType>.Second(sourceValue);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, RefType>);
            var unionB = TaggedUnion<StructType, RefType>.First(default);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, object?>);
            var unionB = TaggedUnion<StructType, object?>.Second(null);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, StructType>.First(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<RefType, StructType>);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, RefType>.First(PlusFifteenIdRefType);
            var unionB = TaggedUnion<RefType, RefType>.Second(PlusFifteenIdRefType);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);
            var unionB = default(TaggedUnion<StructType, RefType>);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Same_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.First(SomeTextStructType);

            var actual = TaggedUnion.Same(unionA, unionB);
            Assert.False(actual);
        }
    }
}
