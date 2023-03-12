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
    public void GetValueOrAbsent_DictionaryPairsAreNull_ExpectArgumentNullException()
    {
        IDictionary<string, StructType> sourceDictionary = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("pairs", ex?.ParamName);

        void Test()
            =>
            _ = sourceDictionary.GetValueOrAbsent(SomeString);
    }

    [Test]
    public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsFalse_ExpectAbsent()
    {
        var sourceDictionary = new StubDictionary<RefType, int>
        {
            [ZeroIdRefType] = PlusFifteen
        };

        var actual = sourceDictionary.GetValueOrAbsent(PlusFifteenIdRefType);
        var expected = Optional<int>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void GetValueOrAbsent_DictionaryPairsPairsTryGetValueReturnsTrue_ExpectPresent(
        object? expectedValue)
    {
        var sourceDictionary = new StubDictionary<StructType, object?>
        {
            [LowerSomeTextStructType] = MinusFifteenIdNullNameRecord,
            [NullTextStructType] = expectedValue
        };

        var actual = sourceDictionary.GetValueOrAbsent(NullTextStructType);
        var expected = Optional<object?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }
}
