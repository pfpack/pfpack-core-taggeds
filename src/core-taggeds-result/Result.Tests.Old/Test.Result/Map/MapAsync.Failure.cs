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
    public void MapFailureAsync_MapFailureAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapFailureAsync<int>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailureAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task MapFailureAsync_SourceIsDefaultOrFailure_FailureExpectResultOfMapFailureAsync(
        Result<RefType, StructType> source)
    {
        var failureResult = new SomeError(PlusFifteen);
        var actual = await source.MapFailureAsync(_ => Task.FromResult(failureResult));

        var expected = new Result<RefType, SomeError>(failureResult);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public async Task MapFailureAsync_SourceIsSuccessAndValueIsNull_ExpectResultOfNullSuccess(
        Result<RefType?, StructType> source)
    {
        var failureResult = decimal.MinusOne;
        var actual = await source.MapFailureAsync(_ => Task.FromResult(failureResult));
            
        var expected = new Result<RefType?, decimal>(null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task MapFailureAsync_SourceIsSuccess_ExpectResultOfSourceSuccess(
        Result<RefType, StructType> source)
    {
        var failureResult = new SomeError(int.MaxValue);
        var actual = await source.MapFailureAsync(_ => Task.FromResult(failureResult));
            
        var expected = new Result<RefType, SomeError>(PlusFifteenIdRefType);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
