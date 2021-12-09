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
    public void ForwardAsyncSelf_NextFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.ForwardAsync(null!));

        Assert.AreEqual("nextFactoryAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task ForwardAsyncSelf_SourceIsDefaultOrFailure_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        Result<RefType, StructType> next = new StructType
        {
            Text = "Some error message."
        };

        var actual = await source.ForwardAsync(_ => Task.FromResult(next));
        Assert.AreEqual(source, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsyncSelf_SourceIsSuccessAndNextIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var next = default(Result<RefType, StructType>);
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        Assert.AreEqual(next, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsyncSelf_SourceIsSuccessAndNextIsSuccess_ExpectNext(
        Result<RefType?, StructType> source)
    {
        Result<RefType?, StructType> next = Result.Success<RefType?>(null);
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        Assert.AreEqual(next, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public async Task ForwardAsyncSelf_SourceIsSuccessAndNextIsFailure_ExpectNext(
        Result<RefType, StructType> source)
    {
        var next = new Result<RefType, StructType>(SomeTextStructType);
        var actual = await source.ForwardAsync(_ => Task.FromResult(next));

        Assert.AreEqual(next, actual);
    }
}
