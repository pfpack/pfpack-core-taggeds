using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalStaticTest
{
    [Test]
    public void PresentOrElse_ValueIsNotNull_ExpectPresent()
    {
        var sourceValue = PlusFifteenIdRefType;

        var actual = Optional.PresentOrElse<RefType?>(sourceValue);
        var expected = Optional<RefType?>.Present(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrElse_ValueIsNull_ExpectAbsent()
    {
        var actual = Optional.PresentOrElse<RefType?>(null!);
        var expected = Optional<RefType?>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrElseWithStructValue_ValueIsNotNull_ExpectPresent()
    {
        var sourceValue = SomeTextStructType;

        var actual = Optional.PresentOrElse(sourceValue);
        var expected = Optional<StructType>.Present(SomeTextStructType);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrElseWithStructValue_NullableValueIsNotNull_ExpectPresent()
    {
        StructType? sourceValue = SomeTextStructType;

        var actual = Optional.PresentOrElse(sourceValue);
        var expected = Optional<StructType>.Present(SomeTextStructType);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrElseWithStructValue_ValueIsNull_ExpectAbsent()
    {
        var actual = Optional.PresentOrElse<StructType>(null!);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
