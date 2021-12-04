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
    public void RecoverSelf_OtherFactoryIsNull_ExpectArgumentNullException(
        Result<RefType, StructType> source)
    {
        var actualException = Assert.Throws<ArgumentNullException>(
            () => _ = source.Recover(null!));

        Assert.AreEqual("otherFactory", actualException!.ParamName);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessNullTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.SuccessPlusFifteenIdRefTypeTestSource))]
    public void RecoverSelf_SourceIsSuccess_ExpectSourceResult(
        Result<RefType, StructType> source)
    {
        var other = new Result<RefType, StructType>(MinusFifteenIdRefType);
        var actual = source.Recover(_ => other);

        Assert.AreEqual(source, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverSelf_SourceIsDefaultOrFailureAndOtherIsDefault_ExpectDefault(
        Result<RefType, StructType> source)
    {
        var other = default(Result<RefType, StructType>);
        var actual = source.Recover(_ => other);

        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverSelf_SourceIsDefaultOrFailureAndOtherIsSuccess_ExpectOther(
        Result<RefType, StructType> source)
    {
        var other = Result.Success(PlusFifteenIdRefType).With<StructType>();
        var actual = source.Recover(_ => other);

        Assert.AreEqual(other, actual);
    }

    [Test]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureDefaultTestSource))]
    [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.FailureSomeTextStructTypeTestSource))]
    public void RecoverSelf_SourceIsDefaultOrFailureAndOtherIsFailure_ExpectOther(
        Result<RefType, StructType> source)
    {
        Result<RefType, StructType> other = Result.Failure(SomeTextStructType);
        var actual = source.Recover(_ => other);

        Assert.AreEqual(other, actual);
    }
}
