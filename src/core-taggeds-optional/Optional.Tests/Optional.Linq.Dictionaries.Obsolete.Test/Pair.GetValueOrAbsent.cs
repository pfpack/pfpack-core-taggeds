using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqDictionariesExtensionsObsoleteTest
{
    [Test]
    public void GetValueOrAbsent_PairsAreNull_ExpectArgumentNullException()
    {
        IEnumerable<KeyValuePair<int, StructType>> sourcePairs = null!;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, PlusFifteen));
        Assert.AreEqual("pairs", ex!.ParamName);
    }

    [Test]
    public void GetValueOrAbsent_PairsDoNotContainKey_ExpectAbsent()
    {
        var sourcePairs = CreatePairsCollection(
            new KeyValuePair<int, RefType?>(MinusFifteen, ZeroIdRefType),
            new KeyValuePair<int, RefType?>(Zero, null),
            new KeyValuePair<int, RefType?>(int.MaxValue, PlusFifteenIdRefType));

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

        var sourcePairs = CreatePairsCollection(
            new KeyValuePair<string?, object?>(null, ZeroIdRefType),
            new KeyValuePair<string?, object?>(SomeString, PlusFifteenIdRefType),
            new KeyValuePair<string?, object?>(TabString, null),
            new KeyValuePair<string?, object?>(sourceKey, expectedValue),
            new KeyValuePair<string?, object?>(SomeString, MinusFifteenIdRefType));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, sourceKey);
        var expected = Optional<object?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [TestCase]
    public void GetValueOrAbsent_PairsContainOnlyOneKeyAndKeyIsNull_ExpectPresentKeyValue()
    {
        var expectedValue = SomeTextStructType;

        var sourcePairs = CreatePairsCollection(
            new KeyValuePair<RefType?, StructType>(PlusFifteenIdRefType, NullTextStructType),
            new KeyValuePair<RefType?, StructType>(null, expectedValue));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, null);
        var expected = Optional<StructType>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GetValueOrAbsent_PairsContainMoreThanOneKey_ExpectFirst()
    {
        var expectedValue1 = NullTextStructType;
        var expectedValue2 = SomeTextStructType;

        var sourcePairs = CreatePairsCollection(
            new KeyValuePair<RefType, StructType>(PlusFifteenIdRefType, NullTextStructType),
            new KeyValuePair<RefType, StructType>(MinusFifteenIdRefType, SomeTextStructType),
            new KeyValuePair<RefType, StructType>(PlusFifteenIdRefType, SomeTextStructType));

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourcePairs, PlusFifteenIdRefType);

        var expected1 = Optional<StructType>.Present(expectedValue1);
        var expected2 = Optional<StructType>.Present(expectedValue2);

        bool equalToAnExpected = actual.Equals(expected1) || actual.Equals(expected2);
        Assert.True(equalToAnExpected);
    }
}
