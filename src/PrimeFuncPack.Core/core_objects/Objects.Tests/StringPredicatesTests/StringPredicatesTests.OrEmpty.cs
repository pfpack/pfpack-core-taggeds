#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
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
        [TestCase(" ")]
        [TestCase("some")]
        public void IsNullOrEmpty_SourceIsNotEmpty_ExpectFalse(
            in string source)
        {
            var actual = StringPredicates.IsNullOrEmpty(source);
            Assert.False(actual);
        }
    }
}
