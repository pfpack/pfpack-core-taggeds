#nullable enable

namespace System
{
    partial class Result
    {
        public static Result<Unit, Unit> True()
            =>
            Result<Unit, Unit>.Success(default);

        public static Result<Unit, Unit> False()
            =>
            Result<Unit, Unit>.Failure(default);
    }
}
