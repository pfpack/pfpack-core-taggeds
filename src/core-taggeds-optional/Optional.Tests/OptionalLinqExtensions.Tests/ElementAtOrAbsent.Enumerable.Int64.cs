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
    public void ElementAtOrAbsentByLong_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        long index = 1;

        var ex = Assert.Throws<ArgumentNullException>(() => _ = source.ElementAtOrAbsent(index));
        Assert.AreEqual("source", ex?.ParamName);
    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    public void ElementAtOrAbsentByLong_CollectionIndexIsInRange_ExpectPresentItem(
        long index)
    {
        var source = CreateCollection<StructType?>(SomeTextStructType, NullTextStructType, null);
        var actual = source.ElementAtOrAbsent(index);

        var expectedValue = source.ElementAt(checked((int)index));
        var expected = Optional<StructType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(long.MinValue)]
    [TestCase(-1)]
    [TestCase(3)]
    [TestCase(long.MaxValue)]
    public void ElementAtOrAbsentByLong_CollectionIndexIsNotInRange_ExpectAbsent(
        long index)
    {
        var source = CreateCollection(PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType);

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<RefType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(long.MinValue)]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(long.MaxValue)]
    public void ElementAtOrAbsentByLong_CollectionIsEmpty_ExpectAbsent(
        long index)
    {
        var source = CreateCollection<RefType>();

        var actual = source.ElementAtOrAbsent(index);
        var expected = Optional<RefType>.Absent;

        Assert.AreEqual(expected, actual);
    }
}
