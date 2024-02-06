using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class ResultTest
{
    [Test]
    public void EqualsInequality_ResultAIsDefaultAndResultBIsDefault_ExpectFalse()
    {
        var resultA = new Result<StructType?, SomeError>();
        var resultB = default(Result<StructType?, SomeError>);

        var actual = resultA != resultB;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsInequality_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNull_ExpectFalse()
    {
        var resultA = new Result<SomeError?, StructType>(null);
        var resultB = Result<SomeError?, StructType>.Success(null);

        var actual = resultA != resultB;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsInequality_ResultAIsSuccessAndResultBIsSuccessAndValuesAreEqual_ExpectFalse()
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
        var resultB = new Result<SomeRecord, StructType>(bValue);

        var actual = resultA != resultB;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsInequality_ResultAIsFailureAndResultBIsFailureAndValuesAreEqual_ExpectFalse()
    {
        var errorCode = PlusFifteen;
        var aValue = new SomeError(errorCode);
        var resultA = Result<DateTimeOffset, SomeError>.Failure(aValue);

        var bValue = new SomeError(errorCode);
        var resultB = new Result<DateTimeOffset, SomeError>(bValue);

        var actual = resultA != resultB;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsInequality_ResultAIsFailureWithDefaultValueAndResultBIsDefault_ExpectFalse()
    {
        var resultA = new Result<object, SomeError>();
        var resultB = new Result<object, SomeError>(default(SomeError));

        var actual = resultA != resultB;
        Assert.That(actual, Is.False);            
    }

    [Test]
    public void EqualsInequality_ResultAIsDefaultAndResultBIsFailureWithDefaultValue_ExpectFalse()
    {
        var resultA = Result<SomeRecord?, StructType>.Failure(default);
        var resultB = new Result<SomeRecord?, StructType>();

        var actual = resultA != resultB;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsInequality_ResultAIsSuccessAndResultBIsSuccessAndValuesAreNotEqual_ExpectTrue()
    {
        var aValue = new RefType();
        var resultA = Result<RefType?, SomeError>.Success(aValue);

        var bValue = new RefType();
        var resultB = Result<RefType?, SomeError>.Success(bValue);

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsFailureAndResultBIsFailureAndValuesAreNotEqual_ExpectTrue()
    {
        var text = "Some new text.";
        var aValue = new StructType
        {
            Text = text
        };
        var resultA = Result<SomeRecord?, StructType>.Failure(aValue);

        var bValue = new StructType
        {
            Text = text + ".."
        };
        var resultB = Result<SomeRecord?, StructType>.Failure(bValue);

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsSuccessAndResultBIsFailure_ExpectTrue()
    {
        var someValue = SomeTextStructType;

        var resultA = Result<StructType, StructType>.Success(someValue);
        var resultB = Result<StructType, StructType>.Failure(someValue);

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsSuccessAndResultBIsDefault_ExpectTrue()
    {
        var resultA = new Result<RefType?, StructType>(ZeroIdRefType);
        var resultB = default(Result<RefType?, StructType>);

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsFailureAndResultBIsSuccess_ExpectTrue()
    {
        var someValue = MinusFifteen;

        var resultA = Result<int, int>.Failure(someValue);
        var resultB = Result<int, int>.Success(someValue);

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsFailureWithNotDefaultValueAndResultBIsDefault_ExpectTrue()
    {
        var resultA = Result<RefType, StructType>.Failure(SomeTextStructType);
        var resultB = default(Result<RefType, StructType>);

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsDefaultAndResultBIsSuccess_ExpectTrue()
    {
        var resultA = default(Result<StructType, SomeError>);
        var resultB = new Result<StructType, SomeError>(default(StructType));

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsInequality_ResultAIsDefaultAndResultBIsFailureWithNotDefaultValue_ExpectTrue()
    {
        var resultA = new Result<StructType, SomeError>();
        var resultB = new Result<StructType, SomeError>(new SomeError(PlusFifteen));

        var actual = resultA != resultB;
        Assert.That(actual, Is.True);
    }
}
