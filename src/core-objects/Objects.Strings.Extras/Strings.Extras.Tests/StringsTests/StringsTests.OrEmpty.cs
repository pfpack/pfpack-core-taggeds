#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

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
        [TestCase(EmptyString)]
        [TestCase(WhiteSpaceString)]
        [TestCase(TabString)]
        [TestCase(SomeString)]
        public void OrEmpty_SourceIsNotNull_ExpectSourceValue(
            string source)
        {
            var actual = Strings.OrEmpty(source);
            Assert.AreEqual(source, actual);
        }
    }
}
