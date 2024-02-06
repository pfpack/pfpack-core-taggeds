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
    public void MapValueAsync_MapSuccessAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var failureResult = default(SomeError);

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapValueAsync<DateTime, SomeError>(null!, _ => ValueTask.FromResult(failureResult)));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapSuccessAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void MapValueAsync_MapFailureAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = SomeString
        };

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapValueAsync<SomeRecord, int>(_ => ValueTask.FromResult(successResult), null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailureAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task MapValueAsync_SourceIsSuccess_ExpectSuccessResultOfMapSuccess(
        Result<RefType, StructType> source)
    {
        var successResult = (SomeRecord?)null;
        var failureResult = new SomeError(PlusFifteen);

        var actual = await source.MapValueAsync(
            _ => ValueTask.FromResult(successResult),
            _ => ValueTask.FromResult(failureResult));

        var expected = new Result<SomeRecord?, SomeError>(successResult);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task MapValueAsync_SourceIsDefaultOrFailure_ExpectFailureResultOfMapFailure(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = SomeString
        };
        var failureResult = int.MaxValue;

        var actual = await source.MapValueAsync(
            _ => ValueTask.FromResult(successResult),
            _ => ValueTask.FromResult(failureResult));

        var expected = new Result<SomeRecord, int>(failureResult);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
