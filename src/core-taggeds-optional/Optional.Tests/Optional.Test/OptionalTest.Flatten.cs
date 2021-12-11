using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Linq;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void Flatten_SourceIsPresent_ExpectSingleValue(
        object? sourceValue)
    {
        var source = Optional<object?>.Present(sourceValue);
        var actual = source.Flatten();

        Assert.AreEqual(1, actual.Count());
        var actualValue = actual.Single();

        Assert.AreEqual(sourceValue, actualValue);
    }

    [Test]
    public void Flatten_SourceIsAbsent_ExpectEmpty()
    {
        var source = Optional<RefType>.Absent;
        var actual = source.Flatten();

        Assert.IsEmpty(actual);
    }
}
