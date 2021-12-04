using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void ImplicitSuccess_SourceValueIsNullForgivenRef_ExpectIsSuccessReturnsTrue()
    {
        Result<RefType, StructType> actual = (RefType)null!;
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNullForgivenRef_ExpectIsFailureReturnsFalse()
    {
        Result<RefType, StructType> actual = (RefType)null!;
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNullableRef_ExpectIsSuccessReturnsTrue()
    {
        Result<RefType?, StructType> actual = (RefType?)null;
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNullableRef_ExpectIsFailureReturnsFalse()
    {
        Result<RefType?, StructType> actual = (RefType?)null;
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNullableStruct_ExpectIsSuccessReturnsTrue()
    {
        Result<StructType?, StructType> actual = (StructType?)null;
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNullableStruct_ExpectIsFailureReturnsFalse()
    {
        Result<StructType?, StructType> actual = (StructType?)null;
        Assert.False(actual.IsFailure);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
    {
        Result<RefType, StructType> actual = ZeroIdRefType;
        Assert.True(actual.IsSuccess);
    }

    [Test]
    public void ImplicitSuccess_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
    {
        Result<StructType, SomeError> actual = default(StructType);
        Assert.False(actual.IsFailure);
    }
}
