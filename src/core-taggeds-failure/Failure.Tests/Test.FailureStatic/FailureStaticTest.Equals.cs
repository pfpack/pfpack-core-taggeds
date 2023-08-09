using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureStaticTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equals_LeftIsEqualToRight_ExpectTrue(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = Failure.Equals(left, right);
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equals_LeftIsNotEqualToRight_ExpectFalse(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = Failure.Equals(left, right);
        Assert.False(actual);
    }
}
