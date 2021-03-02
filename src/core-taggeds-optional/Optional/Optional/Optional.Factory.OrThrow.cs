#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        [Obsolete(ObsoleteMessages.PresentOrThrow, error: true)]
        [DoesNotReturn]
        public static Optional<T> PresentOrThrow<T>([DisallowNull] T value)
            =>
            throw new NotImplementedException(ObsoleteMessages.PresentOrThrow);

        [Obsolete(ObsoleteMessages.PresentOrThrow, error: true)]
        [DoesNotReturn]
        public static Optional<T> PresentOrThrow<T>([DisallowNull] T? value) where T : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.PresentOrThrow);
    }
}
