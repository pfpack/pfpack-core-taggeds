#nullable enable

using PrimeFuncPack.Extensions.Primitives;

namespace PrimeFuncPack
{
    partial struct Optional<T>
    {
        public static bool Same(in Optional<T> optionalA, in Optional<T> optionalB)
            =>
            Box.Same(optionalA.box, optionalB.box);

        public bool Same(in Optional<T> other)
            =>
            Same(this, other);

        public int SamenessHashCode()
            =>
            box switch { Box<T> present => present.SamenessHashCode(), _ => default };
    }
}
