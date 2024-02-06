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
    public void ForwardValueAsyncMapFailure_NextFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mappedFailure = new SomeError(PlusFifteen);

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.ForwardValueAsync<SomeRecord, SomeError>(null!,  _ => ValueTask.FromResult(mappedFailure)));

        Assert.That(actualException!.ParamName, Is.EqualTo("nextFactoryAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void ForwardValueAsyncMapFailure_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var next = new Result<SomeRecord, SomeError>(new SomeRecord());

        Func<StructType, ValueTask<SomeError>> mapFailureAsync = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), mapFailureAsync));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailureAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task ForwardValueAsyncMapFailure_SourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
        Result<RefType, StructType> source)
    {
        var next = new Result<SomeRecord, SomeError>(new SomeError(MinusFifteen));
        var mappedFailure = new SomeError(int.MaxValue);

        var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => ValueTask.FromResult(mappedFailure));
        var expected = new Result<SomeRecord, SomeError>(mappedFailure);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task ForwardValueAsyncMapFailure_SourceIsSuccessAndNextIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var next = default(Result<string, SomeError>);
        var mappedFailure = new SomeError(PlusFifteen);

        var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => ValueTask.FromResult(mappedFailure));
        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task ForwardValueAsyncMapFailure_SourceIsSuccessAndNextIsSuccess_ExpectNext(
        Result<RefType, StructType> source)
    {
        Result<RefType, SomeError> next = Result.Success(PlusFifteenIdRefType);
        var mappedFailure = new SomeError(int.MaxValue);

        var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => ValueTask.FromResult(mappedFailure));
        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task ForwardValueAsyncMapFailure_SourceIsSuccessAndNextIsFailure_ExpectNext(
        Result<RefType, StructType> source)
    {
        Result<SomeRecord, SomeError> next = Result.Failure(new SomeError(int.MinValue));
        var mappedFailure = new SomeError(PlusFifteen);

        var actual = await source.ForwardValueAsync(_ => ValueTask.FromResult(next), _ => ValueTask.FromResult(mappedFailure));
        Assert.That(actual, Is.EqualTo(next));
    }
}
