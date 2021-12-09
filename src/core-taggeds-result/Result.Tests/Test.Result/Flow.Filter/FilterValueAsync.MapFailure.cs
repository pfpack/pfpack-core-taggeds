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

        Assert.AreEqual("predicateAsync", actualException!.ParamName);
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

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterValueAsync(
                _ => ValueTask.FromResult(true), null!, _ => ValueTask.FromResult(mapped)));

        Assert.AreEqual("causeFactoryAsync", actualException!.ParamName);
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

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterValueAsync(
                _ => ValueTask.FromResult(false), _ => ValueTask.FromResult(cause), null!));

        Assert.AreEqual("mapFailureAsync", actualException!.ParamName);
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
        Assert.AreEqual(expected, actual);
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
        Assert.AreEqual(expected, actual);
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
        Assert.AreEqual(expected, actual);
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
        Assert.AreEqual(expected, actual);
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
        Assert.AreEqual(expected, actual);
    }
}
