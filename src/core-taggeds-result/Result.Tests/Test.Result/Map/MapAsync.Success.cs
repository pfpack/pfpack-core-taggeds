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
    public void MapSuccessAsync_MapSuccessAsyncFuncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.MapSuccessAsync<SomeError>(null!));

        Assert.AreEqual("mapSuccessAsync", actualException!.ParamName);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task MapSuccessAsync_SourceIsSuccess_ExpectSuccessResultOfMapSuccessAsync(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = SomeString
        };

        var actual = await source.MapSuccessAsync(
            _ => Task.FromResult(successResult));
            
        var exected = new Result<SomeRecord, StructType>(successResult);
        Assert.AreEqual(exected, actual);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public async Task MapSuccessAsync_SourceIsDefault_ExpectResultOfDefaultFailure(
        Result<RefType, StructType> source)
    {
        var successResult = decimal.MaxValue;
        var actual = await source.MapSuccessAsync(_ => Task.FromResult(successResult));

        var exected = default(Result<decimal, StructType>);
        Assert.AreEqual(exected, actual);
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task MapSuccessAsync_SourceIsFailure_FailureResultOfSourceFailure(
        Result<RefType, StructType> source)
    {
        var successResult = (string?)null;
        var actual = await source.MapSuccessAsync(_ => Task.FromResult(successResult));

        var exected = new Result<string?, StructType>(SomeTextStructType);
        Assert.AreEqual(exected, actual);
    }
}
