using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqExtensionsTests
{
    [Test]
    public void GetValueOrAbsent_PairsAreNull_ExpectArgumentNullException()
    {
        IEnumerable<KeyValuePair<int, StructType>> sourcePairs = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("pairs"));

        void Test()
            =>
            _ = sourcePairs.GetValueOrAbsent(PlusFifteen);
    }

    [Test]
    public void GetValueOrAbsent_PairsDoNotContainKey_ExpectAbsent()
    {
        var sourcePairs = CreatePairCollection<int, RefType?>(
            new(MinusFifteen, ZeroIdRefType),
            new(Zero, null),
            new(int.MaxValue, PlusFifteenIdRefType));

        var actual = sourcePairs.GetValueOrAbsent(PlusFifteen);
        var expected = Optional<RefType?>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void GetValueOrAbsent_PairsContainOnlyOneKey_ExpectPresentKeyValue(
        object? expectedValue)
    {
        var sourceKey = "Some Key";

        var sourcePairs = CreatePairCollection<string?, object?>(
            new (null, ZeroIdRefType),
            new (SomeString, PlusFifteenIdRefType),
            new (TabString, null),
            new (sourceKey, expectedValue),
            new (SomeString, MinusFifteenIdRefType));

        var actual = sourcePairs.GetValueOrAbsent(sourceKey);
        var expected = Optional<object?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase]
    public void GetValueOrAbsent_PairsContainOnlyOneKeyAndKeyIsNull_ExpectPresentKeyValue()
    {
        var expectedValue = SomeTextStructType;

        var sourcePairs = CreatePairCollection<RefType?, StructType>(
            new(PlusFifteenIdRefType, NullTextStructType),
            new(null, expectedValue));

        var actual = sourcePairs.GetValueOrAbsent(null);
        var expected = Optional<StructType>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetValueOrAbsent_PairsContainMoreThanOneKey_ExpectFirst()
    {
        var expectedValue1 = NullTextStructType;
        var expectedValue2 = SomeTextStructType;

        var sourcePairs = CreatePairCollection<RefType, StructType>(
            new(PlusFifteenIdRefType, NullTextStructType),
            new(MinusFifteenIdRefType, SomeTextStructType),
            new(PlusFifteenIdRefType, SomeTextStructType));

        var actual = sourcePairs.GetValueOrAbsent(PlusFifteenIdRefType);

        var expected1 = Optional<StructType>.Present(expectedValue1);
        var expected2 = Optional<StructType>.Present(expectedValue2);

        bool equalToAnExpected = actual.Equals(expected1) || actual.Equals(expected2);
        Assert.That(equalToAnExpected);
    }
}
