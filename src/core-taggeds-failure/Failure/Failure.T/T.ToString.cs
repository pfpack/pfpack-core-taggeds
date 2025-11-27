using System.Globalization;
using System.Text;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        string.Format(
            CultureInfo.InvariantCulture,
            FailureToStringCompositeFormat.Value,
            typeof(TFailureCode).Name,
            FailureCode,
            FailureMessage,
            SourceException is null ? null : "\"",
            SourceException ?? (object)"null",
            SourceException is null ? null : "\"");
}

internal static class FailureToStringCompositeFormat
{
    internal static CompositeFormat Value => Instance.Value;

    private static class Instance
    {
        internal static readonly CompositeFormat Value = CompositeFormat.Parse(
            "Failure<{0}>:{{ \"FailureCode\": \"{1}\", \"FailureMessage\": \"{2}\", \"SourceException\": {3}{4}{5} }}");
    }
}
