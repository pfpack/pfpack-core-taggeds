#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static Result<Unit, Unit> True()
            =>
            SuccessBuilder<Unit>.Create(default);

        public static Result<Unit, Unit> False()
            =>
            FailureBuilder<Unit>.Create(default);
    }
}
