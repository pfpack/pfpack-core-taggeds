using System;

namespace PrimeFuncPack.Core.Tests;

partial class ResultStaticTest
{
    [Test]
    public void True_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.True();
        Assert.That(actual.IsSuccess, Is.True);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void True_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.True();
        Assert.That(actual.IsFailure, Is.False);
    }
}
