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
        public void Success_SourceValueIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _ = Result<RefType, StructType>.Success(null!));
            Assert.AreEqual("success", ex.ParamName);
        }

        [Test]
        public void Success_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
        {
            var actual = Result<StructType, SomeError>.Success(default);
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void Success_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
        {
            var actual = Result<RefType, StructType>.Success(PlusFifteenIdRefType);
            Assert.False(actual.IsFailure);
        }
    }
}