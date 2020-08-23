#nullable enable

using NUnit.Framework;
using PrimeFuncPack.Core.Objects.Tests.TestData;
using System;

namespace PrimeFuncPack.Core.Objects.Tests
{
    partial class StringsTests
    {
        [Test]
        public void ToStringOrEmpty_SourceIsNull_ExpectEmpty()
        {
            RefType source = null!;

            var actual = Strings.ToStringOrEmpty(source);
            Assert.IsEmpty(actual);
        }

        [Test]
        public void ToStringOrEmpty_SourceToStringIsNull_ExpectEmpty()
        {
            var source = new RefType
            {
                Text = null
            };

            var actual = Strings.ToStringOrEmpty(source);
            Assert.IsEmpty(actual);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("some value")]
        public void ToStringOrEmpty_SourceToStringIsNotNull_ExpectActualToStringValue(
            in string sourceToStringValue)
        {
            var source = new RefType
            {
                Text = sourceToStringValue
            };

            var actual = Strings.ToStringOrEmpty(source);
            Assert.AreEqual(sourceToStringValue, actual);
        }
    }
}
