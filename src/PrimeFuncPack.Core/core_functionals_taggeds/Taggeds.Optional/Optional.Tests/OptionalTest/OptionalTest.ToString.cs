#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Primitives.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void ToString_SourceIsAbsent_ExpectEmptyString()
        {
            var source = Optional<StubType>.Absent;

            var actual = source.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceIsPresentAndValueIsNull_ExpectEmptyString()
        {
            var source = Optional<StubType?>.Present(null);

            var actual = source.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToString_SourceIsPresentAndValueToStringIsNull_ExpectEmptyString()
        {
            var sourceValue = new StubType(null);
            var source = Optional<StubType>.Present(sourceValue);

            var actual = source.ToString();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(TabString)]
        [TestCase(ThreeWhiteSpacesString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsPresentAndValueToStringIsNotNull_ExpectSourceValueToStringResult(
            in string sourceValueToStringResult)
        {
            var sourceValue = new StubType(sourceValueToStringResult);
            var source = Optional<StubType>.Present(sourceValue);

            var actual = source.ToString();
            Assert.AreEqual(sourceValueToStringResult, actual);
        }
    }
}
