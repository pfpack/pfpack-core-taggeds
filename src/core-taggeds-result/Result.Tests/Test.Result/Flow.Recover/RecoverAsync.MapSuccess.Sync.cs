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
    public void RecoverAsyncWithMapSuccessSync_OtherFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mappedSuccess = int.MaxValue;

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.RecoverAsync<int, SomeError>(null!, _ => mappedSuccess));

        Assert.AreEqual("otherFactoryAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void RecoverAsyncWithMapSuccessSync_MapSuccessIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var other = new Result<string, SomeError>(SomeString);

        Func<RefType, string> mapSuccess = null!;
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.RecoverAsync(_ => Task.FromResult(other), mapSuccess));

        Assert.AreEqual("mapSuccess", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task RecoverAsyncWithMapSuccessSync_SourceIsSuccess_ExpectSuccessResultOfMappedValue(
        Result<RefType, StructType> source)
    {
        var other = new Result<string, SomeError>(EmptyString);
        var mappedSuccess = SomeString;

        var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => mappedSuccess);
        Result<string, SomeError> expected = mappedSuccess;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverAsyncWithMapSuccessSync_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = default(Result<object, SomeError>);
        var mappedSuccess = new object();

        var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => mappedSuccess);
        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverAsyncWithMapSuccessSync_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = Result.Success(new SomeRecord()).With<SomeError>();
        var mappedSuccess = new SomeRecord
        {
            Text = "Some property value"
        };

        var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => mappedSuccess);
        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task RecoverAsyncWithMapSuccessSync_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<string, SomeError> other = new SomeError(PlusFifteen);
        var mappedValue = "Some success text value";

        var actual = await source.RecoverAsync(_ => Task.FromResult(other), _ => mappedValue);
        Assert.AreEqual(other, actual);
    }
}
