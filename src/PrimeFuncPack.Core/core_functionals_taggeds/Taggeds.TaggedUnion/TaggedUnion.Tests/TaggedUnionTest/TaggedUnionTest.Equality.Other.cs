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
        public void EqualsWithOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            var other = new TaggedUnion<StructType, RefType>();

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceFirstValueEqualsOtherFirstValue_ExpectTrue()
        {
            var source = TaggedUnion<StructType?, RefType>.First(null);
            var other = TaggedUnion<StructType?, RefType>.First(null);

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceSecondValueEqualsOtherSecondValue_ExpectTrue()
        {
            var source = TaggedUnion<StructType, RefType>.Second(MinusFifteenIdRefType);
            var other = (TaggedUnion<StructType, RefType>)MinusFifteenIdRefType;

            var actual = source.Equals(other);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsDefaultAndOtherIsFirst_ExpectFalse()
        {
            var source = default(TaggedUnion<RefType?, StructType>);
            var other = TaggedUnion<RefType?, StructType>.First(null);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsDefaultAndOtherIsSecond_ExpectFalse()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            var other = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsFirstAndOtherIsDefault_ExpectFalse()
        {
            var source = TaggedUnion<RefType, StructType>.First(ZeroIdRefType);
            var other = default(TaggedUnion<RefType, StructType>);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsFirstAndOtherIsSecond_ExpectFalse()
        {
            var source = TaggedUnion<RefType?, RefType?>.First(null);
            var other = TaggedUnion<RefType?, RefType?>.Second(null);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsSecondAndOtherIsDefault_ExpectFalse()
        {
            var source = TaggedUnion<StructType, RefType>.Second(ZeroIdRefType);
            var other = default(TaggedUnion<StructType, RefType>);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceIsSecondAndOtherIsFirst_ExpectFalse()
        {
            var source = TaggedUnion<StructType, StructType>.Second(default);
            var other = TaggedUnion<StructType, StructType>.First(default);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceFirstValueDoesNotEqualOtherFirstValue_ExpectFalse()
        {
            var id = Zero;

            var sourceValue = new RefType
            {
                Id = id
            };
            var source = TaggedUnion<RefType?, StructType?>.First(sourceValue);

            var otherValue = new RefType
            {
                Id = id
            };
            var other = TaggedUnion<RefType?, StructType?>.First(otherValue);

            var actual = source.Equals(other);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithOther_SourceSecondValueDoesNotEqualOtherSecondValue_ExpectFalse()
        {
            var sourceValue = new StructType
            {
                Text = SomeString
            };

            var source = TaggedUnion<RefType, StructType?>.Second(sourceValue);
            var other = TaggedUnion<RefType, StructType?>.Second(null);

            var actual = source.Equals(other);
            Assert.False(actual);
        }
    }
}