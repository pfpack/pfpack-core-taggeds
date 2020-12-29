#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Taggeds.Tests
{
    partial class ResultTest
    {
        [Test]
        public void ImplicitFailureBuilder_ExpectIsSuccessReturnsFalse()
        {
            var source = Result.Failure(SomeTextStructType);
            Result<RefType, StructType> actual = source;

            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void ImplicitFailureBuilder_ExpectIsFailureReturnsTrue()
        {
            var source = default(FailureBuilder<SomeError>);
            Result<SomeError, SomeError> actual = source;

            Assert.True(actual.IsFailure);
        }
    }
}