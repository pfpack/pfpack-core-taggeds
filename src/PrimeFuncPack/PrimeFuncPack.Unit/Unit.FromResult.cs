#nullable enable

using System.Diagnostics.CodeAnalysis;
using static PrimeFuncPack.Internals.CodeAnalysisServices.CodeAnalysisConsts.SuppressMessageCategories;
using static PrimeFuncPack.Internals.CodeAnalysisServices.CodeAnalysisConsts.SuppressMessageCheckIds;
using static PrimeFuncPack.Internals.CodeAnalysisServices.CodeAnalysisConsts.SuppressMessageJustifications;

namespace PrimeFuncPack
{
    partial struct Unit
    {
        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static Unit FromResult<TResult>(in TResult result) => default;
    }
}
