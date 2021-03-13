#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(TSuccess success)
            =>
            union = new(success);

        public Result(TFailure failure)
            =>
            union = new(failure);
    }
}
