using PrimeFuncPack.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalLinqExtensionsTests
{
    [Test]
    public void SingleOrAbsent_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.SingleOrAbsent();
    }

    [Test]
    public void SingleOrAbsent_ListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateList<StructType>();

        var actual = source.SingleOrAbsent();
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void SingleOrAbsent_ListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
        object? singleItem)
    {
        var source = CreateList(singleItem);

        var actual = source.SingleOrAbsent();
        var expected = Optional<object?>.Present(singleItem);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SingleOrAbsent_ListSourceContainsMoreThanOneElement_ExpectInvalidOperationException()
    {
        var source = CreateList(PlusFifteenIdRefType, MinusFifteenIdRefType);
        _ = Assert.Throws<InvalidOperationException>(Test);

        void Test()
            =>
            _ = source.SingleOrAbsent();
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.SingleOrAbsent(CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ListExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = CreateList(PlusFifteenIdRefType);
        Func<Exception> exceptionFactory = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("moreThanOneElementExceptionFactory"));

        void Test()
            =>
            _ = source.SingleOrAbsent(exceptionFactory);
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ListSourceIsEmpty_ExpectAbsent()
    {
        var source = CreateList<StructType>();

        var actual = source.SingleOrAbsent(CreateSomeException);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.ObjectNullableTestSource))]
    public void SingleOrAbsentWithExceptionFactory_ListSourceContainsOnlyOneElement_ExpectPresentSingleElement(
        object? singleItem)
    {
        var source = CreateList(singleItem);

        var actual = source.SingleOrAbsent(CreateSomeException);
        var expected = Optional<object?>.Present(singleItem);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SingleOrAbsentWithExceptionFactory_ListSourceContainsMoreThanOneElement_ExpectCreatedException()
    {
        var source = CreateList(PlusFifteenIdRefType, MinusFifteenIdRefType);
        var createdException = new SomeException();

        var ex = Assert.Throws<SomeException>(Test);
        Assert.That(ex, Is.SameAs(createdException));

        void Test()
            =>
            _ = source.SingleOrAbsent(() => createdException);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateList(MinusFifteenIdRefType);
        Func<RefType, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("predicate"));

        void Test()
            =>
            _ = source.SingleOrAbsent(predicate);
    }

    [Test]
    public void SingleOrAbsentByPredicate_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateList(SomeTextStructType, NullTextStructType);

        var actual = source.SingleOrAbsent(static _ => false);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SingleOrAbsentByPredicate_ListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
    {
        var expectedText = "Expected Text";
        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var source = CreateList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

        var actual = source.SingleOrAbsent(item => expectedText.Equals(item?.Text, StringComparison.InvariantCultureIgnoreCase));
        var expected = Optional<StructType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SingleOrAbsentByPredicate_ListPredicateResultIsTrueMoreThanOneTime_ExpectInvalidOperationException()
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

        var source = CreateList<StructType?>(
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
    public void SingleOrAbsentByPredicateAndFactory_ListSourceIsNull_ExpectArgumentNullException()
    {
        IList<StructType> source = null!;
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("source"));

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false, CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ListPredicateIsNull_ExpectArgumentNullException()
    {
        var source = CreateList(MinusFifteenIdRefType);
        Func<RefType, bool> predicate = null!;

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.That(ex!.ParamName, Is.EqualTo("predicate"));

        void Test()
            =>
            _ = source.SingleOrAbsent(predicate, CreateSomeException);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ListExceptionFactoryIsNull_ExpectArgumentNullException()
    {
        var source = CreateList(MinusFifteenIdRefType);
        var ex = Assert.Throws<ArgumentNullException>(Test);

        Assert.That(ex!.ParamName, Is.EqualTo("moreThanOneMatchExceptionFactory"));

        void Test()
            =>
            _ = source.SingleOrAbsent(static _ => false, null!);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ListPredicateResultIsAlreadyFalse_ExpectAbsent()
    {
        var source = CreateList(SomeTextStructType, NullTextStructType);

        var actual = source.SingleOrAbsent(static _ => false, CreateSomeException);
        var expected = Optional<StructType>.Absent;

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ListPredicateResultIsTrueOnlyOnce_ExpectPresentSuccessfulElement()
    {
        const string expectedText = "Expected Text";

        var expectedValue = new StructType
        {
            Text = expectedText
        };

        var source = CreateList<StructType?>(SomeTextStructType, expectedValue, NullTextStructType, null);

        var actual = source.SingleOrAbsent(Predicate, CreateSomeException);
        var expected = Optional<StructType?>.Present(expectedValue);

        Assert.That(actual, Is.EqualTo(expected));

        static bool Predicate(StructType? item)
            =>
            string.Equals(expectedText, item?.Text, StringComparison.InvariantCultureIgnoreCase);
    }

    [Test]
    public void SingleOrAbsentByPredicateAndFactory_ListPredicateResultIsTrueMoreThanOneTime_ExpectCreatedException()
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

        var source = CreateList<StructType?>(
            SomeTextStructType, expectedValue, NullTextStructType, null, expectedTextStructType);

        var createdException = new SomeException();
        var actualException = Assert.Throws<SomeException>(Test);

        Assert.That(actualException, Is.SameAs(createdException));

        void Test()
            =>
            _ = source.SingleOrAbsent(Predicate, () => createdException);

        static bool Predicate(StructType? item)
            =>
            string.Equals(expectedText, item?.Text, StringComparison.InvariantCultureIgnoreCase);
    }
}
