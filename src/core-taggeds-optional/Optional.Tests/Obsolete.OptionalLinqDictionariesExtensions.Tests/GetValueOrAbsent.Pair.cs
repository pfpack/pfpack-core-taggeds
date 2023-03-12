using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ObsoleteOptionalLinqDictionariesExtensionsTests
{
    [Test]
    public void GetValueOrAbsent_PairsAreNull_ExpectArgumentNullException()
    {
        IEnumerable<KeyValuePair<int, StructType>> sourcePairs = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("pairs", ex?.ParamName);

        void Test()
            =>
            _ = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, PlusFifteen);
    }

    [Test]
    public void GetValueOrAbsent_PairsDoNotContainKey_ExpectAbsent()
    {
        var sourcePairs = CreatePairsCollection<int, RefType?>(
            new(MinusFifteen, ZeroIdRefType),
            new(Zero, null),
            new(int.MaxValue, PlusFifteenIdRefType));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, PlusFifteen);
        var expected = Optional<RefType?>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void GetValueOrAbsent_PairsContainOnlyOneKey_ExpectPresentKeyValue(
        object? expectedValue)
    {
        var sourceKey = "Some Key";

        var sourcePairs = CreatePairsCollection<string?, object?>(
            new(null, ZeroIdRefType),
            new(SomeString, PlusFifteenIdRefType),
            new(TabString, null),
            new(sourceKey, expectedValue),
            new(SomeString, MinusFifteenIdRefType));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, sourceKey);
        var expected = Optional<object?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [TestCase]
    public void GetValueOrAbsent_PairsContainOnlyOneKeyAndKeyIsNull_ExpectPresentKeyValue()
    {
        var expectedValue = SomeTextStructType;

        var sourcePairs = CreatePairsCollection<RefType?, StructType>(
            new(PlusFifteenIdRefType, NullTextStructType),
            new(null, expectedValue));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, null);
        var expected = Optional<StructType>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetValueOrAbsent_PairsContainMoreThanOneKey_ExpectFirst()
    {
        var expectedValue1 = NullTextStructType;
        var expectedValue2 = SomeTextStructType;

        var sourcePairs = CreatePairsCollection<RefType, StructType>(
            new(PlusFifteenIdRefType, NullTextStructType),
            new(MinusFifteenIdRefType, SomeTextStructType),
            new(PlusFifteenIdRefType, SomeTextStructType));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, PlusFifteenIdRefType);

        var expected1 = Optional<StructType>.Present(expectedValue1);
        var expected2 = Optional<StructType>.Present(expectedValue2);

        bool equalToAnExpected = actual.Equals(expected1) || actual.Equals(expected2);
        Assert.True(equalToAnExpected);
    }
}
