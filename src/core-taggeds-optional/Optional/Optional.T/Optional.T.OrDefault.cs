#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Optional<T>
    {
        [return: MaybeNull]
        public T OrDefault()
            =>
            InternalHandleFold(Pipeline.Pipe, static () => default);
    }
}
