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
    public void MapAsync_MapSuccessAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var failureResult = new SomeError(MinusFifteen);

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapAsync<int, SomeError>(null!, _ => Task.FromResult(failureResult)));

        Assert.AreEqual("mapSuccessAsync", actualException!.ParamName);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void MapAsync_MapFailureAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var successResult = EmptyString;

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapAsync<string, SomeError>(_ => Task.FromResult(successResult), null!));

        Assert.AreEqual("mapFailureAsync", actualException!.ParamName);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task MapAsync_SourceIsSuccess_ExpectSuccessResultOfMapSuccess(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = SomeString
        };
        var failureResult = MinusFifteen;

        var actual = await source.MapAsync(
            _ => Task.FromResult(successResult),
            _ => Task.FromResult(failureResult));

        var exected = new Result<SomeRecord, int>(successResult);
        Assert.AreEqual(exected, actual);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task MapAsync_SourceIsDefaultOrFailure_ExpectFailureResultOfMapFailure(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = EmptyString
        };

        var failureResult = default(SomeError);

        var actual = await source.MapAsync(
            _ => Task.FromResult(successResult),
            _ => Task.FromResult(failureResult));

        var exected = new Result<SomeRecord, SomeError>(failureResult);
        Assert.AreEqual(exected, actual);
    }
}
