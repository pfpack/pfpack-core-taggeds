#nullable enable

namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            success;

        public static Result<TSuccess, Unit> Absent<TSuccess>() where TSuccess : notnull
            =>
            default(Unit);
    }
}
