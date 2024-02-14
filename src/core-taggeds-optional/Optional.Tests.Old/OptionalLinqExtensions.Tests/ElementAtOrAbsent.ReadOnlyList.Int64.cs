using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqExtensionsTests
{
    [Test]
    public void ElementAtOrAbsentByLong_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        long index = 1;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.ElementAtOrAbsent(index);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ElementAtOrAbsentByLong_ReadOnlyListIndexIsInRange_ExpectPresentItem(
        long index)
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType, null, ZeroIdRefType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(checked((int)index));
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
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

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(long.MinValue)]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(long.MaxValue)]
    public void ElementAtOrAbsentByLong_ReadOnlyListIsEmpty_ExpectAbsent(
        long index)
    {
        var source = CreateReadOnlyList<RefType>();

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
