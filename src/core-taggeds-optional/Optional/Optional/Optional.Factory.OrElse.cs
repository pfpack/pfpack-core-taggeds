#nullable enable

using System.Diagnostics.CodeAnalysis;

namespace System
{
    partial class Optional
    {
        [Obsolete(ObsoleteMessages.PresentOrElse, error: true)]
        [DoesNotReturn]
        public static Optional<T> PresentOrElse<T>([DisallowNull] T value)
            =>
            throw new NotImplementedException(ObsoleteMessages.PresentOrElse);

        [Obsolete(ObsoleteMessages.PresentOrElse, error: true)]
        [DoesNotReturn]
        public static Optional<T> PresentOrElse<T>([DisallowNull] T? value) where T : struct
            =>
            throw new NotImplementedException(ObsoleteMessages.PresentOrElse);
    }
}
