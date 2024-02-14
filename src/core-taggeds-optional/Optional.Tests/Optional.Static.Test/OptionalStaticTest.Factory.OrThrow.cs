using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalStaticTest
{
    [Test]
    public void PresentOrThrow_ValueIsNotNull_ExpectPresent()
    {
        var sourceValue = PlusFifteenIdRefType;

        var actual = Optional.PresentOrThrow<RefType?>(sourceValue);
        var expected = Optional<RefType?>.Present(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrThrow_ValueIsNull_ExpectArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentException>(() => _ = Optional.PresentOrThrow<RefType?>(null!));
        Assert.That(ex!.ParamName, Is.EqualTo("value"));
    }

    [Test]
    public void PresentOrThrowWithStructValue_ValueIsNotNull_ExpectPresent()
    {
        var sourceValue = SomeTextStructType;

        var actual = Optional.PresentOrThrow(sourceValue);
        var expected = Optional<StructType>.Present(SomeTextStructType);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrThrowWithStructValue_NullableValueIsNotNull_ExpectPresent()
    {
        StructType? sourceValue = SomeTextStructType;

        var actual = Optional.PresentOrThrow(sourceValue);
        var expected = Optional<StructType>.Present(SomeTextStructType);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void PresentOrThrowWithStructValue_ValueIsNull_ExpectArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentException>(() => _ = Optional.PresentOrThrow<StructType>(null!));
        Assert.That(ex!.ParamName, Is.EqualTo("value"));
    }
}
