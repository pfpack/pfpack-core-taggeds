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
        public void EqualsWithObject_SourceIsDefaultAndObjectIsDefault_ExpectTrue()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            object? obj = new TaggedUnion<StructType, RefType>();

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceFirstValueEqualsObjectFirstValue_ExpectTrue()
        {
            var source = TaggedUnion<StructType?, RefType>.First(null);
            object? obj = TaggedUnion<StructType?, RefType>.First(null);

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceSecondValueEqualsObjectSecondValue_ExpectTrue()
        {
            var source = TaggedUnion<StructType, RefType>.Second(MinusFifteenIdRefType);
            object? obj = (TaggedUnion<StructType, RefType>)MinusFifteenIdRefType;

            var actual = source.Equals(obj);
            Assert.True(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsDefaultAndObjectIsFirst_ExpectFalse()
        {
            var source = default(TaggedUnion<RefType?, StructType>);
            object? obj = TaggedUnion<RefType?, StructType>.First(null);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsDefaultAndObjectIsSecond_ExpectFalse()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            object? obj = TaggedUnion<StructType, RefType>.Second(PlusFifteenIdRefType);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsFirstAndObjectIsDefault_ExpectFalse()
        {
            var source = TaggedUnion<RefType, StructType>.First(ZeroIdRefType);
            object? obj = default(TaggedUnion<RefType, StructType>);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsFirstAndObjectIsSecond_ExpectFalse()
        {
            var source = TaggedUnion<RefType?, RefType?>.First(null);
            object? obj = TaggedUnion<RefType?, RefType?>.Second(null);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsSecondAndObjectIsDefault_ExpectFalse()
        {
            var source = TaggedUnion<StructType, RefType>.Second(ZeroIdRefType);
            object? obj = default(TaggedUnion<StructType, RefType>);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceIsSecondAndObjectIsFirst_ExpectFalse()
        {
            var source = TaggedUnion<StructType, StructType>.Second(default);
            object? obj = TaggedUnion<StructType, StructType>.First(default);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceFirstValueIsNotEqualObjectFirstValue_ExpectFalse()
        {
            var id = Zero;

            var sourceValue = new RefType
            {
                Id = id
            };
            var source = TaggedUnion<RefType?, StructType?>.First(sourceValue);

            var objValue = new RefType
            {
                Id = id
            };
            object? obj = TaggedUnion<RefType?, StructType?>.First(objValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_SourceSecondValueIsNotEqualObjectSecondValue_ExpectFalse()
        {
            var sourceValue = new StructType
            {
                Text = SomeString
            };

            var source = TaggedUnion<RefType, StructType?>.Second(sourceValue);
            object? obj = TaggedUnion<RefType, StructType?>.Second(null);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_ObjectIsOtherTaggedUnion_ExpectFalse()
        {
            var sourceValue = new StructType
            {
                Text = SomeString
            };

            var source = TaggedUnion<RefType, StructType?>.Second(sourceValue);
            object? obj = TaggedUnion<RefType, StructType>.Second(sourceValue);

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_ObjectIsNotTaggedUnion_ExpectFalse()
        {
            var sourceValue = PlusFifteenIdRefType;

            var source = TaggedUnion<RefType, StructType?>.First(sourceValue);
            object? obj = sourceValue;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }

        [Test]
        public void EqualsWithObject_ObjectIsNull_ExpectFalse()
        {
            var sourceValue = PlusFifteenIdRefType;

            var source = TaggedUnion<RefType, StructType?>.First(sourceValue);
            object? obj = null;

            var actual = source.Equals(obj);
            Assert.False(actual);
        }
    }
}