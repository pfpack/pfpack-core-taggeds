using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ImplicitSuccessBuilder_ExpectIsSuccessReturnsTrue()
    {
        var source = Result.Success(PlusFifteenIdRefType);
        Result<RefType, SomeError> actual = source;

        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void ImplicitSuccessBuilder_ExpectIsFailureReturnsFalse()
    {
        var source = Result.Success<StructType?>(SomeTextStructType);
        Result<StructType?, StructType> actual = source;

        Assert.That(actual.IsFailure, Is.False);
    }
}
