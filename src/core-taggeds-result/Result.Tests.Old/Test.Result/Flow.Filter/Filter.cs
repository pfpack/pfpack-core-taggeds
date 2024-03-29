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
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void Filter_PredicateIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Filter(null!, _ => SomeTextStructType));

        Assert.That(actualException!.ParamName, Is.EqualTo("predicate"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void Filter_CauseFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Filter(_ => true, null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("causeFactory"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void Filter_PredicateReturnsTrue_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        var causeFailure = SomeTextStructType;

        var actual = source.Filter(
            _ => true,
            _ => causeFailure);

        Assert.That(actual, Is.EqualTo(source));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void Filter_PredicateReturnsFalseAndSourceIsSuccess_ExpectResultOfCauseFailure(
        Result<RefType, StructType> source)
    {
        var causeFailure = SomeTextStructType;
        var actual = source.Filter(
            _ => false,
            _ => causeFailure);

        var expected = new Result<RefType, StructType>(causeFailure);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void Filter_PredicateReturnsFalseAndSourceIsDefaultOrFailure_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        var causeFailure = new StructType
        {
            Text = "Some error message."
        };

        var actual = source.Filter(
            _ => false,
            _ => causeFailure);

        Assert.That(actual, Is.EqualTo(source));
    }
}
