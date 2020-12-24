#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Objects.Strings.Tests
{
    partial class StringPredicatesTests
    {
        [Test]
        public void IsNullOrEmpty_SourceIsNull_ExpectTrue()
        {
            string? source = null;

            var actual = StringPredicates.IsNullOrEmpty(source);
            Assert.True(actual);
        }

        [Test]
        public void IsNullOrEmpty_SourceIsEmpty_ExpectTrue()
        {
            string source = string.Empty;

            var actual = StringPredicates.IsNullOrEmpty(source);
            Assert.True(actual);
        }

        [Test]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void IsNullOrEmpty_SourceIsNotEmpty_ExpectFalse(
            string source)
        {
            var actual = StringPredicates.IsNullOrEmpty(source);
            Assert.False(actual);
        }
    }
}
