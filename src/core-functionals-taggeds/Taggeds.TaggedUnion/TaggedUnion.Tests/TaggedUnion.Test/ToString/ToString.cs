#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class TaggedUnionTest
    {
        [Test]
        public void ToString_SourceIsDefault_ExpectEmptyString()
        {
            var source = default(TaggedUnion<StructType, RefType>);
            var actual = source.ToString();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceIsFirstAndValueIsNull_ExpectEmptyString()
        {
            var source = TaggedUnion<object?, StructType>.First(null);
            var actual = source.ToString();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceIsFirstAndValueToStringReturnsNull_ExpectEmptyString()
        {
            var sourceValue = new StubToStringType(null);

            var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
            var actual = source.ToString();

            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsFirstAndValueToStringDoesNotReturnNull_ExpectResultOfValueToString(
            string resultOfValueToString)
        {
            var sourceValue = new StubToStringType(resultOfValueToString);

            var source = TaggedUnion<StubToStringType, RefType>.First(sourceValue);
            var actual = source.ToString();

            Assert.AreEqual(resultOfValueToString, actual);
        }

        [Test]
        public void ToString_SourceIsSecondAndValueIsNull_ExpectEmptyString()
        {
            var source = TaggedUnion<decimal, StructType?>.Second(null);
            var actual = source.ToString();

            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceIsSecondAndValueToStringReturnsNull_ExpectEmptyString()
        {
            var sourceValue = new StubToStringType(null);

            var source = TaggedUnion<string, StubToStringType>.Second(sourceValue);
            var actual = source.ToString();

            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsSecondAndValueToStringDoesNotReturnNull_ExpectResultOfValueToString(
            string resultOfValueToString)
        {
            var sourceValue = new StubToStringType(resultOfValueToString);

            var source = TaggedUnion<StructType, StubToStringType>.Second(sourceValue);
            var actual = source.ToString();

            Assert.AreEqual(resultOfValueToString, actual);
        }
    }
}
