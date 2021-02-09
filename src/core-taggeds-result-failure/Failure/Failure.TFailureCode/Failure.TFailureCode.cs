#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    public readonly partial struct Failure<TFailureCode> : IEquatable<Failure<TFailureCode>>
        where TFailureCode : struct
    {
        private readonly TFailureCode failureCode;

        private readonly string? failureMessage;

        public Failure(
            TFailureCode failureCode,
            [AllowNull] string failureMessage)
<<<<<<< HEAD
        {
            this.failureCode = failureCode;
            this.failureMessage = failureMessage switch
            {
                "" => null,
                _ => failureMessage
            };
        }
=======
            =>
            (this.failureCode, this.failureMessage) = (failureCode, failureMessage ?? string.Empty);
>>>>>>> 8b0666d138ccb3352db0808576b8d25a1abe9201

        public TFailureCode FailureCode
            =>
            failureCode;

        public string FailureMessage
            =>
            failureMessage ?? string.Empty;
    }
}