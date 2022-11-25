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
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsAreNull_ExpectArgumentNullException()
    {
        IReadOnlyDictionary<int, StructType> sourceDictionary = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("dictionary", ex?.ParamName);

        void Test()
            =>
            _ = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, PlusFifteen);
    }

    [Test]
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsFalse_ExpectAbsent()
    {
        var source = new Dictionary<int, RefType>
        {
            [PlusFifteen] = PlusFifteenIdRefType
        };

        var sourceDictionary = new StubReadOnlyDictionary<int, RefType>(source);

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, MinusFifteen);
        var expected = Optional<RefType>.Absent;

        Assert.AreEqual(expected, actual);
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

        var sourceDictionary = new StubReadOnlyDictionary<int, string?>(source);

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, PlusFifteen);
        var expected = Optional<string?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }
}
