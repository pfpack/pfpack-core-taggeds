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
        public void ImplicitSuccess_SourceValueIsNull_ExpectArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(TestFunc);
            Assert.AreEqual("success", ex.ParamName);

            static void TestFunc()
            {
                Result<RefType, StructType> _ = (RefType)null!;
            }
        }

        [Test]
        public void ImplicitSuccess_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
        {
            Result<RefType, StructType> actual = ZeroIdRefType;
            Assert.True(actual.IsSuccess);
        }

        [Test]
        public void ImplicitSuccess_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
        {
            Result<StructType, object> actual = default(StructType);
            Assert.False(actual.IsFailure);
        }
    }
}