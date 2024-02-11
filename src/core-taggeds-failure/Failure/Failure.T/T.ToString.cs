using System.Runtime.CompilerServices;
using static System.FormattableString;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        Invariant(
            $"Failure<{typeof(TFailureCode).Name}>:{{ \"FailureCode\": {FailureCode}, \"FailureMessage\": \"{FailureMessage}\", \"SourceException\": {InnerSourceExceptionString()} }}");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string InnerSourceExceptionString()
        =>
        SourceException is null ? "null" : Invariant($"\"{SourceException}\"");
}
