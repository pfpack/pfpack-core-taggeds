using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Absent_Default_ExpectAbsentIsTrue()
    {
        var actual = default(Optional<RefType>);
        Assert.True(actual.IsAbsent);
    }

    [Test]
    public void Absent_Default_ExpectPresentIsFalse()
    {
        var actual = default(Optional<RefType>);
        Assert.False(actual.IsPresent);
    }
}
