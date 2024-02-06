using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ImplicitFailureBuilder_ExpectIsSuccessReturnsFalse()
    {
        var source = Result.Failure(SomeTextStructType);
        Result<RefType?, StructType> actual = source;

        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void ImplicitFailureBuilder_ExpectIsFailureReturnsTrue()
    {
        var source = default(FailureBuilder<SomeError>);
        Result<SomeError, SomeError> actual = source;

        Assert.That(actual.IsFailure, Is.True);
    }
}
