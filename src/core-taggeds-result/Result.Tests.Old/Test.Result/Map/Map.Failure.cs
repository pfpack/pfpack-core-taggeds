using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void MapFailure_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.MapFailure<SomeError>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailure"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void MapFailure_SourceIsDefaultOrFailure_FailureExpectResultOfMapFailure(
        Result<RefType, StructType> source)
    {
        var failureResult = new SomeError(MinusFifteen);
        var actual = source.MapFailure(_ => failureResult);

        var expected = new Result<RefType, SomeError>(failureResult);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void MapFailure_SourceIsSuccessAndValueIsNull_ExpectResultOfNullSuccess(
        Result<RefType, StructType> source)
    {
        var failureResult = MinusFifteen;
        var actual = source.MapFailure(_ => failureResult);
            
        var expected = new Result<RefType, int>(null!);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void MapFailure_SourceIsSuccess_ExpectResultOfSourceSuccess(
        Result<RefType, StructType> source)
    {
        var failureResult = new SomeError(int.MaxValue);
        var actual = source.MapFailure(_ => failureResult);
            
        var expected = new Result<RefType, SomeError>(MinusFifteenIdRefType);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
