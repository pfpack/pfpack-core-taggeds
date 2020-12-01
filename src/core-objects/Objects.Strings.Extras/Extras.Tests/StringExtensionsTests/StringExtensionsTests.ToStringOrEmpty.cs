#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Objects.Tests
{
    partial class StringExtensionsTests
    {
        [Test]
        public void ToStringOrEmpty_SourceIsNull_ExpectEmpty()
        {
            StubType source = null!;

            var actual = source.ToStringOrEmpty();
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToStringOrEmpty_SourceToStringIsNull_ExpectEmpty()
        {
            var source = new StubType(null);

            var actual = source.ToStringOrEmpty();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToStringOrEmpty_SourceToStringIsNotNull_ExpectActualToStringValue(
            in string sourceToStringValue)
        {
            var source = new StubType(sourceToStringValue);

            var actual = source.ToStringOrEmpty();
            Assert.AreEqual(sourceToStringValue, actual);
        }
    }
}
