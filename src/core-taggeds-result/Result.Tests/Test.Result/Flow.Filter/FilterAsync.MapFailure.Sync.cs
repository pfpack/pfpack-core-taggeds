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
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void FilterAsyncWithMapFailureSync_PredicateIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var cause = int.MaxValue;
        var mapped = Zero;

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterAsync(null!, _ => Task.FromResult(cause), _ => mapped));

        Assert.AreEqual("predicateAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterAsyncWithMapFailureSync_CauseFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mapped = new SomeError(MinusFifteen);

        Func<RefType, Task<SomeError>> causeFactoryAsync = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterAsync(_ => Task.FromResult(true), causeFactoryAsync, _ => mapped));

        Assert.AreEqual("causeFactoryAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void FilterAsyncWithMapFailureSync_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var cause = default(SomeError);

        Func<StructType, SomeError> mapFailure = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterAsync(_ => Task.FromResult(false), _ => Task.FromResult(cause), mapFailure));

        Assert.AreEqual("mapFailure", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public async Task FilterAsyncWithMapFailureSync_PredicateReturnsTrueAndSourceIsNullSuccess_ExpectSuccessResultOfNull(
        Result<RefType?, StructType> source)
    {
        var cause = new SomeError(PlusFifteen);
        var mapped = new SomeError(int.MaxValue);

        var actual = await source.FilterAsync(
            _ => Task.FromResult(true),
            _ => Task.FromResult(cause),
            _ => mapped);

        var expected = new Result<RefType?, SomeError>(null);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task FilterAsyncWithMapFailureSync_PredicateReturnsTrueAndSourceIsNotNullSuccess_ExpectSuccessResultOfSorceValue(
        Result<RefType, StructType> source)
    {
        var cause = new SomeError(int.MaxValue);
        var mapped = new SomeError(int.MinValue);

        var actual = await source.FilterAsync(
            _ => Task.FromResult(true),
            _ => Task.FromResult(cause),
            _ => mapped);

        var expected = new Result<RefType, SomeError>(PlusFifteenIdRefType);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FilterAsyncWithMapFailureSync_PredicateReturnsTrueAndSourceIsFailure_ExpectFailureResultOfMappedValue(
        Result<RefType, StructType> source)
    {
        var cause = new SomeError(MinusFifteen);
        var mapped = new SomeError(PlusFifteen);

        var actual = await source.FilterAsync(
            _ => Task.FromResult(true),
            _ => Task.FromResult(cause),
            _ => mapped);

        var expected = new Result<RefType, SomeError>(mapped);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task FilterAsyncWithMapFailureSync_PredicateReturnsFalseAndSourceIsSuccess_ExpectResultOfCauseFailure(
        Result<RefType, StructType> source)
    {
        var cause = decimal.One;
        var mapped = decimal.MinValue;

        var actual = await source.FilterAsync(
            _ => Task.FromResult(false),
            _ => Task.FromResult(cause),
            _ => mapped);

        var expected = new Result<RefType, decimal>(cause);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FilterAsyncWithMapFailureSync_PredicateReturnsFalseAndSourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
        Result<RefType, StructType> source)
    {            
        var cause = new SomeError(int.MaxValue);
        var mapped = new SomeError(MinusFifteen);

        var actual = await source.FilterAsync(
            _ => Task.FromResult(false),
            _ => Task.FromResult(cause),
            _ => mapped);
            
        var expected = new Result<RefType, SomeError>(mapped);
        Assert.AreEqual(expected, actual);
    }
}
