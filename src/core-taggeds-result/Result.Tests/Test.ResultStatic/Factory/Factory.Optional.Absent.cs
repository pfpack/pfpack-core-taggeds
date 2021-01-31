#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultStaticTest
    {
        [Test]
        public void Absent_ExpectIsSuccessReturnsFalse()
        {
            var actual = Result.Absent<StructType>();
            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void Absent_ExpectIsFailureReturnsTrue()
        {
            var actual = Result.Absent<SomeRecord>();
            Assert.True(actual.IsFailure);
        }
    }
}