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
    public void RecoverWithMapSuccess_OtherFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var mappedSuccess = int.MaxValue;

        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Recover<int, SomeError>(null!, _ => mappedSuccess));

        Assert.AreEqual("otherFactory", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void RecoverWithMapSuccess_MapSuccessIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var other = Result.Success<decimal>(decimal.MinusOne).With<SomeError>();

        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Recover(_ => other, null!));

        Assert.AreEqual("mapSuccess", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void RecoverWithMapSuccess_SourceIsSuccess_ExpectSuccessResultOfMappedValue(
        Result<RefType, StructType> source)
    {
        Result<SomeRecord, SomeError> other = new SomeRecord
        {
            Text = SomeString
        };

        var mappedSuccess = new SomeRecord
        {
            Text = TabString
        };

        var actual = source.Recover(_ => other, _ => mappedSuccess);
        var expected = new Result<SomeRecord, SomeError>(mappedSuccess);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = new Result<string, SomeError>();
        var mappedSuccess = SomeString;

        var actual = source.Recover(_ => other, _ => mappedSuccess);
        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<decimal, int> other = Result.Success(decimal.MinValue);
        var mappedSuccess = decimal.One;

        var actual = source.Recover(_ => other, _ => mappedSuccess);
        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverWithMapSuccess_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<object, SomeError> other = new SomeError(PlusFifteen);
        var mappedValue = new object();

        var actual = source.Recover(_ => other, _ => mappedValue);
        Assert.AreEqual(other, actual);
    }
}
