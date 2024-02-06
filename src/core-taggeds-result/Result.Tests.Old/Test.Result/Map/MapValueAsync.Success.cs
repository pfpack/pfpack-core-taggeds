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
    public void MapSuccessValueAsync_MapSuccessValueAsyncFuncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapSuccessValueAsync<SomeError>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapSuccessAsync"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task MapSuccessValueAsync_SourceIsSuccess_ExpectSuccessResultOfMapSuccessValueAsync(
        Result<RefType, StructType> source)
    {
        var successResult = (SomeRecord?)null;

        var actual = await source.MapSuccessValueAsync(
            _ => ValueTask.FromResult(successResult));
            
        var expected = new Result<SomeRecord?, StructType>(successResult);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public async Task MapSuccessValueAsync_SourceIsDefault_ExpectResultOfDefaultFailure(
        Result<RefType, StructType> source)
    {
        var successResult = SomeString;
        var actual = await source.MapSuccessValueAsync(_ => ValueTask.FromResult(successResult));

        var expected = default(Result<string, StructType>);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task MapSuccessValueAsync_SourceIsFailure_FailureResultOfSourceFailure(
        Result<RefType, StructType> source)
    {
        var successResult = new object();
        var actual = await source.MapSuccessValueAsync(_ => ValueTask.FromResult(successResult));

        var expected = new Result<object, StructType>(SomeTextStructType);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
