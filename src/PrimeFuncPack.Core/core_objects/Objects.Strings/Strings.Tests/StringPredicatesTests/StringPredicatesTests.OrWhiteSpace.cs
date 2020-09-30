#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Objects.Strings.Tests
{
    partial class StringPredicatesTests
    {
        [Test]
        public void IsNullOrWhiteSpace_SourceIsNull_ExpectTrue()
        {
            string? source = null;

            var actual = StringPredicates.IsNullOrWhiteSpace(source);
            Assert.True(actual);
        }

        [Test]
        public void IsNullOrWhiteSpace_SourceIsEmpty_ExpectTrue()
        {
            string source = string.Empty;

            var actual = StringPredicates.IsNullOrWhiteSpace(source);
            Assert.True(actual);
        }

        [Test]
        [TestCase(WhiteSpaceString)]
        [TestCase(ThreeWhiteSpacesString)]
        [TestCase(TabString)]
        public void IsNullOrWhiteSpace_SourceIsWhiteSpace_ExpectTrue(
            in string source)
        {
            var actual = StringPredicates.IsNullOrWhiteSpace(source);
            Assert.True(actual);
        }

        [Test]
        public void IsNullOrWhiteSpace_SourceIsNotWhiteSpace_ExpectFalse()
        {
            var source = SomeString;

            var actual = StringPredicates.IsNullOrWhiteSpace(source);
            Assert.False(actual);
        }
    }
}
