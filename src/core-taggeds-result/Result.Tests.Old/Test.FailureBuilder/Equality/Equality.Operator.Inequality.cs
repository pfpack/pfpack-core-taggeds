using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureBuilderTest
{
    [Test]
    public void Inequality_LeftIsDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = new FailureBuilder<StructType>();
        var right = default(FailureBuilder<StructType>);

        var actual = left != right;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Inequality_LeftIsDefaultAndRightFailureIsDefault_ExpectFalse()
    {
        var left = default(FailureBuilder<StructType>);
        var right = Result.Failure(default(StructType));

        var actual = left != right;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Inequality_LeftFailureIsDefaultAndRightIsDefault_ExpectFalse()
    {
        var left = Result.Failure(default(SomeError));
        var right = new FailureBuilder<SomeError>();

        var actual = left != right;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Inequality_LeftFailureIsDefaultAndRightFailureIsDefault_ExpectFalse()
    {
        var left = Result.Failure(new StructType());
        var right = Result.Failure(new StructType());

        var actual = left != right;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Inequality_LeftFailureIsEqualToRightFailure_ExpectFalse()
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

        var actual = left != right;
        Assert.That(actual, Is.False);
    }

    [Test]
    public void Inequality_LeftIsDefaultAndRightIsNotDefault_ExpectTrue()
    {
        var left = new FailureBuilder<SomeError>();
        var right = Result.Failure(new SomeError(int.MaxValue));

        var actual = left != right;
        Assert.That(actual, Is.True);
    }

    [Test]
    public void Inequality_LeftFailureIsNotEqualToRightFailure_ExpectTrue()
    {
        var leftFailure = new SomeError(MinusFifteen);
        var left = Result.Failure(leftFailure);

        var rightFailure = new SomeError(int.MaxValue);
        var right = Result.Failure(rightFailure);

        var actual = left != right;
        Assert.That(actual, Is.True);
    }
}
