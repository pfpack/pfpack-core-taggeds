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
    public void LastOrAbsent_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<RefType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.LastOrAbsent();
    }

    [Test]
    public void LastOrAbsent_ListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateList<StructType>();

        var actual = source.LastOrAbsent();
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void LastOrAbsent_ListSourceIsNotEmpty_ExpectPresentLastItem(
        object? lastItem)
    {
        var source = CreateList(new object(), new { Value = SomeString }, lastItem);

        var actual = source.LastOrAbsent();
        var expected = Optional<object?>.Present(lastItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void LastOrAbsentByPredicate_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.LastOrAbsent(static _ => true);
    }

    [Test]
    public void LastOrAbsentByPredicate_ListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateList(SomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.LastOrAbsent(null!);
    }

    [Test]
    public void LastOrAbsentByPredicate_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateList(SomeTextStructType, NullTextStructType);

        var actual = source.LastOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void LastOrAbsentByPredicate_ListPredicateResultIsNotAlreadyFalse_ExpectPresentLastSuccessful()
    {
        const int expectedId = 75;

        var expectedValue = new RefType
        {
            Id = expectedId
        };

        var otherRefType = new RefType
        {
            Id = expectedId
        };

        var source = CreateList(
            PlusFifteenIdRefType, otherRefType, MinusFifteenIdRefType, null, expectedValue, ZeroIdRefType);

        var actual = source.LastOrAbsent(Predicate);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);

        static bool Predicate(RefType? item)
            =>
            item?.Id is expectedId;
    }
}
