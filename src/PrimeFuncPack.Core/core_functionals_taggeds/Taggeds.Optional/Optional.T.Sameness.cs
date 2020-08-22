#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static bool Same(Optional<T> optionalA, Optional<T> optionalB)
            =>
            Box<T>.Same(optionalA.box, optionalB.box);

        public bool Same(Optional<T> other)
            =>
            Same(this, other);

        public int GetSamenessHashCode()
            =>
            HashCode.Combine(SamenessContract, GetBoxSamenessHashCode());

        private static Type SamenessContract => typeof(Optional<T>);

        private int GetBoxSamenessHashCode()
            =>
            box switch { not null => box.GetSamenessHashCode(), _ => default };
    }
}
