using NUnit.Framework;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalStaticTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Present_ExpectPresent(
        object? sourceValue)
    {
        var actual = Optional.Present(sourceValue);
        var expected = Optional<object?>.Present(sourceValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Absent_ExpectAbsent()
    {
        var actual = Optional.Absent<string>();
        var expected = Optional<string>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Absent_FromUnit_ExpectAbsent()
    {
        var actual = Optional.Absent<string>(Unit.Value);
        var expected = Optional<string>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
