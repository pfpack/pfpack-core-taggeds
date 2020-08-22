#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Optional<T>
    {
        [return: MaybeNull]
        public T OrDefault()
            =>
            ImplFold(Pipeline.Pipe, () => default);
    }
}
