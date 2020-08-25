#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
{
    partial class StringsTests
    {
        [Test]
        public void OrEmpty_SourceIsNull_ExpectEmpty()
        {
            string? source = null;

            var actual = Strings.OrEmpty(source);
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        [TestCase("some")]
        public void OrEmpty_SourceIsNotNull_ExpectSourceValue(
            in string source)
        {
            var actual = Strings.OrEmpty(source);
            Assert.AreEqual(source, actual);
        }
    }
}
