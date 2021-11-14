using System.Diagnostics.CodeAnalysis;

namespace System;

partial class Failure
{
    public static Failure<Unit> Create(
        [AllowNull] string failureMessage)
        =>
        new(
            failureCode: default,
            failureMessage: failureMessage);
}
