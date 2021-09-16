#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void Present_Constructor_SourceIsNull_ExpectPresentIsTrue()
        {
            var actual = new Optional<StructType?>(null);
            Assert.True(actual.IsPresent);
        }

        [Test]
        public void Present_Constructor_SourceIsNull_ExpectAbsentIsFalse()
        {
            var actual = new Optional<StructType?>(null);
            Assert.False(actual.IsAbsent);
        }

        [Test]
        public void Present_Constructor_SourceIsNotNull_ExpectPresentIsTrue()
        {
            var actual = new Optional<RefType>(PlusFifteenIdRefType);
            Assert.True(actual.IsPresent);
        }

        [Test]
        public void Present_Constructor_SourceIsNotNull_ExpectAbsentIsFalse()
        {
            var actual = new Optional<RefType>(MinusFifteenIdRefType);
            Assert.False(actual.IsAbsent);
        }
    }
}
