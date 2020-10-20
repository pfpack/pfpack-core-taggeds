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
        public void Equals_UnionAIsDefaultAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<object, StructType?>);
            var unionB = new TaggedUnion<object, StructType?>();

            var samenessComparer = new TaggedUnionSamenessComparer<object, StructType?>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void Equals_UnionAIsUnionAreSameAsSource_ExpectTrue(
            in TaggedUnion<RefType, StructType> source)
        {
            var unionA = source;
            var unionB = source;

            var samenessComparer = new TaggedUnionSamenessComparer<RefType, StructType>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.True(actual);
        }

        [Test]
        public void Equals_UnionAFirstValueSameUnionBFirstValue_ExpectFalse()
        {
            var sourceValue = new { Id = PlusFifteen };

            var unionA = TaggedUnion<object, StructType>.First(sourceValue);
            var unionB = TaggedUnion<object, StructType>.First(sourceValue);

            var samenessComparer = new TaggedUnionSamenessComparer<object, StructType>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionASecondValueSameUnionBSecondValue_ExpectFalse()
        {
            var sourceValue = default(StructType);

            var unionA = TaggedUnion<RefType?, StructType>.Second(sourceValue);
            var unionB = TaggedUnion<RefType?, StructType>.Second(sourceValue);

            var samenessComparer = new TaggedUnionSamenessComparer<RefType?, StructType>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, RefType>);
            var unionB = TaggedUnion<StructType, RefType>.First(default);

            var samenessComparer = new TaggedUnionSamenessComparer<StructType, RefType>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsDefaultAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = default(TaggedUnion<StructType, object?>);
            var unionB = TaggedUnion<StructType, object?>.Second(new object());

            var samenessComparer = new TaggedUnionSamenessComparer<StructType, object?>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsFirstAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType, StructType>.First(null!);
            var unionB = default(TaggedUnion<RefType, StructType>);

            var samenessComparer = new TaggedUnionSamenessComparer<RefType, StructType>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsFirstAndUnionBIsSecond_ExpectFalse()
        {
            var unionA = TaggedUnion<RefType?, RefType?>.First(MinusFifteenIdRefType);
            var unionB = TaggedUnion<RefType?, RefType?>.Second(MinusFifteenIdRefType);

            var samenessComparer = new TaggedUnionSamenessComparer<RefType?, RefType?>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsSecondAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, RefType?>.Second(null);
            var unionB = default(TaggedUnion<StructType, RefType?>);

            var samenessComparer = new TaggedUnionSamenessComparer<StructType, RefType?>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }

        [Test]
        public void Equals_UnionAIsSecondAndUnionBIsFirst_ExpectFalse()
        {
            var unionA = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.First(SomeTextStructType);

            var samenessComparer = new TaggedUnionSamenessComparer<StructType, StructType>();

            var actual = samenessComparer.Equals(unionA, unionB);
            Assert.False(actual);
        }
    }
}
