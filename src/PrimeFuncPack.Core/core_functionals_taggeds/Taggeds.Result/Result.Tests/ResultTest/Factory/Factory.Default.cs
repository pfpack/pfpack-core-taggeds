#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class ResultTest
    {
        [Test]
        public void Default_ExpectIsSuccessReturnsFalse()
        {
            var actual = default(Result<RefType, StructType>);
            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void Default_ExpectIsFailureReturnsTrue()
        {
            var actual = default(Result<RefType, StructType>);
            Assert.True(actual.IsFailure);
        }
    }
}