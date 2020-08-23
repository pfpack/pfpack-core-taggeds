#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
{
    partial class StringExtensionsTests
    {
        [Test]
        public void OrEmpty_SourceIsNull_ExpectEmpty()
        {
            string? source = null;

            var actual = source.OrEmpty();
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("some")]
        public void OrEmpty_SourceIsNotNull_ExpectSourceValue(
            in string source)
        {
            var actual = source.OrEmpty();
            Assert.AreEqual(source, actual);
        }
    }
}
