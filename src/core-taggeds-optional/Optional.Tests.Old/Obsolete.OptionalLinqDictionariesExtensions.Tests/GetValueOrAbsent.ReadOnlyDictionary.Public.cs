using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ObsoleteOptionalLinqDictionariesExtensionsTests
{
    [Test]
    public void GetValueOrAbsent_PublicReadOnlyDictionaryPairsAreNull_ExpectArgumentNullException()
    {
        IReadOnlyDictionary<int, StructType> sourceDictionary = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("dictionary"));

        void Test()
            =>
            _ = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, PlusFifteen);
    }

    [Test]
    public void GetValueOrAbsent_PublicReadOnlyDictionaryPairsTryGetValueReturnsFalse_ExpectAbsent()
    {
        var source = new Dictionary<int, RefType>
        {
            [PlusFifteen] = PlusFifteenIdRefType
        };

        var sourceDictionary = new StubReadOnlyDictionary<int, RefType>(source);

        var actual = OptionalLinqDictionariesExtensions.GetValueOrAbsent(sourceDictionary, MinusFifteen);
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetValueOrAbsent_PublicReadOnlyDictionaryPairsTryGetValueReturnsTrue_ExpectPresent()
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

        Assert.That(actual, Is.EqualTo(expected));
    }
}
