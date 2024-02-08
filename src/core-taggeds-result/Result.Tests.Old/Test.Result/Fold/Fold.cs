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
    public void Fold_MapSuccessIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Fold(null!, _ => new object()));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapSuccess"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void Fold_MapFailureIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Fold(_ => MinusFifteen, null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("mapFailure"));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void Fold_SourceIsSuccess_ExpectResultOfMapSuccess(
        Result<RefType, StructType> source)
    {
        var successResult = ThreeWhiteSpacesString;
        var failureResult = SomeString;

        var actual = source.Fold(
            _ => successResult,
            _ => failureResult);

        Assert.That(actual, Is.SameAs(successResult));
    }

    [Test]        
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void Fold_SourceIsDefaultOrFailure_ExpectResultOfMapFailure(
        Result<RefType, StructType> source)
    {
        var successResult = new SomeRecord
        {
            Text = SomeString
        };

        var failureResult = new SomeRecord
        {
            Text = ThreeWhiteSpacesString
        };

        var actual = source.Fold(
            _ => successResult,
            _ => failureResult);

         Assert.That(actual, Is.SameAs(failureResult));
    }
}
