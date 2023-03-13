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
    public void ElementAtOrAbsentByIndex_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var index = Index.FromStart(1);

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
        Assert.AreEqual("source", ex?.ParamName);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ElementAtOrAbsentByIndex_CollectionIndexIsInRange_ExpectPresentItem(
        int indexValue)
    {
        var index = Index.FromStart(indexValue);

        var source = CreateCollection(PlusFifteenIdRefType, null, ZeroIdRefType);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(index);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(3)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByIndex_CollectionIndexIsNotInRange_ExpectAbsent(
        int indexValue)
    {
        var index = Index.FromStart(indexValue);

        var source = CreateCollection(NullTextStructType, SomeTextStructType, default);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(int.MaxValue)]
    public void ElementAtOrAbsentByIndex_CollectionIsEmpty_ExpectAbsent(
        int indexValue)
    {
        var index = Index.FromStart(indexValue);

        var source = CreateCollection<StructType>();

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }
}
