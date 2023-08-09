using System.Text;
using static System.FormattableString;

namespace System;

partial struct Failure<TFailureCode>
{
    public override string ToString()
        =>
        new StringBuilder(
            "Failure<")
        .Append(
            typeof(TFailureCode).Name)
        .Append(
            ">:{ \"FailureCode\": ")
        .Append(
            FailureCode.ToString())
        .Append(
            ", \"FailureMessage\": \"")
        .Append(
            FailureMessage)
        .Append(
            "\", \"SourceException\": ")
        .Append(
            SourceException is null ? "null" : Invariant($"\"{SourceException}\""))
        .Append(
            " }")
        .ToString();
}
