using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void Default_ExpectIsSuccessReturnsFalse()
    {
        var actual = default(Result<RefType, StructType>);
        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void Default_ExpectIsFailureReturnsTrue()
    {
        var actual = default(Result<RefType, StructType>);
        Assert.That(actual.IsFailure, Is.True);
    }
}
