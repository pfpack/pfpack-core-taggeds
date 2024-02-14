using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ObsoleteReadOnlyOptionalLinqExtensionsTests
{
    [Test]
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsAreNull_ExpectArgumentNullException()
    {
        IReadOnlyDictionary<int, StructType> sourceDictionary = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("dictionary"));

        void Test()
            =>
            _ = OptionalLinqExtensions.GetValueOrAbsent(sourceDictionary, PlusFifteen);
    }

    [Test]
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsFalse_ExpectAbsent()
    {
        var source = new Dictionary<int, RefType>
        {
            [PlusFifteen] = MinusFifteenIdRefType
        };

        var sourceDictionary = new StubReadOnlyDictionary<int, RefType>(source);

        var actual = OptionalLinqExtensions.GetValueOrAbsent(sourceDictionary, MinusFifteen);
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetValueOrAbsent_ReadOnlyDictionaryPairsTryGetValueReturnsTrue_ExpectPresent()
    {
        var expectedValue = MinusFifteenIdNullNameRecord;

        var source = new Dictionary<decimal, RecordType>
        {
            [decimal.MinusOne] = expectedValue,
            [decimal.MaxValue] = PlusFifteenIdSomeStringNameRecord
        };

        var sourceDictionary = new StubReadOnlyDictionary<decimal, RecordType>(source);

        var actual = OptionalLinqExtensions.GetValueOrAbsent(sourceDictionary, decimal.MinusOne);
        var expected = Optional<RecordType>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
