using NUnit.Framework;
using System;
using System.Globalization;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void ToString_SourceIsAbsent_ExpectAbsentString()
        {
            var source = Optional<StubType>.Absent;

            var actual = source.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "Optional.Absent[{0}]:()",
                typeof(StubType));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_SourceIsPresentAndValueIsNull_ExpectPresentEmptyString()
        {
            var source = Optional<StubType?>.Present(null);

            var actual = source.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "Optional.Present[{0}]:{1}",
                typeof(StubType),
                string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_SourceIsPresentAndValueToStringIsNull_ExpectPresentEmptyString()
        {
            var sourceValue = new StubType(null);
            var source = Optional<StubType>.Present(sourceValue);

            var actual = source.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "Optional.Present[{0}]:{1}",
                typeof(StubType),
                string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(TabString)]
        [TestCase(TwoTabsString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TwoWhiteSpacesString)]
        [TestCase(ThreeWhiteSpacesString)]
        [TestCase(MixedWhiteSpacesString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsPresentAndValueToStringIsNotNull_ExpectSourceValueToStringResult(
            string sourceValueToStringResult)
        {
            var sourceValue = new StubType(sourceValueToStringResult);
            var source = Optional<StubType>.Present(sourceValue);

            var actual = source.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "Optional.Present[{0}]:{1}",
                typeof(StubType),
                sourceValueToStringResult);

            Assert.AreEqual(expected, actual);
        }

        // TODO: Add test case source including decimal with point
        [Test]
        [TestCase(null)]
        [TestCase(EmptyString)]
        [TestCase(TabString)]
        [TestCase(TwoTabsString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TwoWhiteSpacesString)]
        [TestCase(ThreeWhiteSpacesString)]
        [TestCase(MixedWhiteSpacesString)]
        [TestCase(SomeString)]
        [TestCase(MinusOne)]
        [TestCase(Zero)]
        [TestCase(One)]
        public void ToString_Common(
            object? sourceValue)
        {
            var source = Optional<object?>.Present(sourceValue);

            var actual = source.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "Optional.Present[{0}]:{1}",
                typeof(object),
                sourceValue);

            Assert.AreEqual(expected, actual);
        }
    }
}
