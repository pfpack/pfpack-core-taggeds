﻿using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqExtensionsTests
{
    [Test]
    public void LastOrAbsent_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.LastOrAbsent();
    }

    [Test]
    public void LastOrAbsent_ReadOnlyListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateReadOnlyList<RefType>();

        var actual = source.LastOrAbsent();
        var expected = Optional<RefType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void LastOrAbsent_ReadOnlyListSourceIsNotEmpty_ExpectPresentLastItem(
        object? lastItem)
    {
        var source = CreateReadOnlyList(new object(), new { Value = SomeString }, lastItem);

        var actual = source.LastOrAbsent();
        var expected = Optional<object?>.Present(lastItem);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LastOrAbsentByPredicate_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.LastOrAbsent(static _ => true);
    }

    [Test]
    public void LastOrAbsentByPredicate_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateReadOnlyList(SomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("predicate"));

        void Test()
            =>
            _ = source.LastOrAbsent(null!);
    }

    [Test]
    public void LastOrAbsentByPredicate_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

        var actual = source.LastOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void LastOrAbsentByPredicate_ReadOnlyListPredicateResultIsNotAlreadyFalse_ExpectPresentLastSuccessful()
    {
        const int expectedId = 255;

        var expectedValue = new RefType
        {
            Id = expectedId
        };

        var otherRefType = new RefType
        {
            Id = expectedId
        };

        var source = CreateReadOnlyList(
            PlusFifteenIdRefType, otherRefType, MinusFifteenIdRefType, null, expectedValue, ZeroIdRefType);

        var actual = source.LastOrAbsent(Predicate);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));

        static bool Predicate(RefType? item)
            =>
            item?.Id is expectedId;
    }
}
