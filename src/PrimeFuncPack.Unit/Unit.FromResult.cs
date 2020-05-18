#nullable enable

using System.Diagnostics.CodeAnalysis;
using static PrimeFuncPack.Internals.CodeAnalysis.SuppressMessageCategories;
using static PrimeFuncPack.Internals.CodeAnalysis.SuppressMessageCheckIds;
using static PrimeFuncPack.Internals.CodeAnalysis.SuppressMessageJustifications;

namespace PrimeFuncPack
{
    partial struct Unit
    {
        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static Unit FromResult<TResult>(in TResult result) => default;
    }
}
