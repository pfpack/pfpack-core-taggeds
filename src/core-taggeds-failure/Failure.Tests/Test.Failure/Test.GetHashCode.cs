using System;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void GetHashCode_FirstIsEqualToSecondAndTypesAreSame_ExpectHashCodesAreEqual(
        Failure<EnumType> first, Failure<EnumType> second)
    {
        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        Assert.Equal(firstHashCode, secondHashCode);
    }

    [Fact]
    public static void GetHashCode_FirstTypeIsNotEqualToSecondType_ExpectHashCodesAreNotEqual()
    {
        var first = new Failure<int>(PlusFifteen, SomeString);
        var second = new Failure<byte>(PlusFifteen, SomeString);

        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        Assert.NotEqual(firstHashCode, secondHashCode);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void GetHashCode_FirstIsNotEqualToSecondAndTypesAreSame_ExpectHashCodesAreNotEqual(
        Failure<EnumType> first, Failure<EnumType> second)
    {
        var firstHashCode = first.GetHashCode();
        var secondHashCode = second.GetHashCode();

        Assert.NotEqual(firstHashCode, secondHashCode);
    }
}
