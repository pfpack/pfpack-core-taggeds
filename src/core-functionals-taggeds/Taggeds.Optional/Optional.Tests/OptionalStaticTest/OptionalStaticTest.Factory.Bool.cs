#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class OptionalStaticTest
    {
        [Test]
        public void True_ExpectPresent()
        {
            var actual = Optional.True();
            var expected = Optional<Unit>.Present(Unit.Value);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void False_ExpectAbsent()
        {
            var actual = Optional.False();
            var expected = Optional<Unit>.Absent;

            Assert.AreEqual(expected, actual);
        }
    }
}
