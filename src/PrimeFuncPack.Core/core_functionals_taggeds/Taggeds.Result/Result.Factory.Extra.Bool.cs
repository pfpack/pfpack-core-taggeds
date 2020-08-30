#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static Result<Unit, Unit> True()
            =>
            SuccessBuilderImpl<Unit>.Create(default);

        public static Result<Unit, Unit> False()
            =>
            FailureBuilderImpl<Unit>.Create(default);
    }
}
