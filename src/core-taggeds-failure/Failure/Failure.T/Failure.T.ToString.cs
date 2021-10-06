#nullable enable

using static System.FormattableString;

namespace System;

    partial struct Failure<TFailureCode>
    {
        public override string ToString()
            =>
            Invariant(
                $"A failure of {typeof(TFailureCode)}: {{ Code: {FailureCode}, Message: \"{FailureMessage}\" }}");
    }
