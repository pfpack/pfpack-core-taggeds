using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ConstructorFromSuccess_SourceValueIsNullForgivenRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = new Result<SomeRecord, StructType>(null!);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNullForgivenRef_ExpectIsFailureReturnsFalse()
    {
        var actual = new Result<SomeRecord, StructType>(null!);
        Assert.That(actual.IsFailure, Is.False);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNullableRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = new Result<SomeRecord?, StructType>(null);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNullableRef_ExpectIsFailureReturnsFalse()
    {
        var actual = new Result<RefType?, StructType>(null);
        Assert.That(actual.IsFailure, Is.False);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNullableStruct_ExpectIsSuccessReturnsTrue()
    {
        var actual = new Result<StructType?, StructType>(null);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNullableStruct_ExpectIsFailureReturnsFalse()
    {
        var actual = new Result<StructType?, StructType>(null);
        Assert.That(actual.IsFailure, Is.False);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
    {
        var actual = new Result<SomeError, StructType>(default(SomeError));
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void ConstructorFromSuccess_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
    {
        var actual = new Result<RefType, SomeError>(PlusFifteenIdRefType);
        Assert.That(actual.IsFailure, Is.False);
    }
}
