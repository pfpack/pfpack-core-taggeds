using System;
using DeepEqual.Syntax;
using Xunit;

namespace PrimeFuncPack.Core.Tests;

partial class FailureTest
{
    [Theory]
    [MemberData(nameof(FailureTestSource.ToExceptionTestData), MemberType = typeof(FailureTestSource))]
    public static void ToException_ExpectFailureException(
        Failure<SomeFailureCode> source, Failure<SomeFailureCode>.Exception expected)
    {
        var actual = source.ToException();
        expected.ShouldDeepEqual(actual);
    }
}