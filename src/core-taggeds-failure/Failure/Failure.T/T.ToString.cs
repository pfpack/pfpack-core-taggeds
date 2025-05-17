using System.Globalization;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        string.Format(
            CultureInfo.InvariantCulture,
            "Failure<{0}>:{{ \"FailureCode\": \"{1}\", \"FailureMessage\": \"{2}\", \"SourceException\": {3}{4}{5} }}",
            typeof(TFailureCode).Name,
            FailureCode,
            FailureMessage,
            SourceException is null ? null : "\"",
            SourceException ?? (object)"null",
            SourceException is null ? null : "\"");
}
