#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Objects.Objects.Tests
{
    public sealed partial class ObjectPredicatesTests
    {
        [Test]
        public void IsNotNull_ValueIsNull_ExpectFalse()
        {
            object source = null!;

            var actual = ObjectPredicates.IsNotNull(source);
            Assert.False(actual);
        }

        [Test]
        public void IsNotNull_ValueIsNotNull_ExpectTrue()
        {
            var source = PlusFifteenIdRefType;

            var actual = ObjectPredicates.IsNotNull(source);
            Assert.True(actual);
        }
    }
}
