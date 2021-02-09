#nullable enable

using static System.FormattableString;

namespace System
{
    partial struct Failure<TFailureCode>
    {
        public override string ToString()
            =>
            Invariant(
                $"Failure of {typeof(TFailureCode).Name} {{ Code = {FailureCode}, Message = {FailureMessage} }}");
    }
}