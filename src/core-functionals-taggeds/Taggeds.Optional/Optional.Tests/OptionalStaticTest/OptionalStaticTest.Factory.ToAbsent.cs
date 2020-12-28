#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalStaticTest
    {
        [Test]
        public void ToAbsent_T_ExpectAbsent()
        {
            var actual = Optional.ToAbsent(SomeString);
            var expected = Optional<string>.Absent;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ToAbsent_T_T_ExpectAbsent()
        {
            var actual = Optional.ToAbsent<string, string>(SomeString);
            var expected = Optional<string>.Absent;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToAbsent_TSource_T_ExpectAbsent()
        {
            var actual = Optional.ToAbsent<int, string>(PlusFifteen);
            var expected = Optional<string>.Absent;

            Assert.AreEqual(expected, actual);
        }

    }
}
