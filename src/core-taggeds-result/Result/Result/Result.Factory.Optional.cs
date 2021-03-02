#nullable enable

namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success)
            =>
            new(success);

        public static Result<TSuccess, Unit> Absent<TSuccess>()
            =>
            new(Unit.Value);
    }
}
