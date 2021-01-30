#nullable enable

using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultStaticTest
    {
        [Test]
        public void True_ExpectIsSuccessReturnsTrue()
        {
            var actual = Result.True();
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void True_ExpectIsFailureReturnsFalse()
        {
            var actual = Result.True();
            Assert.False(actual.IsFailure);
        }
    }
}