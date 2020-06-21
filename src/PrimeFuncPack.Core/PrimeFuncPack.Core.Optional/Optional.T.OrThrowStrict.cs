#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial struct Optional<T>
    {
        [return: NotNull]
        public T OrThrowStrict()
        {
            if (box is null || box.Value is null)
            {
                throw new InvalidOperationException("The optional does not have a not null value.");
            }

            return box.Value;
        }
    }
}
