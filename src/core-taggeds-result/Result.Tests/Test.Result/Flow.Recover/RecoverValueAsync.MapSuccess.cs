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
    public void RecoverValueAsyncWithMapSuccess_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mappedSuccess = new SomeRecord
        {
            Text = "Some Property Value"
        };

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.RecoverValueAsync<SomeRecord, SomeError>(null!, _ => ValueTask.FromResult(mappedSuccess)));

        Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void RecoverValueAsyncWithMapSuccess_MapSuccessIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var other = new Result<string, SomeError>("Some success string");

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.RecoverValueAsync(_ => ValueTask.FromResult(other), null!));

        Assert.AreEqual("mapSuccessAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task RecoverValueAsyncWithMapSuccess_SourceIsSuccess_ExpectSuccessResultOfMappedValue(
        Result<RefType, StructType> source)
    {
        Result<SomeRecord, SomeError> other = new SomeRecord 
        {
            Text = "Some other property value"
        };

        var mappedSuccess = new SomeRecord 
        {
            Text = null
        };

        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other), _ => ValueTask.FromResult(mappedSuccess));
        var expected = Result.Success(mappedSuccess).With<SomeError>();

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverValueAsyncWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = default(Result<string, SomeError>);
        var mappedSuccess = "Some mapped value";

        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other), _ => ValueTask.FromResult(mappedSuccess));
        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverValueAsyncWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = Result.Success(int.MaxValue).With<SomeError>();
        var mappedSuccess = MinusFifteen;

        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other), _ => ValueTask.FromResult(mappedSuccess));
        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverValueAsyncWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = new Result<SomeRecord, SomeError>(new SomeError(PlusFifteen));
        var mappedValue = new SomeRecord
        {
            Text = "Some record text property value"
        };

        var actual = await source.RecoverValueAsync(_ => ValueTask.FromResult(other), _ => ValueTask.FromResult(mappedValue));
        Assert.AreEqual(other, actual);
    }
}
