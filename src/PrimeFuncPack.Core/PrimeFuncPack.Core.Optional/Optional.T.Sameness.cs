#nullable enable

namespace System
{
    partial struct Optional<T>
    {
        public static bool Same(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Box<T>.Same(optionalA.box, optionalB.box);

        public bool Same(in Optional<T> other)
            =>
            Same(this, other);

        public int SamenessHashCode()
            =>
            box switch { null => default, var present => present.SamenessHashCode() };
    }
}
