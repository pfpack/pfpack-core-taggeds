#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class StringExtensionsTests
    {
        [Test]
        public void ToStringOrEmpty_SourceIsNull_ExpectEmpty()
        {
            ToStringStubType source = null!;

            var actual = source.ToStringOrEmpty();
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToStringOrEmpty_SourceToStringIsNull_ExpectEmpty()
        {
            var source = new ToStringStubType(null);

            var actual = source.ToStringOrEmpty();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void ToStringOrEmpty_SourceToStringIsNotNull_ExpectActualToStringValue(
            string sourceToStringValue)
        {
            var source = new ToStringStubType(sourceToStringValue);

            var actual = source.ToStringOrEmpty();
            Assert.AreEqual(sourceToStringValue, actual);
        }
    }
}
