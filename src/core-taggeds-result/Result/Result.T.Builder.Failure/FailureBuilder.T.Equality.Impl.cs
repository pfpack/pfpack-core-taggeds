namespace PrimeFuncPack.Core
{
    partial struct FailureBuilder<TFailure>
    {
        public bool Equals(FailureBuilder<TFailure> other)
            =>
            FailureComparer.Equals(failure, other.failure);
    }
}
