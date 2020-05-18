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
        public static bool Equals(in Unit valueA, in Unit valueB)
            =>
            true;

        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static bool operator ==(in Unit valueA, in Unit valueB)
            =>
            true;

        [SuppressMessage(category: Style, checkId: RemoveUnusedParameter, Justification = ShippedPublicAPI)]
        public static bool operator !=(in Unit valueA, in Unit valueB)
            =>
            false;

        public bool Equals(Unit other)
            =>
            true;

        public override bool Equals(object obj)
            =>
            obj is Unit;

        public override int GetHashCode() => default;
    }
}
