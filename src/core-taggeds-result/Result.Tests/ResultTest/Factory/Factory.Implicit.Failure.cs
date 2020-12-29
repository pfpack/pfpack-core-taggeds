#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests
{
    partial class ResultTest
    {
        [Test]
        public void ImplicitFailure_ExpectIsSuccessReturnsFalse()
        {
            var actual = Result<StructType, SomeError>.Failure(new SomeError(PlusFifteen));
            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void ImplicitFailure_ExpectIsFailureReturnsTrue()
        {
            var actual = Result<RefType, StructType>.Failure(default);
            Assert.True(actual.IsFailure);
        }
    }
}