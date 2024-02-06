using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultStaticTest
{
    [Test]
    public void Present_SourceValueIsNullForgivenRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Present<SomeRecord>(null!);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void Present_SourceValueIsNullForgivenRef_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Present<SomeRecord>(null!);
        Assert.That(actual.IsFailure, Is.False);
    }

    [Test]
    public void Present_SourceValueIsNullableRef_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Present<SomeRecord?>(null);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void Present_SourceValueIsNullableRef_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Present<SomeRecord?>(null);
        Assert.That(actual.IsFailure, Is.False);
    }

    [Test]
    public void Present_SourceValueIsNullableStruct_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Present<StructType?>(null);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void Present_SourceValueIsNullableStruct_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Present<StructType?>(null);
        Assert.That(actual.IsFailure, Is.False);
    }

    [Test]
    public void Present_SourceValueIsNotNull_ExpectIsSuccessReturnsTrue()
    {
        var actual = Result.Present<StructType>(default);
        Assert.That(actual.IsSuccess, Is.True);
    }

    [Test]
    public void Present_SourceValueIsNotNull_ExpectIsFailureReturnsFalse()
    {
        var actual = Result.Present(ZeroIdRefType);
        Assert.That(actual.IsFailure, Is.False);
    }
}
