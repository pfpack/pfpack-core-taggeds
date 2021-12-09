using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Present_Explicit_SourceIsNull_ExpectPresentIsTrue()
    {
        var actual = Optional<StructType?>.Present(null);
        Assert.True(actual.IsPresent);
    }

    [Test]
    public void Present_Explicit_SourceIsNull_ExpectAbsentIsFalse()
    {
        var actual = Optional<StructType?>.Present(null);
        Assert.False(actual.IsAbsent);
    }

    [Test]
    public void Present_Explicit_SourceIsNotNull_ExpectPresentIsTrue()
    {
        var actual = Optional<RefType>.Present(PlusFifteenIdRefType);
        Assert.True(actual.IsPresent);
    }

    [Test]
    public void Present_Explicit_SourceIsNotNull_ExpectAbsentIsFalse()
    {
        var actual = Optional<RefType>.Present(MinusFifteenIdRefType);
        Assert.False(actual.IsAbsent);
    }
}
