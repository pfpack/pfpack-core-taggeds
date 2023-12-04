using System;
using PrimeFuncPack.UnitTest;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equals_LeftIsEqualToRight_ExpectTrue(
        Failure<EnumType> left, Failure<EnumType> right)
    {
        var actual = Failure.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equals_LeftIsNotEqualToRight_ExpectFalse(
        Failure<EnumType> left, Failure<EnumType> right)
    {
        var actual = Failure.Equals(left, right);
        Assert.False(actual);
    }
}
