#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class OptionalTest
    {
        [Test]
        public void Absent_Constructor_ExpectAbsentIsTrue()
        {
            var actual = new Optional<RefType>();
            Assert.True(actual.IsAbsent);
        }

        [Test]
        public void Absent_Constructor_ExpectPresentIsFalse()
        {
            var actual = new Optional<RefType>();
            Assert.False(actual.IsPresent);
        }
    }
}
