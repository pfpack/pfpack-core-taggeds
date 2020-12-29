#nullable enable

namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success)
            =>
            success;

        public static Result<TSuccess, Unit> Absent<TSuccess>()
            =>
            Unit.Value;
    }
}
