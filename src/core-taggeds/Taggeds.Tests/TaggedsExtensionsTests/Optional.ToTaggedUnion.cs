using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class TaggedsExtensionsTests
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Optional_ToTaggedUnion_OptionalIsPresent_ExpectActualIsFirst(
        object? sourceValue)
    {
        var optional = Optional.Present(sourceValue);
        var actual = optional.ToTaggedUnion();

        var expected = TaggedUnion<object?, Unit>.First(sourceValue);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Optional_ToTaggedUnion_OptionalIsAbsent_ExpectActualIsSecond()
    {
        var optional = Optional.Absent<RefType>();
        var actual = optional.ToTaggedUnion();

        var expected = TaggedUnion<RefType, Unit>.Second(Unit.Value);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
