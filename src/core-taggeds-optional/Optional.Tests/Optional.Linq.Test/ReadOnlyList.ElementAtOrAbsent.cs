using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqExtensionsTest
{
    [Test]
    public void ElementAtOrAbsentByInt_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        int index = 1;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.ElementAtOrAbsent(index);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void ElementAtOrAbsentByInt_ReadOnlyListIndexIsInRange_ExpectPresentItem(
        int index)
    {
        var source = CreateReadOnlyList(null, MinusFifteenIdRefType, ZeroIdRefType, PlusFifteenIdRefType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(int.MinValue)]
    [TestCase(-1)]
    [TestCase(2)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByInt_ReadOnlyListIndexIsNotInRange_ExpectAbsent(
        int index)
    {
        var source = CreateReadOnlyList(SomeTextStructType, default);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ElementAtOrAbsentByLong_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        long index = 1;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.ElementAtOrAbsent(index);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ElementAtOrAbsentByLong_ReadOnlyListIndexIsInRange_ExpectPresentItem(
        int index)
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType, null, ZeroIdRefType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(long.MinValue)]
    [TestCase(-1)]
    [TestCase(4)]
    [TestCase(long.MaxValue)]
    public void ElementAtOrAbsentByLong_ReadOnlyListIndexIsNotInRange_ExpectAbsent(
        long index)
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType, null);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<RefType?>.Absent;

        Assert.AreEqual(expected, actual);
    }
}
