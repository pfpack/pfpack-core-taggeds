#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        // TODO: For v1.2: Implement the ToString in according to Optional/Unit v1.2
        public override string ToString()
            =>
            InternalFold(
                value => value?.ToString() ?? string.Empty,
                value => value.ToString() ?? string.Empty);
    }
}
