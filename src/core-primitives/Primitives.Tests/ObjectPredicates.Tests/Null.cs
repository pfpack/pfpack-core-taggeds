#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Primitives.Tests
{
    partial class ObjectPredicatesTests
    {
        [Test]
        public void IsNull_ValueIsNull_ExpectTrue()
        {
            RefType source = null!;

            var actual = ObjectPredicates.IsNull(source);
            Assert.True(actual);
        }

        [Test]
        public void IsNull_ValueIsNotNull_ExpectFalse()
        {
            var source = new
            {
                Text = SomeTextStructType
            };

            var actual = ObjectPredicates.IsNull(source);
            Assert.False(actual);
        }
    }
}
