using NUnit.Framework;
using PrimeFuncPack.UnitTest;
using System;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class OptionalStaticTest
{
    [Test]
    public void Equals_AIsAbsentAndBIsAbsent_ExpectTrue()
    {
        var optionalA = Optional<RefType>.Absent;
        var optionalB = Optional<RefType>.Absent;

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.True(actual);
    }

    [Test]
    public void Equals_AIsDefaultAndBIsAbsent_ExpectTrue()
    {
        var optionalA = default(Optional<RefType>);
        var optionalB = Optional<RefType>.Absent;

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.True(actual);
    }

    [Test]
    public void Equals_AIsAbsentAndBIsDefault_ExpectTrue()
    {
        var optionalA = Optional<RefType>.Absent;
        var optionalB = default(Optional<RefType>);

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.True(actual);
    }

    [Test]
    public void Equals_AIsPresentAndBIsPresentAndValuesAreSame_ExpectTrue()
    {
        var value = PlusFifteenIdRefType;

        var optionalA = Optional<RefType>.Present(value);
        var optionalB = Optional<RefType>.Present(value);

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.True(actual);
    }

    [Test]
    public void Equals_AIsPresentAndBIsPresentAndValuesAreNull_ExpectTrue()
    {
        var optionalA = Optional<StructType?>.Present(null);
        var optionalB = Optional<StructType?>.Present(null);

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.True(actual);
    }

    [Test]
    public void Equals_AIsAbsentAndBIsPresent_ExpectFalse()
    {
        var optionalA = Optional<RefType>.Absent;
        var optionalB = Optional<RefType>.Present(MinusFifteenIdRefType);

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.False(actual);
    }

    [Test]
    public void Equals_AIsPresentAndBIsAbsent_ExpectFalse()
    {
        var optionalA = Optional<StructType>.Present(default);
        var optionalB = Optional<StructType>.Absent;

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.False(actual);
    }

    [Test]
    public void Equals_AIsPresentAndBIsPresentAndValuesAreNotSame_ExpectFalse()
    {
        var optionalA = Optional<RefType>.Present(PlusFifteenIdRefType);
        var optionalB = Optional<RefType>.Present(ZeroIdRefType);

        var actual = Optional.Equals(optionalA, optionalB);
        Assert.False(actual);
    }
}
