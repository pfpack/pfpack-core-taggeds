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
        public void Same_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = default(TaggedUnion<StructType, object>);
            var other = new TaggedUnion<StructType, object>();

            var actual = source.Same(other);
            Assert.True(actual);
        }

        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.TaggedUnionTestSource))]
        public void Same_SourceAndOtherAreSame_ExpectTrue(
            in TaggedUnion<RefType, StructType> source)
        {
            var other = source;

            var actual = source.Same(other);
            Assert.True(actual);
        }

        [Test]
        public void Same_SourceFirstValueSameAsOtherFirstValue_ExpectFalse()
        {
            var sourceValue = new object();

            var source = TaggedUnion<object, RefType>.First(sourceValue);
            var other = TaggedUnion<object, RefType>.First(sourceValue);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceSecondValueIsSameAsOtherSecondValue_ExpectFalse()
        {
            var sourceValue = PlusFifteen;

            var source = TaggedUnion<RefType, int>.Second(sourceValue);
            var other = TaggedUnion<RefType, int>.Second(sourceValue);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceIsDefaultAndOtherIsFirst_ExpectFalse()
        {
            var source = default(TaggedUnion<decimal, object>);
            var other = TaggedUnion<decimal, object>.First(default);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceIsDefaultAndOtherIsSecond_ExpectFalse()
        {
            var source = default(TaggedUnion<byte, RefType>);
            var other = TaggedUnion<byte, RefType>.Second(null!);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceIsFirstAndOtherIsDefault_ExpectFalse()
        {
            var source = TaggedUnion<StructType, RefType>.First(default);
            var other = default(TaggedUnion<StructType, RefType>);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceIsFirstAndOtherIsSecond_ExpectFalse()
        {
            var source = TaggedUnion<RefType, RefType>.First(ZeroIdRefType);
            var other = TaggedUnion<RefType, RefType>.Second(ZeroIdRefType);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceIsSecondAndOtherIsDefault_ExpectFalse()
        {
            var source = TaggedUnion<StructType, RefType>.Second(MinusFifteenIdRefType);
            var other = default(TaggedUnion<StructType, RefType>);

            var actual = source.Same(other);
            Assert.False(actual);
        }

        [Test]
        public void Same_SourceIsSecondAndOtherIsFirst_ExpectFalse()
        {
            var source = TaggedUnion<StructType, StructType>.Second(default);
            var other = TaggedUnion<StructType, StructType>.First(default);

            var actual = source.Same(other);
            Assert.False(actual);
        }
    }
}