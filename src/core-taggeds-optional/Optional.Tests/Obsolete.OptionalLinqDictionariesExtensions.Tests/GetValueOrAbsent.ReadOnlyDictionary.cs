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
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsAreNull_ExpectArgumentNullException()
    {
        IReadOnlyDictionary<int, StructType> sourceDictionary = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("pairs"));

        void Test()
            =>
            _ = OptionalLinqDictionariesExtensions.GetValueOrAbsent((IEnumerable<KeyValuePair<int, StructType>>)sourceDictionary, PlusFifteen);
    }

    [Test]
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsFalse_ExpectAbsent()
    {
        var source = new Dictionary<int, RefType>
        {
            [PlusFifteen] = PlusFifteenIdRefType
        };

        IEnumerable<KeyValuePair<int, RefType>> sourceDictionary = new StubReadOnlyDictionary<int, RefType>(source);

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, MinusFifteen);
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsTrue_ExpectPresent()
    {
        var expectedValue = SomeString;

        var source = new Dictionary<int, string?>
        {
            [One] = string.Empty,
            [PlusFifteen] = expectedValue,
            [MinusFifteen] = LowerAnotherString,
            [Zero] = null
        };

        IEnumerable<KeyValuePair<int, string?>> sourceDictionary = new StubReadOnlyDictionary<int, string?>(source);

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, PlusFifteen);
        var expected = Optional<string?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
