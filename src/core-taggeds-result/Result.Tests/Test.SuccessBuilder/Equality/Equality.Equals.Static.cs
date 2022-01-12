using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class SuccessBuilderTest
{
    [Test]
    public void EqualsStatic_LeftIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = default(SuccessBuilder<RefType>);
        var right = new SuccessBuilder<RefType>();

        var actual = SuccessBuilder<RefType>.Equals(left, right);
        Assert.True(actual);
    }

    [Test]
    public void EqualsStatic_LeftIsDefaultAndRightSuccessIsNull_ExpectTrue()
    {
        var left = default(SuccessBuilder<SomeRecord?>);
        var right = Result.Success<SomeRecord?>(null);

        var actual = SuccessBuilder<SomeRecord?>.Equals(left, right);
        Assert.True(actual);
    }

    [Test]
    public void EqualsStatic_LeftSuccessIsDefaultAndRightIsDefault_ExpectTrue()
    {
        var left = Result.Success<StructType>(new());
        var right = new SuccessBuilder<StructType>();

        var actual = SuccessBuilder<StructType>.Equals(left, right);
        Assert.True(actual);
    }

    [Test]
    public void EqualsStatic_LeftSuccessIsDefaultAndRightSuccessIsDefault_ExpectTrue()
    {
        var left = Result.Success<SomeRecord?>(null);
        var right = Result.Success<SomeRecord?>(null);

        var actual = SuccessBuilder<SomeRecord?>.Equals(left, right);
        Assert.True(actual);
    }

    [Test]
    public void EqualsStatic_LeftSuccessIsEqualRightSuccess_ExpectTrue()
    {
        var text = "Some property string value";

        var leftSuccess = new SomeRecord
        {
            Text = text
        };
        var left = Result.Success(leftSuccess);

        var rightSuccess = new SomeRecord
        {
            Text = text
        };
        var right = Result.Success(rightSuccess);

        var actual = SuccessBuilder<SomeRecord>.Equals(left, right);
        Assert.True(actual);
    }

    [Test]
    public void EqualsStatic_LeftIsDefaultAndRightIsNotDefault_ExpectFalse()
    {
        var left = new SuccessBuilder<object>();
        var right = Result.Success<object>(new());

        var actual = SuccessBuilder<object>.Equals(left, right);
        Assert.False(actual);
    }

    [Test]
    public void EqualsStatic_LeftSuccessIsNotEqualToRightSuccess_ExpectFalse()
    {
        var leftSuccess = new RefType();
        var left = Result.Success(leftSuccess);

        var rightSuccess = new RefType();
        var right = Result.Success(rightSuccess);

        var actual = SuccessBuilder<RefType>.Equals(left, right);
        Assert.False(actual);
    }
}
