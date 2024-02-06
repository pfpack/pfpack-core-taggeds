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
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void RecoverFailure_OtherFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Recover<SomeError>(null!));

        Assert.That(actualException!.ParamName, Is.EqualTo("otherFactory"));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    public void RecoverFailure_SourceIsNullSuccess_ExpectSuccessResultOfSourceValue(
        Result<RefType?, StructType> source)
    {
        var other = Result.Success<RefType?>(PlusFifteenIdRefType).With<SomeError>();

        var actual = source.Recover(_ => other);
        var expected = new Result<RefType?, SomeError>(null);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessMinusFifteenIdRefTypeTestSource))]
    public void RecoverFailure_SourceIsNotNullSuccess_ExpectSuccessResultOfSourceValue(
        Result<RefType, StructType> source)
    {
        var other = Result.Failure(new SomeError(MinusFifteen)).With<RefType>();

        var actual = source.Recover(_ => other);
        var expected = new Result<RefType, SomeError>(MinusFifteenIdRefType);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverFailure_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = new Result<RefType, SomeError>();
        var actual = source.Recover(_ => other);

        Assert.That(actual, Is.EqualTo(other));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverFailure_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<RefType, int> other = Result.Success(ZeroIdRefType);
        var actual = source.Recover(_ => other);

        Assert.That(actual, Is.EqualTo(other));
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverFailure_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = new Result<RefType, decimal>(decimal.One);
        var actual = source.Recover(_ => other);

        Assert.That(actual, Is.EqualTo(other));
    }
}
