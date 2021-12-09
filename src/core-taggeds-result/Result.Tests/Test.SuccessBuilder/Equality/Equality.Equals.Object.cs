using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class SuccessBuilderTest
{
    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = default(SuccessBuilder<SomeRecord?>);
        object? other = new SuccessBuilder<SomeRecord>();

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherSuccessIsNullAndTypesAreSame_ExpectTrue()
    {
        var source = default(SuccessBuilder<RefType>);
        object? other = Result.Success<RefType>(null!);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = Result.Success(default(StructType?));
        object? other = new SuccessBuilder<StructType?>();

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsDefaultAndOtherSuccessIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = Result.Success<SomeRecord?>(null);
        object? other = Result.Success<SomeRecord?>(null);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsEqualToOtherSuccessAndTypesAreSame_ExpectTrue()
    {
        var someValue = PlusFifteen;

        var sourceSuccess = new SomeError(someValue);
        var source = Result.Success(sourceSuccess);

        var otherSuccess = new SomeError(someValue);
        object? other = Result.Success(otherSuccess);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectFalse()
    {
        var source = default(SuccessBuilder<StructType>);
        object? other = default(SuccessBuilder<StructType?>);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherSuccessIsNullAndTypesAreNotSame_ExpectFalse()
    {
        var source = new SuccessBuilder<RefType?>();
        object? other = Result.Success<SomeRecord?>(null);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectFalse()
    {
        var source = Result.Success(default(SomeError));
        object? other = new SuccessBuilder<SomeError?>();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsNullAndOtherSuccessIsNullAndTypesAreNotSame_ExpectFalse()
    {
        var source = Result.Success<SomeRecord>(null!);
        object? other = Result.Success<RefType>(null!);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsEqualToOtherSuccessAndTypesAreNotSame_ExpectFalse()
    {
        var someValue = PlusFifteen;
        var source = Result.Success(someValue);
        object? other = Result.Success<decimal>(someValue);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsNull_ExpectFalse()
    {
        var source = new SuccessBuilder<SomeRecord?>();

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsNotDefaultAndOtherIsNull_ExpectFalse()
    {
        var source = Result.Success(PlusFifteenIdRefType);

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsNotDefaultAndTypesAreSame_ExpectFalse()
    {
        var source = new SuccessBuilder<SomeRecord>();
        object? other = Result.Success<SomeRecord>(new());

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsNotEqualToOtherSuccessAndTypesAreSame_ExpectFalse()
    {
        var sourceSuccess = new object();
        var source = Result.Success(sourceSuccess);

        var otherSuccess = new object();
        object? other = Result.Success(otherSuccess);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsNullAndOtherSuccessIsNotNull_ExpectFalse()
    {
        var source = Result.Success<RefType?>(null);
        object? other = Result.Success<RefType?>(new());

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceSuccessIsNotNullAndOtherSuccessIsNull_ExpectFalse()
    {
        var source = Result.Success<RefType>(new());
        object? other = Result.Success<RefType>(null!);

        var actual = source.Equals(other);
        Assert.False(actual);
    }
}
