namespace System
{
    partial class Result
    {
        public static Result<TSuccess, Unit> Present<TSuccess>(TSuccess success)
            =>
            new(success: success);

        public static Result<TSuccess, Unit> Absent<TSuccess>()
            =>
            new(failure: default);
    }
}
