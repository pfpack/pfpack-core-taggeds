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
    public void FoldValueAsync_MapSuccessAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var failureResult = SomeString;

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FoldValueAsync(null!, _ => ValueTask.FromResult(failureResult)));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapSuccessAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FoldValueAsync_MapFailureAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var successResult = new object();

        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.FoldValueAsync(_ => ValueTask.FromResult(successResult), null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailureAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task FoldValueAsync_SourceIsSuccess_ExpectResultOfMapSuccess(
        Result<RefType, StructType> source)
    {
        var successResult = int.MaxValue;
        var failureResult = PlusFifteen;

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(successResult),
            _ => ValueTask.FromResult(failureResult));

        Assert.That(actual, Is.EqualTo(successResult));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FoldValueAsync_SourceIsDefaultOrFailure_ExpectResultOfMapFailure(
        Result<RefType, StructType> source)
    {
        SomeError? successResult = new SomeError(PlusFifteen);
        SomeError? failureResult = null;

        var actual = await source.FoldValueAsync(
            _ => ValueTask.FromResult(successResult),
            _ => ValueTask.FromResult(failureResult));

        Assert.That(actual, Is.EqualTo(failureResult));
    }
}
