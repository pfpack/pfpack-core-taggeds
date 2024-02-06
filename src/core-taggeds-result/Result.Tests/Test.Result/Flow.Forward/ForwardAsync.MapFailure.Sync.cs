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
    public void ForwardAsyncMapFailureSync_NextFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mappedFailure = new SomeError(PlusFifteen);

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.ForwardAsync<SomeRecord, SomeError>(null!,  _ => mappedFailure));

        Assert.That(actualException!.ParamName, Is.EqualTo("nextFactoryAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void ForwardAsyncMapFailureSync_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        Result<SomeRecord, SomeError> next = new SomeError(MinusFifteen);

        Func<StructType, SomeError> mapFailure = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.ForwardAsync(_ => Task.FromResult(next), mapFailure));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailure"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task ForwardAsyncMapFailureSync_SourceIsDefaultOrFailure_ExpectResultOfMappedFailure(
        Result<RefType, StructType> source)
    {
        Result<SomeRecord, SomeError> next = new SomeRecord();
        var mappedFailure = new SomeError(MinusFifteen);

        var actual = await source.ForwardAsync(_ => Task.FromResult(next), _ => mappedFailure);
        var expected = new Result<SomeRecord, SomeError>(mappedFailure);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsyncMapFailureSync_SourceIsSuccessAndNextIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var next = default(Result<string, SomeError>);
        var mappedFailure = new SomeError(PlusFifteen);

        var actual = await source.ForwardAsync(_ => Task.FromResult(next), _ => mappedFailure);
        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsyncMapFailureSync_SourceIsSuccessAndNextIsSuccess_ExpectNext(
        Result<RefType, StructType> source)
    {
        var next = new Result<RefType, SomeError>(MinusFifteenIdRefType);
        var mappedFailure = new SomeError(int.MaxValue);

        var actual = await source.ForwardAsync(_ => Task.FromResult(next), _ => mappedFailure);
        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsyncMapFailureSync_SourceIsSuccessAndNextIsFailure_ExpectNext(
        Result<RefType, StructType> source)
    {
        Result<SomeRecord, SomeError> next = Result.Failure(new SomeError(MinusFifteen));
        var mappedFailure = new SomeError(int.MinValue);

        var actual = await source.ForwardAsync(_ => Task.FromResult(next), _ => mappedFailure);
        Assert.That(actual, Is.EqualTo(next));
    }
}
