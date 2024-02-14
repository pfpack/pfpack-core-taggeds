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
    public void FirstOrAbsent_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.FirstOrAbsent();
    }

    [Test]
    public void FirstOrAbsent_ListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateList<StructType?>();

        var actual = source.FirstOrAbsent();
        var expected = Optional<StructType?>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void FirstOrAbsent_ListSourceIsNotEmpty_ExpectPresentFirstItem(
        object? firstItem)
    {
        var source = CreateList(firstItem, new object(), new { Value = SomeString });

        var actual = source.FirstOrAbsent();
        var expected = Optional<object?>.Present(firstItem);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FirstOrAbsentByPredicate_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.FirstOrAbsent(static _ => true);
    }

    [Test]
    public void FirstOrAbsentByPredicate_ListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateList(SomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("predicate"));

        void Test()
            =>
            _ = source.FirstOrAbsent(null!);
    }

    [Test]
    public void FirstOrAbsentByPredicate_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateList(PlusFifteenIdRefType, MinusFifteenIdRefType, ZeroIdRefType, null);

        var actual = source.FirstOrAbsent(static _ => false);
        var expected = Optional<RefType?>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FirstOrAbsentByPredicate_ListPredicateResultIsNotAlreadyFalse_ExpectPresentFirstSuccessful()
    {
        const int expectedId = 1015;

        var expectedValue = new RefType
        {
            Id = expectedId
        };

        var otherRefType = new RefType
        {
            Id = expectedId
        };

        var source = CreateList(PlusFifteenIdRefType, expectedValue, MinusFifteenIdRefType, null, otherRefType);

        var actual = source.FirstOrAbsent(Predicate);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));

        static bool Predicate(RefType? item)
            =>
            item?.Id is expectedId;
    }
}
