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
    public void FilterAsync_PredicateAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var causeFailure = SomeTextStructType;

        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterAsync(null!, _ => Task.FromResult(causeFailure)));

        Assert.AreEqual("predicateAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void FilterAsync_CauseFactoryAsyncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.ThrowsAsync<ArgumentNullException>(
            async () => _ = await source.FilterAsync(_ => Task.FromResult(false), null!));

        Assert.AreEqual("causeFactoryAsync", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FilterAsync_PredicateReturnsTrue_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        var causeFailure = default(StructType);

        var actual = await source.FilterAsync(
            _ => Task.FromResult(true),
            _ => Task.FromResult(causeFailure));

        Assert.AreEqual(source, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public async Task FilterAsync_PredicateReturnsTrueAndSourceIsSuccess_ExpectResultOfCauseFailure(
        Result<RefType, StructType> source)
    {
        var causeFailure = SomeTextStructType;
            
        var actual = await source.FilterAsync(
            _ => Task.FromResult(false),
            _ => Task.FromResult(causeFailure));

        var expected = Result<RefType, StructType>.Failure(causeFailure);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public async Task FilterAsync_PredicateReturnsTrueAndSourceIsDefaultOrFailure_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        var causeFailure = new StructType
        {
            Text = "Some error."
        };

        var actual = await source.FilterAsync(
            _ => Task.FromResult(false),
            _ => Task.FromResult(causeFailure));

        Assert.AreEqual(source, actual);
    }
}
