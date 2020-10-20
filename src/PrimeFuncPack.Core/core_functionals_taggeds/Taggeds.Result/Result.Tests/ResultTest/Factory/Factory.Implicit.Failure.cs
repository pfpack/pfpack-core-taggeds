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
        public void ImplicitFailure_SourceValueIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(TestFunc);
            Assert.AreEqual("failure", ex.ParamName);

            static void TestFunc()
            {
                Result<StructType, RefType> _ = (RefType)null!;
            }
        }

        [Test]
        public void ImplicitFailure_SourceValueIsNotNull_ExpectIsSuccessReturnsFalse()
        {
            var actual = Result<StructType, RefType>.Failure(MinusFifteenIdRefType);
            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void ImplicitFailure_SourceValueIsNotNull_ExpectIsFailureReturnsTrue()
        {
            var actual = Result<RefType, StructType>.Failure(default);
            Assert.True(actual.IsFailure);
        }
    }
}