using System;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.EqualPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equality_LeftIsEqualToRight_ExpectTrue(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = left == right;
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(FailureTestSource.UnequalPairTestData), MemberType = typeof(FailureTestSource))]
    public static void Equality_LeftIsNotEqualToRight_ExpectTrue(
        Failure<SomeFailureCode> left, Failure<SomeFailureCode> right)
    {
        var actual = left == right;
        Assert.False(actual);
    }
}
