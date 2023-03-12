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
    public void FirstOrAbsent_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent();
    }

    [Test]
    public void FirstOrAbsent_CollectionSourceIsEmpty_ExpectAbsent()
    {
        var source = Enumerable.Empty<RefType>();

        var actual = source.FirstOrAbsent();
        var expected = Optional<RefType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void FirstOrAbsent_CollectionSourceIsNotEmpty_ExpectPresentFirstItem(
        object? firstItem)
    {
        var source = CreateCollection(firstItem, new object(), new { Value = SomeString });

        var actual = source.FirstOrAbsent();
        var expected = Optional<object?>.Present(firstItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FirstOrAbsentByPredicate_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent(static _ => true);
    }

    [Test]
    public void FirstOrAbsentByPredicate_CollectionPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateCollection(SomeTextStructType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.FirstOrAbsent(null!);
    }

    [Test]
    public void FirstOrAbsentByPredicate_CollectionPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateCollection(SomeTextStructType, NullTextStructType);

        var actual = source.FirstOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void FirstOrAbsentByPredicate_CollectionPredicateResultIsNotAlreadyFalse_ExpectPresentFirstSuccessful()
    {
        var expectedId = 171;
        var expectedValue = new RefType
        {
            Id = expectedId
        };

        var otherRefType = new RefType
        {
            Id = expectedId
        };

        var source = CreateCollection(PlusFifteenIdRefType, expectedValue, MinusFifteenIdRefType, null, otherRefType);

        var actual = source.FirstOrAbsent(item => item?.Id == expectedId);
        var expected = Optional<RefType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }
}
