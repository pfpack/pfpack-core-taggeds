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
        Assert.That(actual.IsPresent, Is.True);
    }

    [Test]
    public void Present_Explicit_SourceIsNull_ExpectAbsentIsFalse()
    {
        var actual = Optional<StructType?>.Present(null);
        Assert.That(actual.IsAbsent, Is.False);
    }

    [Test]
    public void Present_Explicit_SourceIsNotNull_ExpectPresentIsTrue()
    {
        var actual = Optional<RefType>.Present(PlusFifteenIdRefType);
        Assert.That(actual.IsPresent, Is.True);
    }

    [Test]
    public void Present_Explicit_SourceIsNotNull_ExpectAbsentIsFalse()
    {
        var actual = Optional<RefType>.Present(MinusFifteenIdRefType);
        Assert.That(actual.IsAbsent, Is.False);
    }
}
