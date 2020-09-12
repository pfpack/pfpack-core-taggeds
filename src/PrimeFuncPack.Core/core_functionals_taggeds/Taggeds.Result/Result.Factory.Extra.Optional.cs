#nullable enable

namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success) where TSuccess : notnull
            =>
            Result<TSuccess, Unit>.Success(success);

        public static Result<TSuccess, Unit> Absent<TSuccess>() where TSuccess : notnull
            =>
            Result<TSuccess, Unit>.Failure(default);
    }
}
