#nullable enable

using NUnit.Framework;
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
                "The absent value of type {0}: ()",
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
                "A present value of type {0}: {1}",
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
                "A present value of type {0}: {1}",
                typeof(StubType),
                string.Empty);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(TabString)]
        [TestCase(ThreeWhiteSpacesString)]
        [TestCase(SomeString)]
        public void ToString_SourceIsPresentAndValueToStringIsNotNull_ExpectSourceValueToStringResult(
            string sourceValueToStringResult)
        {
            var sourceValue = new StubType(sourceValueToStringResult);
            var source = Optional<StubType>.Present(sourceValue);

            var actual = source.ToString();

            var expected = string.Format(
                CultureInfo.InvariantCulture,
                "A present value of type {0}: {1}",
                typeof(StubType),
                sourceValueToStringResult);

            Assert.AreEqual(expected, actual);
        }
    }
}
