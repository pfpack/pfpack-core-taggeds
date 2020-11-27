#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(in TSuccess success)
            =>
            union = new(success ?? throw new ArgumentNullException(nameof(success)));

        public Result(in TFailure failure)
            =>
            // TODO: Delete this comment when TFailure became struct
            // Note: failure is not checked for null here due to TFailure is going to become struct
            union = new(failure);
    }
}
