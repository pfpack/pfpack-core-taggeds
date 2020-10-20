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
        public void ImplicitFailureBuilder_SourceBuilderIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(TestFunc);
            Assert.AreEqual("failure", ex.ParamName);

            static void TestFunc()
            {
                Result<StructType, RefType> _ = (FailureBuilder<RefType>)null!;
            }
        }

        [Test]
        public void ImplicitFailureBuilder_SourceBuilderIsNotNull_ExpectIsSuccessReturnsFalse()
        {
            var source = Result.Failure(ZeroIdRefType);
            Result<RefType, RefType> actual = source;

            Assert.False(actual.IsSuccess);
        }

        [Test]
        public void ImplicitFailureBuilder_SourceBuilderIsNotNull_ExpectIsFailureReturnsTrue()
        {
            var source = Result.Failure(NullTextStructType);
            Result<StructType, StructType> actual = source;

            Assert.True(actual.IsFailure);
        }
    }
}