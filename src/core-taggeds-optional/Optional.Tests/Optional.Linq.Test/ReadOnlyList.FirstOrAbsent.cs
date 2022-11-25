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
    public void FirstOrAbsent_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent();
    }

    [Test]
    public void FirstOrAbsent_ReadOnlyListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateReadOnlyList<RefType>();

        var actual = source.FirstOrAbsent();
        var expected = Optional<RefType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void FirstOrAbsent_ReadOnlyListSourceIsNotEmpty_ExpectPresentFirstItem(
        object? firstItem)
    {
        var source = CreateReadOnlyList(firstItem, new object(), new { Value = SomeString });

        var actual = source.FirstOrAbsent();
        var expected = Optional<object?>.Present(firstItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FirstOrAbsentByPredicate_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent(static _ => true);
    }

    [Test]
    public void FirstOrAbsentByPredicate_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateReadOnlyList(SomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent(null!);
    }

    [Test]
    public void FirstOrAbsentByPredicate_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

        var actual = source.FirstOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FirstOrAbsentByPredicate_ReadOnlyListPredicateResultIsNotAlreadyFalse_ExpectPresentFirstSuccessful()
    {
        const int expectedId = 171;

        var expectedValue = new RefType
        {
            Id = expectedId
        };

        var otherRefType = new RefType
        {
            Id = expectedId
        };

        var source = CreateReadOnlyList(PlusFifteenIdRefType, expectedValue, MinusFifteenIdRefType, null, otherRefType);

        var actual = source.FirstOrAbsent(Predicate);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);

        static bool Predicate(RefType? item)
            =>
            item?.Id is expectedId;
    }
}
