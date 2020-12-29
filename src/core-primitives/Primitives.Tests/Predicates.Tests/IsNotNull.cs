#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    public sealed partial class PredicatesTests
    {
        [Test]
        public void IsNotNull_ValueIsNull_ExpectFalse()
        {
            object source = null!;

            var actual = Predicates.IsNotNull(source);
            Assert.False(actual);
        }

        [Test]
        public void IsNotNull_ValueIsNotNull_ExpectTrue()
        {
            var source = PlusFifteenIdRefType;

            var actual = Predicates.IsNotNull(source);
            Assert.True(actual);
        }
    }
}
