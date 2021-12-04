using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureBuilderTest
{
    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = new FailureBuilder<StructType>();
        object? other = default(FailureBuilder<StructType>);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherFailureIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = default(FailureBuilder<StructType>);
        object? other = Result.Failure(default(StructType));

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = Result.Failure(default(StructType));
        object? other = default(FailureBuilder<StructType>);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsDefaultAndOtherFailureIsDefaultAndTypesAreSame_ExpectTrue()
    {
        var source = Result.Failure(default(SomeError));
        object? other = Result.Failure(new SomeError());

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsEqualToOtherFailureAndTypesAreSame_ExpectTrue()
    {
        var errorCode = PlusFifteen;

        var sourceFailure = new SomeError(errorCode);
        var source = Result.Failure(sourceFailure);

        var otherFailure = new SomeError(errorCode);
        object? other = Result.Failure(otherFailure);

        var actual = source.Equals(other);
        Assert.True(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectFalse()
    {
        var source = default(FailureBuilder<SomeError>);
        object? other = new FailureBuilder<StructType>();

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherFailureIsDefaultAndTypesAreNotSame_ExpectFalse()
    {
        var source = default(FailureBuilder<StructType>);
        object? other = Result.Failure(default(SomeError));

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectFalse()
    {
        var source = Result.Failure(default(SomeError));
        object? other = default(FailureBuilder<StructType>);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsDefaultAndOtherFailureIsDefaultAndTypesAreNotSame_ExpectFalse()
    {
        var source = Result.Failure(default(StructType));
        object? other = Result.Failure(new SomeError());

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsEqualToOtherFailureAndTypesAreNotSame_ExpectFalse()
    {
        var someValue = MinusFifteen;
        var source = Result.Failure(someValue);
        object? other = Result.Failure<decimal>(someValue);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsNull_ExpectFalse()
    {
        var source = new FailureBuilder<StructType>();

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsNotDefaultAndOtherIsNull_ExpectFalse()
    {
        var source = Result.Failure(MinusFifteen);

        var actual = source.Equals(null);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceIsDefaultAndOtherIsNotDefaultAndTypesAreSame_ExpectFalse()
    {
        var source = new FailureBuilder<int>();
        object? other = Result.Failure(PlusFifteen);

        var actual = source.Equals(other);
        Assert.False(actual);
    }

    [Test]
    public void EqualsObject_SourceFailureIsNotEqualToOtherFailureAndTypesAreSame_ExpectFalse()
    {
        var sourceFailure = new SomeError(PlusFifteen);
        var source = Result.Failure(sourceFailure);

        var otherFailure = new SomeError(MinusFifteen);
        object? other = Result.Failure(otherFailure);

        var actual = source.Equals(other);
        Assert.False(actual);
    }
}
