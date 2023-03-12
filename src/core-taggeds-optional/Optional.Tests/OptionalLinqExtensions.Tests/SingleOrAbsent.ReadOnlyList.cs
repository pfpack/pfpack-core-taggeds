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
    public void SingleOrAbsent_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent();
    }

    [Test]
    public void SingleOrAbsent_ReadOnlyListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateReadOnlyList<StructType>();

        var actual = source.SingleOrAbsent();
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void SingleOrAbsent_ReadOnlyListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
        object? singleItem)
    {
        var source = CreateReadOnlyList(singleItem);

        var actual = source.SingleOrAbsent();
        var expected = Optional<object?>.Present(singleItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsent_ReadOnlyListSourceContainsMoreThanOneElement_ExpectInvalidOperationException()
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType, MinusFifteenIdRefType);
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.SingleOrAbsent();
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ReadOnlyListExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType);
        Func<Exception> exceptionFactory = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("moreThanOneElementExceptionFactory", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(exceptionFactory);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateReadOnlyList<StructType>();

        var actual = source.SingleOrAbsent(CreateSomeException);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
        object? singleItem)
    {
        var source = CreateReadOnlyList(singleItem);

        var actual = source.SingleOrAbsent(CreateSomeException);
        var expected = Optional<object?>.Present(singleItem);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ReadOnlyListSourceContainsMoreThanOneElement_ExpectCreatedException()
    {
        var source = CreateReadOnlyList(PlusFifteenIdRefType, MinusFifteenIdRefType);
        var createdException = new SomeException();

        var ex = Assert.Throws<SomeException>(Test);
        Assert.AreSame(createdException, ex);

        void Test()
            =>
            _ = source.SingleOrAbsent(() => createdException);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateReadOnlyList(MinusFifteenIdRefType);
        Func<RefType, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(predicate);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

        var actual = source.SingleOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ReadOnlyListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
    {
        var expectedText = "Expected Text";
        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var source = CreateReadOnlyList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

        var actual = source.SingleOrAbsent(item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));
        var expected = Optional<StructType?>.Present(expectedValue);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ReadOnlyListPredicateResultIsTrueMoreThanOneTime_ExpectInvalidOperationException()
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

        var source = CreateReadOnlyList<StructType?>(
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
    public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListSourceIsNull_ExpectArgumentNullException()
    {
        IReadOnlyList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("source", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false, CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateReadOnlyList(MinusFifteenIdRefType);
        Func<RefType, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.AreEqual("predicate", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(predicate, CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = CreateReadOnlyList(MinusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.AreEqual("moreThanOneMatchExceptionFactory", ex?.ParamName);

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false, null!);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateReadOnlyList(SomeTextStructType, NullTextStructType);

        var actual = source.SingleOrAbsent(static _ => false, CreateSomeException);
        var expected = Optional<StructType>.Absent;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
    {
        const string expectedText = "Expected Text";

        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var source = CreateReadOnlyList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

        var actual = source.SingleOrAbsent(item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase), CreateSomeException);

        var expected = Optional<StructType?>.Present(expectedValue);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ReadOnlyListPredicateResultIsTrueMoreThanOneTime_ExpectCreatedException()
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

        var source = CreateReadOnlyList<StructType?>(
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
