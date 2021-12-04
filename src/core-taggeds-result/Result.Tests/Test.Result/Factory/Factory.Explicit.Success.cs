using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void Success_SourceValueIsNullForgivenRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result<RefType, StructType>.Success(null!);
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void Success_SourceValueIsNullForgivenRef_ExpectIsFailureReturnsFalse()
    {
        var actual = Result<RefType, StructType>.Success(null!);
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void Success_SourceValueIsNullableRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result<RefType?, StructType>.Success(null);
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void Success_SourceValueIsNullableRef_ExpectIsFailureReturnsFalse()
    {
        var actual = Result<RefType?, StructType>.Success(null);
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void Success_SourceValueIsNullableStruct_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result<StructType?, StructType>.Success(null);
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void Success_SourceValueIsNullableStruct_ExpectIsFailureReturnsFalse()
    {
        var actual = Result<StructType?, StructType>.Success(null);
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void Success_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result<StructType, SomeError>.Success(default);
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void Success_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
    {
        var actual = Result<RefType, StructType>.Success(PlusFifteenIdRefType);
        Assert.False(actual.IsFailure);
    }
}
