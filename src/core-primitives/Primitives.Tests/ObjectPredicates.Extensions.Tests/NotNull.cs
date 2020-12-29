#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class ObjectPredicateExtensionsTests
    {
        [Test]
        public void IsNotNull_ValueIsNull_ExpectFalse()
        {
            RefType source = null!;

            var actual = source.IsNotNull();
            Assert.False(actual);
        }

        [Test]
        public void IsNotNull_ValueIsNotNull_ExpectTrue()
        {
            var source = MinusFifteenIdRefType;

            var actual = source.IsNotNull();
            Assert.True(actual);
        }
    }
}
