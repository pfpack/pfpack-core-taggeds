#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(in TSuccess success)
            =>
            unionRaw = new(success ?? throw new ArgumentNullException(nameof(success)));

        public Result(in TFailure failure)
            =>
            unionRaw = new(failure);
    }
}
