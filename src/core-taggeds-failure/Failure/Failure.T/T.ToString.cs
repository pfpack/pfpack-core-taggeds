using System.Globalization;
using System.Text;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
    {
        (object sourceExObj, string? sourceExQuote) = SourceException is not null
            ? ((object)SourceException, "\"")
            : ("null", null);

        return string.Format(
            CultureInfo.InvariantCulture,
            FailureToStringFormat.Value,
            // params:
            typeof(TFailureCode).Name,
            FailureCode,
            FailureMessage,
            sourceExQuote,
            sourceExObj,
            sourceExQuote);
    }
}

internal static class FailureToStringFormat
{
    internal static CompositeFormat Value => InnerInstance.Value;

    private static class InnerInstance
    {
        internal static readonly CompositeFormat Value = CompositeFormat.Parse(
            "Failure<{0}>:{{ \"FailureCode\": \"{1}\", \"FailureMessage\": \"{2}\", \"SourceException\": {3}{4}{5} }}");
    }
}
