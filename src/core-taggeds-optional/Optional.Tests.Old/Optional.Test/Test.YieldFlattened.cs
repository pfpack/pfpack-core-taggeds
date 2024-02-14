using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Linq;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void YieldFlattened_SourceIsPresent_ExpectSingleValue(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);
        var actual = source.YieldFlattened();

        Assert.That(actual.Count(), Is.EqualTo(1));
        
        var actualValue = actual.Single();
        Assert.That(actualValue, Is.SameAs(sourceValue));
    }

    [Test]
    public void YieldFlattened_SourceIsAbsent_ExpectEmpty()
    {
        var source = Optional<RefType>.Absent;
        var actual = source.YieldFlattened();

        Assert.That(actual, Is.Empty);
    }
}
