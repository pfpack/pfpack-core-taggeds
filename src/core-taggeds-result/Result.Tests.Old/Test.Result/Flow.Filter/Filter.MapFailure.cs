using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterWithMapFailure_PredicateIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var causeFailure = new SomeError(MinusFifteen);
        var mappedFailure = new SomeError(int.MinValue);

        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Filter(null!, _ => causeFailure, _ => mappedFailure));

        Assert.That(actualException!.ParamName, Is.EqualTo("predicate"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void FilterWithMapFailure_CauseFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mappedFailure = new SomeError(int.MaxValue);

        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Filter(_ => false, null!, _ => mappedFailure));

        Assert.That(actualException!.ParamName, Is.EqualTo("causeFactory"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void FilterWithMapFailure_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var causeFailure = new SomeError(int.MinValue);

        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Filter(_ => true, _ => causeFailure, null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailure"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void FilterWithMapFailure_PredicateReturnsTrueAndSourceIsNullSuccess_ExpectSuccessResultOfNull(
        Result<RefType?, StructType> source)
    {
        var causeFailure = PlusFifteen;
        var mappedFailure = int.MaxValue;

        var actual = source.Filter(
            _ => true,
            _ => causeFailure,
            _ => mappedFailure);

        var expected = new Result<RefType?, int>(null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void FilterWithMapFailure_PredicateReturnsTrueAndSourceIsNotNullSuccess_ExpectSuccessResultOfSorceValue(
        Result<RefType?, StructType> source)
    {
        var causeFailure = new SomeError(Zero);
        var mappedFailure = new SomeError(int.MinValue);

        var actual = source.Filter(
            _ => true,
            _ => causeFailure,
            _ => mappedFailure);

        var expected = new Result<RefType, SomeError>(MinusFifteenIdRefType);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void FilterWithMapFailure_PredicateReturnsTrueAndSourceIsFailure_ExpectFailureResultOfMappedValue(
        Result<RefType?, StructType> source)
    {
        var causeFailure = new SomeError(MinusFifteen);
        var mappedFailure = new SomeError(PlusFifteen);

        var actual = source.Filter(
            _ => true,
            _ => causeFailure,
            _ => mappedFailure);

        var expected = new Result<RefType, SomeError>(mappedFailure);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterWithMapFailure_PredicateReturnsFalseAndSourceIsSuccess_ExpectResultOfCauseFailure(
        Result<RefType, StructType> source)
    {
        var causeFailure = decimal.MaxValue;
        var mappedFailure = decimal.MinusOne;

        var actual = source.Filter(
            _ => false,
            _ => causeFailure,
            _ => mappedFailure);

        var expected = new Result<RefType, decimal>(causeFailure);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void FilterWithMapFailure_PredicateReturnsFalseAndSourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
        Result<RefType, StructType> source)
    {            
        var causeFailure = new SomeError(Zero);
        var mappedFailure = new SomeError(PlusFifteen);

        var actual = source.Filter(
            _ => false,
            _ => causeFailure,
            _ => mappedFailure);
            
        var expected = new Result<RefType, SomeError>(mappedFailure);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
