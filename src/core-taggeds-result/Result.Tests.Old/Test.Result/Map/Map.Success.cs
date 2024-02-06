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
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void MapSuccess_MapSuccessFuncIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.MapSuccess<int>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapSuccess"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void MapSuccess_SourceIsSuccess_ExpectSuccessResultOfMapSuccess(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = SomeString
        };

        var actual = source.MapSuccess(
            _ => successResult);
            
        var expected = new Result<SomeRecord, StructType>(successResult);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    public void MapSuccess_SourceIsDefault_ExpectResultOfDefaultFailure(
        Result<RefType, StructType> source)
    {
        var successResult = TabString;
        var actual = source.MapSuccess(_ => successResult);

        var expected = default(Result<string, StructType>);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void MapSuccess_SourceIsFailure_FailureResultOfSourceFailure(
        Result<RefType, StructType> source)
    {
        var successResult = PlusFifteen;
        var actual = source.MapSuccess(_ => successResult);

        var expected = new Result<int, StructType>(SomeTextStructType);
        Assert.That(actual, Is.EqualTo(expected));
    }
}
