#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class StringsTests
    {
        [Test]
        public void ToStringOrEmpty_SourceIsNull_ExpectEmpty()
        {
            ToStringStubType source = null!;

            var actual = Strings.ToStringOrEmpty(source);
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToStringOrEmpty_SourceToStringIsNull_ExpectEmpty()
        {
            var source = new ToStringStubType(null);

            var actual = Strings.ToStringOrEmpty(source);
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

            var actual = Strings.ToStringOrEmpty(source);
            Assert.AreEqual(sourceToStringValue, actual);
        }
    }
}
