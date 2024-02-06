using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void Failure_ExpectIsSuccessReturnsFalse()
    {
        var actual = Result<StructType, SomeError>.Failure(new SomeError(PlusFifteen));
        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void Failure_ExpectIsFailureReturnsTrue()
    {
        var actual = Result<RefType?, StructType>.Failure(default);
        Assert.That(actual.IsFailure, Is.True);
    }
}
