#nullable enable

namespace System
{
    partial class Optional
    {
        public static Optional<Unit> True()
            =>
            Optional<Unit>.Present(default);

        public static Optional<Unit> False()
            =>
            Optional<Unit>.Absent;
    }
}
