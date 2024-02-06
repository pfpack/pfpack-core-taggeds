using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;

namespace PrimeFuncPack.Core.Tests;

partial class SuccessBuilderTest
{
    [Test]
    public void EqualsOther_SourceIsDefaultAndOtherIsDefault_ExpectTrue()
    {
        var source = new SuccessBuilder<RefType>();
        var other = default(SuccessBuilder<RefType>);

        var actual = source.Equals(other);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsOther_SourceIsDefaultAndOtherSuccessIsNull_ExpectTrue()
    {
        var source = default(SuccessBuilder<RefType?>);
        var other = Result.Success<RefType?>(null);

        var actual = source.Equals(other);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsOther_SourceSuccessIsDefaultAndOtherIsDefault_ExpectTrue()
    {
        var source = Result.Success(new StructType());
        var other = default(SuccessBuilder<StructType>);

        var actual = source.Equals(other);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsOther_SourceSuccessIsDefaultAndOtherSuccessIsDefault_ExpectTrue()
    {
        var source = Result.Success<RefType>(null!);
        var other = Result.Success<RefType>(null!);

        var actual = source.Equals(other);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsOther_SourceSuccessIsEqualOtherSuccess_ExpectTrue()
    {
        var text = "Some property string value";

        var sourceSuccess = new SomeRecord
        {
            Text = text
        };
        var source = Result.Success(sourceSuccess);

        var otherSuccess = new SomeRecord
        {
            Text = text
        };
        var other = Result.Success(otherSuccess);

        var actual = source.Equals(other);
        Assert.That(actual, Is.True);
    }

    [Test]
    public void EqualsOther_SourceIsDefaultAndOtherIsNotDefault_ExpectFalse()
    {
        var source = new SuccessBuilder<SomeRecord>();
        var other = Result.Success<SomeRecord>(new());

        var actual = source.Equals(other);
        Assert.That(actual, Is.False);
    }

    [Test]
    public void EqualsOther_SourceSuccessIsNotEqualToOtherSuccess_ExpectFalse()
    {
        var sourceSuccess = new RefType();
        var source = Result.Success(sourceSuccess);

        var otherSuccess = new RefType();
        var other = Result.Success(otherSuccess);

        var actual = source.Equals(other);
        Assert.That(actual, Is.False);
    }
}
