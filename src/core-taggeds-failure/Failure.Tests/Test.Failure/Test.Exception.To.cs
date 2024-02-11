using System;
using DeepEqual.Syntax;
using PrimeFuncPack.UnitTest;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.ToExceptionTestData), MemberType = typeof(FailureTestSource))]
    public static void ToException_ExpectFailureException(
        Failure<EnumType> source, Failure<EnumType>.Exception expected)
    {
        var actual = source.ToException();
        expected.ShouldDeepEqual(actual);
    }
}