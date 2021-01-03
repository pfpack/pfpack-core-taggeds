#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void Inequality_UnionAIsDefaultAndUnionBIsFirst_ExpectTrue()
        {
            var unionA = TaggedUnion<RefType, StructType>.First(ZeroIdRefType);
            var unionB = default(TaggedUnion<RefType, StructType>);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionAIsDefaultAndUnionBIsSecond_ExpectTrue()
        {
            var unionA = default(TaggedUnion<RefType?, StructType?>);
            var unionB = TaggedUnion<RefType?, StructType?>.Second(null);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionAIsFirstAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = default(TaggedUnion<StructType, RefType>);
            var unionB = TaggedUnion<StructType, RefType>.First(default);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionAIsFirstAndUnionBIsSecond_ExpectTrue()
        {
            var unionA = TaggedUnion<StructType, StructType>.First(SomeTextStructType);
            var unionB = TaggedUnion<StructType, StructType>.Second(SomeTextStructType);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionAIsSecondAndUnionBIsDefault_ExpectTrue()
        {
            var unionA = TaggedUnion<RefType, StructType>.Second(SomeTextStructType);
            var unionB = default(TaggedUnion<RefType, StructType>);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionAIsSecondAndUnionBIsFirst_ExpectTrue()
        {
            var unionA = TaggedUnion<RefType?, RefType?>.Second(null);
            var unionB = TaggedUnion<RefType?, RefType?>.First(null);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionAFirstValueIsNotEqualUnionBFirstValue_ExpectTrue()
        {
            var aValue = new object();
            var unionA = TaggedUnion<object, StructType?>.First(aValue);

            var bValue = new object();
            var unionB = TaggedUnion<object, StructType?>.First(bValue);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void Inequality_UnionASecondValueIsNotEqualUnionBSecondValue_ExpectTrue()
        {
            var unionA = TaggedUnion<RefType, StructType?>.Second(null);
            var unionB = TaggedUnion<RefType, StructType?>.Second(SomeTextStructType);

            var actual = unionA != unionB;
            Assert.True(actual);
        }

        [Test]
        public void InInequality_UnionAIsDefaultAndUnionBIsDefault_ExpectFalse()
        {
            var unionA = new TaggedUnion<RefType, StructType>();
            var unionB = default(TaggedUnion<RefType, StructType>);

            var actual = unionA != unionB;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_UnionAFirstValueEqualsUnionBFirstValue_ExpectFalse()
        {
            var aValue = new StructType
            {
                Text = SomeString
            };
            var unionA = (TaggedUnion<StructType, RefType?>)aValue;

            var bValue = new StructType
            {
                Text = SomeString
            };
            var unionB = TaggedUnion<StructType, RefType?>.First(bValue);

            var actual = unionA != unionB;
            Assert.False(actual);
        }

        [Test]
        public void Inequality_UnionASecondValueEqualsUnionBSecondValue_ExpectFalse()
        {
            var unionA = (TaggedUnion<StructType?, RefType>)MinusFifteenIdRefType;
            var unionB = TaggedUnion<StructType?, RefType>.Second(MinusFifteenIdRefType);

            var actual = unionA != unionB;
            Assert.False(actual);
        }
    }
}