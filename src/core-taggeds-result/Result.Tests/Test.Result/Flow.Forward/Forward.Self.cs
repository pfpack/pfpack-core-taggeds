using NUnit.Framework;
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
    public void ForwardSelf_NextFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {            
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Forward(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("nextFactory"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void ForwardSelf_SourceIsDefaultOrFailure_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        var next = new Result<RefType, StructType>(PlusFifteenIdRefType);
        var actual = source.Forward(_ => next);

        Assert.That(actual, Is.EqualTo(source));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void ForwardSelf_SourceIsSuccessAndNextIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var next = new Result<RefType, StructType>();
        var actual = source.Forward(_ => next);

        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void ForwardSelf_SourceIsSuccessAndNextIsSuccess_ExpectNext(
        Result<RefType, StructType> source)
    {
        var next = new Result<RefType, StructType>(PlusFifteenIdRefType);
        var actual = source.Forward(_ => next);

        Assert.That(actual, Is.EqualTo(next));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void ForwardSelf_SourceIsSuccessAndNextIsFailure_ExpectNext(
        Result<RefType, StructType> source)
    {
        var next = Result.Failure(SomeTextStructType).With<RefType>();
        var actual = source.Forward(_ => next);

        Assert.That(actual, Is.EqualTo(next));
    }
}
