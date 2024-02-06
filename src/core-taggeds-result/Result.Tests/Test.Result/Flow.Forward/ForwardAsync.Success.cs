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
    public void ForwardAsync_NextFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.ForwardAsync<int>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("nextFactoryAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public async Task ForwardAsync_SourceIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var next = Result.Success<SomeRecord?>(null).With<StructType>();
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        var expected = default(Result<SomeRecord?, StructType>);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task ForwardAsync_SourceIsFailure_ExpectResultOfSourceFailure(
        Result<RefType, StructType> source)
    {
        var next = new Result<int, StructType>(PlusFifteen);
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        var expected = Result.Failure(SomeTextStructType).With<int>();
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsync_SourceIsSuccessAndNextIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var next = default(Result<int, StructType>);
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsync_SourceIsSuccessAndNextIsSuccess_ExpectNext(
        Result<RefType, StructType> source)
    {
        var next = Result.Success(decimal.One).With<StructType>();
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsync_SourceIsSuccessAndNextIsFailure_ExpectNext(
        Result<RefType, StructType> source)
    {
        var next = Result<SomeRecord, StructType>.Failure(SomeTextStructType);
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        Assert.That(actual, Is.EqualTo(next));
    }
}
