using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using System.Threading.Tasks;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterValueAsyncWithMapFailure_PredicateIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var cause = new SomeError(MinusFifteen);
        var mapped = new SomeError(int.MaxValue);

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterValueAsync(
                null!, _ => ValueTask.FromResult(cause), _ => ValueTask.FromResult(mapped)));

        Assert.That(actualException!.ParamName, Is.EqualTo("predicateAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterValueAsyncWithMapFailure_CauseFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mapped = new SomeError(MinusFifteen);

        Func<RefType, ValueTask<SomeError>> causeFactoryAsync = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterValueAsync(
                _ => ValueTask.FromResult(true), causeFactoryAsync, _ => ValueTask.FromResult(mapped)));

        Assert.That(actualException!.ParamName, Is.EqualTo("causeFactoryAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterValueAsyncWithMapFailure_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var cause = decimal.MinusOne;

        Func<StructType, ValueTask<decimal>> mapFailureAsync = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterValueAsync(
                _ => ValueTask.FromResult(false), _ => ValueTask.FromResult(cause), mapFailureAsync));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailureAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public async Task FilterValueAsyncWithMapFailure_PredicateReturnsTrueAndSourceIsNullSuccess_ExpectSuccessResultOfNull(
        Result<RefType?, StructType> source)
    {
        var cause = new SomeError(MinusFifteen);
        var mapped = new SomeError(int.MinValue);

        var actual = await source.FilterValueAsync(
            _ => ValueTask.FromResult(true),
            _ => ValueTask.FromResult(cause),
            _ => ValueTask.FromResult(mapped));

        var expected = new Result<RefType?, SomeError>(null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task FilterValueAsyncWithMapFailure_PredicateReturnsTrueAndSourceIsSuccess_ExpectSuccessResultOfSorceValue(
        Result<RefType, StructType> source)
    {
        var cause = PlusFifteen;
        var mapped = int.MaxValue;

        var actual = await source.FilterValueAsync(
            _ => ValueTask.FromResult(true),
            _ => ValueTask.FromResult(cause),
            _ => ValueTask.FromResult(mapped));

        var expected = new Result<RefType, int>(MinusFifteenIdRefType);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FilterValueAsyncWithMapFailure_PredicateReturnsTrueAndSourceIsFailure_ExpectFailureResultOfMappedValue(
        Result<RefType, StructType> source)
    {
        var cause = new SomeError(MinusFifteen);
        var mapped = new SomeError(PlusFifteen);

        var actual = await source.FilterValueAsync(
            _ => ValueTask.FromResult(true),
            _ => ValueTask.FromResult(cause),
            _ => ValueTask.FromResult(mapped));

        var expected = new Result<RefType, SomeError>(mapped);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task FilterValueAsyncWithMapFailure_PredicateReturnsFalseAndSourceIsSuccess_ExpectResultOfCauseFailure(
        Result<RefType, StructType> source)
    {
        var cause = decimal.MaxValue;
        var mapped = decimal.MinusOne;

        var actual = await source.FilterValueAsync(
            _ => ValueTask.FromResult(false),
            _ => ValueTask.FromResult(cause),
            _ => ValueTask.FromResult(mapped));

        var expected = new Result<RefType, decimal>(cause);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FilterValueAsyncWithMapFailure_PredicateReturnsFalseAndSourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
        Result<RefType, StructType> source)
    {            
        var cause = new SomeError(int.MinValue);
        var mapped = new SomeError(PlusFifteen);

        var actual = await source.FilterValueAsync(
            _ => ValueTask.FromResult(false),
            _ => ValueTask.FromResult(cause),
            _ => ValueTask.FromResult(mapped));
            
        var expected = new Result<RefType, SomeError>(mapped);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
