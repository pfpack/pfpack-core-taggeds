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
    public void ElementAtOrAbsentByInt_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        int index = 1;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
        Assert.That(ex!.ParamName, Is.EqualTo("source"));
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ElementAtOrAbsentByInt_CollectionIndexIsInRange_ExpectPresentItem(
        int index)
    {
        var source = CreateCollection(PlusFifteenIdRefType, null, ZeroIdRefType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(int.MinValue)]
    [TestCase(-1)]
    [TestCase(3)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByInt_CollectionIndexIsNotInRange_ExpectAbsent(
        int index)
    {
        var source = CreateCollection(NullTextStructType, SomeTextStructType, default);

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
    public void ElementAtOrAbsentByInt_CollectionIsEmpty_ExpectAbsent(
        int index)
    {
        var source = CreateCollection<StructType>();

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }
}
