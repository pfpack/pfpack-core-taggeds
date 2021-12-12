using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Present_Implicit_SourceIsNull_ExpectPresentIsTrue()
    {
        Optional<StructType?> actual = null;
        Assert.True(actual.IsPresent);
    }

    [Test]
    public void Present_Implicit_SourceIsNull_ExpectAbsentIsFalse()
    {
        Optional<StructType?> actual = null;
        Assert.False(actual.IsAbsent);
    }

    [Test]
    public void Present_Implicit_SourceIsNotNull_ExpectPresentIsTrue()
    {
        Optional<RefType> actual = PlusFifteenIdRefType;
        Assert.True(actual.IsPresent);
    }

    [Test]
    public void Present_Implicit_SourceIsNotNull_ExpectAbsentIsFalse()
    {
        Optional<RefType> actual = MinusFifteenIdRefType;
        Assert.False(actual.IsAbsent);
    }
}
