#nullable enable

namespace System
{
    partial struct Result<TSuccess, TFailure>
    {
        public Result(TSuccess success)
        {
            isSuccess = true;
            this.success = success;
            failure = default;
        }

        public Result(TFailure failure)
        {
            isSuccess = false;
            success = default!;
            this.failure = failure;
        }
    }
}
