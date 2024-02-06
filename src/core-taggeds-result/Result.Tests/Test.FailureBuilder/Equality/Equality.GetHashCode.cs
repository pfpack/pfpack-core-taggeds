using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureBuilderTest
{
    [Test]
    public void GetHashCode_SourceIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectHashCodesAreEqual()
    {
        var source = new FailureBuilder<SomeError>();
        var other = default(FailureBuilder<SomeError>);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceIsDefaultAndOtherFailureIsDefaultAndTypesAreSame_ExpectHashCodesAreEqual()
    {
        var source = default(FailureBuilder<int>);
        var other = Result.Failure(default(int));

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsDefaultAndOtherIsDefaultAndTypesAreSame_ExpectHashCodesAreEqual()
    {
        var source = Result.Failure(default(StructType));
        var other = new FailureBuilder<StructType>();

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsDefaultAndOtherFailureIsDefaultAndTypesAreSame_ExpectHashCodesAreEqual()
    {
        var source = Result.Failure(default(SomeError));
        var other = Result.Failure(default(SomeError));

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsEqualToOtherFailureAndTypesAreSame_ExpectHashCodesAreEqual()
    {
        var errorCode = MinusFifteen;

        var sourceFailure = new SomeError(errorCode);
        var source = Result.Failure(sourceFailure);

        var otherFailure = new SomeError(errorCode);
        var other = Result.Failure(otherFailure);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
    {
        var source = default(FailureBuilder<SomeError>);
        var other = new FailureBuilder<StructType>();

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceIsDefaultAndOtherFailureIsDefaultAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
    {
        var source = new FailureBuilder<SomeError>();
        var other = Result.Failure(new StructType());

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsDefaultAndOtherIsDefaultAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
    {
        var source = Result.Failure(new SomeError());
        var other = default(FailureBuilder<StructType>);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsDefaultAndOtherFailureIsDefaultAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
    {
        var source = Result.Failure(default(StructType));
        var other = Result.Failure(default(SomeError));

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsEqualToOtherFailureAndTypesAreNotSame_ExpectHashCodesAreNotEqual()
    {
        var someValue = MinusFifteen;
        var source = Result.Failure(someValue);
        var other = Result.Failure<long>(someValue);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceIsDefaultAndOtherIsDefaultTypeSameSourceFailure_ExpectHashCodesAreNotEqual()
    {
        var source = new FailureBuilder<StructType>();
        var other = default(StructType);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceIsNotDefaultAndOtherIsSameAsSourceFailure_ExpectHashCodesAreNotEqual()
    {
        var failure = new SomeError(PlusFifteen);
        var source = Result.Failure(failure);
        var other = failure;

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceIsDefaultAndOtherIsNotDefaultAndTypesAreSame_ExpectHashCodesAreNotEqual()
    {
        var source = new FailureBuilder<StructType>();
        var other = Result.Failure(SomeTextStructType);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }

    [Test]
    public void GetHashCode_SourceFailureIsNotEqualToOtherFailureAndTypesAreSame_ExpectHashCodesAreNotEqual()
    {
        var sourceFailure = new SomeError(PlusFifteen);
        var source = Result.Failure(sourceFailure);

        var otherFailure = new SomeError(MinusFifteen);
        var other = Result.Failure(otherFailure);

        var sourceHashCode = source.GetHashCode();
        var otherHashCode = other.GetHashCode();

        Assert.That(otherHashCode, Is.Not.EqualTo(sourceHashCode));
    }
}
