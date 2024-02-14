using PrimeFuncPack.UnitTest;
using System;
using System.Linq;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Obsolete]
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void YieldSingleOrEmpty_SourceIsPresent_ExpectSingleValue(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);
        var actual = source.YieldSingleOrEmpty();

        Assert.That(actual.Count(), Is.EqualTo(1));

        var actualValue = actual.Single();
        Assert.That(actualValue, Is.SameAs(sourceValue));
    }

    [Obsolete]
    [Test]
    public void YieldSingleOrEmpty_SourceIsAbsent_ExpectEmpty()
    {
        var source = Optional<RefType>.Absent;
        var actual = source.YieldSingleOrEmpty();

        Assert.That(actual, Is.Empty);
    }
}
