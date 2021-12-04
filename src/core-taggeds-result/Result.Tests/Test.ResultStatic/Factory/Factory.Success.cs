using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultStaticTest
{
    [Test]
    public void SuccessThenWith_SourceValueIsNullForgivenRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Success<RefType>(null!).With<StructType>();
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNullForgivenRef_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Success<RefType>(null!).With<StructType>();
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNullableRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Success<RefType?>(null).With<StructType>();
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNullableRef_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Success<RefType?>(null).With<StructType>();
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNullableStruct_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Success<StructType?>(null).With<StructType>();
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNullableStruct_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Success<StructType?>(null).With<StructType>();
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Success<SomeError>(default).With<StructType>();
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void SuccessThenWith_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Success(PlusFifteenIdRefType).With<SomeError>();
        Assert.False(actual.IsFailure);
    }
}
