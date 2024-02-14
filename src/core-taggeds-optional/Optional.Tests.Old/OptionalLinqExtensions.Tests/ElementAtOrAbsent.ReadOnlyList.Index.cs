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
    public void ElementAtOrAbsentByIndex_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var index = Index.FromStart(1);

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
    [TestCase(3)]
    public void ElementAtOrAbsentByIndex_ReadOnlyListIndexIsInRange_ExpectPresentItem(
        int indexValue)
    {
        var index = Index.FromStart(indexValue);

        var source = CreateReadOnlyList(null, MinusFifteenIdRefType, ZeroIdRefType, PlusFifteenIdRefType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(2)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByIndex_ReadOnlyListIndexIsNotInRange_ExpectAbsent(
        int indexValue)
    {
        var index = Index.FromStart(indexValue);

        var source = CreateReadOnlyList(SomeTextStructType, default);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByIndex_ReadOnlyListIsEmpty_ExpectAbsent(
        int indexValue)
    {
        var index = Index.FromStart(indexValue);

        var source = CreateReadOnlyList<StructType>();

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
