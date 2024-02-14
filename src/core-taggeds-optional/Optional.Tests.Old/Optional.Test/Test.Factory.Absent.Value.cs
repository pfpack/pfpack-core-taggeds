using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Absent_Value_ExpectAbsentIsTrue()
    {
        var actual = Optional<StructType>.Absent;
        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public void Absent_Value_ExpectPresentIsFalse()
    {
        var actual = Optional<StructType>.Absent;
        Assert.That(actual.IsPresent, Is.False);
    }
}
