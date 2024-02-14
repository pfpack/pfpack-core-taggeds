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
        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public void Absent_Default_ExpectPresentIsFalse()
    {
        var actual = default(Optional<RefType>);
        Assert.That(actual.IsPresent, Is.False);
    }
}
