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
    public void RecoverValueAsyncFailure_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.RecoverValueAsync<SomeError>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("otherFactoryAsync"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public async Task RecoverValueAsyncFailure_SourceIsNullSuccess_ExpectSuccessResultOfSourceValue(
        Result<RefType?, StructType> source)
    {
        var other = Result<RefType?, SomeError>.Success(PlusFifteenIdRefType);

        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));
        var expected = new Result<RefType?, SomeError>(null);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task RecoverValueAsyncFailure_SourceIsNotNullSuccess_ExpectSuccessResultOfSourceValue(
        Result<RefType, StructType> source)
    {
        var other = Result<RefType, SomeError>.Failure(new SomeError(int.MinValue));

        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));
        var expected = new Result<RefType, SomeError>(PlusFifteenIdRefType);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverValueAsyncFailure_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<RefType, int> other = int.MaxValue;
        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

        Assert.That(actual, Is.EqualTo(other));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverValueAsyncFailure_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = Result.Success(ZeroIdRefType).With<decimal>();
        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

        Assert.That(actual, Is.EqualTo(other));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverValueAsyncFailure_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<RefType, SomeError> other = new SomeError(PlusFifteen);
        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other));

        Assert.That(actual, Is.EqualTo(other));
    }
}
