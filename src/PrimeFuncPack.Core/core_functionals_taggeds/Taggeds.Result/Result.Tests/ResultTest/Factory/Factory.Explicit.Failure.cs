#nullable enable

using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Functionals.Taggeds.Tests
{
    partial class ResultTest
    {
        [Test]
        public void Failure_SourceValueIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Result<StructType, RefType>.Failure(null!));
            Assert.AreEqual("failure", ex.ParamName);
        }

        [Test]
        public void Failure_SourceValueIsNotNull_ExpectIsSuccessReturnsFalse()
        {
            var actual = Result<StructType, RefType>.Failure(MinusFifteenIdRefType);
            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void Failure_SourceValueIsNotNull_ExpectIsFailureReturnsTrue()
        {
            var actual = Result<RefType, StructType>.Failure(default);
            Assert.True(actual.IsFailure);
        }
    }
}