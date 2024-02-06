using System;

namespace PrimeFuncPack.Core.Tests;

partial class ResultStaticTest
{
    [Test]
    public void False_ExpectIsSuccessReturnsFalse()
    {
        var actual = Result.False();
        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void False_ExpectIsFailureReturnsTrue()
    {
        var actual = Result.False();
        Assert.That(actual.IsFailure, Is.True);
    }
}
