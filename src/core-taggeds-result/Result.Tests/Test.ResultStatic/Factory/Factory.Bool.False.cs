using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultStaticTest
    {
        [Test]
        public void False_ExpectIsSuccessReturnsFalse()
        {
            var actual = Result.False();
            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void False_ExpectIsFailureReturnsTrue()
        {
            var actual = Result.False();
            Assert.True(actual.IsFailure);
        }
    }
}