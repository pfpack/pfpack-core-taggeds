using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class ResultStaticTest
{
    [Test]
    public void Absent_ExpectIsSuccessReturnsFalse()
    {
        var actual = Result.Absent<StructType>();
        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void Absent_ExpectIsFailureReturnsTrue()
    {
        var actual = Result.Absent<SomeRecord>();
        Assert.That(actual.IsFailure, Is.True);
    }
}
