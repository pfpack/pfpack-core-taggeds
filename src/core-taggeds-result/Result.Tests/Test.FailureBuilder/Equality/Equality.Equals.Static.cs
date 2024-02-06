using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureBuilderTest
{
    [Test]
    public void EqualsStatic_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = new FailureBuilder<int>();
        var right = default(FailureBuilder<int>);

        var actual = FailureBuilder<int>.Equals(left, right);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_LeftIsDefaultAndRightFailureIsDefault_ExpectTrue()
    {
        var left = new FailureBuilder<SomeError>();
        var right = Result.Failure(default(SomeError));

        var actual = FailureBuilder<SomeError>.Equals(left, right);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_LeftFailureIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = Result.Failure(default(StructType));
        var right = default(FailureBuilder<StructType>);

        var actual = FailureBuilder<StructType>.Equals(left, right);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_LeftFailureIsDefaultAndRightFailureIsDefault_ExpectTrue()
    {
        var left = Result.Failure(new StructType());
        var right = Result.Failure(default(StructType));

        var actual = FailureBuilder<StructType>.Equals(left, right);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_LeftFailureIsEqualToRightFailure_ExpectTrue()
    {
        var text = "Some text value.";

        var leftFailure = new StructType
        {
            Text = text
        };
        var left = Result.Failure(leftFailure);

        var rightFailure = new StructType
        {
            Text = text
        };
        var right = Result.Failure(rightFailure);

        var actual = FailureBuilder<StructType>.Equals(left, right);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsStatic_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
    {
        var left = new FailureBuilder<decimal>();
        var right = Result.Failure(decimal.One);

        var actual = FailureBuilder<decimal>.Equals(left, right);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsStatic_LeftFailureIsNotEqualToRightFailure_ExpectFalse()
    {
        var leftFailure = new SomeError(PlusFifteen);
        var left = Result.Failure(leftFailure);

        var rightFailure = new SomeError(MinusFifteen);
        var right = Result.Failure(rightFailure);

        var actual = FailureBuilder<SomeError>.Equals(left, right);
        Assert.That(actual, Is.False);
    }
}
