using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultStaticTest
{
    [Test]
    public void FailureThenWith_ExpectIsSuccessReturnsFalse()
    {
        var actual = Result.Failure(SomeTextStructType).With<RefType?>();
        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void FailureThenWith_ExpectIsFailureReturnsTrue()
    {
        var actual = Result.Failure<StructType>(default).With<SomeRecord>();
        Assert.That(actual.IsFailure, Is.True);
    }
}
