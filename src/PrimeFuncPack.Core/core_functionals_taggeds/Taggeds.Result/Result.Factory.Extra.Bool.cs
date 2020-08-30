#nullable enable

using PrimeFuncPack.Core.Result.Builders;

namespace System
{
    partial class Result
    {
        public static Result<Unit, Unit> True()
            =>
            ImplSuccessBuilder<Unit>.Create(default);

        public static Result<Unit, Unit> False()
            =>
            ImplFailureBuilder<Unit>.Create(default);
    }
}
