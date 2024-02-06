using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ConstructorFromFailureValue_ExpectIsSuccessReturnsFalse()
    {
        var actual = new Result<RefType?, StructType>(default(StructType));
        Assert.That(actual.IsSuccess, Is.False);
    }

    [Test]
    public void ConstructorFromFailureValue_ExpectIsFailureReturnsTrue()
    {
        var actual = new Result<RefType, SomeError>(new SomeError(MinusFifteen));
        Assert.That(actual.IsFailure, Is.True);
    }
}
