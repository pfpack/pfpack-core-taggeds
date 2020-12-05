#nullable enable

using NUnit.Framework;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Objects.Objects.Tests
{
    partial class ObjectPredicateExtensionsTests
    {
        [Test]
        public void IsNull_ValueIsNull_ExpectTrue()
        {
            object source = null!;

            var actual = source.IsNull();
            Assert.True(actual);
        }

        [Test]
        public void IsNull_ValueIsNotNull_ExpectFalse()
        {
            var source = ZeroIdRefType;

            var actual = source.IsNull();
            Assert.False(actual);
        }
    }
}
