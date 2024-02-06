using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void EqualsStatic_ResultAIsDefaultAndResultBIsDefault_ExpectTrue()
    {
        var resultA = new Result<SomeRecord?, SomeError>();
        var resultB = default(Result<SomeRecord?, SomeError>);

        var actual = Result<SomeRecord?, SomeError>.Equals(resultA, resultB);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNull_ExpectTrue()
    {
        var resultA = Result<SomeRecord?, StructType>.Success(null);
        Result<SomeRecord?, StructType> resultB = null;

        var actual = Result<SomeRecord?, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_ResultAIsSuccessAndResultBIsSuccessAndValuesAreEqual_ExpectTrue()
    {
        var text = "Some new text.";
        var aValue = new SomeRecord
        {
            Text = text
        };
        var resultA = Result<SomeRecord, StructType>.Success(aValue);

        var bValue = new SomeRecord
        {
            Text = text
        };
        Result<SomeRecord, StructType> resultB = bValue;

        var actual = Result<SomeRecord, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_ResultAIsFailureAndResultBIsFailureAndValuesAreEqual_ExpectTrue()
    {
        var errorCode = MinusFifteen;
        var aValue = new SomeError(errorCode);
        Result<RefType, SomeError> resultA = aValue;

        var bValue = new SomeError(errorCode);
        var resultB = Result<RefType, SomeError>.Failure(bValue);

        var actual = Result<RefType, SomeError>.Equals(resultA, resultB);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_ResultAIsFailureWithDefaultValueAndResultBIsDefault_ExpectTrue()
    {
        var resultA = default(Result<RefType, DateTime>);
        Result<RefType, DateTime> resultB = default(DateTime);

        var actual = Result<RefType, DateTime>.Equals(resultA, resultB);
        Assert.That(actual, Is.True);            
    }

    [Test]
    public void EqualsStatic_ResultAIsDefaultAndResultBIsFailureWithDefaultValue_ExpectTrue()
    {
        var resultA = Result<RefType, StructType>.Failure(default);
        var resultB = default(Result<RefType, StructType>);

        var actual = Result<RefType, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNotEqual_ExpectFalse()
    {
        var aValue = new RefType();
        var resultA = Result<RefType, StructType>.Success(aValue);

        var bValue = new RefType();
        var resultB = Result<RefType, StructType>.Success(bValue);

        var actual = Result<RefType, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsFailureAndResultBIsFailureAndValuesAreNotEqual_ExpectFalse()
    {
        var text = "Some new text.";
        var aValue = new StructType
        {
            Text = text
        };
        var resultA = Result<SomeRecord, StructType>.Failure(aValue);

        var bValue = new StructType
        {
            Text = text + ".."
        };
        var resultB = Result<SomeRecord, StructType>.Failure(bValue);

        var actual = Result<SomeRecord, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsSuccessAndResultBIsFailure_ExpectFalse()
    {
        var someValue = new SomeError(MinusFifteen);

        var resultA = Result<SomeError, SomeError>.Success(someValue);
        var resultB = Result<SomeError, SomeError>.Failure(someValue);

        var actual = Result<SomeError, SomeError>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsSuccessAndResultBIsDefault_ExpectFalse()
    {
        var resultA = Result<RefType, StructType>.Success(ZeroIdRefType);
        var resultB = default(Result<RefType, StructType>);

        var actual = Result<RefType, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsFailureAndResultBIsSuccess_ExpectFalse()
    {
        var someValue = PlusFifteen;

        var resultA = Result<decimal, decimal>.Failure(someValue);
        var resultB = Result<decimal, decimal>.Success(someValue);

        var actual = Result<decimal, decimal>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsFailureWithNotDefaultValueAndResultBIsDefault_ExpectFalse()
    {
        var resultA = Result<RefType?, StructType>.Failure(SomeTextStructType);
        var resultB = default(Result<RefType?, StructType>);

        var actual = Result<RefType?, StructType>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsDefaultAndResultBIsSuccess_ExpectFalse()
    {
        var resultA = default(Result<StructType, SomeError>);
        var resultB = Result<StructType, SomeError>.Success(default);

        var actual = Result<StructType, SomeError>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_ResultAIsDefaultAndResultBIsFailureWithNotDefaultValue_ExpectFalse()
    {
        var resultA = default(Result<StructType, SomeError>);
        var resultB = Result<StructType, SomeError>.Failure(new SomeError(PlusFifteen));

        var actual = Result<StructType, SomeError>.Equals(resultA, resultB);
        Assert.That(actual, Is.False);
    }
}
