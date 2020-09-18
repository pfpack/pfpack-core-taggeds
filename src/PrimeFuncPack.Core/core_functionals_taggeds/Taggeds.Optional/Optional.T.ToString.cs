#nullable enable

using static System.Strings;

namespace System
{
    partial struct Optional<T>
    {
        public override string ToString()
            =>
            Fold(ToStringOrEmpty, GetEmpty);
    }
}
