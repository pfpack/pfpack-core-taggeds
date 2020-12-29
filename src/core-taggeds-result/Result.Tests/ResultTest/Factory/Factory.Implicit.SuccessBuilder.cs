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
        public void ImplicitSuccessBuilder_SourceBuilderIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(TestFunc);
            Assert.AreEqual("success", ex.ParamName);

            static void TestFunc()
            {
                Result<StructType, SomeError> _ = (SuccessBuilder<StructType>)null!;
            }
        }

        [Test]
        public void ImplicitSuccessBuilder_SourceBuilderIsNotNull_ExpectIsSuccessReturnsTrue()
        {
            var source = Result.Success(PlusFifteenIdRefType);
            Result<RefType, SomeError> actual = source;

            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void ImplicitSuccessBuilder_SourceBuilderIsNotNull_ExpectIsFailureReturnsFalse()
        {
            var source = Result.Success(SomeTextStructType);
            Result<StructType, StructType> actual = source;

            Assert.False(actual.IsFailure);
        }
    }
}