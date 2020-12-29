#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class StringPredicateExtensionsTests
    {
        [Test]
        public void IsNullOrEmpty_SourceIsNull_ExpectTrue()
        {
            string? source = null;

            var actual = source.IsNullOrEmpty();
            Assert.True(actual);
        }

        [Test]
        public void IsNullOrEmpty_SourceIsEmpty_ExpectTrue()
        {
            string source = string.Empty;

            var actual = source.IsNullOrEmpty();
            Assert.True(actual);
        }

        [Test]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void IsNullOrEmpty_SourceIsNotEmpty_ExpectFalse(
            string source)
        {
            var actual = source.IsNullOrEmpty();
            Assert.False(actual);
        }
    }
}
