using System;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalStaticTest
{
    [Test]
    public void True_ExpectPresent()
    {
        var actual = Optional.True();
        var expected = Optional<Unit>.Present(Unit.Value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void False_ExpectAbsent()
    {
        var actual = Optional.False();
        var expected = Optional<Unit>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
