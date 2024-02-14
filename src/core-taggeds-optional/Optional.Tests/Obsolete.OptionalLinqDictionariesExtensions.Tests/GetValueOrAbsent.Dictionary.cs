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
    public void GetValueOrAbsent_DictionaryPairsAreNull_ExpectArgumentNullException()
    {
        IDictionary<string, StructType> sourceDictionary = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("pairs"));

        void Test()
            =>
            _ = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, SomeString);
    }

    [Test]
    public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsFalse_ExpectAbsent()
    {
        var sourceDictionary = new StubDictionary<RefType, int>
        {
            [MinusFifteenIdRefType] = One
        };

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, PlusFifteenIdRefType);
        var expected = Optional<int>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsTrue_ExpectPresent(
        object? expectedValue)
    {
        var sourceDictionary = new StubDictionary<StructType, object?>
        {
            [SomeTextStructType] = new object(),
            [NullTextStructType] = expectedValue
        };

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, NullTextStructType);
        var expected = Optional<object?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
