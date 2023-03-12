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
    public void SingleOrAbsent_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent();
    }

    [Test]
    public void SingleOrAbsent_CollectionSourceIsEmpty_ExpectAbsent()
    {
        var source = Enumerable.Empty<StructType>();

        var actual = source.SingleOrAbsent();
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void SingleOrAbsent_CollectionSourceContainsOnlyOneElement_ExpectPresentSingleElement(
        object? singleItem)
    {
        var source = CreateCollection(singleItem);

        var actual = source.SingleOrAbsent();
        var expected = Optional<object?>.Present(singleItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsent_CollectionSourceContainsMoreThanOneElement_ExpectInvalidOperationException()
    {
        var source = CreateCollection(PlusFifteenIdRefType, MinusFifteenIdRefType);
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.SingleOrAbsent();
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_CollectionExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = CreateCollection(PlusFifteenIdRefType);
        Func<Exception> exceptionFactory = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("moreThanOneElementExceptionFactory", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(exceptionFactory);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_CollectionSourceIsEmpty_ExpectAbsent()
    {
        var source = Enumerable.Empty<StructType>();

        var actual = source.SingleOrAbsent(CreateSomeException);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void SingleOrAbsentWithExceptionFactory_CollectionSourceContainsOnlyOneElement_ExpectPresentSingleElement(
        object? singleItem)
    {
        var source = CreateCollection(singleItem);

        var actual = source.SingleOrAbsent(CreateSomeException);
        var expected = Optional<object?>.Present(singleItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_CollectionSourceContainsMoreThanOneElement_ExpectCreatedException()
    {
        var source = CreateCollection(PlusFifteenIdRefType, MinusFifteenIdRefType);
        var createdException = new SomeException();

        var ex = Assert.Throws<SomeException>(Test);
        Assert.AreSame(createdException, ex);

        void Test()
            =>
            _ = source.SingleOrAbsent(() => createdException);
    }

    [Test]
    public void SingleOrAbsentByPredicate_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false);
    }

    [Test]
    public void SingleOrAbsentByPredicate_CollectionPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateCollection(MinusFifteenIdRefType);
        Func<RefType, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(predicate);
    }

    [Test]
    public void SingleOrAbsentByPredicate_CollectionPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateCollection(SomeTextStructType, NullTextStructType);

        var actual = source.SingleOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicate_CollectionPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
    {
        var expectedText = "Expected Text";
        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var source = CreateCollection<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

        var actual = source.SingleOrAbsent(item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));
        var expected = Optional<StructType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicate_CollectionPredicateResultIsTrueMoreThanOneTime_ExpectInvalidOperationException()
    {
        const string expectedText = "Expected Text";

        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var expectedTextStructType = new StructType
        {
            Text = expectedText
        };

        var source = CreateCollection<StructType?>(
            SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.SingleOrAbsent(Predicate);

        static bool Predicate(StructType? item)
            =>
            string.Equals(expectedText, item?.Text, StringComparison.InvariantCultureIgnoreCase);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_CollectionSourceIsNull_ExpectArgumentNullException()
    {
        IEnumerable<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(Predicate, CreateSomeException);

        static bool Predicate(StructType _)
            =>
            false;
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_CollectionPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateCollection(MinusFifteenIdRefType);
        Func<RefType, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(predicate, CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_CollectionExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = CreateCollection(MinusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("moreThanOneMatchExceptionFactory", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(Predicate, null!);

        static bool Predicate(RefType _)
            =>
            false;
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_CollectionPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateCollection(SomeTextStructType, NullTextStructType);

        var actual = source.SingleOrAbsent(static _ => false, CreateSomeException);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_CollectionPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
    {
        var expectedText = "Expected Text";
        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var source = CreateCollection<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

        var actual = source.SingleOrAbsent(
            item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase),
            CreateSomeException);

        var expected = Optional<StructType?>.Present(expectedValue);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_CollectionPredicateResultIsTrueMoreThanOneTime_ExpectCreatedException()
    {
        const string expectedText = "Expected Text";

        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var expectedTextStructType = new StructType
        {
            Text = expectedText
        };

        var source = CreateCollection<StructType?>(
            SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

        var createdException = new SomeException();
        var actualException = Assert.Throws<SomeException>(Test);

        Assert.AreSame(createdException, actualException);

        void Test()
            =>
            _ = source.SingleOrAbsent(Predicate, () => createdException);

        static bool Predicate(StructType? item)
            =>
            string.Equals(expectedText, item?.Text, StringComparison.InvariantCultureIgnoreCase);
    }
}
