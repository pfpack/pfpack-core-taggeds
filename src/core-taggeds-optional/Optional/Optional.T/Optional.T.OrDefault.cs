#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Optional<T>
    {
        [return: MaybeNull]
        public T OrDefault()
            =>
            InnerFold(Pipeline.Pipe, static () => default);
    }
}
