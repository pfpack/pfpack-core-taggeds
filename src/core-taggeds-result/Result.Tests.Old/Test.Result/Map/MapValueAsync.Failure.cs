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
    public void MapFailureValueAsync_MapFailureValueAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapFailureValueAsync<SomeError>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailureAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task MapFailureValueAsync_SourceIsDefaultOrFailure_FailureExpectResultOfMapFailureValueAsync(
        Result<RefType, StructType> source)
    {
        var failureResult = PlusFifteen;
        var actual = await source.MapFailureValueAsync(_ => ValueTask.FromResult(failureResult));

        var expected = new Result<RefType, int>(failureResult);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public async Task MapFailureValueAsync_SourceIsSuccessAndValueIsNull_ExpectResultOfNullSuccess(
        Result<RefType?, StructType> source)
    {
        var failureResult = decimal.MinusOne;
        var actual = await source.MapFailureValueAsync(_ => ValueTask.FromResult(failureResult));
            
        var expected = new Result<RefType?, decimal>(null);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task MapFailureValueAsync_SourceIsSuccess_ExpectResultOfSourceSuccess(
        Result<RefType, StructType> source)
    {
        var failureResult = default(SomeError);
        var actual = await source.MapFailureValueAsync(_ => ValueTask.FromResult(failureResult));
            
        var expected = new Result<RefType, SomeError>(PlusFifteenIdRefType);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
