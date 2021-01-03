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
        public void Default_ExpectAbsentIsTrue()
        {
            var actual = default(Optional<RefType>);
            Assert.True(actual.IsAbsent);
        }

        [Test]
        public void Default_ExpectPresentIsFalse()
        {
            var actual = default(Optional<RefType>);
            Assert.False(actual.IsPresent);
        }

        [Test]
        public void Absent_ExpectAbsentIsTrue()
        {
            var actual = Optional<StructType>.Absent;
            Assert.True(actual.IsAbsent);
        }

        [Test]
        public void Absent_ExpectPresentIsFalse()
        {
            var actual = Optional<StructType>.Absent;
            Assert.False(actual.IsPresent);
        }

        [Test]
        public void Present_SourceIsNull_ExpectPresentIsTrue()
        {
            var actual = Optional<StructType?>.Present(null);
            Assert.True(actual.IsPresent);
        }

        [Test]
        public void Present_SourceIsNull_ExpectAbsentIsFalse()
        {
            var actual = Optional<StructType?>.Present(null);
            Assert.False(actual.IsAbsent);
        }

        [Test]
        public void Present_SourceIsNotNull_ExpectPresentIsTrue()
        {
            var actual = Optional<RefType>.Present(PlusFifteenIdRefType);
            Assert.True(actual.IsPresent);
        }

        [Test]
        public void Present_SourceIsNotNull_ExpectAbsentIsFalse()
        {
            var actual = Optional<RefType>.Present(MinusFifteenIdRefType);
            Assert.False(actual.IsAbsent);
        }
    }
}
