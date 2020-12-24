#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(TSuccess success)
            =>
            unionRaw = new(success ?? throw new ArgumentNullException(nameof(success)));

        public Result(TFailure failure)
            =>
            unionRaw = new(failure);
    }
}
