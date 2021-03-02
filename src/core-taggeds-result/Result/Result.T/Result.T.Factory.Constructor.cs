#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(TSuccess success)
            =>
            unionRaw = new(success);

        public Result(TFailure failure)
            =>
            unionRaw = new(failure);
    }
}
