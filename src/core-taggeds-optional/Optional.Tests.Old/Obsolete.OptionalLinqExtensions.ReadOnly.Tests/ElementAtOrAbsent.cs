using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ObsoleteReadOnlyOptionalLinqExtensionsTests
{
    [Test]
    public void ElementAtOrAbsentByInt_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        int index = 1;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = OptionalLinqExtensions.ElementAtOrAbsent(source, index);
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
        var actual = OptionalLinqExtensions.ElementAtOrAbsent(source, index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
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

        var actual = OptionalLinqExtensions.ElementAtOrAbsent(source, index);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ElementAtOrAbsentByLong_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        long index = 1;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = OptionalLinqExtensions.ElementAtOrAbsent(source, index);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ElementAtOrAbsentByLong_ReadOnlyListIndexIsInRange_ExpectPresentItem(
        int index)
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType, null, ZeroIdRefType);
        var actual = OptionalLinqExtensions.ElementAtOrAbsent(source, index);

        var expectedValue = source.ElementAt(index);
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

        var actual = OptionalLinqExtensions.ElementAtOrAbsent(source, index);
        var expected = Optional<RefType?>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
