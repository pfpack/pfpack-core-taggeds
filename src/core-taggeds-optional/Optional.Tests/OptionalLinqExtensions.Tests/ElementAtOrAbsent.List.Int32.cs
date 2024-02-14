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
    public void ElementAtOrAbsentByInt_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<RefType> source = null!;
        int index = 1;

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
    public void ElementAtOrAbsentByInt_ListIndexIsInRange_ExpectPresentItem(
        int index)
    {
        var source = CreateList<StructType?>(SomeTextStructType, null, NullTextStructType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<StructType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(int.MinValue)]
    [TestCase(-1)]
    [TestCase(2)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByInt_ListIndexIsNotInRange_ExpectAbsent(
        int index)
    {
        var source = CreateList(SomeTextStructType, default);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(int.MinValue)]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByInt_ListIsEmpty_ExpectAbsent(
        int index)
    {
        var source = CreateList<StructType>();

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
