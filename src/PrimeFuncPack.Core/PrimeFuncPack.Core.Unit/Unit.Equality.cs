#nullable enable

using System.Diagnostics.CodeAnalysis;
using static PrimeFuncPack.Internals.CodeAnalysisServices.CodeAnalysisConsts.SuppressMessageCategories;
using static PrimeFuncPack.Internals.CodeAnalysisServices.CodeAnalysisConsts.SuppressMessageCheckIds;
using static PrimeFuncPack.Internals.CodeAnalysisServices.CodeAnalysisConsts.SuppressMessageJustifications;

namespace System
{
    partial struct Unit
    {
        private const bool EqualsResult = true;

        private const bool NotEqualsResult = false;

        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static bool Equals(in Unit valueA, in Unit valueB)
            =>
            EqualsResult;

        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static bool operator ==(in Unit valueA, in Unit valueB)
            =>
            EqualsResult;

        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static bool operator !=(in Unit valueA, in Unit valueB)
            =>
            NotEqualsResult;

        public bool Equals(Unit other)
            =>
            EqualsResult;

        public override bool Equals(object? obj) => obj switch
        {
            Unit _ =>
            EqualsResult,

            _ => false
        };

        public override int GetHashCode() => default;
    }
}
