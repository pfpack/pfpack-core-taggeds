using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    public void Absent_Constructor_ExpectAbsentIsTrue()
    {
        var actual = new Optional<RefType>();
        Assert.That(actual.IsAbsent, Is.True);
    }

    [Test]
    public void Absent_Constructor_ExpectPresentIsFalse()
    {
        var actual = new Optional<RefType>();
        Assert.That(actual.IsPresent, Is.False);
    }
}
